$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
$tempmenu = "";

exec(realitybites2);

$RBModListAdmin = "\nReality Bites 2.0";
// MODERN-PORT (2026-09-04): the mod overwrote $ModList with its display name so the 1998
// server browser showed "Reality Bites 2.0". $modList is also the SEARCH PATH: the next
// EvalSearchPath() (Server::storeData, every createServer) rebuilt it as
// "Reality;Bites;2.0;base" and dropped the mod folder, so every mission-time exec
// (objectives.cs, game.cs, comchat.cs) resolved to BASE and joining clients were told
// the mod was "Reality Bites 2.0". Left as the real launch chain; servers now advertise
// "rb2", which is what the Modern Client's join prompt and the store pack expect.
//$ModList = $RBModListAdmin;
function String::len(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}

function ComputerCrash(%client)
{


	if (%client.burntime >= 1)
	{
		client::setGuiMode(%client, floor(getRandom() * 6));
		%client.burntime--;
		%cl = %client;
		schedule("ComputerCrash(" @ %client @ ");",0.2);

	schedule("bottomprint(" @ %cl @ ", \"<jc><f1>Go be an immature ass somewhere else.\", 1);", 0);
	Client::sendMessage(%cl, 0, "~wmale4.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wmale5.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale2.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale1.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale3.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale4.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale5.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~wflagreturn_message.wav");
	Client::sendMessage(%cl, 0, "~wflagcapture.wav");
	Client::sendMessage(%cl, 0, "~wturretfire1_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~wrmt_radar.wav");
	Client::sendMessage(%cl, 0, "~wexplo3.wav");
	Client::sendMessage(%cl, 0, "~wexplo4.wav");
	Client::sendMessage(%cl, 0, "~wdebris_large.wav");
	Client::sendMessage(%cl, 0, "~wlaserhit.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");

	}
	else
	client::setGuiMode(%client, 0);

}

function String::replace(%string, %search, %replace)
{
	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)
	{
		%lenstr = String::len(%string);
		%lenser = String::len(%search);
		%part1 = String::getSubStr(%string, 0, %loc - 1);
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
		%string = %part1 @ "" @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}
	return %string;
}


function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
		//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2)
		$TypeStart = 0;
	else
		$TypeStart = 1;
	for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
		if($MLIST::Type[%type] != "Training")
		{
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
			%index++;
		}
}

