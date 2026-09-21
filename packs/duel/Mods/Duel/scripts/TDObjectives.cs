function loopgui(%cl)
{
	both(%cl.guilock);
	schedule("loopgui("@%cl@");",0.5);
}
function FindHighLight(%mode)
{
	%z = 0;
	%b = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%cl[%z++] = %cl;
	}
	%z++;
	for(%x = 1; %x < %z; %x++)
	{
		%cl = %cl[%x];
		eval( "%score = %cl." @ %mode @ ";");
		if(%score > %b)
		{
			%b = %cl[%x];
		}
	}
	//echo(%mode@" - client: "@%cl@" score: "@%score@" Best: "@%b);
	return %b;
}

function fillsp()
{
	for(%x = 0; %x < 16; %x++)
	{

		%type = "DefaultBeacon";
		%class = "StaticShape";
		%turret = newObject(%type,%class,%type,true);
		echo(%turret@" "@$TeamDuel::Spawn[1,%x]);
		gamebase::setposition(%turret, $TeamDuel::Spawn[1, %x]);
		gamebase::setteam(%turret, $TeamDuel::RealTeam[1]);
		%turret = newObject(%type,%class,%type,true);
		gamebase::setposition(%turret, $TeamDuel::Spawn[2, %x]);
		gamebase::setteam(%turret, $TeamDuel::RealTeam[2]);
	}
}

function remoteKfghfhgfhg(%clientId)
{
	DuelMOD::missionObjectives();
}
function remoteKlye(%client)
{
	for(%x = 0; %x < 100; %x++)
	{
		%string = %string@" "@floor(getrandom()*100) ;
	}
	//%string = "13 123 14 141 15 16 00:01 423 32 32 21 1 121 1 1 12 21 3 2 2 54 5 5 3 6 6 2 2 5 2 1 27 13 14 412 123 1 53 123 43 3421 5 1 2313 23 23 123 23 10 324 321 333 323 1 329 328 327 88 89 899 90 91 92 93 94";
	RestoreScore(%client, %string);
}
function Admin::smurfObjectives(%cl,%target)
{
	%currentteam = client::getteam(%cl);
	client::setinitialteam(%cl, 7);
	gamebase::setteam(%cl, 7);
	remoteObjectivesMode(%cl);
	%LineNum=0;
	Team::setObjective(7, %lineNum, "<jc><f10>"@client::getname(%target)@"'s smurfs");
	for(%x = 0; (gw(%target.smurfs, %x)!="" && gw(%target.smurfs, %x)!="-1") || (gw(%target.smurfs, %x+1)!="" && gw(%target.smurfs, %x+1)!="-1"); %x++)
	{
		Team::setObjective(7, %lineNum++, %lineNum@".<f1> "@gw(%target.smurfs, %x));
	}
	for(%s = %lineNum+1; %s < 41 ;%s++)
	{
		Team::setObjective(7, %s, " ");
	}
	client::setinitialteam(%cl, %currentteam);
	gamebase::setteam(%cl, %currentteam);
}
function DuelMOD::missionObjectives() {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DuelMOD::missionObjectives);
	}



	if($timeReached == "false")
	{
		for(%x = -1; %x < 6; %x++)
		{
			Team::clearObjectives(%x);
			//for(%s = 0; %s < 50 ;%s++)
			//{
			//	Team::setObjective(%x, %s, " ");
			//}
		}

		sett(x,x,x);
	}
	else {
		$TDisLoaded = "";
	}
	%lineNum = "0";
	%mostkillstring = KillString();
	%winnerstreakstring = StreakString();
	%mostmidairstring = MostMidairString();
	%furthestmidairstring = FurthestMidairString();

	%numClients = getNumClients();
	for(%x = -1; %x < 6; %x++)
	{
		%lineNum = "0";
		%lineNum = TeamDuel::Heading(%x, %lineNum);
		if(%mostkillstring != "None")
		{
			%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Most kills:<f5><L40><Bskull_small.bmp><f0> "@ %mostkillstring);
			//Team::setObjective(%x, %lineNum++, "<L25><f1>|<F0>S<f1>|");
			//Team::setObjective(%x, %lineNum++, "<L25><f1>|<F0>H<f1>|");
			//Team::setObjective(%x, %lineNum++, "<L25><f1>|<F0>I<f1>|");
			//Team::setObjective(%x, %lineNum++, "<L25><f1>|<F0>T<f1>|");


		}
		if(%winnerstreakstring != "None")
		{
			%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Longest Winning Streak:<L40><Bskull_small.bmp><f0> "@%winnerstreakstring);
		}
		if($DuelMostMidAir != "0" && $DuelLongestmaholder != "")
		{
			%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Most Midairs:<L40><Bskull_small.bmp><f0> " @ $DuelMostMidAirHolder @ " with " @ $DuelMostMidAir @ " midairs!");
			%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Furthest Midair: <L40><Bskull_small.bmp><f0> "@ $DuelLongestmaholder @ " with a distance of " @ $DuelLongestMA @ " meters!");
		}
		if($DuelBestTimeHolder != "" && $DuelBestTime != "9999")
		{
			%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Fastest Win:<L40><Bskull_small.bmp><f0> " @ $DuelBestTimeHolder @ " beat " @ $DuelBestTimeLoser @ " in " @ formattedbest($DuelBestTime));
		}
		//Team::setObjective(%x, %lineNum++, " ");
       // Team::setObjective(%x, %lineNum++, "<f1>Most Midairs Record:<L40><Bskull_small.bmp><f0>" @ %mostmidairstring);//$Duel::MostMidAirHolder @ " with " @ $Duel::MostMidAir @ " midairs!");
        //Team::setObjective(%x, %lineNum++, "<f1>Furthest Midair Record:<L40><Bskull_small.bmp><f0>" @ %furthestmidairstring);//$Duel::Longestmaholder @ " with a distance of " @ $Duel::LongestMA @ " meters!");

		%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Winning Streak Record:<L40><Bskull_small.bmp><f0>" @ $Duel::RecordHolder @ " with " @ $Duel::RecordNum @ " kills in a row!");
		%lineNum++; Team::setObjective(%x, %lineNum, "<f1>Fastest Win Record:<L40><Bskull_small.bmp><f0>" @ $Duel::RecordTimeHolder @ " beat " @ $Duel::RecordTimeLoser @ " in " @ formattedbest($Duel::RecordTime));

		//Team::setObjective(%x, %lineNum++, "<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z@"<L"@%z++@">"@%z);

		//Team::setObjective(%x, %lineNum++, "<F0>F0           <F1>F1          <F2>F2        <F3>F3       <F4>F4       <F5>F5         <F6>F6          <F7>F7       <F8>F8        <F9>F9      <F10>          F10");
	}

	%lineNum++;
	%lineNum = SortPlayers(%lineNum);

	for(%x = -1; %x < 6; %x++)
	{
		for(%s = %lineNum; %s < 41 ;%s++)
		{
			Team::setObjective(%x, %s, " ");
		}
		for(%s = %lineNum; %s < 41 ;%s++)
		{
			Team::setObjective(%x, %s, " ");
		}
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if($timereached)
		{
			CleanupTimes(%cl);
			//UpdateFile(%cl);
			Score::UpdateFile(%cl);
			if(CheckSavedStats(%cl) && %cl.password != "" && %cl.marked != "true")
			{
				//SaveStats(%cl);
				%cl.password = "";
				%cl.Loaded = false;
			}
			setHigh(%cl);
			$DuelStreak[%cl] = 0;
			GameBase::setTeam(%cl, -1);
		}
		else {
			%time = Time::getMinutes((floor(getSimTime()) - %cl.LastAction));
			if(%time > 2 && %cl.team != "" && %cl.isSuperAdmin != "true")
			{
				messageall(1, Client::GetName(%cl)@" has been removed from his team for being afk("@%time@" minutes)");
				LeaveTeam(%cl);
				return;
			}
			if(%time > 5 && %numclients+1 >= $Server::maxPlayers)
			{
			   echo(Client::GetName(%cl)@" has been kicked for going afk on a full server");
			   if(%cl.isSuperAdmin != "")
			   {
			 	  	kick(%cl, "afk");
				}
			   //banlist::add(client::getTransportAddress(%cl), 1);
		   }
		   else {
			%cl.canjump = true;
			%cl.cantrigger = true;
			Game::refreshClientScore(%cl);
				if(%cl.justConnected != "true")
				{
					HoldHisScore(%cl);
				}
			}
		}
		if(%cl.DMnotify != true && %cl.dm && $DeathMatch::Arena == "WalledIn" && Client::getOwnedObject(%cl)!=-1)
		{
			%dif = vector::getdistance(gamebase::getposition(%cl), $DeathMatch::Center);
			//both(client::getname(%cl) @" - "@%dif);

			if(%dif > 120) {
				DM::Notify(%cl, 11);
			}

		}

	}
	if($timeReached)
	{
		echo("LineNum "@%linenum);
		if(%linenum < 10)
		{

			$noscores=true;
		}
		deletevariables("$SavedStats*");
		deletevariables("$SavedStates*");
	}
	$timeReached = false;


}

