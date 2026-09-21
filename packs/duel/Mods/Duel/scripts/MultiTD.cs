//TODO:
//TDMenu check challenging/matchstatus to check for multi-TD and bility to join.
//remove challengeteam option when there are no teams to challenge
//when a team is removed need to check to see if it's the only team in match,
//if so stop match/reset flags, also check to see if it's the only team alive if so end round and start the next

//less sensors but increase their range
$MultiTeamDuel::Teams = "";//1 2 3 4 5 6 7 8 9 10 11 12 13 14";


function Multiteam::AddTeam(%team)
{
	//both("add team "@%team@" teams... "@$MultiTeamDuel::Teams);
	for(%x = 0; gw($MultiTeamDuel::Teams,%x) != -1; %x++)
	{
		if(gw($MultiTeamDuel::Teams,%x) == %team)
		{
			return false;
		}
	}
	$MultiTeamDuel::Teams = $MultiTeamDuel::Teams@" "@%team;
	if($MultiTeamDuel::CountDown)
	{
		$TeamDuel::MissionArea[%team] = 700;
		$TeamDuel::Center[%team] = $MultiTeamDuel::Center;
		if($TeamDuel::Ticker[0])
		{
			$TeamDuel::Leader[%team].notready = true;
		}
		MultiTeamDuel::TeamTickerSpawn(%team);
	}
	$TeamDuel::InMatch[%team] = "True";
	$TeamDuel::Start[%team] = $TeamDuel::Start[0];
	//both("teams 2... "@$MultiTeamDuel::Teams);
}
function Multiteam::CheckMatchStatus()
{
	//both("MTD:T "@$MultiTeamDuel::Teams);

	if(gw($MultiTeamDuel::Teams, 1) == -1)
	{
		echo($MultiTeamDuel::Teams@" Only one team, cancel this bitch");
		$MultiTeamDuel::Teams = gw($MultiTeamDuel::Teams, 0);
		//both($MultiTeamDuel::Teams);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.team == $MultiTeamDuel::Teams && %cl.isalive == "True")
			{
				ForceOneObs(%cl);
			}
		}
		$MultiTeamDuel::Teams = 0;
		$MultiTeamDuel::CountDown = false;
		$TeamDuel::Challenging[$MultiTeamDuel::Teams] = "";
		$TeamDuel::Score[$MultiTeamDuel::Teams] = "0";
		$TeamDuel::InMatch[$MultiTeamDuel::Teams] = "";
		$TeamDuel::Start[$MultiTeamDuel::Teams] = "";
		$TeamDuel::Abort[$MultiTeamDuel::Teams] = false;
		$TeamDuel::Leader[$MultiTeamDuel::Teams].notready = false;
		$MultiTeamDuel::Teams = "";

		return false;
	}
	return true;
}
function Multiteam::RemoveTeam(%team)
{
	//both("teams R1... "@$MultiTeamDuel::Teams);
	%strandedteam = "";
	%newset = "";
	for(%x = 0; gw($MultiTeamDuel::Teams,%x) != -1; %x++)
	{
		%space = " ";	if(%x == 0)	{	%space = "";	}
		if(gw($MultiTeamDuel::Teams,%x) != %team)
		{
			%newset = %newset@ %space @gw($MultiTeamDuel::Teams,%x);
		}
	}
	$MultiTeamDuel::Teams = %newset;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.team == %team && %cl.isalive == "True")
		{
			ForceOneObs(%cl, %cl);
			//
		}
	}
	$TeamDuel::Challenging[%Team] = "";
	$TeamDuel::Score[%Team] = "0";
	$TeamDuel::InMatch[%Team] = "";
	$TeamDuel::Start[%Team] = "";
	$TeamDuel::Abort[%Team] = false;
	Multiteam::CheckMatchStatus();
	//both("teams R2... "@$MultiTeamDuel::Teams);
}

