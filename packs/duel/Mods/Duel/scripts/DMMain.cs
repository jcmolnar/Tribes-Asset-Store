function GEInit()
{
	  %obj = newObject("", SimVolume, "ge.vol");
	 // addToSet("MissionGroup\\Volumes", %obj);
      addToSet("MissionCleanup", %obj);
	  %obj = newObject("", SimVolume, "pd.vol");
      addToSet("MissionCleanup", %obj);
      both("Loading GE & PD vol...");
}


//
//if($DeathMatch::Arena == "" || $goldeneye)
//{
	$DeathMatch::Arena = "Arena_Madness";
//}
//else {
	//$DeathMatch::Arena = $Arena[$DeathMatch::Arena]++;
//}

if($missionname == "BloodyVengeance")
{
	$DeathMatch::Arena = "WalledIn";
}
if($DeathMatch::Arena == "WalledIn" && $missionname != "BloodyVengeance")
{
	$DeathMatch::Arena = "Arena_Madness";
}
if($missionname == "Goldeneye & Perfect Dark")
{
	$DeathMatch::Arena = "Egyptian";
}
function remoteP(%client)
{
	%dmglvl = gamebase::getdamagelevel(client::getownedobject(%client));
	//%test = radnomItems(6,bullshit,faggot,nigger,spic,gook,cracker);
	%dmg = floor(100 - ((gamebase::getdamagelevel(client::getownedobject(%client)) / 0.66) * 100)) ;
	if(!%dmg)
	{
	//	return echo(gamebase::getdamagelevel(client::getownedobject(%client))@" 100%");
	}


	echo(gamebase::getdamagelevel(client::getownedobject(%client))@" "@%dmg);
}

//echo("DeathMatch initialized");
//$SimGame::Timescale = 60;
function DM::Notify(%cl, %c)
{
	if(Client::getOwnedObject(%cl)!=-1)
	{
		%cl.DMnotify = true;
		%cpos = gamebase::getposition(%cl);
		%dif = floor(Vector::getDistance(getword(%cpos, 0)@" "@getword(%cpos, 1)@" 0", getword($DeathMatch::Center, 0)@" "@getword($DeathMatch::Center, 1)@" 0"));
		if(%dif > 120)
		{
			%c--;
			if(%c<1)
			{
				//GameBase::SetDamageLevel(client::getownedobject(%cl), 15);
				playNextAnim(%cl);
				Player::kill(%cl);
				Client::onKilled(%cl,%cl);
				%cl.DMnotify = "";
				return;
			}

			client::sendmessage(%cl, 1, "You have "@%c@" second(s) to get back in the game."@$error);
			schedule("DM::Notify("@%cl@","@%c@");",1);
			return;
		}
	}
	%cl.DMnotify = "";
}
function GetPlayType(%client)
{
	if(%client.DM)
	{
		return "DM";
	}
	else if(%client.Team != "")
	{
		return "TD";
	}
	else if(%client.Team == "")
	{
		return "DL";
	}
	return "";
}
function DeathMatch::LoadArenas()
{
	//make_Arena(Auth, 99, 99);
	//schedule("$SimGame::Timescale=1;", 5);
	if($DeathMatch::Master)
	{
		schedule("$DeathMatch::Master = true;", 5);
		schedule("DeathMatch::Start();", 5);
	}
	$DeathMatch::Master = "false";
	//schedule("make_Arena(ArenaMadness, 99, 99);", 1);
	//schedule("make_Arena(OldMilwaukee, 99, 99);", 2);
	//schedule("make_Arena(Gonrena, 99, 99);", 3);
	//make_Arena(ASWP, 99, 9);
	//schedule("make_Arena(Neighbor, 99, 99);", 4);
	//schedule("$DeathMatch::Master = true;", 5);
	//echo("DeathMatch Arenas Loaded!");
}




$DeathMatch::Loadouts = true;
$DeathMatch::Master = true;