function remoteFetchData(%client)
{

echo(%client);
Client::sendMessage(%client, 1, "TURN OFF YOUR SCRIPT!  IT IS LAGGING MY SERVER!!!!");

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

//	verify that this is a valid mission:
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
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
	{
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " changed the mission to " @ %misName @ "");
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

	%name = Client::getName(%client);


	for (%x = 0; %x < 100; %x++) // Go thru all 100 fun passwords
	{
		if(%password != "" && %password == $FunPassword[%x])
		{
			$xFuntext[%x] = String::replace($FunText[%x], "%person", %name);
			messageAll(3, $xFunText[%x]);
			if ($FunPassword[%x] == "")
					break;
			%password = "bypass"; // Make sure player doesn't get killed for using a fun password

		}	
	}

	for (%x = 0; %x < 100; %x++) // Go thru all 100 deadly sin passwords
	{
		if(%password != "" && %password == $DeadlyPassword[%x])
		{
			$xDeadlyText[%x] = String::replace($DeadlyText[%x], "%person", %name);
			messageAll(3, $xDeadlyText[%x]);

			Player::blowUp(%client);
			remoteKill(%client);

			if ($DeadlyPassword[%x] == "")
				break;
			%password = "bypass"; // Don't double kill a player for using a deadly password

		}	
	}

	for (%x = 0; %x < 100; %x++) // Go thru all 100 faker passwords
	{
		if(%password != "" && %password == $FakerPassword[%x])
		{
			$xFakerText[%x] = String::replace($FakerText[%x], "%person", %name);
			messageAll(2, $xFakerText[%x]);

			if ($FakerPassword[%x] == "")
				break;
			%password = "bypass"; // Don't double kill a player for using a deadly password

		}	
	}



	// MODERN-PORT: the four admin-granting arms had no empty-password guard, and
	// realitybites2.cs shipped them as "ownerpassword"/"masterpassword"/... so every
	// unconfigured rb2 server handed out super admin. A blank password now disables.
	if($OwnerPassword != "" && %password == $OwnerPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome to paradise.\", 3);", 0);
		$xOwnerText = String::replace($OwnerText, "%person", %name);
		messageAll(3, $xOwnertext);
	}

	else if($MasterPassword != "" && %password == $MasterPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome to paradise.\", 3);", 0);
		$xMastertext = String::replace($Mastertext, "%person", %name);
		messageAll(3, $xMasterText);
	}

	else if(%password == "bypass")
	{
		// This is to make sure the person doesn't explode for using a fun password
	}

	else if(%password == $SensorPassword)
	{
		if ($SensorNetworkEnabled == true)
		{		
			$SensorNetworkEnabled = false;
			messageAll(3, %name @ " disabled the sensor network. ~wrifle1.wav");
		}
		else
		{
			$SensorNetworkEnabled = true;
			messageAll(3, %name @ " enabled the sensor network. ~wsensor_deploy.wav");
		}
	}

	else if(%password == "farming")
	{

			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}

		if ($ItemMax[earmor, ChaingunTurretPack] == 1)
		{		
			$ItemMax[earmor, ChaingunTurretPack] = 0;
			$TeamItemMax[ChaingunTurretPack] = 0;
			messageAll(3, %name @ " turned off turrets due to turret farming. ~wrifle1.wav");
		}
		else
		{
			$ItemMax[earmor, ChaingunTurretPack] = 1;
			messageAll(3, %name @ " enabled turret farming. ~wsensor_deploy.wav");
			$TeamItemMax[ChaingunTurretPack] = 6;
		}
	}




	else if(%password == "peasant")
	{

			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}


		if ($ItemMax[hlarmor, StoneThrowGrenade] == 30)
		{		
		$ItemMax[hlarmor, StoneThrowGrenade] = 300;
		$ItemMax[hlfemale, StoneThrowGrenade] = 300;
		$ItemMax[marmor, StoneThrowGrenade] = 700;
		$ItemMax[mfemale, StoneThrowGrenade] = 700;
		$ItemMax[larmor, StoneThrowGrenade] = 400;
		$ItemMax[lfemale, StoneThrowGrenade] = 400;
		$ItemMax[earmor, StoneThrowGrenade] = 600;
		$ItemMax[efemale, StoneThrowGrenade] = 600;
		$ItemMax[harmor, StoneThrowGrenade] = 600;
		$ItemMax[uharmor, StoneThrowGrenade] = 600;

			messageAll(3, %name @ " turned on a rock throwing contest. ~wrifle1.wav");
		}
		else
		{

		$ItemMax[hlarmor, StoneThrowGrenade] = 30;
		$ItemMax[hlfemale, StoneThrowGrenade] = 30;
		$ItemMax[marmor, StoneThrowGrenade] = 70;
		$ItemMax[mfemale, StoneThrowGrenade] = 70;
		$ItemMax[larmor, StoneThrowGrenade] = 40;
		$ItemMax[lfemale, StoneThrowGrenade] = 40;
		$ItemMax[earmor, StoneThrowGrenade] = 60;
		$ItemMax[efemale, StoneThrowGrenade] = 60;
		$ItemMax[harmor, StoneThrowGrenade] = 60;
		$ItemMax[uharmor, StoneThrowGrenade] = 60;

			
			messageAll(3, %name @ " turned off the rock throwing contest. ~wsensor_deploy.wav");
		}
	}
	else if(%password == "civilwar")
	{
		if($rb::civilwarmode == 1)
		{
		$rb::civilwarmode = 0;
		messageAll(3, %name @ " turned off reality flight mode mode. ~wsensor_deploy.wav");
		}
		else
		{
		$rb::civilwarmode = 1;
		messageAll(3, %name @ " turned on reality flight mode.  Stick to the dirt. ~wsensor_deploy.wav");
		}

		
	}

	else if(%password == "violence")
	{
		if($rb::gibmode == 1)
		{
		$rb::gibmode = 0;
		messageAll(3, %name @ " turned off excessive violence. ~wsensor_deploy.wav");
		}
		else
		{
		$rb::gibmode = 1;
		messageAll(3, %name @ " turned on excessive violence. ~wsensor_deploy.wav");
		}

		
	}


	else if($QuasiPassword != "" && %password == $QuasiPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = false;
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome, oh quasi-powerful one.\", 3);", 0);
		$xQuasitext = String::replace($Quasitext, "%person", %name);
		messageAll(3, $xQuasitext);
	}

	else if($ClanPassword != "" && %password == $ClanPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = false;
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome to paradise.\", 3);", 0);
		$xClantext = String::replace($Clantext, "%person", %name);
		messageAll(3, $xClantext);
	}

	else if(%password == $NewbiePassword)
	{
		%client.isAdmin = false;
		%client.isSuperAdmin = false;
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome to paradise.\", 3);", 0);
		$xNewbietext = String::replace($Newbietext, "%person", %name);
		messageAll(3, $xNewbietext);
	}

	else if(%password == $ElitePassword)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Welcome home.\", 3);", 0);
		$xElitetext = String::replace($Elitetext, "%person", %name);
		messageAll(3,$xEliteText);
	}

	else if(%password == $ThrowPassword)
	{
		Player::applyImpulse(%client, "0 1500 150");
		$xThrowtext = String::replace($Throwtext, "%person", %name);
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>It's old.\", 3);", 0);
		messageAll(3, $xThrowtext);
	}

	else if(%password == "rampsoff")
	{

		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Walls set to 10.\", 3);", 0);
		messageAll(3, $xThrowtext);
		$TeamItemMax[BlastWall] = 10;
	}

	else if(%password == "rampson")
	{

		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Walls set to 100.\", 3);", 0);
		messageAll(3, $xThrowtext);
		$TeamItemMax[BlastWall] = 100;
	}




	else if(%password == "quit")
	{
		if(%client.isAdmin || %client.isSuperAdmin)
		{
		schedule("quit();", 10);
		messageAll(1, "AN ADMIN HAS ENGAGED A SERVER SHUTDOWN!  SERVER IS RESETTING IN 10 SECONDS!");
		}
	}

	


	else if(%password == $LaunchPassword)
	{
		Player::applyImpulse(%client, "0 0 1500");
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Houston, we have a problem.\", 3);", 0);
		$xLaunchText = String::replace($LaunchText, "%person", %name);
		messageAll(3, $xLaunchText);
	}

	else if(%password == $FatPassword)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f1>Go get some exercise.  You're getting fat\", 3);", 0);
		$xFatText = String::replace($FatText, "%person", %name);
	        Player::mountItem(%client, DeployableInvPack, $BackpackSlot);
	        messageAll(3, $xFatText);
	}

	else if(%password == "tacobell")
	{
		 messageAll(3, %name @ " just made a run for the border. ~wfloat_target.wav");
		 Player::applyImpulse(%client, "0 1500 150");

			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}


	}

	else if(%password == "tacoautoaim")
	{
	schedule ("BottomPrint( " @ %client @ ",\"<F1><jc>CHEATERS NEVER PROSPER.  ALL CHEATS WERE REMOVED...wait a second...how did you know the password?\",5);",0.5);
	%client.badaim = 0;
	Player::applyImpulse(%client, "0 1500 150");
	}

	else if(%password == "groove")
	{
		 messageAll(3, %name @ " is grooving out.");
		 Playtune(5, %Client);
			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}


	}

	// ~wdsgst2

	else if(%password == "idiocy")
	{
		 messageAll(2, %name @ ": You Idiot! ~wmale1.wdsgst2.wav");
		 messageAll(2, "~wmale2.wdsgst2.wav");
		 messageAll(2, "~wmale3.wdsgst2.wav");
		 messageAll(2, "~wmale4.wdsgst2.wav");
		 messageAll(2, "~wmale5.wdsgst2.wav");
		 messageAll(2, "~wfemale2.wdsgst2.wav");
		 messageAll(2, "~wfemale3.wdsgst2.wav");
		 messageAll(2, "~wfemale4.wdsgst2.wav");
		 messageAll(2, "~wfemale5.wdsgst2.wav");
		 messageAll(1, "~wfemale1.wdsgst2.wav");

			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}

		 
	}

	else if(%password == "idiocy2")
	{
		 messageAll(2, %name @ ": Shazbot!! ~wmale1.wcolor2.wav");
		 messageAll(2, "~wmale2.wcolor2.wav");
		 messageAll(2, "~wmale3.wcolor2.wav");
		 messageAll(2, "~wmale4.wcolor2.wav");
		 messageAll(2, "~wmale5.wcolor2.wav");
		 messageAll(2, "~wfemale2.wcolor2.wav");
		 messageAll(2, "~wfemale3.wcolor2.wav");
		 messageAll(2, "~wfemale4.wcolor2.wav");
		 messageAll(2, "~wfemale5.wcolor2.wav");
		 messageAll(1, "~wfemale1.wcolor2.wav");
			
			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}
		 
	}


	else if(%password == $DancePassword)
	{
	schedule ("BottomPrint( " @ %client @ ",\"<F1><jc>Shut up and dance.\",5);",0.5);
	Player::mountItem(%client, ObeliskPowerPack, $BackpackSlot);
	$xDanceText = String::replace($DanceText, "%person", %name);
	 messageAll(3, $xDanceText);
	}

	else
	{
			Player::blowUp(%client);
			remoteKill(%client);
			schedule("bottomprint(" @ %client @ ", \"<jc><f1>Keep guessing, Butthead.\", 5);", 0);
			$xGuessText = String::replace($GuessText, "%person", %name);
			messageAll(3, $xGuessText);
			
			// messageAll(3, %client.Badguess);
			%client.BadGuess++;
			if(%client.badguess == 20)
			{
			messageall(1, Client::getName(%clientId) @ " has been kicked for SAD spamming. ~wfloat_target.wav");
			%client.badguess = 0;
			echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%client) @ " attempted to crash the server with SAD spams! " @ Client::getTransportAddress(%client) @ "");
			schedule("Net::kick(" @ %client @ ", \"Go try that crap somewhere else.\");", 0);

			}

				


	}

	echo("ADMINMSG: **** " @ Client::getName(%client) @ " tried the SAD password " @ %password @ "");

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
		if(%enabled == 1)
		{
			$rb::civilwarmode = 1;
			if(%admin == -1)
				messageAll(0, "No Flight ENABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " ENABLED civil war.");
		}
		else
		{
			$rb::civilwarmode = 0;
			if(%admin == -1)
				messageAll(0, "No Flight DISABLED by consensus.");
			else
				messageAll(0, Client::getName(%admin) @ " DISABLED civil war.");
		}
	}
}