function HoardString()
{
	  if ($FlagHunter::HoardMode)
	         {
	            %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	            if ((%curTimeLeft <= ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft > ($FlagHunter::HoardEndTime * 60)))
	            {
	               %hoardTimeLeft = %curTimeLeft - ($FlagHunter::HoardEndTime * 60);
	               %hoardMinutesLeft = floor(%hoardTimeLeft / 60);
	               %hoardSecondsLeft = floor(%hoardTimeLeft - (%hoardMinutesLeft * 60));
	               if (%hoardMinutesLeft == 0)
	               {
	                  if (%hoardSecondsLeft == 1)
	                     %timeString = "1 second";
	                  else
	                     %timeString = %hoardSecondsLeft @ " seconds";
	               }
	               else
	               {
	                  if (%hoardMinutesLeft == 1)
	                     %timeString = "1 minute";
	                  else
	                     %timeString = %hoardMinutesLeft @ " minutes";
	                  if (%hoardSecondsLeft > 0)
	                  {
	                     if (%hoardSecondsLeft == 1)
	                        %timeString = %timeString @ " and 1 second";
	                     else
	                        %timeString = %timeString @ " and " @ %hoardSecondsLeft @ " seconds";
	                  }
	               }
	               Team::setObjective(%l, %lineNum++, "<f1>   - HOARD mode is ON!  You will not be able to return");
	               Team::setObjective(%l, %lineNum++, "<f1>     any flags to the nexus for " @ %timeString @ ".");
	            }
	            else
	            {
	               %timeUntilHoard = %curTimeLeft - ($FlagHunter::HoardStartTime * 60);
	               if (%timeUntilHoard > 0)
	               {
	                  %hoardMinutesLeft = floor(%timeUntilHoard / 60);
	                  if (%hoardMinutesLeft == 0)
	                  {
	                     %hoardSecondsLeft = floor(%timeUntilHoard);
	                     if (%hoardSecondsLeft == 1)
	                        %timeString = "1 second";
	                     else
	                        %timeString = %hoardSecondsLeft @ " seconds";
	                  }
	                  else
	                  {
	                     if (%hoardMinutesLeft == 1)
	                        %timeString = "approximately 1 minute";
	                     else
	                        %timeString = "approximately " @ %hoardMinutesLeft @ " minutes";
	                  }
	                  Team::setObjective(%l, %lineNum++, "<f1>   - HOARD mode is ON!  In " @ %timeString @ " you will");
	                  Team::setObjective(%l, %lineNum++, "<f1>     not be able to return any flags to the nexus.");
	               }
	            }
         }
}
$row[0] = "<F0>";
$row[1] = "<F0>";
$row[2] = "<F4>";
$row[3] = "<F0>";
$row[4] = "<F4>";
$row[5] = "<F0>";
$row[6] = "<F4>";
$row[7] = "<F0>";
$row[8] = "<F4>";
$row[9] = "<F0>";
$row[10] = "<F4>";
function TeamDuel::Heading(%x, %lineNum)
{
	if($timeReached == "disabled")//used to be false der
	{
		Team::setObjective(%x, %lineNum++, "<jc><f5>Duel Statistics");
		Team::setObjective(%x, %lineNum++, "<f1>Mission Name: " @ $missionName);
		Team::setObjective(%x, %lineNum++, "<f1>Mission Objectives:");
		Team::setObjective(%x, %lineNum++, "<f1>   -Duel other players!");
		Team::setObjective(%x, %lineNum++, "<f1>   -Try to get the most wins, the longest winning streak, or the fastest win!");
		Team::setObjective(%x, %lineNum++, "<f1>   -You cannot damage your opponent for the first second of the battle. No cheap shots!");
		Team::setObjective(%x, %lineNum++, " ");
		Team::setObjective(%x, %lineNum++, "<f1>Use the TAB menu to select your weapons and pack loadout, then select a player on the TAB menu and request a duel. Fight to the death.");
		Team::setObjective(%x, %lineNum++, " ");
	}
	if($timeReached == "true" || $timeReached == "false")
	{
		Team::setObjective(%x, %lineNum++, "<jc><f5>Final Statistics");
		Team::setObjective(%x, %lineNum++, " ");
	}
	return %lineNum;
}
function Kills(%client)
{
	return %client.score["DM", "scoreKillsTotal"]+%client.score["TD", "scoreKillsTotal"]+%client.score["DL", "scoreKillsTotal"] ;
}
function TDamage(%client, %mode)
{
	%c = 0;
	for(%i= -1 ; %i < 14; %i++)
	{
		//%client.dmgDone[%type[%y], %x]= "0";
		if(%client.score[%mode, "dmgDone", %i] != "" && %client.score[%mode, "dmgDone", %i] != "-1")
		{
			//echo(%i@" "@%client.score[%mode, "dmgDone", %i]);
			%c = %c+%client.score[%mode, "dmgDone", %i];
		}
	}
	//echo("total = "@%c);
	return %c;
}//%cl.dmgDone[%number]1-6
function Midairs(%client)
{
	for(%i= 3 ; %i < 13; %i++)
	{
		if(%i!=6)
		{
			%total += %client.score["TD", "MidAirs", %i]+%client.score["DL", "MidAirs", %i]+%client.score["DM", "MidAirs", %i];
		}
	}
	return %total;


	//return %client.DLmah+%client.DMmah+%client.TDmah ;
}
function FurthestMA(%client)
{
	if(Midairs(%client) > 0)
	{
		if(%client.DLmad > %client.TDmad && %client.DLmad > %client.DMmad)
		{
			return %client.DLmad ;
		}
		else if(%client.TDmad > %client.DLmad && %client.TDmad > %client.DMmad)
		{
			return %client.TDmad ;
		}
		else if(%client.DMmad > %client.DLmad && %client.DMmad > %client.TDmad)
		{
			return %client.DMmad ;
		}
	}
	return 0;
}
function MostMidairS()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++)
	%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++)
		{
			if(Midairs(%clientList[%i]) < Midairs(%clientList[%i+1]) && Client::getName((%clientList[%i])) != "")
			{
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1] = %hold; %doIt=1;
			}
		}
	}

	%best = %clientList[0];

	%best = CheckForTie(%best, "MidAirs");
	return %best;
}
function CheckForTie(%clientId, %type)
{
	%count = "1";
	%best = %clientId;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%type == "Kills")
		{
			if(Kills(%cl) == Kills(%clientId) && %cl != %clientId)
			{
				%count++;
				%best = %best@" "@%cl ;
			}
		}
		if(%type == "Streak")
		{
			if($HighStreak[%cl] == $HighStreak[%clientId] && %cl != %clientId)
			{
				%count++;
				%best = %best@" "@%cl ;
			}
		}
		if(%type == "MidAirs")
		{
			if(Midairs(%cl) == Midairs(%clientId) && %cl != %clientId)
			{
				%count++;
				%best = %best@" "@%cl ;
			}
		}
		if(%type == "FurthestMA")
		{
			if(FurthestMA(%cl) == FurthestMA(%clientId) && %cl != %clientId)
			{
				%count++;
				%best = %best@" "@%cl ;
			}
		}
	}
	return %count@" "@%best ;
}
function FurthestMidairS()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++)
	%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++)
		{
			if(FurthestMA(%clientList[%i]) < FurthestMA(%clientList[%i+1]) && Client::getName((%clientList[%i])) != "")
			{
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1] = %hold; %doIt=1;
			}
		}
	}

	%best = %clientList[0];

	%best = CheckForTie(%best, "FurthestMA");
	return %best;
}

