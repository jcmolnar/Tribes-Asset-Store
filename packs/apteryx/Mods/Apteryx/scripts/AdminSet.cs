// part 3 of admin
// admin set.

//=============================
// process changes in a less painfull way.. -plasmatic

function ServerSwitches(%clientId,%option,%action)
{
	if (%action)
	{
	messageAll(0, Client::getName(%clientId) @ " ENABLED " @ %option @"~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " ENABLED " @ %option, 3);
	logAdminAction(%clientId, " ENABLED " @ %option);
	}	
	else
	{
	messageAll(0, Client::getName(%clientId) @ " DISABLED " @ %option @"~wCapturedTower.wav");	
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " DISABLED " @ %option, 3);
	logAdminAction(%clientId, " DISABLED " @ %option);	
	}
 if (%option == "Fair Teams"){if(%action) $Annihilation::FairTeams = 1;else $Annihilation::FairTeams = 0;}
 if (%option == "turret points"){if(%action) $TurretPoints = 1;else $TurretPoints = 0;}
 if (%option == "deployable turrets"){if(%action) $NoDeployableTurret = 0;else $NoDeployableTurret = 1;}
 if (%option == "map turrets"){if(%action) $NoMapTurrets = 0;else $NoMapTurrets = 1;}
 if (%option == "Inventories"){if(%action) $NoInv = 0;else $NoInv = 1;}
 if (%option == "Vehicle Stations"){if(%action) $NoVehicle = 0;else $NoVehicle = 1;}
 if (%option == "Generators"){if(%action) $NoGenerator = 0;else $NoGenerator = 1;}
 if (%option == "Flag captures"){if(%action) $NoFlagCaps = 0;else $NoFlagCaps = 1;}
 if (%option == "Voting"){if(%action) $NoVote = 0;else $NoVote = 1;}	
 if (%option == "Voting Admin"){if(%action) $Annihilation::VoteAdmin = 1;else $Annihilation::VoteAdmin = 0;}
 if (%option == "Voting Builder"){if(%action) $Annihilation::VoteBuild = 1;else $Annihilation::VoteBuild = 0;}
 if (%option == "Observer Alert"){if(%action) $Annihilation::obsAlert = 1;else $Annihilation::obsAlert = 0;}
 if (%option == "personal skins"){if(%action) $Annihilation::UsePersonalSkin = 1;else $Annihilation::UsePersonalSkin = 0;}

 if (%option == "Quick Inventories"){if(%action) $Annihilation::QuickInv = 1;else $Annihilation::QuickInv = 0;}
 if (%option == "Zappy Inventories"){if(%action) $Annihilation::Zappy = 1;else $Annihilation::Zappy = 0;}
 if (%option == "Extended Inventories"){if(%action) $Annihilation::ExtendedInvs = 1;else $Annihilation::ExtendedInvs = 0;}
}

//===================================


function Admin::setTeamDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Server::TeamDamageScale = 1;
			if(%admin == -1)
			{
				messageAll(0, "Team damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage ENABLED by consensus.");
			}
			else
			{	
				messageAll(0, Client::getName(%admin) @ " ENABLED team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED team damage.", 3);
				logAdminAction(%admin, "Team damage ENABLED.");
			}
		}
		else
		{
			$Server::TeamDamageScale = 0;
			if(%admin == -1)
			{
				messageAll(0, "Team damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED Team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Team damage.", 3);
				logAdminAction(%admin, "Team damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Annihilation::SafeBase = 0;
			if(%admin == -1)
			{
				messageAll(0, "BASE damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>BASE damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED BASE damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED BASE damage.", 3);
				logAdminAction(%admin, "BASE damage ENABLED.");
			}
		}
		else
		{
			$Annihilation::SafeBase = 1;
			if(%admin == -1)
			{
				messageAll(0, "Base damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED Base damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Base damage.", 3);
				logAdminAction(%admin, "Base damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseHealingEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Annihilation::BaseHeal = 1;
			AutoRepair(0.003);
			if(%admin == -1)
			{
				messageAll(0, "Base healing ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing ENABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED base healing.", 3);
				logAdminAction(%admin, "base healing ENABLED.");
			}
		}
		else
		{
			$Annihilation::BaseHeal = 0;
			AutoRepair(-0.003);
			if(%admin == -1)
			{
				messageAll(0, "Base healing DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED base healing.", 3);
				logAdminAction(%admin, "Base healing DISABLED.");
			}
		}
	}
}

function Admin::setPlayerDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$NoPlayerDamage = 0;
			if(%admin == -1)
			{
				messageAll(0, "Player damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Player damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Player damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED Player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED Player damage.", 3);
				logAdminAction(%admin, "player damage ENABLED.");
			}
		}
		else
		{
			$NoPlayerDamage = 1;
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED player damage.", 3);
				logAdminAction(%admin, "player damage DISABLED.");
			}

		}
	}
}

function Admin::setAreaDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Annihilation::OutOfArea = "";
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED.");
			}				
		}
		else
		{
			$Annihilation::OutOfArea = 1;
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage DISABLED.");
			}
		}
	}
}
function Admin::setBuild(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Build = 1;
			if(%admin == -1)
			{
				messageAll(0, "Builder ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Builder ENABLED by consensus.", 3);
				logAdminAction(%admin, "builder ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED Builder.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED Builder.", 3);
				logAdminAction(%admin, " ENABLED builder.");
			}
		}
		else
		{
			$Build = 0;
 			if(%admin == -1)
 			{
				messageAll(0, "Builder DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Builder DISABLED by consensus.", 3);
				logAdminAction(%admin, "builder ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED Builder.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Builder.", 3);
				logAdminAction(%admin, " DISABLED builder.");
			}
		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.~wCapturedTower.wav");
		else
		{	
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " switched to free for all mode.", 3);
			logAdminAction(%clientId, "switched to free for all mode.");
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
			messageAll(0, "Server switched to Tournament Mode.~wCapturedTower.wav");
		else
		{
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " Server switched to Tournament Mode.", 3);
			logAdminAction(%clientId, "Server switched to Tournament Mode.");
		}
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}





//=======================================
// map changes


function randommap(%clientId)
{
	if(%clientId)
		messageAll(0,Client::getName(%clientId)@ " picked a random mission.~wCapturedTower.wav");
	else
		messageAll(0, "Starting a random mission");
	echo("GAME: Starting a random mission.");
	$timeLimitReached = true;
	Server::nextMission(false,true);
}

function nextmap(%clientId)
{
	if(%clientId)
		messageAll(0,Client::getName(%clientId)@ " started the next mission.~wCapturedTower.wav");
	else
		messageAll(0, "Starting next Mission");
	echo("GAME: Starting next map.");
	$timeLimitReached = true;
	Server::nextMission();
}

function replaymap(%clientId)
{
	if(%clientId)
		messageAll(0,Client::getName(%clientId)@ " restarted the mission.~wCapturedTower.wav");
	else
		messageAll(0, "Restarting Mission");
	echo("GAME: restarting map.");
	$timeLimitReached = true;
	Server::nextMission(true);
}
//=================================================