function remoteSPAWN(%clientId)
{
}
function DM::JoinDM(%client)
{
	if(%client.IsAlive == "" && !$Dueling[%client])
	{
		Start::TimeTracker(%client, "DeathMatchTime");
		if(%client.DM != "true")
		{
			messageall(0, client::getname(%client) @" joined the fray.");
		}
		%client.observerMode = "";
		%client.observerTarget = "";
		%client.DMJoins++;
		%time = Time::getMinutes((floor(getSimTime()) - floor(%client.leaveDM)));
		%client.joinDM = getSimTime();
		if(%client.DMJoins > 4 && %time < 1)
		{
			%client.fagzilla += 5;
		}
		%client.DM = true;
		%pl = DeathMatch::Spawn(%client);
		Client::setControlObject(%client, %client.Owns);
		GameBase::SetDamageLevel(%client.Owns, 0);
		%client.guiLock = false;
		Client::setGuiMode(%client, $GuiModePlay);
		%client.observerMode = "";
		Observer::checkObserved(%client);
		if($DeathMatch::CountDown)
		{
			%client.observerMode = "pregame";
			Client::setControlObject(%client, Client::getObserverCamera(%client));
			Observer::setOrbitObject(%client, %pl, 5, 5, 5);
		}
		Game::refreshClientScore(%client);
	}
	else {
		client::sendmessage(%client, $Red, "End your duel or leave your team first!"@$error);
	}
}
function processMenuDMenu(%client, %option)
{
	%opt1 = GetWord(%option, 0);
	%opt2 = GetWord(%option, 1);
	if(%client.fagzilla > 100)
	{
		client::sendmessage(%client, 1, ""@$error);
		return;
	}
	if(%opt1 == "JoinDM" && !%client.dm && !$timeReached)// && %client.fagzilla < 100)
	{
		DM::JoinDM(%client);
	}
	if(%opt1 == "LeaveDM")
	{
		%time = Time::getMinutes((floor(getSimTime()) - floor(%client.lastDamage)));
		%client.DMLeaves++;
		if(%client.DMLeaves > 5 && %time < 1)
		{
			%client.fagzilla += 10;
		}
		%client.leaveDM = getSimTime();
		DM::LeaveDM(%client);
	}
}
function DM::LeaveDM(%client)
{
	if(%client.DM)
	{
		Stop::TimeTracker(%client, "DeathMatchTime");
		//if(%client.Team == "" && $Dueling[%client] == "")
		//{
			if((floor(100 - (gamebase::getdamagelevel(client::getownedobject(%client)) / 0.66) * 100)) < 30)
			{
				%client.fagzilla += 5;
				remoteKill(%client);
			}
			Player::onKilled(Client::getOwnedObject(%client));
			%client.DM = false;
			%client.GoToSpecialMap = false;
			Game::refreshClientScore(%client);
			//if(%client.Team == "")
			//{
				Observer::enterObserverMode(%client);
			//}
		//}
		//else {
		//	client::sendmessage(%client, $Red, "You broke it!"@$error);
		//}
	}
}