function FurthestMidairString()
{
	%top = FurthestMidairS();
	//messageall(1, %top@" "@GetWord(%top, 1).score);
	%num = GetWord(%top, 0);
	%score = FurthestMA(GetWord(%top, 1));
	if(%score == "0")
	{
		return "None";
	}
	%message = client::getname(GetWord(%top, 1))@" with a distance of "@%score@" meters!" ;
	if(%num > 1)
	{
		for(%x = 1; %x < %num+1; %x++)
		{
			if(GetWord(%top, %x) != "")
			{
				if(%x > 1)
				{
					%string = %string@", and "@client::getname(GetWord(%top, %x)) ;
				}
				if(%x == "1")
				{
					%string = client::getname(GetWord(%top, %x)) ;
				}
			}
		}
		%message = "Tie between "@%string@" with a distance of  "@%score@" meters each! This NEVER happens!" ;
	}
	return %message;
}
function MostMidairString()
{
	%top = MostMidairS();
	//messageall(1, %top@" "@GetWord(%top, 1).score);
	%num = GetWord(%top, 0);
	%score = Midairs(GetWord(%top, 1));
	if(%score == "0")
	{
		return "None";
	}
	%message = client::getname(GetWord(%top, 1))@" with "@%score@" midairs!" ;
	if(%num > 1)
	{
		for(%x = 1; %x < %num+1; %x++)
		{
			if(GetWord(%top, %x) != "")
			{
				if(%x > 1)
				{
					%string = %string@", and "@client::getname(GetWord(%top, %x)) ;
				}
				if(%x == "1")
				{
					%string = client::getname(GetWord(%top, %x)) ;
				}
			}
		}
		%message = "Tie between "@%string@" with "@%score@" midairs each!" ;
	}
	return %message;
}
function TopWins()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++)
	%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++)
		{
			if(Kills(%clientList[%i]) < Kills(%clientList[%i+1]) && Client::getName((%clientList[%i])) != "")
			{
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1] = %hold; %doIt=1;
			}
		}
	}

	%best = %clientList[0];

	%best = CheckForTie(%best, "Kills");
	return %best;
}
function TopStreak()
{
	%numClients = getNumClients();
	for(%i = 0 ; %i < %numClients ; %i++)
	%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1)
	{
		%doIt = "";
		for(%i= 0 ; %i < %numClients; %i++)
		{
			if($HighStreak[%clientList[%i]] < $HighStreak[%clientList[%i+1]] && Client::getName((%clientList[%i])) != "")
			{
				%hold = %clientList[%i];
				%clientList[%i] = %clientList[%i+1];
				%clientList[%i+1] = %hold; %doIt=1;
			}
		}
	}

	%best = %clientList[0];
	//messageall(1, %best@" "@client::getname(%best)@" "@$HighStreak[%best]);

	%best = CheckForTie(%best, "Streak");
	return %best;
}