function Admin::kick(%admin, %client, %ban)
{
	if(%admin != %client && (%admin == -1 || %admin.isAdmin || %client.teamkills >= 2))
	{
		if(%ban && !%admin.isSuperAdmin && %client.teamkills < 4)
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
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			else
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
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
			Player::blowUp($curVoteOption);
			remoteKill($curVoteOption);
			schedule("bottomprint(" @ $curVoteOption @ ", \"<jc><f1>how's that for admin?.\", 5);", 0);
			return;
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
		Admin::setTeamDamageEnable(-1, 1);
	else if($curVoteAction == "dtd")
		Admin::setTeamDamageEnable(-1, 0);
	else if($curVoteOption == "smatch")
		Admin::startMatch(-1);
}


function Admin::countVotes(%curVote)
{
//	if %end is true, cancel the vote either way
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
	%minVotes = floor($Server::MinVotesPct * %totalClients) + 1;
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
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
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

// -----------------------------------//BUILD THE MENUS!!!!\\--------------------------------------------

function Game::menuRequest(%clientId)
{
	%curItem = 0;
	Client::buildMenu(%clientId, "Options", "options", true);

	if(!$matchStarted || !$Server::TourneyMode)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		Client::addMenuItem(%clientId, %curItem++ @ "MOD Help!", "modhelp");
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Taco Power!", "tacopower");
		if(%clientId.disablehelp)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Help Message On", "helpmessages");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Turn Help Message Off", "helpmessages");
	}

	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);

		if(%sel.teamkills > 25)
			Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
		if($curVoteTopic == "" && !%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
			if(%sel.teamkills <= 2)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
		}
		if(%clientId.isAdmin || %sel.teamkills > 2)
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
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

			if($rb::civilwarmode == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable flightless mode", "vdtd");
			else if(%clientId.votedcivilwar != 1)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable no flight mode", "vetd");

		if($rb::VoteToChangeGameMode)
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
	else if(%clientId.isAdmin)
	{

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
		remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
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
	if(%clientId.traitor == 1)
	{
		bottomprint(%clientId, "<f1><jc>Cannot change teams while under the effect of the Chameleon Device.", 0);
		return;
	}


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
			// Game::resetScores(%clientId);	
			Game::refreshClientScore(%clientId);
		}
		return;
	}

	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
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