function processMenuDMMenu(%client, %option) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction("processMenuDMMenu "@%option);
	}
	%time = Time::getMinutes((floor(getSimTime()) - %client.LastAction));
	if(%option != "checkinvites")
	{
		if(%time > 0.9)
		{
			%client.LastAction = floor(getSimTime());
			Game::refreshClientScore(%client);
		}
		else
		{
			%client.LastAction = floor(getSimTime());
		}
	}

       %o = getWord(%option, 0);
       %extra = getWord(%option, 1);
       %extra2 = getWord(%option, 2);
       %extra3 = getWord(%option, 3);
       %extra4 = getWord(%option, 4);
       %extra5 = getWord(%option, 5);
       %extra6 = getWord(%option, 6);
       %extra7 = getWord(%option, 7);
	if(%o == "base" && $curVoteTopic == "")
	{
		%p = 0;
		Client::buildMenu(%client, "DeathMatch Voting", "DMMenu", true);
		if($DeathMatch::Loadouts)
		{
			Client::addMenuItem(%client, %p++@"Disable Loadout Spawn", "vtoggle");
		}
		else {
			Client::addMenuItem(%client, %p++@"Enable Loadout Spawn", "vtoggle");
		}
		if($FlagHunter::Master)
		{
			Client::addMenuItem(%client, %p++@"Disable Flag Hunter", "vtoggleFH");

			  if($FlagHunter::GreedMode)
				 Client::addMenuItem(%client, %p++ @ "Vote to disable GREED", "vdgm");
			  else
				 Client::addMenuItem(%client, %p++ @ "Vote to enable GREED", "vegm");
			  if(!$FlagHunter::HoardMode)
				 Client::addMenuItem(%client, %p++ @ "Vote to enable HOARD", "vehm");
		}
		else {
			Client::addMenuItem(%client, %p++@"Enable Flag Hunter", "vtoggleFH");
		}
		Client::addMenuItem(%client, %p++@"Change Mission", "vote");
		return;
	}
	if(%o == "vtoggle" && $curVoteTopic == "")
	{
		if($DeathMatch::Loadouts)
		{
			$curVoteTopic = "Disable Loadout Spawning";
		}
		else {
			$curVoteTopic = "Enable Loadout Spawning";
		}
		$curVoteInitiator = %client;
		$curVoteAction = "DMChange";
		DeathMatch::Message($White, client::getname(%client)@" initiated a vote to: "@$curVoteTopic);
		DeathMatch::Bottom($White, "<jc><f1>"@client::getname(%client)@" <f0> initiated a vote to: <f1>"@$curVoteTopic);
		if($qq)
			%time = 1;
		else
			%time = 15;

		Schedule("DeathMatch::VoteCheck();", %time);
		VoteGraphic();
		%client.vote = "Yes";
	}
	if(%o == "vtoggleFH" && $curVoteTopic == "")
	{
		if($qq)
			%time = 1;
		else
			%time = 15;

		if($FlagHunter::Master)
		{
			$curVoteTopic = "Disable Flag Hunter";
		}
		else {
			$curVoteTopic = "Enable Flag Hunter";
		}
		$curVoteInitiator = %client;
		$curVoteAction = "DMChange";
		DeathMatch::Message($White, client::getname(%client)@" initiated a vote to: "@$curVoteTopic);
		DeathMatch::Bottom($White, "<jc><f1>"@client::getname(%client)@" <f0> initiated a vote to: <f1>"@$curVoteTopic);
		Schedule("DeathMatch::VoteCheck();", %time);
		VoteGraphic();
		%client.vote = "Yes";
	}


   else if(%o == "vegm")
      DM::startVote(%client, "enable GREED mode", "egm", 0);
   else if(%o == "vdgm")
      DM::startVote(%client, "disable GREED mode", "dgm", 0);
   else if(%o == "egm")
      Admin::setGreedMode(%client, true);
   else if(%o == "dgm")
      Admin::setGreedMode(%client, false);
   else if(%o == "vehm")
      DM::startVote(%client, "enable HOARD mode", "ehm", 0);
   else if(%o == "vdhm")
      DM::startVote(%client, "disable HOARD mode", "dhm", 0);
   else if(%o == "ehm")
      Admin::setHoardMode(%client, true);
   else if(%o == "dhm")
      Admin::setHoardMode(%client, false);


	if(%o == "vote" && $curVoteTopic == "")
	{
		DeathMatch::changeMissionMenu(%client, %extra);
		return;
	}


}

function DM::startVote(%client, %votetopic, %o)
{
		if($qq)
			%time = 1;
		else
			%time = 15;


		$curVoteTopic = %votetopic;

		$curVoteInitiator = %client;
		$curVoteAction = %o;
		DeathMatch::Message($White, client::getname(%client)@" initiated a vote to: "@$curVoteTopic);
		DeathMatch::Bottom($White, "<jc><f1>"@client::getname(%client)@" <f0> initiated a vote to: <f1>"@$curVoteTopic);
		Schedule("DeathMatch::VoteCheck();", %time);
		VoteGraphic();
		%client.vote = "Yes";
}