//$HighStreak[];
function StreakString()
{
	%top = TopStreak();
	%num = GetWord(%top, 0);
	%score = $HighStreak[GetWord(%top, 1)];
	if(%score == "0")
	{
		return "None";
	}
	%message = client::getname(GetWord(%top, 1))@" with "@%score@" kills in a row!" ;
	if(%num > 1)
	{
		for(%x = 1; %x < %num+1; %x++)
		{
			if(GetWord(%top, %x) != "")
			{
				if(%x > 1)
				{
					%string = %string@", and "@client::getname(GetWord(%top, %x)) ;
				}
				if(%x == "1")
				{
					%string = client::getname(GetWord(%top, %x)) ;
				}
			}
		}
		%message = "Tie between "@%string@" with "@%score@" kills in a row!" ;
	}
	return %message;
}
function KillString()
{
	%top = TopWins();
	//messageall(1, %top@" "@GetWord(%top, 1).score);
	%num = GetWord(%top, 0);
	%score = Kills(GetWord(%top, 1));
	if(%score == "0")
	{
		return "None";
	}
	%message = client::getname(GetWord(%top, 1))@" with "@%score@" kills!" ;
	if(%num > 1)
	{
		for(%x = 1; %x < %num+1; %x++)
		{
			if(GetWord(%top, %x) != "")
			{
				if(%x > 1)
				{
					%string = %string@", and "@client::getname(GetWord(%top, %x)) ;
				}
				if(%x == "1")
				{
					%string = client::getname(GetWord(%top, %x)) ;
				}
			}
		}
		%message = "Tie between "@%string@" with "@%score@" kills each!" ;
	}
	return %message;
}
function remoteDS(%cl)
{
	echo("running score display");
	exec(tdobjectives);
	Score::Display(%cl, %cl);
}
function Score::Clear(%team) {
	for(%i = 0; %i <= 40; %i++) {
		Team::setObjective(%team, %i, " ");
	}
}
%weaponSpacing = "12 8 12 10 10 13 9 11 11 13 9";
$WeaponByDamage[3] = "Plasma";
$WeaponByDamage[4] = "Disc";
$WeaponByDamage[5] = "Grenade";
$WeaponByDamage[1] = "Chaingun";
$WeaponByDamage[6] = "Laser";
$WeaponByDamage[7] = "Mortar";
$WeaponByDamage[8] = "Blaster";
$WeaponByDamage[9] = "Elf Gun";
$WeaponByDamage[11] = "Hand Nade";
$WeaponByDamage[13] = "Mine";

$WeaponByDamage[0] = "Gaia";
$WeaponByDamage[3] = "Plasma Gun";
$WeaponByDamage[4] = "Disc Launcher";
$WeaponByDamage[5] = "Grenade Launcher";
$WeaponByDamage[1] = "Chaingun";
$WeaponByDamage[6] = "Laser Rifle";
$WeaponByDamage[7] = "Mortar";
$WeaponByDamage[8] = "Blaster";
$WeaponByDamage[9] = "Elf Gun";
$WeaponByDamage[14] = "Hand Grenade";
$WeaponByDamage[13] = "Mine";

//%number = 123.45651111;
//echo(%number);