function Multiteam::CreateSpawns()
{
	%teams = $MultiTeamDuel::Teams;

	for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x-1);
		echo(%x@" team found: "@gw(%Teams,%x-1));
	}


	if(%x-1 <= 1)
		return;


	//$MultiTeamDuel::Center = "0 0 0";
	%offset[1] = "-5 5 1";	%offset[2] = "5 -5 1";
	%offset[3] = "-5 -5 1";	%offset[4] = "5 5 1";
	%offset[5] = "1 5 1";	%offset[6] = "1 -5 1";
	%offset[7] = "-5 1 1";	%offset[8] = "5 1 1";
	for(%x = 1; %x < 9; %x++)
	{
		%offset[%x+8] = gw(%offset[%x], 0)/2@" "@gw(%offset[%x], 1)/2@" 1";
		echo(%x+8@" offsets made");
	}



	for(%x = 1; %x < 9; %x++)
	{
		%randommulti = floor((getrandom()*2))+7.5;//@" "@floor((getrandom()*15)+10)@" 1";
		%noffset[%x] = vector::multiply(%randommulti@" "@%randommulti@" 100", %offset[%x]);
		//messageall(0,"random multi "@%randommulti);
		$TeamDuel::Spawn[%x, 0] = vector::add(%noffset[%x], $MultiTeamDuel::Center);
		$TeamDuel::SpawnRot[%x, 0] = "0 0 "@gw(Vector::getRotation(Vector::normalize(Vector::sub($MultiTeamDuel::Center, $TeamDuel::Spawn[%x, 0]))), 2);
		//%mm = mymarker($TeamDuel::Spawn[%Team[%x], 0], $TeamDuel::SpawnRot[%Team[%x], 0]);
		//schedule("deleteObject("@%mm@");", 30);
		for(%y = 1; %offset[%y] != ""; %y++)
		{
			$TeamDuel::Spawn[%x, %y] = vector::add(%offset[%y], $TeamDuel::Spawn[%x, 0]);
			$TeamDuel::SpawnRot[%x, %y] = "0 0 "@gw(Vector::getRotation(Vector::normalize(Vector::sub($MultiTeamDuel::Center, $TeamDuel::Spawn[%x, 0]))), 2);
			//%mm = mymarker($TeamDuel::Spawn[%Team[%x], %y], $TeamDuel::SpawnRot[%Team[%x], %y]);
			//schedule("deleteObject("@%mm@");", 30);
		}
	}

}
function Multiteam::BeginTeamDuel()
{
	$MultiTeamDuel::CountDown = false;
	%Teams = $MultiTeamDuel::Teams;
	for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x-1);
	}
	%message = "<jc><f0>Fight!<f1>";
	//both(%message);

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		for(%x = 1; %Team[%x] != ""; %x++)
		{
			if(%cl.team == %team[%x])
			{
				Multiteam::Unlock(%cl);
			}
		}
	}
	$TeamDuel::Start[0] = floor(getSimTime() + 0.5);
	for(%x = 1; %Team[%x] != ""; %x++)
	{
		$TeamDuel::Start[%Team[%x]] = $TeamDuel::Start[0];
		//$TeamDuel::Ticker[%Team[%x]] = false;
		$TeamDuel::CanHurt[%Team[%x]] = "";
		schedule("TeamDuelCanHurt(" @ %Team[%x] @ ");", $DuelHurtDelay+1.00);
	}
	PrintTeam(%Teams, %message, bottom);//top, center, bottom

	CreateMissionArea(%Teams, $TeamDuel::Start[0]);
	moveSensors(%Teams);
}
function Multiteam::CountDown(%timeLeft)
{
	if($MultiTeamDuel::CountDown)
	{
		//if(Multiteam::CheckMatchStatus())
		$TeamDuel::Ticker[0] = false;
		echo("Multiteam::CountDown!! "@%timeLeft);
		%Teams = $MultiTeamDuel::Teams;
		for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
		{

			%Team[%x] = gw(%Teams,%x-1);
			$TeamDuel::Ticker[%Team[%x]] = false;
			$TeamDuel::CanHurt[%Team[%x]] = "False";
		}
		if(%timeLeft == 0)
		{
			Multiteam::BeginTeamDuel(%Teams);
			echo("Match Started");
			return;
		}
		if(%timeLeft == 1)
		{
			%message = "<jc><f1>Match starts in <f2>1<f1> second.";
		}
		else
		{
			if(%timeLeft <= 5)
			{
				%message = "<jc><f1>Match starts in <f2>" @ %timeLeft @ "<f1> seconds.";
			}
			else
			{
				if(%timeLeft == 10)
				{
					%message = "<jc><f1>Match starts in <f2>" @ %timeLeft @ "<f1> seconds.";
				}
			}
		}
		PrintTeam(%Teams, %message, bottom);//top, center, bottom
		schedule("Multiteam::CountDown(" @ (%timeLeft - 1) @ ");", 1);
	}
	else
	{
		echo("cancelling during countdown");
	}
}
function Multiteam::TeamDuelCountDownTicker(%tick)
{
	if($MultiTeamDuel::CountDown)
	{
		$TeamDuel::Ticker[0] = true;
		%Teams = $MultiTeamDuel::Teams;
		%TeamsNotReady = "";
		//echo("Multiteam::TeamDuelCountDownTicker!! "@%tick);
		if(%tick == "")
		{
			%tick = 0;
		}
		for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
		{
			%Team[%x] = gw(%Teams,%x-1);
		}
		for(%x = 1; %Team[%x] != ""; %x++)
		{
			if($TeamDuel::Abort[%Team[%x]])
			{
				echo(%Team[%x]@" aborted");
				//$TeamDuel::Abort[%Team[%x]] = false;
				//$TeamDuel::Ticker[%Team[%x]] = "";
				//return;
			}
			$TeamDuel::Ticker[%Team[%x]] = true;
			if($TeamDuel::Leader[%Team[%x]].notready)
			{
				if(%x == 1)
				{
					%TeamsNotReady = %Team[%x];
				}
				else {
					%TeamsNotReady = %TeamsNotReady@" "@%Team[%x] ;
				}
			}

		}
		if(%TeamsNotReady != "")
		{
			%tick++;
			if(%tick/10 == "1")
			{
				%tick = -4;
				%message = "Waiting on ";
				%and = "";
				for(%x = 0; gw(%TeamsNotReady,%x) != -1; %x++)
				{
					if(%x == 0)
					{
						%message = %message @ client::getname($TeamDuel::Leader[gw(%TeamsNotReady,%x)]);
					}
					if(gw(%TeamsNotReady,%x+1) == -1)
					{
						%and = "and ";
					}
					if(%x > 0)
					{
						%message = %message @", "@ %and @ client::getname($TeamDuel::Leader[gw(%TeamsNotReady,%x)]) ;
					}
				}
				%message = %message@ " to ready up.";
				TMessage(666, 666, $Green, %message, 1);
			}
			//PrintTeam(%Teams, %message, bottom);//top, center, bottom
			schedule("Multiteam::TeamDuelCountDownTicker("@ %tick @ ");", 1);
		}
		else {
			Multiteam::CountDown(6);
		}
	}
	else {
		echo("cancelling ticker");
	}
}