function DeathMatch::changeMissionMenu(%client, %extra)
{
	if(%extra > 1)
	{
	}

	%P=0;
	Client::buildMenu(%client, "Arena Menu", "DMVote", true);

			for(%x = %extra; %x < $Arenas; %x++)
			{
				if(%x == "0") { %x++; }
				//both($arena[%x]@" Done?: "@$DM::Done[$Arena[%x]]);
				if($DM::Done[$Arena[%x]])
				{
					Client::addMenuItem(%client, %p++ @ $Arena[%x], $Arena[%x]);
				}
				if(%p > 6 && $Arena[%x+1] != "")
				{
					Client::addMenuItem(%client, %p++ @ "more...", "vote "@ %x+1);
					break;
				}
			}
}
function processMenuDMVote(%client, %mission)
{
	if(getword(%mission, 0) == "vote")
	{
		echo(getword(%mission, 0)@" "@getword(%mission, 1));
		return processMenuDMMenu(%client, %mission) ;
	}

	if(%client.DMLoading)
	{
		//both("Dm Load: "@%mission@" proj "@%client.projectname);
		DeathMatch::MakeArena(%mission, %client.projectname);
		%client.DMLoading = "";
		return;
	}



	if(getword(%mission, 0) == "vote")
	{
		echo(getword(%mission, 0)@" "@getword(%mission, 1));
		return processMenuDMMenu(%client, %mission) ;
	}
	if($qq)
		%time = 1;
	else
		%time = 15;

	if($curVoteTopic == "")
	{
		//if($TeamDuel::ArenaStatus[%mission] == "Free")
		//{
			$curVoteInitiator = %client;
			$curVoteTopic = "DMChange";
			$curVoteAction = "DMChange";
			$curVoteOption = %mission;
			DeathMatch::Message($White, client::getname(%client)@" initiated a vote to change DM mission to: "@%mission);
			DeathMatch::Bottom($White, "<jc><f1>"@client::getname(%client)@" <f0>initiated a vote to change DM mission to: <f1>"@%mission);
			Schedule("DeathMatch::VoteCheck();", %time);//klye
			VoteGraphic();
		//}
		//else {
//			client::sendmessage(%client, $Red, "That map is currently in use"@$error);
//			$curVoteInitiator = "";
//			$curVoteTopic = "";
//			$curVoteAction = "";
//			$curVoteOption = "";
//		}
	}
	else {
		Client::sendMessage(%client, 0, "Voting already in progress.");
	}
}
function DeathMatch::voteSucceded()
{
	if($curVoteTopic == "DMChange")
	{
		DeathMatch::Stop();
		$DeathMatch::Arena = $curVoteOption ;
		DeathMatch::Start();
	}
	else if($curVoteTopic == "Disable Loadout Spawning")
	{
		$DeathMatch::Loadouts = false;
	}
	else if($curVoteTopic == "Enable Loadout Spawning")
	{
		$DeathMatch::Loadouts = true;
	}
	else if($curVoteTopic == "Disable Flag Hunter")
	{
		DeleteNexus();
		$FlagHunter::Master = false;
	}
	else if($curVoteTopic == "Enable Flag Hunter")
	{
		$FlagHunter::Master = true;
		MakeNexus();
	}
	else if($curVoteAction == "egm")
		Admin::setGreedMode(-1, true);
	else if($curVoteAction == "dgm")
		Admin::setGreedMode(-1, false);
	else if($curVoteAction == "ehm")
		Admin::setHoardMode(-1, true);
	else if($curVoteAction == "dhm")
		Admin::setHoardMode(-1, false);
}
function Admin::setGreedMode(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $FlagHunter::GreedMode = true;
         if(%admin == -1)
            messageAll(1, "GREED mode is ON by consensus!");
         else
            messageAll(1, Client::getName(%admin) @ " has turned GREED mode ON!");
      }
      else
      {
         $FlagHunter::GreedMode = false;
         if(%admin == -1)
            messageAll(1, "GREED mode is OFF by consensus.");
         else
            messageAll(1, Client::getName(%admin) @ " has turned GREED mode Off.");
      }

      //update the objectives page
      DM::missionObjectives();
   }
}