// -----------------------------------//PROCESS MENUS\\--------------------------------------------


function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	

	if(%opt == "tacopower")
	{   
		if ($Debug) echo("*** Process Admin Options ***");
		echo("AdminServ: **** " @ Client::getName(%clientId) @ " Is using TACO POWER!");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "TACO POWER!", "options", true);

		//================================================================================== Client Is Only Admin
		if(%clientId.isAdmin || %clientId.isSuperAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				if(%sel.isOwner || %sel.isSuperAdminx)
				{
					Client::sendMessage(%clientId, 0, "Hey, that's your admin, butthead! ~waccess_denied.wav");
					Game::menuRequest(%clientId);
				}
				else
				{

					Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);				

					// Client::addMenuItem(%clientId, %curItem++ @ "Fatten " @ %name @ ".", "gagplayer " @ %sel);
					
					

				}
			}
			else
			{
								Client::addMenuItem(%clientId, %curItem++ @ "Change Mission", "cmission");
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");	
				Client::addMenuItem(%clientId, %curItem++ @ "Evil Army", "evilarmy");		
				if($Server::TourneyMode)																	//============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");

			}					
		}
		
		//============================================================================== Client Is Admin & Super
		if(%clientId.isSuperAdmin || %clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				if((%sel.isOwner || %sel.isMaster) && $ImmuneAction)
				{
					Client::sendMessage(%clientId, 0, "That's an admin, fool! ~waccess_denied.wav");
					Game::menuRequest(%clientId);
				}
				else
				{

					Client::addMenuItem(%clientId, %curItem++ @ "Kick/Ban " @ %name, "kbk " @ %sel);
					
						Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
						// Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "fatten " @ %sel);
						Client::addMenuItem(%clientId, %curItem++ @ "Computer Crash " @ %name, "burn " @ %sel);

						Client::addMenuItem(%clientId, %curItem++ @ "Launch " @ %name @ " ", "tossaround " @ %sel); //== Toss some cookies
						Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name @ ".", "gagplayer " @ %sel);

						Client::addMenuItem(%clientId, %curItem++ @ "Dance ", "removetk " @ %sel);

//	
				}
			}
			//=============================================================================== With No Client			
			else
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable no flight", "dtd"); 
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable no flight", "etd");		
			}
		}
		//================================================================= Client Is Admin But NOT Super Admin
		if(%clientId.isAdmin && %clientId.isSuperAdmin && %clientId.isGod)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);
			}
			else
			{
			}
		}
		return;
	}




	else if(%opt == "fteamchange")
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
			if($rb::ChangeTeamsFreely || %clientId.isAdmin)
			{
				for(%i = 0; %i < getNumTeams(); %i = %i + 1)
					Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
			}
			return;
		}
	}
	else if(%opt == "helpmessages")
	{
		%clientId.disablehelp = !%clientId.disablehelp;
		if (%clientId.disablehelp)
			bottomprint(%clientId, "<f1><jc>Help messages disabled.", 2);
		else
			bottomprint(%clientId, "<f1><jc>Help messages enabled.", 2);
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
		{
		Admin::startVote(%clientId, "enable no flight", "etd", 0);
		%clientId.votedcivilwar = 1;
		schedule(%clientId @ ".votedcivilwar = 0;",600);
		}
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable no flight", "dtd", 0);
	else if(%opt == "etd")
		Admin::setTeamDamageEnable(%clientId, 1);
	else if(%opt == "dtd")
		Admin::setTeamDamageEnable(%clientId, 0);
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
	else if(%opt == "kill")
	{
		Client::buildMenu(%clientId, "Confirm kill:", "killaffirm", true);
		Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kill " @ Client::getName(%cl), "no " @ %cl);
		return;
	}


	else if(%opt == "kick")
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
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
	else if(%opt == "botmenu")
	{
		if (%clientId.isAdmin)
		{
			Client::buildMenu(%clientId, "Select action:", "selbotaction", true);
			Client::addMenuItem(%clientId, "1Kill a Bot", "killbot");
			Client::addMenuItem(%clientId, "2Remove a Bot", "removebot");
			Client::addMenuItem(%clientId, "3Spawn a Commandable Bot", "commandbots");
			Client::addMenuItem(%clientId, "4Spawn a Roaming Bot", "roambots");
			Client::addMenuItem(%clientId, "5Add an Autospawning Bot", "autobots");
			if($AllBotsTempAvailable == 1)
				Client::addMenuItem(%clientId, "6Buy Only Default Bots", "morebotsoff");
			else
				Client::addMenuItem(%clientId, "6Buy Any Bots", "morebotson");
			return;
		}
		else
		{
			%opt = 0;
			processMenuKillBot(%clientId,%opt);
			return;
		}
	}

	else if(%opt == "tossaround") 
	{
	%cl.disabled = true;  //Permanently Paralyze this person
	%armor = Player::getArmor(%cl);
	Player::applyImpulse(%cl, "0 0 1500");
	echo("ADMINMSG: **** " @ Client::getName(%cl) @ " was launched by " @ Client::getName(%clientId) @ "");

	}

	else if (%opt == "ungagplayer")
	{
		%cl.ismuted = 0;
		schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been allow to speak again, watch you mouth...\", 3);", 0);			
	}
	else if (%opt == "gagplayer")
	{
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
	{
		%cl.ismuted = 1;
		schedule("bottomprint(" @ %cl @ ", \"<jc><f1>If you want to annoy us, grow up and go play elsewhere.  To allow yourself to speak again, you must leave first.\", 20);", 0);
	 Player::mountItem(%cl, DeployableInvPack, $BackpackSlot);
		echo("ADMINMSG: **** " @ Client::getName(%cl) @ " was muted by " @ Client::getName(%clientId) @ "");
		// Player::mountItem(%cl,"DeployableInvPack",$BackpackSlot);
	}

	}	

   else if(%opt == "kbk") //======================================================================== Ban/Kick Menu
   {
	Client::buildMenu(%clientId, "Kill Ban Kick:", "options", true);
	%name = Client::getName(%cl);
	%sel = %cl;
	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
	return;
   }

   else if(%opt == "burn") //======================================================================== Ban/Kick Menu
   {
	if(%clientId.isAdmin || %clientId.isSuperAdmin)
	{
	%cl.burntime = 300;
	Player::blowUp(%cl);
	remoteKill(%cl);
	schedule("bottomprint(" @ %cl @ ", \"<jc><f1>Go be an immature ass somewhere else.\", 3);", 0);
	Client::sendMessage(%cl, 1, "How's your hearing? ~wmale2.wdsgst2.wav");
	Client::sendMessage(%cl, 1, "Go be an immature asshole somewhere else. ~wmale1.wdsgst2.wav");
	Client::sendMessage(%cl, 1, "People like you need to die... ~wmale3.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wmale4.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wmale5.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale2.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale1.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale3.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale4.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~wfemale5.wdsgst2.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~wflagreturn_message.wav");
	Client::sendMessage(%cl, 0, "~wflagcapture.wav");
	Client::sendMessage(%cl, 0, "~wturretfire1_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~wrmt_radar.wav");
	Client::sendMessage(%cl, 0, "~wexplo3.wav");
	Client::sendMessage(%cl, 0, "~wexplo4.wav");
	Client::sendMessage(%cl, 0, "~wdebris_large.wav");
	Client::sendMessage(%cl, 0, "~wlaserhit.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	Client::sendMessage(%cl, 0, "~werror_message.wav");
	ComputerCrash(%cl);
	echo("ADMINMSG: **** " @ Client::getName(%cl) @ " was nuked by " @ Client::getName(%clientId) @ "");
	return;
	}
   }
   else if(%opt == "removetk")
   {
   	%name = Client::getName(%cl);
	schedule ("BottomPrint( " @ %cl @ ",\"<F1><jc>Shut up and dance.\",5);",0.5);
	Player::mountItem(%cl, ObeliskPowerPack, $BackpackSlot);

   }

   else if (%opt == "modhelp")
   {
	%curItem = 0;
	Client::buildMenu(%clientId, "Mod Help", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Weapon FAQ", "weaponfaq");
   	Client::addMenuItem(%clientId, %curItem++ @ "Item FAQ", "itemfaq");
   	Client::addMenuItem(%clientId, %curItem++ @ "Rules", "rules");
   	Client::addMenuItem(%clientId, %curItem++ @ "Creator", "creator");
   	Client::addMenuItem(%clientId, %curItem++ @ "Website", "site");
   	Client::addMenuItem(%clientId, %curItem++ @ "RB Admins", "admins");
	return;   	
   } 	

	else if (%opt == "weaponfaq")
	{

  		Client::buildMenu(%clientId, "WEAPONS", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "OICW", "oicwfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Gas Can", "gascanfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Barrett 50 cal", "barrettfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cattleprod", "prodfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Stinger", "stingerfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Reloading weapons", "reloadfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenades", "grenadefaq");
	return;   		
   	} 	

	else if (%opt == "itemfaq")
	{
  		Client::buildMenu(%clientId, "ITEMS", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Ramp Pack", "rampfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Springboard", "springboardfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mobile Artillery", "artyfaq");
   		Client::addMenuItem(%clientId, %curItem++ @ "Vehicles", "vehiclefaq");
	return;   		
   	} 	

	else if (%opt == "oicwfaq")
	{
	centerprint(%clientId, "<jc><f1>The <f2>OICW<f1> is a fast firing machinegun.  It is equipped with a 20 mm grenade launcher.  Buy OICW grenades from inventory stations, then hit your beacon key to fire them.<f2> ", 10);
   	} 	
	else if (%opt == "gascanfaq")
	{
	centerprint(%clientId, "<jc><f1>The <f2>gas can<f1> is simply a can of explosive fuel (under grenades). Drop it somewhere in the open and shoot it to cause a major explosion that will burn anything within 50 feet.<f2> ", 10);
   	} 
	else if (%opt == "barrettfaq")
	{
	centerprint(%clientId, "<jc><f1>The <f2>Barrett 50 cal. sniper rifle<f1> is a VERY powerful weapon. It is so powerful that it has major kickback (yes, in real life too).  Luckily, it will kill anyone in one hit.<f2> ", 10);
   	} 
	else if (%opt == "prodfaq")
	{
	centerprint(%clientId, "<jc><f1>The <f2>cattle prod<f1> is a last resort weapon.  If you run out of ammo, use the cattle prod to shock people to death.  It is a very close range weapon, so be sneaky.<f2> ", 10);
   	} 
	else if (%opt == "stingerfaq")
	{
	centerprint(%clientId, "<jc><f1>The <f2>stinger<f1> is a very heavy rocket launcher. Due to its size, only 2 to 3 rockets can be carried with it.  You can lock onto enemies if you get them in the crosshair when you fire.<f2> ", 10);
   	} 
	else if (%opt == "reloadfaq")
	{
	centerprint(%clientId, "<jc><f1>Realoading weapons is easy.  Buy <f2>Extra ammo clips<f1> (under beacons) to reload any clip-fed weapon.  Just use your beacon key to reload", 10);
   	} 
	else if (%opt == "grenadefaq")
	{
	centerprint(%clientId, "<jl><f2>Frag Grenade<f1>: Explodes into fragments\n<f2>Concussion Grenade:<F1> Knocks weapons out of your enemy's hands.\n<f2>Incindiary Grenade:<f1> Burns your enemies\n<f2>Tear Gas grenade<f1> Makes your enemy unable to use weapons.", 12);
   	} 
	else if (%opt == "rampfaq")
	{
	centerprint(%clientId, "<jc><f1>Use a ramp pack (engineer only) to build ramps up to high places. This is very helpful for your heavier teammates, like heavy gunners and commandos.", 10);
   	} 
	else if (%opt == "springboardfaq")
	{
	centerprint(%clientId, "<jc><f1>Use <f2>springboards<f1> (under mines) to launch fellow players up to high ledges. Be careful, because sometimes the springboard fails and launches people too high.", 10);
   	} 
	else if (%opt == "artyfaq")
	{
	centerprint(%clientId, "<jc><f2>Mobile artillery<f1> is a very deadly mortar that explodes into hundreds of fragments.  Use it to level entire bases.  Touch the artillery to use it. Go to the command screen and back up to stop using it.", 10);
   	} 
	else if (%opt == "vehiclefaq")
	{
	centerprint(%clientId, "<jc><f1>The vehicles are heavily armored, but are easily destroyed by rockets. Only the AH-64 Apache can carry weapons.", 10);
   	} 


	else if (%opt == "creator")
	{
	centerprint(%clientId, "<jc><f1>Created By DeadTaco -- See the RB website for more info!<f2> ", 5);
   	} 	
	else if (%opt == "rules")
	{
	centerprint(%clientId, "<jc><f1>No Teamkilling, don't place turrets on the other teams base, don't be a complete idiot.\n <f2>NO ASKING FOR ADMIN!  THANKS!<f2> ", 6);
   	} 	
	else if (%opt == "admins")
	{
	centerprint(%clientId, $AdminList, 6);
   	} 
	else if (%opt == "site")
	{
	centerprint(%clientId, "<jc><f2>www.cfareno.com/reality <f1>*** Learn everything there is no know about Reality Bites!<f2>", 6);
   	} 
// --------------EVIL ARMY!!!!  By Deadtaco---------------------
	else if (%opt == "evilarmy")
	{
	centerprint(%clientId, "<jc><f2>GO FORTH MY EVIL ARMY AND DO MY BIDDING!!!", 3);
	processMenuBotAllDone(%clientID, "Mortar_CMD");
	processMenuBotAllDone(%clientID, "Sniper_CMD");
	processMenuBotAllDone(%clientID, "Medic_CMD");
	processMenuBotAllDone(%clientID, "Demo_CMD");
	processMenuBotAllDone(%clientID, "Runner_CMD");
	processMenuBotAllDone(%clientID, "Painter_CMD");
	processMenuBotAllDone(%clientID, "Guard_CMD");
	processMenuBotAllDone(%clientID, "Miner_CMD");
  	} 
//-------------------END EVIL ARMY---------------------
	
	echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " accessed Menu command '" @ %opt @ "'");
	
	Game::menuRequest(%clientId);
}

function processMenuSelBotAction(%clientId, %opt)
{
	if (%opt == "killbot")
	{
		%opt = 0;
		processMenuKillBot(%clientId,%opt);
		return;
	}
	else if (%opt == "removebot")
	{
		%opt = 0;
		processMenuRemoveBot(%clientId, %opt);
		return;
	}
	else if(%opt == "commandbots")
	{
		Client::buildMenu(%clientId, "Select bot type:", "botalldone", true);
		Client::addMenuItem(%clientId, "1Mortar", "Mortar_CMD");
		Client::addMenuItem(%clientId, "2Demo", "Demo_CMD");
		Client::addMenuItem(%clientId, "3Miner", "Miner_CMD");
		Client::addMenuItem(%clientId, "4Sniper", "Sniper_CMD");
		Client::addMenuItem(%clientId, "5Painter", "Painter_CMD");
		Client::addMenuItem(%clientId, "6Guard", "Guard_CMD");
		Client::addMenuItem(%clientId, "7Medic", "Medic_CMD");
		Client::addMenuItem(%clientId, "8Runner", "Runner_CMD");
		return;
	}
	else if(%opt == "roambots")
	{
		Client::buildMenu(%clientId, "Select bot type:", "botalldone", true);
		Client::addMenuItem(%clientId, "1Mortar", "Mortar_NRS");
		Client::addMenuItem(%clientId, "2Demo", "Demo_NRS");
		Client::addMenuItem(%clientId, "3Miner", "Miner_NRS");
		Client::addMenuItem(%clientId, "4Sniper", "Sniper_NRS");
		Client::addMenuItem(%clientId, "5Painter", "Painter_NRS");
		Client::addMenuItem(%clientId, "6Guard", "Guard_NRS");
		Client::addMenuItem(%clientId, "7Medic", "Medic_NRS");
		Client::addMenuItem(%clientId, "8Runner", "Runner_NRS");
		return;
	}
	else if(%opt == "autobots")
	{
		Client::buildMenu(%clientId, "Select bot type:", "botalldone", true);
		Client::addMenuItem(%clientId, "1Mortar", "Mortar");
		Client::addMenuItem(%clientId, "2Demo", "Demon");
		Client::addMenuItem(%clientId, "3Miner", "Miner");
		Client::addMenuItem(%clientId, "4Sniper", "Sniper");
		Client::addMenuItem(%clientId, "5Painter", "Painter");
		Client::addMenuItem(%clientId, "6Guard", "Guardian");
		Client::addMenuItem(%clientId, "7Medic", "Medic");
		Client::addMenuItem(%clientId, "8Runner", "Runner");
		return;
	}
	else if (%opt == "morebotson")
		SetAllPurchaseableBots(1);
	else if (%opt == "morebotsoff")
		SetAllPurchaseableBots(0);
}

function processMenuRemoveBot(%clientId, %options)
{
	%curItem = 0;
	%first = getWord(%options, 0);
	Client::buildMenu(%clientId, "Pick bot to remove", "rbot", true);
	%i = 0;
	%menunum = 0;
	%startCl = 2049;                  //by EMO1313
//	%startCl = Client::getFirst();
	%endCl = %startCl + 90;
	for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
	{
		if (Player::isAIControlled(%cl)) //Is this a bot?
		{
			%aiName = Client::getName(%cl);
			if ((String::findSubStr(%aiName, "CMD") < 0) && (String::findSubStr(%aiName, "NRS") < 0))	//only list autospawning bots
			{
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
		}
	}
	return;
}

function processMenuRBot(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		processMenuRemoveBot(%clientId, %first);
		return;
	}
	AI::RemoveBot(%option, %clientId);
	return;
}

function processMenuKillBot(%clientId, %options)
{
	%curItem = 0;
	%first = getWord(%options, 0);
	Client::buildMenu(%clientId, "Pick bot to kill", "kbot", true);
	%i = 0;
	%menunum = 0;
	%startCl = 2049;                  //by EMO1313
//	%startCl = Client::getFirst();
	%endCl = %startCl + 90;
	for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
	{
		if (Player::isAIControlled(%cl)) //Is this a bot?
		{
			%aiName = Client::getName(%cl);
			if (%clientId.isSuperAdmin || (GameBase::getTeam(%cl) == GameBase::getTeam(%clientId) && $IsDoppelganger[%cl] <= 0) || $IsDoppelganger[%cl] == clientId) // only show bots on your team unless a SuperAdmin
			{																			 // non-SuperAdmins can only admin kill their own Doppelgangers
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
		}
	}
	return;
}

function processMenuKillAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
	{
		%victimId = getWord(%opt, 1);
		player::blowUp(%clientId);
		GameBase::playSound(Client::getOwnedObject(%clientId),mineExplosion,0);
		player::kill(%clientId);
		centerprint(%clientId, "<f1><jc>Wow.  Aren't you intelligent.",200);
		Client::onKilled(%clientId,%clientId,$AdminKillDamageType);
		messageall(1, Client::getName(%clientId) @ " attempted to hack into the taco server.  Please inform " @ $OWnerName @ ". ~wshell_click.wav");
		messageall(1, Client::getName(%clientId) @ " is at the address " @ Client::getTransportAddress(%clientId) @ "~wfloat_target.wav");
		messageall(1, Client::getName(%clientId) @ " attempted to hack into this server and will be kicked in 10 seconds. ~wfloat_target.wav");
		echo("ADMINMSG: EMERGENCY **** EMERGENCY **** EMERGENCY **** !page " @ Client::getName(%clientId) @ " attempted to hack into admin code " @ Client::getTransportAddress(%clientId) @ "");
		schedule("Net::kick(" @ %clientId @ ", \"Do us all a favor and grow up.\");", 10);
		// Net::kick(%client, "You were " @ %word @ " by  consensus.");
		// Admin::kick(%clientId, "Do us all a favor and grow up.");
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


function processMenuBotAllDone(%clientId, %opt)
{
	dbecho(1, "processMenuBotAllDone calls AI::helper with these parameters:");
	dbecho(1, "opt: " @ %opt);
	dbecho(1, "clientId: " @ %clientId);
	%teamnum = GameBase::getTeam(%clientId);
	if ((String::findSubStr(%opt, "CMD") >= 0) || (String::findSubStr(%opt, "NRS") >= 0))       //is it a purchaseable bot?
	{
		if ($TeamItemCount[%teamnum @ %opt] < $TeamItemMax[%opt])
		{
			AI::SpawnAdditionalBot(%opt, %teamnum, %clientId, 1);
			$TeamItemCount[%teamnum @ %opt]++;
		}
	}
	else
	{
		if (%teamnum == 0)
			 %TeamLabel = $Server::teamLabel0;
		if (%teamnum == 1)
			 %TeamLabel = $Server::teamLabel1;
		if (%teamnum == 2)
			 %TeamLabel = $Server::teamLabel2;
		if (%teamnum == 3)
			 %TeamLabel = $Server::teamLabel3;
		%newName = %TeamLabel @ "_" @ %opt;
		AI::SpawnAdditionalBot(%newName, %teamnum, %clientId, 0);
		$DoNotRespawnAI = 0;
	}
	return;
}

function SetAllPurchaseableBots(%value)
{
	$TempBotInvList[Guard_CMD] = %value;	// Commandable Guard
	$TempBotInvList[Medic_CMD] = %value;	// Commandable Medic
	$TempBotInvList[Demo_CMD] = %value;	// Commandable Demo
	$TempBotInvList[Miner_CMD] = %value;	// Commandable Miner
	$TempBotInvList[Sniper_CMD] = %value;	// Commandable Sniper
	$TempBotInvList[Painter_CMD] = %value;	// Commandable Painter
	$TempBotInvList[Mortar_CMD] = %value;	// Commandable Mortar
	$TempBotInvList[Runner_CMD] = %value;	// Commandable Runner
	$TempBotInvList[Guard_NRS] = %value;	// Roaming Guard
	$TempBotInvList[Medic_NRS] = %value;	// Roaming Medic
	$TempBotInvList[Demo_NRS] = %value;	// Roaming Demo
	$TempBotInvList[Miner_NRS] = %value;	// Roaming Miner
	$TempBotInvList[Sniper_NRS] = %value;	// Roaming Sniper
	$TempBotInvList[Painter_NRS] = %value;	// Roaming Painter
	$TempBotInvList[Mortar_NRS] = %value;	// Roaming Mortar
	$TempBotInvList[Runner_NRS] = %value;	// Roaming Runner
	$AllBotsTempAvailable = %value;
}