function Multiteam::Unlock(%clientId)
{
	Client::setControlObject(%clientId, %clientId.owns);
	Client::setOwnedObject(%clientId, %clientId.owns);
	GameBase::SetDamageLevel(%clientId.owns, 0);
	Client::setGuiMode(%clientId, $GuiModePlay);

	%clientId.guiLock = false;

	%clientId.oob = false;
	%clientId.observerMode = "";
}


function Multiteam::lock(%clientId, %pl)
{
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %pl, 5, 5, 5);
	%clientId.observertarget = "";
	%clientId.observerMode = "pregame";
	%clientId.guiLock = false;
	%clientId.oob = false;
}
function Multiteam::SetDefaults(%extra)
{
	$TeamDuel::Time[0] = $TeamDuel::Time[%extra];
	$TeamDuel::Rounds[0] = $TeamDuel::Rounds[%extra];
	$TeamDuel::Weapons[0] = $TeamDuel::Weapons[%extra];
	if($TeamDuel::Weapons[%extra] == "Custom")
	{
		//both("setting custom weaps...");
		$TeamDuel::Weapons[0] = "Custom";
		$TeamDuel::CustomWeapons[0, 0] = $TeamDuel::CustomWeapons[%extra, 0];
		$TeamDuel::CustomWeapons[0, 1] = $TeamDuel::CustomWeapons[%extra, 1];
		$TeamDuel::CustomWeapons[0, 2] = $TeamDuel::CustomWeapons[%extra, 2];
	}
	$TeamDuel::Packs[0] = $TeamDuel::Packs[%extra];
	$TeamDuel::Arena[0] = $TeamDuel::Arena[%extra];
	$TeamDuel::Mines[0] = $TeamDuel::Mines[%extra];
	$TeamDuel::Armor[0] = $TeamDuel::Armor[%extra];
	$TeamDuel::Multi[0] = $TeamDuel::Multi[%extra];
}
function Multiteam::SetTeamsDefaults(%team)
{
	echo("MTD SET DEFAULTS");
	$TeamDuel::Challenging[%team] = 0;
	$TeamDuel::Time[%team] = $TeamDuel::Time[0];
	$TeamDuel::Rounds[%team] = $TeamDuel::Rounds[0];
	$TeamDuel::Weapons[%team] = $TeamDuel::Weapons[0];
	$TeamDuel::RealTeam = %team;
	if($TeamDuel::Weapons[0] == "Custom")
	{
		$TeamDuel::Weapons[%team] = "Custom";
		$TeamDuel::CustomWeapons[%team, 0] = $TeamDuel::CustomWeapons[0, 0];
		$TeamDuel::CustomWeapons[%team, 1] = $TeamDuel::CustomWeapons[0, 1];
		$TeamDuel::CustomWeapons[%team, 2] = $TeamDuel::CustomWeapons[0, 2];
	}
	$TeamDuel::Packs[%team] = $TeamDuel::Packs[0];
	$TeamDuel::Arena[%team] = $TeamDuel::Arena[0];
	$TeamDuel::Mines[%team] = $TeamDuel::Mines[0];
	$TeamDuel::Armor[%team] = $TeamDuel::Armor[0];
	$TeamDuel::Multi[%team] = $TeamDuel::Multi[0];
}
function Multiteam::MatchSetup()
{
	%Teams = $MultiTeamDuel::Teams;
	%firstround = true;
	%pause = false;
	for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x-1);
		%spot[%Team[%x]] = -1;
		if($TeamDuel::Score[%Team[%x]] != "0")
		{
			%firstround = false;
		}
		if($TeamDuel::Leader[%Team[%x]].notready)
		{
			%paused = true;
		}
	}
	if(%firstround)
	{
		//%message = "Multi-Team TD starting "@$MultiTeamDuel::Open
		for(%x = 1; %Team[%x] != ""; %x++)
		{
			$TeamDuel::Leader[%Team[%x]].notready = true;
			%message = "Multi-Team TD starting";
			echo("Match Setup: notready status set. Waiting for ready up");
		}
	}

	for(%x = 1; %Team[%x] != ""; %x++)
	{
		$TeamDuel::RealTeam[%Team[%x]] = %Team[%x];
		$TeamDuel::InMatch[%Team[%x]] = "True";
		$TeamDuel::Challenging[%Team[%x]] = 0;
		$TeamDuel::RoundEnded[%Team[%x]] = false;
		$TeamDuel::CanHurt[%Team[%x]] = "False";
		$TeamDuel::MissionArea[%Team[%x]] = 700;
		%spot[%Team[%x]] = -1;
	}
	$TeamDuel::RoundEnded[0] = false;
	$MultiTeamDuel::Center = floor(getrandom()*1024)+1024@" "@floor(getrandom()*1024)+1024@" 1050";
	%pl = spawnPlayer("larmor", $MultiTeamDuel::Center, "0 0 0");
	resetlos(); GameBase::getLOSInfo(%pl, 9999, "-1.57 0 0");
	deleteObject(%pl);
	$MultiTeamDuel::Center = $los::position;

	//both("MULTI first spawn = "@$MultiTeamDuel::Center);
	Multiteam::CreateSpawns();


	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		for(%x = 1; %Team[%x] != ""; %x++)
		{
			$TeamDuel::MissionArea[%Team[%x]] = 700;
			$TeamDuel::Center[%Team[%x]] = $MultiTeamDuel::Center;
			if(%cl.team == %Team[%x])
			{
				if(%cl.DM)
				{
					DM::LeaveDM(%cl);
				}
				%pl = TeamDuelSpawn(%cl, %spot[%Team[%x]]++);
				%cl.owns = %pl;
				%cl.IsAlive = "True";
				%cl.observertarget = "";
				%cl.oob = false;
				//Client::setOwnedObject(%cl, %pl);

				Multiteam::lock(%cl, %pl);
				gamebase::setteam(%cl, %Team[%x]);
				gamebase::setteam(%pl, %Team[%x]);
				//echo("setting team "@client::getname(%cl)@" "@%cl@" "@%pl@" to team: "@%Team[%x]);
				Game::refreshClientScore(%cl);
				$TeamDuel::LeftOff[%Team[%x]] = %spot[%Team[%x]];
			}
		}
	}
	$MultiTeamDuel::CountDown = true;
	Multiteam::TeamDuelCountDownTicker();
}
function MultiTeamDuel::TeamTickerSpawn(%Team)
{
	%spot = -1;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.team == %Team)
		{
			//both("trickered");
			if(%cl.DM)
			{
				DM::LeaveDM(%cl);
			}
			%pl = TeamDuelSpawn(%cl, %spot++);
			%cl.owns = %pl;
			%cl.IsAlive = "True";
			%cl.observertarget = "";
			//Client::setOwnedObject(%cl, %pl);
			gamebase::setteam(%cl, %Team);
			gamebase::setteam(%pl, %Team);
			Multiteam::lock(%cl, %pl);
			Game::refreshClientScore(%cl);
			$TeamDuel::LeftOff[%Team] = %spot;
		}
	}
	//both("trickered end");
}
function MultiTeamDuel::TickerSpawn(%cl)
{
	if(%cl.DM)
	{
		DM::LeaveDM(%cl);
	}
	%pl = TeamDuelSpawn(%cl, $TeamDuel::LeftOff[%cl.Team]++);
	%cl.owns = %pl;
	%cl.IsAlive = "True";
	%cl.observertarget = "";
	//Client::setOwnedObject(%cl, %pl);
	gamebase::setteam(%cl, %cl.team);
	gamebase::setteam(%pl, %cl.team);
	Multiteam::lock(%cl, %pl);
	Game::refreshClientScore(%cl);
	if($TeamDuel::CanHurt[%cl.Team] == "" || $TeamDuel::CanHurt[%cl.Team] == "True")
	{
		schedule("Multiteam::Unlock("@%cl@");",1);
	}
}
function MultiTeamduel::Client::OnKilled(%playerId, %killerId, %damageType, %check)
{
	if(Multiteam::CheckMatchStatus())
	{
		%TeamAliveID = "";
		%TotalTeamsAlive = 0;
		ForceOneObs(%playerId,%killerId);
		Game::refreshClientScore(%playerId);
		if(!$TeamDuel::RoundEnded[0])
		{
			%roundover = true;
			for(%x = 1; gw($MultiTeamDuel::Teams,%x-1) != -1; %x++)
			{
				%Team[%x] = gw($MultiTeamDuel::Teams,%x-1);
			}
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				for(%x = 1; %Team[%x] != ""; %x++)
				{
					if(%cl.team == %Team[%x] && %cl.isalive == "True")
					{
						if(%TeamAliveID == "")
						{
							%TeamAliveID = %Team[%x];
							%TotalTeamsAlive++;
						}
						else if(%TeamAliveID != %Team[%x])
						{
							%TotalTeamsAlive++;
						}
					}
				}
			}
			if(%TotalTeamsAlive <= "1")
			{
				$TeamDuel::RoundEnded[0] = true;
				for(%x = 1; %Team[%x] != ""; %x++)
				{
					$TeamDuel::RoundEnded[%Team[%x]] = true;
					//$TeamDuel::CanHurt[%Team[%x]] = "";
					$TeamDuel::Start[%Team[%x]] = "";
					$TeamDuel::MatchesLost[%Team[%x]]++;
				}
				$TeamDuel::MatchesWon[%TeamAliveID]++;
				$TeamDuel::Score[%TeamAliveID]++;

				%message = "<jc>" @ $TeamDuel::Name[%TeamAliveID] @ " has won the round!\n"@MultiTeamDuel::ScoreString();
				//PrintTeam($MultiTeamDuel::Teams, %message, center);//top, center, bottom
				printTeam($MultiTeamDuel::Teams, %message, center);
				//both(%message);

				schedule("MultiTeamDuel::EndRound();", 5.0);
			}
		}
	}
}