function Admin::setHoardMode(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         if(%admin == -1)
         {
            $FlagHunter::HoardMode = true;
            //messageAll(1, "HOARD mode is ON by consensus!");
            %tl = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
            $FlagHunter::simtime = getSimTime();
            echo("Timeleft: "@%tl);

            if(%tl > 300) {
            	schedule("Admin::disableHorde();", 300);
            	%t = 300; }
            else {
            	schedule("Admin::disableHorde();", (%tl-60));
            	%t = (%tl-60);
			}
			  %mins = time::getminutes(%t);
			  %secs = time::getseconds(%t);

			  if(%mins > 0)
				  %string = %mins @" minutes and ";

			  %string = %string @ %secs@" seconds.";


            messageAll(1, "HOARD mode is ON by consensus! Time: "@%string);
         }
	 }
      //update the objectives page
      //DM::missionObjectives();
   }
}
function Admin::disableHorde()
{
	$FlagHunter::HoardMode = false;
	DeathMatch::Message($Red, "Horde Mode disabled!");
}
function DeathMatch::VoteCheck()
{
	if($curVoteTopic == "")
	{
		return;
	}


	if($Veto == "False")
	{
	   %votesFor = 0;
	   %votesAgainst = 0;
	   %votesAbstain = 0;
	   %totalClients = 0;
	   %totalVotes = 0;

	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   {
		   if(%cl.DM)
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
		  DeathMatch::Message($White, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		  DeathMatch::voteSucceded();
		  //DeathMatch::Stop();
		  //$DeathMatch::Arena = $curVoteOption ;

		  //DeathMatch::Start();
	   }
	   else
	   {
		  DeathMatch::Message($Red, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		  //DeathMatch::voteFailed();
	   }
	}
	$Veto = "False";
	//Admin::voteFailed();
	$curVoteInitiator = "";
	$curVoteTopic = "";
	$curVoteAction = "";
	$curVoteOption = "";
}
//function SpawnIT()
//{
//	for(%x = 0; $DeathMatch::Onject[%x] != ""; %x++)
//	{
//	}
//}


function DeathMatch::Stop()
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.DM)
		{
			Observer::EnterObserverMode(%cl);
		}
	}
	$ArenaInUse[$DeathMatch::Arena,$DeathMatch::ArenaNum] = false;
	$TeamDuel::ArenaStatus[$DeathMatch::Arena] = "Free";
	if($FlagHunter::Master)
	{
		DeleteNexus();
	}
	DeathMatch::ClearObjects();
}
function DeathMatch::Start()
{
	DeathMatch::MakeArena($DeathMatch::Arena);
	if($FlagHunter::Master)
	{
		schedule("NexusInit();",3.5);
	}

	//DeathMatch::MakeSpawns($DeathMatch::Arena);
//	DeathMatch::CreateObjects();
	$DeathMatch::CountDown = "true";
	//$TeamDuel::ArenaStatus[$DeathMatch::Arena] = "Taken";
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.DM)
		{
			%pl = DeathMatch::Spawn(%cl);
			%cl.observerMode = "pregame";
			Client::setControlObject(%cl, Client::getObserverCamera(%cl));
			Observer::setOrbitObject(%cl, %pl, 5, 5, 5);
		}
	}
	schedule("DeathMatch::Message($White, \"Match will begin in 10 seconds\");", 2.5);
	schedule("DeathMatch::Message($White, \"Match will begin in 5 seconds\");", 7.5);
	schedule("DeathMatch::Message($White, \"Match will begin in 4 seconds\");", 8.5);
	schedule("DeathMatch::Message($White, \"Match will begin in 3 seconds\");", 9.5);
	schedule("DeathMatch::Message($White, \"Match will begin in 2 seconds\");", 10.5);
	schedule("DeathMatch::Message($White, \"Match will begin in 1 seconds\");", 11.5);
	schedule("DeathMatch::Message($Red, \"Fight!\");", 12.5);
	schedule("$DeathMatch::CountDown = false;", 12.39);
	schedule("DeathMatch::StartFight();", 12.4);
}

function DeathMatch::Message(%color, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(%cl.DM)
	   {
		   client::sendmessage(%cl, %color, %message);
	   }
   }
}
function DeathMatch::MessageExcept(%client, %color, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(%cl.DM && %cl != %client)
	   {
		   client::sendmessage(%cl, %color, %message);
	   }
   }
}
function DeathMatch::Bottom(%message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(%cl.DM)
	   {
		   bottomprint(%cl, %message);
	   }
   }
}
function DeathMatch::StartFight()
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.DM)
		{
			Client::setControlObject(%cl, %cl.Owns);
			GameBase::SetDamageLevel(%cl.Owns, 0);
			%cl.guiLock = false;
			Client::setGuiMode(%cl, $GuiModePlay);
		}
	}
}

function DeathMatch::ResetSpawns()
{
	for(%x = -1; %x < 80; %x++)
	{
		$DeathMatch::Spawn[%x] = "";
	}
}

function DeathMatch::FurthestSpawn()
{
	%totalcoords = DeathMatch::GetTotalCoords();
	%furthest = 0;
	//both(%totalcoords);

	for(%a = 0; $DeathMatch::Spawn[%a] != ""; %a++)
	{
		%distance = Vector::getDistance($DeathMatch::Spawn[%a], %totalcoords);
		//both("$DM Var.. "@$DeathMatch::Spawn[%a]@" total coords.."@%totalcoords);
		//both("distance.. "@%distance);
		if(%distance > %furthest)
		{
			%furthest = %distance;
			%furthestnum = %a;
		}
	}
	return %furthestnum - floor(getRandom() * 4);
}

function DeathMatch::GetTotalCoords()
{
	%totalpos = "0 0 0";
	%count = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%player = Client::getOwnedObject(%cl);
		if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %cl.dm)
		{
			%totalpos = Vector::Add(gamebase::getposition(%player),%totalpos);
			%count++;
		}
	}
	//both("count "@%count);
	if(%count == 0)
	{
		%random = (floor(getRandom() * ($DeathMatch::TotalSpawns)));
		//both("random.. "@%random);
		return $DeathMatch::Spawn[%random];
	}
	else
	{
		return (getWord(%totalpos, 0)/%count)@" "@(getWord(%totalpos, 1)/%count)@" "@(getWord(%totalpos, 2)/%count) ;
	}
}