//a(%number);
function Score::Display(%client, %viewer, %PlayType)
{
	%prevTeam = gamebase::getteam(%viewer);
	if(%PlayType == "" || %PlayType == -1)
	{
		%PlayType = "TD";
	}

	%team = 6;

	%weaponSpacing = "26 20 26 18 12 14 17 11 20 12 9";
	%weaponOrder = "4 5 3 8 1 6 9 14 7 13";//disc grenade plasma blaster chaingun laser elf handnade mortar mine
	%globalSpacing = "34 15 94 10 12 14 17 11 20 12 9";
	Team::clearObjectives(%team);
	//Score::Clear(%team);

	client::setinitialteam(%viewer, %team);
	gamebase::setteam(%viewer, %team);



	%lineNum = 1;
	Team::setObjective(%team, 0, "<f0>f0<f1>f1<f2>f2<f3>f3<f4>f4<f5>f5<f6>f6<f7>f7<f8>f8<f9>f9");
	Team::setObjective(%team, %lineNum, "<jc><f1>"@client::getname(%client)@" Statistics");												%lineNum++;
	Team::setObjective(%team, %lineNum, "<f1>Globals: (UNFINISHED)");																	%lineNum++;
	%client = %client.MainScoreBackup;
	%L = 0;	%gwvar = -1;
	%globalSpacingOne = "0 30 56 88 121 154";
	%globalSpacingTwo = "22 50 79 112 145 182";
	//Team::setObjective(%team, %lineNum,
	%ObjLine =
										   "<F0>Matches Played: <F1><L22>"@		%client.score["MatchesPlayed"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Rounds Played: <F1><L50>"@		%client.score["RoundsPlayed"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Rounds Survived: <F1><L79>"@	%client.score["RoundsSurvived"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Most Kills(Round): <F1><L112>"@	%client.score["MostKillsPerRound"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Most Hits(Round): <F1><L145>"@	%client.score["MostHitsPerRound"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Most MAs(Round): <F1><L182>"@	%client.score["MostMAsPerRound"] ;
	Team::setObjective(%team, %lineNum, %ObjLine);
	%lineNum++;

	%L = 0;	%gwvar = -1;
	%ObjLine =							   "<F0>Assists: <F1><L22>"@				%client.score[%playType, "Assists"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>BestKillStreak: <F1><L50>"@			%client.score[%playType, "BestKillStreak"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>Suicides: <F1><L79>"@				%client.score[%playType, "scoreSuicide"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>BodyBlocks: <F1><L112>"@			%client.score[%playType, "BodyBlocks"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>HandNadeHits: <F1><L145>"@			%client.score[%playType, "HandNadeHits"]@
	"<L"@gw(%globalSpacingOne, (%L += 1))@"><F0>FurthestGroundShot): <F1><L182>"@	%client.score[%playType, "FurthestGroundShot"] ;
	Team::setObjective(%team, %lineNum, %ObjLine);
	%lineNum++;

	Team::setObjective(%team, %lineNum, "<f1>TeamDuel Stats:<L36>------------------------------------------------------------------------------------------------------------------------");	%lineNum++;

	%gwvar = -1;
	%Header = "";
	%L = 0;
	for(%x = 0; gw(%weaponOrder, %x) != -1; %x++)
	{
		%Header = %Header@
		"<L"@(%L += gw(%weaponSpacing, %gwvar++))@">"@$WeaponByDamage[gw(%weaponOrder, %gwvar)] ;
		if(gw(%weaponOrder, %x+1) == -1)
		{
			%Header = %Header@
			"<L"@(%L += gw(%weaponSpacing, %gwvar++))@">Totals" ;
		}
	}
	Team::setObjective(%team, %lineNum, %Header);																																%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Kills:", "scoreKills", false, %playType, %weaponOrder, %weaponSpacing));					%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>Deaths:", "scoreDeaths", false, %playType, %weaponOrder, %weaponSpacing));				%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Mid-Airs:", "MidAirs", false, %playType, %weaponOrder, %weaponSpacing));					%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>Mid-Airs Caught:", "MidAirsCaught", false, %playType, %weaponOrder, %weaponSpacing));		%lineNum++;
	//Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Furthest Mid-Air:", "FurthestMidAir", false, %playType, %weaponOrder, %weaponSpacing));	%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>Headshots:", "HeadShots", false, %playType, %weaponOrder, %weaponSpacing));				%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F0>Shots Fired:", "shotsFired", false, %playType, %weaponOrder, %weaponSpacing));			%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Hits Landed:", "HitsDone", false, %playType, %weaponOrder, %weaponSpacing));				%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>Hits Received:", "HitsReceived", false, %playType, %weaponOrder, %weaponSpacing));		%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Corpse Mid-Airs:", "CorpseMa", false, %playType, %weaponOrder, %weaponSpacing));			%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>Corpse MA Caught:", "CorpseMaTaken", false, %playType, %weaponOrder, %weaponSpacing));	%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>DMG Done:", "dmgDone", false, %playType, %weaponOrder, %weaponSpacing));					%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F4>DMG Received:", "dmgReceived", false, %playType, %weaponOrder, %weaponSpacing));			%lineNum++;
	Team::setObjective(%team, %lineNum, Score::GetObjectiveWeaponString(%client, "<F1>Direct Shots:", "DirectShots", false, %playType, %weaponOrder, %weaponSpacing));			%lineNum++;
	Team::setObjective(%team, %lineNum, "<f1><L36>------------------------------------------------------------------------------------------------------------------------");	%lineNum++;
	Team::setObjective(%team, %lineNum, "<f0><L36>");	%lineNum++;
	for(%i = %lineNum; %i <= 40; %i++) {
		Team::setObjective(%team, %i, "_"@%i);
	}
	remoteObjectivesMode(%viewer);
	client::setinitialteam(%viewer, %prevTeam);
	gamebase::setteam(%viewer, %prevTeam);

}
function Score::GetObjectiveWeaponString(%client, %objLine, %scoreType, %secondType, %playType, %weaponOrder, %weaponSpacing)
{
	%L = 0;
	%gwvar = -1;
	%total = 0;
	%secondTotal = 0;
	//echo("second type ===== "@%secondType);
	if(%secondType == false)
	{
		//echo("gows numero 1");
		for(%x = 0; gw(%weaponOrder, %x) != -1; %x++)
		{
			%objLine = %objLine@
			"<L"@(%L += gw(%weaponSpacing, %x))@">"@MyRound(%client.score[%playType, %scoreType, gw(%weaponOrder, %x)]) ;
			%total += %client.score[%playType, %scoreType, gw(%weaponOrder, %x)] ;
		}
		%objLine = %objLine@
		"<L"@(%L += gw(%weaponSpacing, %x))@">"@MyRound(%total);
		//echo(%objLine@" XxX "@%total);
	}
	else
	{
		echo("YOU SHOULD NEVER SEE ME");//might use later... it displays a second 'paired' stat in parenthesis red colored next to stat midairshit(midairscaught)
		for(%x = 0; gw(%weaponOrder, %x) != -1; %x++)
		{
			%objLine = %objLine@
			"<F1><L"@(%L += gw(%weaponSpacing, %x))@">"@%client.score[%playType, %scoreType, gw(%weaponOrder, %x)]@"<F0>(<F4>"@%client.score[%playType, %secondType, gw(%weaponOrder, %x)]@"<F0>)" ;
			%total += %client.score[%playType, %scoreType, gw(%weaponOrder, %x)] ;
			%secondTotal += %client.score[%playType, %scoreType, gw(%weaponOrder, %x)] ;
		}
		%objLine = %objLine@
		"<F1><L"@(%L += gw(%weaponSpacing, %x))@">"@MyRound(%total)@"<F0>("@MyRound(%secondTotal)@"<F0>)";
	}
	//echo("MY OBJ LINE "@%objLine@" END");
	return %objLine;
}
function SortPlayers(%lineNum)
{
	if(!$timereached)
	{
		//%DLmad = FindHighLight(DLmad);
		//%DLmah = FindHighLight(DLmah);

		//%TDmad = FindHighLight(TDmad);
		//%TDmah = FindHighLight(TDmah);

		//%DMmah = FindHighLight(DMmah);
		//%DMmad = FindHighLight(DMmad);




		//%DLscoreKills = FindHighLight("DLscoreKills");
		//%TDscoreKills = FindHighLight("TDscoreKills");
		//%DMscoreKills = FindHighLight("DMscoreKills");

		//%DLscoreDeaths = FindHighLight("DLscoreDeaths");
		//%TDscoreDeaths = FindHighLight("TDscoreDeaths");
		//%DMscoreDeaths = FindHighLight("DMscoreDeaths");

	}
//Duel************************
	if(Obj::CheckMode("DL"))
	{
		%playtype = "DL";
		for(%x = -1; %x < 6; %x++)
		{
			//Team::setObjective(%x, %lineNum, " ");
			Team::setObjective(%x, %lineNum, "<f1>Duel Stats:<L36>------------------------------------------------------------------------------------------------------------------------");
			//Team::setObjective(%x, %lineNum+1, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L54>"@$row[3]@"Ratio<L63>"@$row[4]@"Midairs<L74>"@$row[5]@"Furthest MA<L93>"@$row[6]@"Streak<L103>"@$row[7]@"Accuracy<L117>"@$row[6]@"Fastest Win");
			%lineNum++; Team::setObjective(%x, %lineNum, "<L64>"@$row[4]@"Midairs<L77>"@$row[5]@"Farthest MA"@$row[6]@"<L99>Hits");
			%lineNum++; Team::setObjective(%x, %lineNum, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L52>"@$row[3]@"Ratio"@$row[4]@"<L60>D <L64>P <L68>N <L72>HN"@$row[5]@"<L77>D <L81>P <L85>N <L89>HN"@$row[6]@"<L95>D<L99>P<L103>N<L107>HN<L112>"@$row[7]@"Accuracy<L124>");
		}
		//%lineNum++;
		//%lineNum++;
		//%lineNum++;
		//both(%lineNum);
		%c = 0;
		%numClients = getNumClients();
		for(%i = 0 ; %i < %numClients ; %i++)
		%clientList[%i] = getClientByIndex(%i);
		%doIt = 1;
		while(%doIt == 1)
		{
			%doIt = "";
			for(%i= 0 ; %i < %numClients; %i++)
			{
				//(%clientList[%i]).SKT =
				if((%clientList[%i]).score[%playtype, "scoreKillsTotal"] < (%clientList[%i+1]).score[%playtype, "scoreKillsTotal"] && Client::getName(%clientList[%i]) != "")
				{
					%hold = %clientList[%i];
					%clientList[%i] = %clientList[%i+1];
					%clientList[%i+1] = %hold; %doIt=1;
				}
			}
		}
		%index = 0;
		for(%index = 0 ; %index < %numClients; %index++)
		{
			if((%clientList[%index].score[%playtype, "scoreKillsTotal"] + %clientList[%index].score[%playtype, "scoreDeathsTotal"]) > 2)
			{
				(%clientList[%index]).ratio = getEfficiencyRatio(%clientList[%index], "DL");

				if(%DLmad == %clientList[%index])	{	%DLmadT = "<f1>";		}
				if(%DLmah == %clientList[%index])	{	%DLmahT = "<f1>";		}
				if(%DLscoreKills == %clientList[%index])	{	%DLsK = "<f1>";		}
				if(%DLscoreDeaths == %clientList[%index])	{	%DLsD = "<f1>";		}
				//if(client::getname(%clientList[%index]) == $DuelMostMidAirHolder)	{	%DMMA = "<f1>";	}
				//if(client::getname(%clientList[%index]) == $DuelLongestmaholder)	{	%DLMA = "<f1>";	}

			//Team::setObjective(%x, %lineNum++, "<f1>Most Midairs:<L40><Bskull_small.bmp> $DuelMostMidAirHolder $DuelMostMidAir @ " midairs!");
			//Team::setObjective(%x, %lineNum++, "<f1>Furthest Midair: <L40><Bskull_small.bmp><f0> "@ $DuelLongestmaholder @ $DuelLongestMA @ " meters!");

				//echo(client::getname(%clientList[%index]) @"=="@ $DuelBestTimeHolder);
				if(client::getname(%clientList[%index]) == $DuelBestTimeHolder)	{	%DBTH = "<f1>";	}//echo("yesy");	}
				for(%x = -1; %x < 6; %x++)
				{
																						//GetWord(\" "@ %clientList[%index] @" \",0),

					%objmsg =
					"<L2>"@$row[0]@""@(%c + 1) @ ". " @ client::getname(%clientList[%index]) @
					"<L36><L36>"@$row[1]@"" @ (%clientList[%index]).score[%playtype, "scoreKillsTotal"] @
					"<L43>"@$row[2]@"" @ (%clientList[%index]).score[%playtype, "scoreDeathsTotal"] @
					"<L52>"@$row[3]@"" @ (%clientList[%index]).ratio @
					"<L60>"@$row[4]@""@%clientList[%index].score[%playtype, "MidAirs", 4]@
					" <L64>"@%clientList[%index].score[%playtype, "MidAirs", 3]@
					" <L68>"@%clientList[%index].score[%playtype, "MidAirs", 5]@
					" <L72>"@%clientList[%index].score[%playtype, "MidAirs", 7]@""@$row[5]@
					"<L77>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 4])@
					"<L81>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 3])@
					"<L85>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 5])@
					"<L89>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 7])@
					"<L95>"@$row[6]@"" @ %clientList[%index].score[%playtype, "HitsDone", 4]@
					"<L99>" @ %clientList[%index].score[%playtype, "HitsDone", 3]@
					"<L103>" @ %clientList[%index].score[%playtype, "HitsDone", 5]@
					"<L107>" @ %clientList[%index].score[%playtype, "HitsDone", 14] @
					"<L112>"@$row[7]@""@Stats::Accuracy(%clientList[%index])@"%";
					Team::setObjective(%x, %lineNum, %objmsg);
					//Team::setObjective(%x, %lineNum, "<L2>"@$row[0]@""@(%c + 1) @ ". " @ Client::getName(%clientList[%index]) @ "<L36>"@$row[1]@"" @ (%clientList[%index]).DLscoreKills @ "<L43>"@$row[2]@"" @ (%clientList[%index]).DLscoreDeaths @ "<L54>"@$row[3]@"" @ (%clientList[%index]).ratio @ "<L63>"@$row[4]@""@%clientList[%index].DLmah@"<L74>"@$row[5]@""@%clientList[%index].DLmad@"<L93>"@$row[6]@"" @ $DuelStreak[%clientList[%index]] @ "<L103>"@$row[7]@""@Stats::Accuracy(%clientList[%index])@"% <L117>"@$row[6]@""@$DuelBestDisplay[%clientList[%index]]);
					//Team::setObjective(%x, %lineNum, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L54>"@$row[3]@"Ratio<L63>"@$row[4]@"Midairs<L74>"@$row[5]@"Furthest MA<L93>"@$row[6]@"Streak<L103>"@$row[7]@"Accuracy<L117>"@$row[6]@"Fastest Win");

				}
				//echo("DL "@%lineNum);
				%lineNum++;
				%c++;
			}
		}
	}





	if(Obj::CheckMode("TD"))
	{
		%playtype = "TD";

		%c = 0;
		%numClients = getNumClients();
		for(%i = 0 ; %i < %numClients ; %i++)
		{
			%clientList[%i] = getClientByIndex(%i);
		}

		%doIt = 1;
		for(%x = -1; %x < 6; %x++)
		{
			Team::setObjective(%x, %lineNum, " ");
			//if(%lineNum > 15)
			//{
				Team::setObjective(%x, %lineNum+1, $row[1]@"<f1>Team Duel Stats:<L36>------------------------------------------------------------------------------------------------------------------------");
			//}
			Team::setObjective(%x, %lineNum+2, "<L64>"@$row[4]@"Midairs<L77>"@$row[5]@"Farthest MA"@$row[6]@"<L99>Hits");
			Team::setObjective(%x, %lineNum+3, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L52>"@$row[3]@"Ratio"@$row[4]@"<L60>D <L64>P <L68>N <L72>HN"@$row[5]@"<L77>D <L81>P <L85>N <L89>HN"@$row[6]@"<L95>D<L99>P<L103>N<L107>HN<L112>"@$row[7]@"Assists<L122>"@$row[8]@"Damage");
		//	Team::setObjective(%x, %lineNum+3, $row[4]@"<L74>"@%clientList[%index].midairlongest[TD, 4]@" <77>"@%clientList[%index].midairlongest[TD, 3]@" <80>"@%clientList[%index].midairlongest[TD, 5]@" <83>"@%clientList[%index].midairlongest[TD, 7]@"");
		//	..%clientList[%index].midairs[TD, 4]//3=plas,4=disc,5=nade,7=hn
			//Team::setObjective(%x, %lineNum+3, "");
		}
		%lineNum += 4;
		while(%doIt == 1)
		{
			%doIt = "";
			for(%i= 0 ; %i < %numClients; %i++)
			{
				if((%clientList[%i]).score[%playtype, "scoreKillsTotal"] < (%clientList[%i+1]).score[%playtype, "scoreKillsTotal"] && Client::getName((%clientList[%i])) != "")
				{
					%hold = %clientList[%i];
					%clientList[%i] = %clientList[%i+1];
					%clientList[%i+1] = %hold; %doIt=1;
				}
			}
		}
		%index = 0;
		for(%index = 0 ; %index < %numClients; %index++)
		{
			if((%clientList[%index].score[%playtype, "scoreKillsTotal"] + %clientList[%index].score[%playtype, "scoreDeathsTotal"]) > 2)
			{
				(%clientList[%index]).ratio = getEfficiencyRatio(%clientList[%index], "TD");
				for(%x = -1; %x < 6; %x++)
				{
							//scoreweapon 4 3 5 7
							//%clientList[%index]..HitsDone[7]
							//<L94>D <L99>P <L103>N <L107>HN
					%objmsg =
					"<L2>"@$row[0]@""@(%c + 1) @ ". " @ Client::getName(%clientList[%index]) @
					"<L36><L36>"@$row[1]@"" @ (%clientList[%index]).score[%playtype, "scoreKillsTotal"] @
					"<L43>"@$row[2]@"" @ (%clientList[%index]).score[%playtype, "scoreDeathsTotal"] @
					"<L52>"@$row[3]@"" @ (%clientList[%index]).ratio @
					"<L60>"@$row[4]@""@%clientList[%index].score[%playtype, "MidAirs", 4]@
					" <L64>"@%clientList[%index].score[%playtype, "MidAirs", 3]@
					" <L68>"@%clientList[%index].score[%playtype, "MidAirs", 5]@
					" <L72>"@%clientList[%index].score[%playtype, "MidAirs", 7]@""@$row[5]@
					"<L77>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 4])@
					"<L81>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 3])@
					"<L85>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 5])@
					"<L89>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 7])@
					"<L95>"@$row[6]@"" @ %clientList[%index].score[%playtype, "HitsDone", 4]@
					"<L99>" @ %clientList[%index].score[%playtype, "HitsDone", 3]@
					"<L103>" @ %clientList[%index].score[%playtype, "HitsDone", 5]@
					"<L107>" @ %clientList[%index].score[%playtype, "HitsDone", 14] @
					"<L112>"@$row[7]@""@%clientList[%index].score[%playtype, "Assists"]@
					"<L122>"@$row[8]@" "@MyRound(TDamage(%clientList[%index], %playtype));
					Team::setObjective(%x, %lineNum, %objmsg);
					//Team::setObjective(%x, %lineNum, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L54>"@$row[3]@"Ratio<L63>"@$row[4]@"Midairs<L74>"@$row[5]@"Furthest MA<L93>"@$row[6]@"Streak<L103>"@$row[7]@"Accuracy<L117>"@$row[6]@"Fastest Win");

				}
				//echo("DM "@%lineNum);
				%lineNum++;
				%c++;
			}
		}
	}
//TD**************************old

//DM****************************
	if(Obj::CheckMode("DM"))
	{
		%playtype = "DM";
		%c = 0;
		%numClients = getNumClients();
		for(%i = 0 ; %i < %numClients ; %i++)
		%clientList[%i] = getClientByIndex(%i);
		%doIt = 1;
		for(%x = -1; %x < 6; %x++)
		{
			Team::setObjective(%x, %lineNum, " ");
			//if(%lineNum > 15)
			//{
				Team::setObjective(%x, %lineNum+1, $row[1]@"<f1>Death Match Stats:<L36>------------------------------------------------------------------------------------------------------------------------");
			//}
			Team::setObjective(%x, %lineNum+2, "<L64>"@$row[4]@"Midairs<L77>"@$row[5]@"Farthest MA"@$row[6]@"<L99>Hits");
			Team::setObjective(%x, %lineNum+3, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L52>"@$row[3]@"Ratio"@$row[4]@"<L60>D <L64>P <L68>N <L72>HN"@$row[5]@"<L77>D <L81>P <L85>N <L89>HN"@$row[6]@"<L95>D<L99>P<L103>N<L107>HN<L112>"@$row[7]@"Accuracy<L124>"@$row[6]@"Hunters");
		//	Team::setObjective(%x, %lineNum+3, $row[4]@"<L74>"@%clientList[%index].midairlongest[DM, 4]@" <77>"@%clientList[%index].midairlongest[DM, 3]@" <80>"@%clientList[%index].midairlongest[DM, 5]@" <83>"@%clientList[%index].midairlongest[DM, 7]@"");
		//	..%clientList[%index].midairs[DM, 4]//3=plas,4=disc,5=nade,7=hn
			//Team::setObjective(%x, %lineNum+3, "");
		}
		%lineNum += 4;
		while(%doIt == 1)
		{
			%doIt = "";
			for(%i= 0 ; %i < %numClients; %i++)
			{
				if((%clientList[%i]).score[%playtype, "scoreKillsTotal"] < (%clientList[%i+1]).score[%playtype, "scoreKillsTotal"] && Client::getName((%clientList[%i])) != "")
				{
					%hold = %clientList[%i];
					%clientList[%i] = %clientList[%i+1];
					%clientList[%i+1] = %hold; %doIt=1;
				}
			}
		}
		%index = 0;
		for(%index = 0 ; %index < %numClients; %index++)
		{
			if((%clientList[%index].score[%playtype, "scoreKillsTotal"] + %clientList[%index].score[%playtype, "scoreDeathsTotal"]) > 2 || %clientList[%index].score > 50)
			{
				(%clientList[%index]).ratio = getEfficiencyRatio(%clientList[%index], "DM");
				for(%x = -1; %x < 6; %x++)
				{
							//scoreweapon 4 3 5 7
							//%clientList[%index]..HitsDone[7]
							//<L94>D <L99>P <L103>N <L107>HN
					Team::setObjective(%x, %lineNum, "<L2>"@$row[0]@""@(%c + 1) @ ". " @ Client::getName(%clientList[%index]) @
					"<L36><L36>"@$row[1]@"" @ (%clientList[%index]).score[%playtype, "scoreKillsTotal"] @
					"<L43>"@$row[2]@"" @ (%clientList[%index]).score[%playtype, "scoreDeathsTotal"] @
					"<L52>"@$row[3]@"" @ (%clientList[%index]).ratio @
					"<L60>"@$row[4]@""@%clientList[%index].score[%playtype, "MidAirs", 4]@
					" <L64>"@%clientList[%index].score[%playtype, "MidAirs", 3]@
					" <L68>"@%clientList[%index].score[%playtype, "MidAirs", 5]@
					" <L72>"@%clientList[%index].score[%playtype, "MidAirs", 7]@""@$row[5]@
					"<L77>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 4])@
					"<L81>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 3])@
					"<L85>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 5])@
					"<L89>"@floor(%clientList[%index].score[%playtype, "FurthestMidAir", 7])@
					"<L95>"@$row[6]@"" @ %clientList[%index].score[%playtype, "HitsDone", 4]@
					"<L99>" @ %clientList[%index].score[%playtype, "HitsDone", 3]@
					"<L103>" @ %clientList[%index].score[%playtype, "HitsDone", 5]@
					"<L107>" @ %clientList[%index].score[%playtype, "HitsDone", 14] @
					"<L112>"@$row[7]@""@Stats::Accuracy(%clientList[%index])@
					"% <L124>"@$row[6] @ %clientList[%index].score);
					//Team::setObjective(%x, %lineNum, "<L36>"@$row[1]@"Kills<L43>"@$row[2]@"Deaths<L54>"@$row[3]@"Ratio<L63>"@$row[4]@"Midairs<L74>"@$row[5]@"Furthest MA<L93>"@$row[6]@"Streak<L103>"@$row[7]@"Accuracy<L117>"@$row[6]@"Fastest Win");

				}
				//echo("DM "@%lineNum);
				%lineNum++;
				%c++;
			}
		}
	}
	for(%x = -1; %x < 6; %x++)
	{
		for(%s = %lineNum; %s < 40 ;%s++)
		{
			Team::setObjective(%x, %s, " ");
		}
	}

	return %lineNum;
}
function Obj::CheckMode(%mode)
{

	//return true;
	//if(%mode == "DM")
	//{
		//return true;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if((%cl.score[%mode, "scoreKillsTotal"] + %cl.score[%mode, "scoreDeathsTotal"]) > 2)
			{
				//echo(%mode@" kill and death: "@%cl@" "@%cl.scoreKillsTotal[%mode] + %cl.scoreDeathsTotal[%mode]);
				return true;
			}
		}
		return false;
	//}
	if(%mode == "TD")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if((%cl.TDscoreKills + %cl.TDscoreDeaths) > 2)
			{
				//echo("TD kill and death: "@%cl@" "@%cl.TDscoreKills + %cl.TDscoreDeaths);
				return true;
			}
		}
	}
	if(%mode == "DL")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if((%cl.DLscoreKills + %cl.DLscoreDeaths) > 2)
			{
				//echo("DL kill and death: "@%cl@" "@%cl.dlscoreKills + %cl.dlscoreDeaths);
				return true;
			}
		}
	}
	//echo("checkmode false");
	return false;
}


$loaded["TDObjectives.cs"] = true;