function MultiTeamDuel::ScoreString()
{
	for(%x = 0; gw($MultiTeamDuel::Teams,%x) != -1; %x++)
	{
		%Team[%x] = gw($MultiTeamDuel::Teams,%x);
	}
	%doIt=1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %Team[%i] != ""; %i++)
		{
			if($TeamDuel::Score[%Team[%i]] < $TeamDuel::Score[%Team[%i+1]])
			{
				%hold = %Team[%i];
				%Team[%i] = %Team[%i+1];
				%Team[%i+1] = %hold; %doIt=1;
			}
		}
	}

	%tsstr = "<jc>";
	for(%x = 0; %Team[%x] != ""; %x++)
	{
		%tsstr = %tsstr @ "<f1>\n"@FillName($TeamDuel::Name[%Team[%x]]) @ "\t<f3>=<f2>\t" @ $TeamDuel::Score[%Team[%x]] ;
	}
	return %tsstr;
}

function FillName(%name)
{
	%length = String::len(%name);
	//both("before name leng "@%length);
	while(String::len(%name) < 15)
	{
		%name = %name@" ";
	}
	//both("name leng "@String::len(%name));
	return %name;
}

function MultiTeamDuel::EndRound()
{
	%winner = false;
	for(%x = 0; gw($MultiTeamDuel::Teams,%x) != -1; %x++)
	{
		%Team[%x] = gw($MultiTeamDuel::Teams,%x);
		$TeamDuel::Start[%Team[%x]] = "";
		if($TeamDuel::Score[%Team[%x]] == $TeamDuel::Rounds[%Team[%x]] && $TeamDuel::Name[%Team[%x]] != "")
		{
			%winner = %Team[%x];
			echo(%x@" Winner found! Team "@%winner);
		}
	}
	%doIt=1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %Team[%i] != ""; %i++)
		{
			if($TeamDuel::Score[%Team[%i]] < $TeamDuel::Score[%Team[%i+1]])
			{
				%hold = %Team[%i];
				%Team[%i] = %Team[%i+1];
				%Team[%i+1] = %hold; %doIt=1;
			}
		}
	}

	echo("EndRound called for teams "@$MultiTeamDuel::Teams);

	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		for(%x = 0; %Team[%x] != ""; %x++)
		{
			//both("endround: "@%Team[%x]);
			if(%cl.Team == %Team[%x] && %Team[%x] != "")
			{
				for(%clx = Client::getFirst(); %clx != -1; %clx = Client::getNext(%clx))
				{
					if(%clx.observertarget == %cl && %clx.observertarget.DM != "true")
					{
						%clx.observertarget = "";
						%clx.observerMode = "";
						Observer::enterObserverMode(%clx);

					}
				}
				//both("endround force obs: "@%Team[%x]@" cl "@%cl);
				%cl.observerMode = "";
				Observer::enterObserverMode(%cl);
				%cl.guilock = false;
				%cl.IsAlive = "";
				Game::refreshClientScore(%cl);
				setCommandStatus(%cl, 0, "");
				remoteEval(%cl, "setTime", -%curTimeLeft);
			}
		}
	}
	DuelMOD::missionObjectives();
	if(!%winner)
	{
		for(%x = 0; %Team[%x] != ""; %x++)
		{
			if(%x == 0 && $TeamDuel::Score[%Team[%x]] > $TeamDuel::Score[%Team[%x+1]])
			{
				%message = "<f1><jc>You are winning by " @ $TeamDuel::Score[%Team[%x]] - $TeamDuel::Score[%Team[%x+1]] @ ".  You need " @  $TeamDuel::Rounds[%Team[%x]] - $TeamDuel::Score[%Team[%x]] @ " games to win! \n ";
				PrintTeam(%Team[%x], %message, center);//top, center, bottom
				//both(%Team[%x]@" "@%message);
			}
			if(%x != 0 && $TeamDuel::Score[%Team[%x]] < $TeamDuel::Score[%Team[0]])
			{
				%message = "<f1><jc>You are losing by " @ $TeamDuel::Score[%Team[0]] - $TeamDuel::Score[%Team[%x]] @ ".  They need " @ $TeamDuel::Rounds[%Team[0]] - $TeamDuel::Score[%Team[0]] @ " games to win! \n ";
				PrintTeam(%Team[%x], %message, center);//top, center, bottom
				//both(%Team[%x]@" "@%message);
			}
			if(%x != 0 && $TeamDuel::Score[%Team[%x]] == $TeamDuel::Score[%Team[0]])
			{
				%message = "<f1><jc>You are tied for first place.  You need " @ $TeamDuel::Rounds[%Team[%x]] - $TeamDuel::Score[%Team[%x]] @ " games to win! \n ";
				PrintTeam(%Team[%x], %message, center);//top, center, bottom
				//both(%Team[%x]@" "@%message);
			}
		}
	}
	else
	{
		$TeamDuel::Wins[%winner]++;
		%message = $TeamDuel::Name[%winner] @" ("@ $TeamDuel::Score[%winner] @") has won !" ;
		TMessage(666, 666, $Red, %message, 1);
		for(%x = 0; %Team[%x] != ""; %x++)
		{
			$TeamDuel::Challenging[%Team[%x]] = "";
			$TeamDuel::InMatch[%Team[%x]] = "";
			$TeamDuel::Score[%Team[%x]] = "0";
		}

		echo("Match is over for ("@%winner@") and ("@%loser@")");
		if($onlyonce == "false")
		{
			//messageall(1, "Resuming map change.");
			Game::checkTimeLimit();
		}
		return;
	}
		schedule("Multiteam::MatchSetup();", 2.0);
}