function DeathMatch::Spawn(%client)
{
	Score::ResetRoundStats(%client);
	%client.flagCount = 1;
	if($Dueling[%client] || %client.IsAlive != "")
	{
		client::sendmessage(%client, $Red, "End your duel or leave your team first!"@$error);
		return;
		Client::onKilled(%client, %client, 1);
	}
	$spot++;// = DeathMatch::FurthestSpawn();
	//both($spot@": "@$DeathMatch::Spawn[$spot]);
	if($DeathMatch::Spawn[$spot] == "")
	{
		//both("blank spot..");
		$spot = 0;
	}

	%armor = "larmor";
	%pl = spawnPlayer(%armor, $DeathMatch::Spawn[$spot], $DeathMatch::SpawnRot[$spot]);
	Client::setOwnedObject(%client, %pl);
	Client::setSkin(%client, $DeathMatch::Skin);
	if($DeathMatch::Loadouts)
	{
		Player::AssignLoadout(%client, false);
	}
	else {
		Player::SetItemCount(%client, Blaster, 1);
		Player::UseItem(%client, Blaster);
		Player::SetItemCount(%client, RepairKit, 1);
		Player::SetItemCount(%client, Beacon, 3);
		Player::SetItemCount(%client, TargetingLaser,1);
	}
	%client.owns = %pl;
	%pl.owner = %client;
	//if(gamebase::getteam(%client) != "-1")
	//{
		//teamswitch(%client, -1, DeathMatch);
		if(%client.team != "" &&  $DeathMatch::Teams)
		{
			gamebase::setTeam(%client, %client.team);
			echo("Custom");
		}
		else
		{
			gamebase::setTeam(%client, 0);
		}




//	}
	return %pl;
}

function GoToSpecialMap(%clientId)
{
	if(!Player::isDead(Client::getOwnedObject(%clientId)) &&  %clientId.dm)
	{
		%team = 0;
		%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/start");
		if(Group::objectCount(%group) <= $ubercnt+1)
		{
			$ubercnt = -1;
		}
		gamebase::setposition(%clientid,gamebase::getposition(Group::getObject(%group, $ubercnt++)));
	}
	else {
		client::sendmessage(%clientId, $Red, "You must be alive and in DM mode.");
	}
}

