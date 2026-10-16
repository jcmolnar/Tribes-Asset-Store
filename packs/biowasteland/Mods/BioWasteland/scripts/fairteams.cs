//  Mod to keep players on even teams
//
//  Originally written by Shane Hyde
//  Download it from http://www.users.bigpond.net.au/shyde/tribes/
//
//  Modified for use with Wasteland, (http://www.dopplegangers.com/tribes/shifter/)

//  Name & version
//

$modmgtModName = "SHFairteams2";
$modmgtModVers = "1.30";

function SHResetStats()
{
	// echo("Executing reset stats");

	%numteams = getNumTeams();
	%numPLayers = getNumClients();

	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		$SHNumTeamPlayers[%i] = 0;
		$SHMinTeamScore[%i] = 0;
	}

	$SHMinTeamPlayers = 9999;
	$SHMaxTeamScore = 9999;

	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%team = Client::getTeam(%pl);
		$SHNumTeamPlayers[%team] = $SHNumTeamPlayers[%team] + 1;

		if(%pl.SHAddOrder  > $SHMinTeamScore[%team])
		{
			$SHMinTeamScore[%team] = %pl.SHAddOrder ;
			$SHMinTeamClient[%team] = %pl;
		}
	}
	for(%i=0;%i<%numteams;%i++)
	{
		if($SHNumTeamPlayers[%i] < $SHMinTeamPlayers)
		{
			$SHMinTeamPlayers = $SHNumTeamPlayers[%i];
		}
		if($TeamScore[%i] < $SHMaxTeamScore)
		{
			$SHMaxTeamScore = $teamScore[%i];
		}
	}
}

function DumpStats()
{
    	%numteams = getNumTeams();
    	if($debug) echo("MinTeamPlayers " @ $SHMinTeamPlayers);
		if($debug) echo("MinTeamScore " @ $SHMaxteamScore);
    	for(%i=0;%i<%numteams;%i++)
    	{
    	}
}

function EvenTeams()
{

	if ($Wasteland::FairTeams == "False")
	{
		echo("ADMINMSG: *** Fair Teams Is OFF");
		return;
	}

	if($SHAddOrder == "")
		$SHAddOrder = 1;

	%numPLayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		if(%pl.SHAddOrder == "")
		{
			%pl.SHAddOrder = $SHAddOrder;
			$SHAddOrder++;
		}
	}

	SHResetStats();
	DumpStats();

	if($SHFairTeams == "")
	{
		return;
	}

	%numteams = getNumTeams();

	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if(($SHNumTeamPlayers[%i]-1 > $SHMinTeamPlayers || ($SHNumTeamPlayers[%i] > $SHMinTeamPlayers && %teamscore[%i] > $SHMaxTeamScore ))	&& $SHNumTeamPlayers[%i] > 2)
		{
			if(%numteams == 2)
			{
				if($SHNumTeamPLayers[%i] > $SHNumTeamPlayers[1-%i]+1)
				{
					processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
					bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switch sides to even the teams.", 5);
					centerprint($SHMinTeamClient[%i],"<jc><j1>The teams were uneven, you have been switched.", 5);
					return;
				}
				else
				{
					processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
					centerprint($SHMinTeamClient[%i],"<jc><j1>The teams were uneven, you have been switched.", 10);
					bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switch sides to even the teams.", 5);
				}
			}
			else
			{
				processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
				centerprint($SHMinTeamClient[%i],"<jc><j1>The teams were uneven, you have been switched.", 10);
				bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switch sides to even the teams.", 5);
			}
		}
	}
}

function CheckTeamsAreEven()
{

	if ($Wasteland::FairTeams == "False")
	{
		echo("ADMINMSG: *** Fair Teams Is OFF");
		return;
	}

	//echo("ADMINMSG: **** Wasteland Is Checking For Even Teams");

	if($SHAddOrder == "")
		$SHAddOrder = 1;

	%numPLayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		if(%pl.SHAddOrder == "")
		{
			%pl.SHAddOrder = $SHAddOrder;
			$SHAddOrder++;
		}
	}
	SHResetStats();

	if($SHFairTeams == "")
	{
		schedule("CheckteamsAreEven();",$Wasteland::FairCheck);
		return;
	}


	%numteams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if(($SHNumTeamPlayers[%i]-1 > $SHMinTeamPlayers || ($SHNumTeamPlayers[%i] > $SHMinTeamPlayers && %teamscore[%i] > $SHMaxTeamScore )) && $SHNumTeamPlayers[%i] > 2)
		{
			if(%numteams == 2)
			{
				if($SHNumTeamPLayers[%i] > $SHNumTeamPlayers[1-%i]+1)
				{
					//processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
					centerprint($SHMinTeamClient[%i],"<jc><j1>The teams are uneven, you must switch.", 15);
					bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams.", 10);
					echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***");
					schedule("CheckteamsAreEven();",$Wasteland::FairCheck);
					schedule("eventeams();",$Wasteland::FairEvens);
					return;
				}
				else
				{
					//processMenuPickTeam($SHMinTeamClient[%i],-2,"");
					centerprint($SHMinTeamClient[%i],"<jc><j1>The teams are uneven, you must switch.", 15);
					bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams.", 10);
					echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***");
					schedule("eventeams();",$Wasteland::FairEvens);
				}

			}
			else
			{
				//processMenuPickTeam($SHMinTeamClient[%i],-2,"");
				centerprint($SHMinTeamClient[%i],"<jc><j1>The teams are uneven, you must switch.", 15);
				bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams.", 10);
				echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***");
				schedule("eventeams();",$Wasteland::FairEvens);
			}
		}
	}
	schedule("CheckteamsAreEven();",$Wasteland::FairCheck);
}

if ($Wasteland::FairTeams)
{
	if ($Wasteland::FairCheck > 0) schedule("CheckteamsAreEven();",$Wasteland::FairCheck);
	if ($Wasteland::FairEvens > 0) schedule("EvenTeams();",$Wasteland::FairEvens);
	$SHFairTeams = 1;
	echo($modmgtModName @ " v" @ $modmgtModVers @ " loaded");
}