function AA()
{
	%team = 0;
	%TeamDuel::Name[%team++] = "oneoneoneone";
	%TeamDuel::Name[%team++] = "two";
	%TeamDuel::Name[%team++] = "three";
	%TeamDuel::Name[%team++] = "four";
	%TeamDuel::Name[%team++] = "five";
	%TeamDuel::Name[%team++] = "six";
	%TeamDuel::Name[%team++] = "seven";

	%team = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%cl.LastAction = floor(getSimTime());
		setupteam(%team++);
		%cl.team = %team;
		$TeamDuel::Name[%team] = %TeamDuel::Name[%team];
		$TeamDuel::Leader[%team] = %cl;
		Game::refreshClientScore(%cl);
	}
}
function remoteMCS(%cl)
{
	%player = Client::getOwnedObject(%cl);
	GameBase::getLOSInfo(%player,300);

	$MultiTeamDuel::Center = $los::position;


	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	//, CameraTurret, true);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setPosition(%beacon,$los::position);
	Gamebase::setMapName(%beacon,"MultiTeamDuel Beacon");
	Beacon::onEnabled(%beacon);
	Client::sendMessage(%client,0,"MultiTeamDuel Beacon deployed");
}
function mymarker(%pos,%rot)
{
	%class="Player";
	%type = "lfemale";
	%turret = newObject("Player",%class,%type,true);
	addToSet("MissionCleanup", %turret);
	%player = Client::getOwnedObject(%client);
	GameBase::setPosition(%turret,%pos);
	GameBase::setRotation(%turret,%rot);
	GameBase::setTeam(%turret,6);
	Gamebase::setMapName(%turret,%type @ " of "@Client::getName(%client) @ "'s");
	GameBase::setActive(%turret,14);
	GameBase::playSequence(%turret,0,power);
	$los::position = "";
	return %turret;
}
function remoteXXX(){Multiteam::CreateSpawns();}
function LeNadeImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("LestatShell", %trans, %player, %vel);
	//Projectile::spawnProjectile("RoleyPoley", %trans, %player, %vel);

	//%bomb = newObject("", "Mine", "LestatNade");

	//addToSet("MissionCleanup", %bomb);
	//GameBase::throw(%bomb,%player,15,false);
}
function remoteCPT(%cl)
{
		//Centerprint(%cl, "<jc><L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L45>HI!!!");

		Centerprint(%cl, "<F0>F0 <F1>F1<F2>F2   <F3>F3  <F4>F4  <F5>F5    <F6>F6<F7>F7  <F8>F8   <F9>F9 <F10>F10");
}
function asd()
{
		%message = "<jc>" @ $TeamDuel::Name[1] @ " has won the round!\n"@MultiTeamDuel::ScoreString();
		//%message = "<f1><jc><L4>"@$TeamDuel::Name[1] @ ":<f2><L64>" @ $TeamDuel::Score[1] @
		//"<n><L3><jl>"@$TeamDuel::Name[2] @ ":<f2>" @ $TeamDuel::Score[2] @
		//"\n<L1><f1><jc>"@$TeamDuel::Name[3] @ ":<f2>" @ $TeamDuel::Score[3] ;
		PrintTeam($MultiTeamDuel::Teams, %message, top);//top, center, bottom
}