function DeathMatch::Spawn1(%client)
{
	%client.flagCount = 1;
	if($Dueling[%client] || %client.IsAlive != "")
	{
		client::sendmessage(%client, $Red, "End your duel or leave your team first!"@$error);
		return;
		Client::onKilled(%client, %client, 1);
	}
	$spot++;
	//echo($DeathMatch::Spawn[$spot]);
	if($DeathMatch::Spawn[$spot] == "")
	{
		$spot = 0;
	}
	%zit = Client::getOwnedObject(%client);
	if(%zit != "" && %client.DM != "true")
	{
		playNextAnim(%client);
		player::kill(%client);
		gamebase::setTeam(%client, 0);
		Observer::enterObserverMode(%client);
		Item::Pop(%zit);
		$Roaming[%client] = false;
	}
	if(Client::getGender(%client) == "Female")
	{
		%armor = "lfemale";
	}
	else
	{
		%armor = "larmor";
	}
	%rot = "0 0 0";
	if($DeathMatch::Spawn[$spot] == "")
	{
		$spot = 0;
	}
	%pl = spawnPlayer(%armor, $DeathMatch::Spawn[$spot], $DeathMatch::SpawnRot[$spot]);
	//gamebase::setposition(%pl, $DeathMatch::Spawn[$spot]);
	%pl.owner = %client;
	//messageall(0, "Spot: "@$spot@" "@$DeathMatch::Spawn[$spot] @" "@ $DeathMatch::SpawnRot[$spot]);
	Client::setOwnedObject(%client, %pl);
	Client::setSkin(%client, $DeathMatch::Skin[$spot]);
	if($DeathMatch::Skin[$spot] != "")
	{
		Client::setSkin(%client, $DeathMatch::Skin[$spot]);
	}
	if($DeathMatch::Loadouts)
	{
		%packNo = $DuelPackSetup[%client];
		if (%packNo == "")
		{
			%packNo = 1;
		}
		%pack = $DuelRealPack[%packNo];
		Player::SetItemCount(%client, %pack, 1);
		Player::UseItem(%client, %pack);

		if (!$DuelWeaponSetup[%client, 0])
		{
			$DuelWeaponSetup[%client, 0] = 3;
		}
		if (!$DuelWeaponSetup[%client, 1])
		{
			$DuelWeaponSetup[%client, 1] = 2;
		}
		if (!$DuelWeaponSetup[%client, 2])
		{
			$DuelWeaponSetup[%client, 2] = 4;
		}
		for(%i = 0; %i < 3; %i++)
		{
			%weapon = $DuelWeaponSetup[%client, %i];
			%realweapon = $DuelRealWeapon[%weapon];
			%weaponAmmo = %realweapon.imageType.ammoType;
			%armor = Player::GetArmor(%client);
			if(%realweapon == "LaserRifle")
			{
				schedule("addlaser("@%client@");",10);
				//schedule("Player::setItemCount("@%client@","LaserRifle",1);", 10);
			}
			else {
				Player::SetItemCount(%client,%realweapon,1);
			}


			if(%weaponAmmo != "")
			{
				//echo(%pack);
				if(%pack == "ammopack")
				{
					%ammoAmount = ($AmmoPackMax[%weaponAmmo] + $ItemMax[%armor, %weaponAmmo]) ;
					Player::SetItemCount(%client,%weaponAmmo, %ammoAmount);
				}
				else
				{
					Player::SetItemCount(%client,%weaponAmmo, $ItemMax[%armor, %weaponAmmo]);
				}
			}
		}
		Player::UseItem(%client, $DuelRealWeapon[$DuelWeaponSetup[%client, 0]]);
		Player::SetItemCount(%client, Grenade, 5);
		Player::SetItemCount(%client, RepairKit, 1);
		Player::SetItemCount(%client, Beacon, 3);
		Player::SetItemCount(%client, TargetingLaser,1);
	}
	else {
		Player::SetItemCount(%client, Blaster, 1);
		Player::UseItem(%client, Blaster);
		Player::SetItemCount(%client, RepairKit, 1);
		Player::SetItemCount(%client, Beacon, 3);
		Player::SetItemCount(%client, TargetingLaser,1);
	}
	%client.owns = %pl;
	%client.IsIn = false;
	//if(gamebase::getteam(%client) != "3")
	//{
	//	gamebase::setTeam(%client, "3");
	//}
	return %pl;
}
function addlaser(%client)
{
	if(%client.IsAlive == "")
	{
		//both("Addlaser Called");
		%player = Client::getOwnedObject(%client);
		for(%i = 1; %i < 8; %i++)
		{
			if(Player::getItemCount(%player, $DuelRealWeapon[%i]))
			{
				//both("Player has: "@$DuelRealWeapon[%i]@". Count is: "@%count+1);
				%count++;
			}
		}
		if(%count > 2)
		{
			//both("Player denied the gun");
			client::sendmessage(%client, $red, "You have too many weapons to receive: Laser Rifle"@$error);
		}
		else {
			//both("Player receives the gun");
			Player::setItemCount(%client,"LaserRifle",1);
		}
	}
}

//deleteObject("MissionCleanup");
//%set = nameToID("MissionCleanup/ObjectiveSet");
//newObject(MissionCleanup, SimGroup);
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
{
	if(%cl.dm)
	{
		observer::enterobservermode(%cl);
		%cl.dm = false;
	}
}

//DeathMatch::LoadArenas();

//make_arena($DeathMatch::Arena, 99, 99);
//DeathMatch::MakeSpawns($DeathMatch::Arena);
//$DeathMatch::CountDown = "true";


function DeathMatch::MakeArena(%arena, %project)
{
	%cleanup="MissionCleanup";
	//both("Proj "@%project);
	if(%project != "")
	{
		%cleanup = $BuildGroup;
	}


	for(%x = 1; %x < 10; %x++)
	{
		if(!$ArenaInUse[%arena, %x])
		{
			echo(%x @" is free to use for arena "@%arena);// "@$arena[%arena]);
			break;
		}
	}
	$ArenaInUse[%arena, %x] = true;
	$DeathMatch::ArenaNum = %x;

	exec("zz"@%arena@".cs");

	echo("*** Creating: "@%arena@": DeathMatch slot: "@%x@" *** Z:"@$z);//@"Building: "@ %x);

	%offset = $ArenaOffSet[$ArenasMade++];
	$DeathMatch::Offset = %offset;

	if($BVMapSet[%arena]&&$missionname=="BloodyVengeance")
	{
		%offset = vector::sub(%offset, "0 0 1000");
	}

	deleteVariables("$DeathMatch::Spawn*");
	if(%arena == "Rockslide")
	{
		%offset = "0 0 0";
	}

	echo("DM SPAWN: "@$DM::Spawn[0]);
	for(%x = 0; $DM::Spawn[%x] != ""; %x++)
	{
		//echo(

		%pos = Getword($DM::Spawn[%x], 0)+Getword(%offset, 0)@" "@Getword($DM::Spawn[%x], 1)+Getword(%offset, 1)@" "@Getword($DM::Spawn[%x], 2)+Getword(%offset, 2) ;
		$DeathMatch::Spawn[%x] = %pos;//vector::add($DM::Spawn[%x], %offset) ;
		$DeathMatch::SpawnRot[%x] = "0 0 "@getword($DM::SpawnRot[%x], 2) ;
		//both($DeathMatch::SpawnRot[%x]);
	//	echo(%x@" "@%pos@" Z: "@$z);
	}
	$DeathMatch::TotalSpawns = %x;
	//if(!$ArenaIsMade[%arena,%x])
	//{
		$ArenaIsMade[%arena,%x] = true;
		for(%a = 0; %a < $z+1; %a++)
		{

			//%totalpos = Getword($objpos[%a], 0)+Getword(%totalpos, 0)@" "@Getword($objpos[%a], 1)+Getword(%totalpos, 1)@" "@Getword($objpos[%a], 2)+Getword(%totalpos, 2) ;
			if($objtype[%a] == "StaticShape" && $obj[%a] != "InventoryStation55" || $objtype[%a] == "Turret" || $objtype[%a] == "Sensor")
			{
				%spawn = newObject($obj[%a],$objtype[%a],$obj[%a],false);
				addToSet(%cleanup, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, $objrot[%a]);
				//echo($obj[%a]@" "@$objTeam[%a]);
				GameBase::setTeam(%spawn, $objTeam[%a]);
				//Gamebase::setMapName(%spawn, %name);
				GameBase::setActive(%spawn,14);
				GameBase::playSequence(%spawn,0,power);
			}
			if($objtype[%a] == "InteriorShape")
			{
				%spawn = newObject($obj[%a]@".dis",$objtype[%a],$obj[%a]@".dis",true);
				addToSet(%cleanup, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, $objrot[%a]);

			}
			if($objtype[%a] == "Item")
			{
				%amount = "1";

				if($obj[%a] == "PlasmaAmmo")
				{
					%amount = "10";
				}
				if($obj[%a] == "BulletAmmo")
				{
					%amount = "30";
				}
				if($obj[%a] == "GrenadeAmmo" || $obj[%a] == "discammo" || $obj[%a] == "Grenade")
				{
					%amount = "5";
				}
				//echo($obj[%a]@" "@%amount);
				%spawn = newObject($obj[%a],"Item",$obj[%a],%amount,true,true,false);
				addToSet(%cleanup, %spawn);
				%pos = Getword($objpos[%a], 0)+Getword(%offset, 0)@" "@Getword($objpos[%a], 1)+Getword(%offset, 1)@" "@Getword($objpos[%a], 2)+Getword(%offset, 2) ;
				gamebase::setposition(%spawn, %pos);
				gamebase::setrotation(%spawn, %rot);
			}
			%totalpos = Getword(%pos, 0)+Getword(%totalpos, 0)@" "@Getword(%pos, 1)+Getword(%totalpos, 1)@" "@Getword(%pos, 2)+Getword(%totalpos, 2) ;
			if(%project != "")
			{
				%spawn.project = %project;
			}
				//echo(%spawn @" "@%a@"|"@$z@" "@$obj[%a]@" "@$objtype[%a]@" Pos: "@floor(getword(%pos, 0))@" "@floor(getword(%pos, 1))@" "@floor(getword(%pos, 2)));
		}
		%spawn.weld = true;
	//}
	$DeathMatch::Center =  Getword(%totalpos, 0)/$z@" "@  Getword(%totalpos, 1)/$z@" "@  Getword(%totalpos, 2)/$z ;

		deleteVariables("$DM::Spawn*");
		deleteVariables("$TeamDuel::Spawn[X*");
		deleteVariables("$TeamDuel::SpawnRot[X*");
		deletevariables("$obj*");



}


echo("DeathMatch initialized");
//schedule("echo(\"DeathMatch Loaded!\");", 5);
exec(flaghunter);


//DeathMatch::Stop();


schedule("NexusInit();", 3.5);
schedule("DeathMatch::Start();", 0.5);


