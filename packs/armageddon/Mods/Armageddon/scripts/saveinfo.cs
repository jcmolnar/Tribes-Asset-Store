// This has been coded by |*|w00|*|Grey. I hold conceptual copyrights. I realise that I cannot
// enforce this so I choose to ask for credit if you use any of my scripts. Thank you, and ENJOY


function Retrieve(%clientId)
{
	%name2 = Client::getName(%clientId);
	%name = Client::getName(%clientId);
	%name = hashname(%name);
	
	if(%clientId.isregistered)
	{
		LoadBackup(%clientId);
		%playerId = %clientId;
		echo($adminbotname @": Retrieving up Data for ->> "@%name2@" <<-");
		File::delete("config\\" @ %name @ ".cs");
		%clientId.TotalKills = %clientId.TotalKillsR;
		%clientId.TotalDeaths = %clientId.TotalDeathsR;
		%clientId.TotalScore = %clientId.TotalScoreR;
		SaveCharacter(%clientId);
		client::sendMessage(%clientId,3, $adminbotname@": Your Account has been replaced back to last known status. ~wteleport2.wav");
	}    		
	else if(!%clientId.isregistered)
	{
	client::sendMessage(%clientId,3, $adminbotname@": Your name has not been registered so you cannot retrieve. Type !register to register. ~waccess_denied.wav");
	}
}

function Renew(%clientId)
{
	%name2 = Client::getName(%clientId);
	%name = Client::getName(%clientId);
	%name = hashname(%name);

	if(%clientId.isregistered)
	{
		%playerId = %clientId;
		%clientId.TotalKills = %clientId.TotalKills - %playerId.scoreKills;
		%clientId.TotalDeaths = %clientId.TotalDeaths - %playerId.scoreDeaths;
		%clientId.TotalScore = %clientId.TotalScore - %playerId.score;
		BackupCharacter(%clientId);
		echo($adminbotname @": Backing up Data for ->> "@%name2@" <<-");
		File::delete("config\\" @ %name @ ".cs");
		%clientId.TotalKills = (0 - %playerId.scoreKills) - %playerId.scoreKills ;
		%clientId.TotalDeaths = (0 - %playerId.scoreDeaths) - %playerId.scoreDeaths;
		%clientId.TotalScore = (0 - %playerId.score) - %playerId.score;
		SaveCharacter(%clientId);
		client::sendMessage(%clientId,3, $adminbotname@": You have a clean slate. Your Account has been renewed. ~wteleport2.wav");
	}
	else if(!%clientId.isregistered)
	{
	
		client::sendMessage(%clientId,3, $adminbotname@": Your name has not been registered so you cannot renew. Type !register to register. ~waccess_denied.wav");
	}
}
function DeleteAcc(%clientId)
{
	%name = Client::getName(%clientId);
	%name = hashname(%name);
	%name2 = "GreyBOTBackup_" @ VRBot::hashname(Client::getName(%clientId)); // PORT: was the hash of the client NUMBER

	if(%clientId.isregistered)
	{
		$botsaved = $botsaved - 1;
		echo("Decreasing Saved Register Clients");
		%playerId = %clientId;
		File::delete("config\\" @ %name @ ".cs");
		File::delete("config\\" @ %name2 @ ".cs");
		%clientId.TotalKills = 0 - %playerId.scoreKills;
		%clientId.TotalDeaths = 0 - %playerId.scoreDeaths;
		%clientId.TotalScore = 0 - %playerId.score;
		%clientId.isregistered = false;
		echo("Account Removed");
		client::sendMessage(%clientId,3, $adminbotname@": Your Account has been removed. ~wshieldhit.wav");
	}
	else if(!%clientId.isregistered)
	{
	
		client::sendMessage(%clientId,3, $adminbotname@": Your name has not been registered so you cannot delete your account. Type !register to register. ~waccess_denied.wav");
	}
}
function DeletePassAcc(%clientId)
{
	%name = Client::getName(%clientId);
	%name = hashname(%name);

	if(%clientId.isregistered)
	{
		%playerId = %clientId;
		File::delete("config\\" @ %name @ ".cs");
		%clientId.TotalPasstry = 0;
		%clientId.TotalConnections = 0;
		
		echo("Password Attempts Removed");
		client::sendMessage(%clientId,3, $adminbotname@": Your Password Attempts have been wiped. ~wshieldhit.wav");
	}
	else if(!%clientId.isregistered)
	{
	
		client::sendMessage(%clientId,3, $adminbotname@": Your name has not been registered so your attempts have not been recorded. ~waccess_denied.wav");
	}
}
function updateconnectionlog(%clientId)
{
	echo("UPDATING CONNECTION LOG SAVED CLIENT CHARACTERS!");
	if($botsaved == "" && !%clientId.isregistered)
		{
			echo("New setup");
			$botsaved  = 0;
		}
		else if(%clientId.isregistered)
		{
			echo("Not Updating Log as Player is Already registered");
		}
		else 
		{
			echo("Incrementing Saved Characters");
			$botsaved  = $botsaved  + 1;
			File::delete("config\\botinfo.cs");
			export("$botsaved", "config\\botinfo.cs" , true);
		}
}
function LoadBackup(%clientId)
{
	%clname = Client::getName(%clientId);
	%name = Client::getName(%clientId);
	%name = VRBot::hashname(%name);
	%filename = "GreyBOTBackup_" @ %name @ ".cs"; // PORT: prefix added


	if(isFile("config\\" @ %filename))
	{
		//=================================================================== clear $funk::var's
		
		for(%i = 1; %i <= 30; %i++)
			$funk::var[%name, 0, %i] = "";
		for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			$funk::var[%name, 2, %i] = "";
		$funk::var[%name, 1] = "";

		//====================================================================== load character
	      echo("Loading Backup Info for player... " @ %name @ " ...");
		exec(%filename);
		if ($funk::var[%name , password] == $Client::info[%clientId, 5])
		{
			
			%clientId.TotalKillsR = $funk::var[%name, 0, 7];		
			%clientId.TotalDeathsR = $funk::var[%name, 0, 8];
			%clientId.TotalScoreR = $funk::var[%name, 0, 9];	
			%clientId.isregistered = $funk::var[%name, 0, 10];
		}
		else
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your scores.\", 5);", 5);
			for(%i = 1; %i <= 30; %i++)
				$funk::var[%name, 0, %i] = "";
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
				$funk::var[%name, 2, %i] = "";
			$funk::var[%name, 1] = "";
			return;
		}
			
	}
	else
	{
	echo("No File in Database");
	}
	if($funk::var[%name, 0, 10] == "true")
	{
		echo("GreyBOT: "@%clname@" Is Known and Registered");
	}
   	Game::refreshClientScore(%clientId);
}


function BackupCharacter(%clientId)
{
	if (gamebase::getteam(%clientId) < 0 || gamebase::getteam(%clientId) > 8)
		return;

	if ($Client::info[%clientId, 5] == "")
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your scores.\", 5);", 5);	
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disconnect, enter a password that you would like to use in the OtherInfo field.\", 5);", 10);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Reconnect and you will be able to save your scores.\", 5);", 15);
		%clientId.isregistered = "false";
		echo("Not Registered");
		return;
	}
	else
	{
		%name = Client::getName(%clientId);
		%name = VRBot::hashname(%name);

		for(%i = 1; %i <= 30; %i++)
			$funk::var["[\"" @ %name @ "\", 0, " @ %i @ "]"] = "";

		if(%clientId.dead != "1" || %clientId.observerMode == "" || client::getownedobject(%clientId) != "-1")
		{
			for(%i = 1; $funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] != ""; %i++)
				$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";

			$funk::var["[\"" @ %name @ "\", 1]"] = "";
		}

		echo("Saving player " @ %name @ "...");
		

		%playerId = %clientId;
		%clientId.TotalKills = %clientId.TotalKills;
		%clientId.TotalDeaths = %clientId.TotalDeaths;
		%clientId.TotalScore = %clientId.TotalScore;
		%clientId.isregistered = true;
		
		$funk::var["[\"" @ %name @ "\", 0, 7]"] = %clientId.TotalKills;
		$funk::var["[\"" @ %name @ "\", 0, 8]"] = %clientId.TotalDeaths;
		$funk::var["[\"" @ %name @ "\", 0, 9]"] = %clientId.TotalScore;
		$funk::var["[\"" @ %name @ "\", 0, 10]"] = %clientId.isregistered;
		

		$funk::var["[\"" @ %name @ "\", password]"] = $Client::info[%clientId, 5];
		

	      echo("Deleting old file before backup for " @ %clientId @ "...");
		File::delete("config\\GreyBOTBackup_" @ %name @ ".cs");
		export("funk::var[\"" @ %name @ "\",*", "config\\GreyBOTBackup_" @ %name @ ".cs", false);
	      echo("Backup complete for " @ %name @ ".");
		
	}
}

function SaveCharacter(%clientId, %bot)
{
	if (gamebase::getteam(%clientId) < 0 || gamebase::getteam(%clientId) > 8)
		return;

	if ($Client::info[%clientId, 5] == "")
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your scores.\", 5);", 5);	
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disconnect, enter a password that you would like to use in the OtherInfo field.\", 5);", 10);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Reconnect and you will be able to save your scores.\", 5);", 15);
		%clientId.isregistered = "false";
		echo("Not Registered");
		return;
	}
	else
	{
		updateconnectionlog(%clientId);
		%name = Client::getName(%clientId);
		%name = hashname(%name);

		for(%i = 1; %i <= 30; %i++)
			$funk::var["[\"" @ %name @ "\", 0, " @ %i @ "]"] = "";

		if(%clientId.dead != "1" || %clientId.observerMode == "" || client::getownedobject(%clientId) != "-1")
		{
			for(%i = 1; $funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] != ""; %i++)
				$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";

			$funk::var["[\"" @ %name @ "\", 1]"] = "";
		}

		echo("Saving player " @ %name @ "...");

		%playerId = %clientId;
		%clientId.TotalKills = %clientId.TotalKills + %playerId.scoreKills;
		%clientId.TotalDeaths = %clientId.TotalDeaths + %playerId.scoreDeaths;
		%clientId.TotalScore = %clientId.TotalScore + %playerId.score;
		%clientId.TotalConnections = %clientId.TotalConnections + %clientId.connections;
		%clientId.TotalPasstry = %clientId.TotalPasstry + %clientId.passtry;
		%clientId.isregistered = true;
		
		$funk::var["[\"" @ %name @ "\", 0, 7]"] = %clientId.TotalKills;
		$funk::var["[\"" @ %name @ "\", 0, 8]"] = %clientId.TotalDeaths;
		$funk::var["[\"" @ %name @ "\", 0, 9]"] = %clientId.TotalScore;
		$funk::var["[\"" @ %name @ "\", 0, 10]"] = %clientId.isregistered;
		$funk::var["[\"" @ %name @ "\", 0, 11]"] = %clientId.TotalConnections;
		$funk::var["[\"" @ %name @ "\", 0, 12]"] = %clientId.TotalPasstry;
		



		
		
		$funk::var["[\"" @ %name @ "\", password]"] = $Client::info[%clientId, 5];
		

	      echo("Deleting old file before save for " @ %clientId @ "...");
		File::delete("config\\" @ %name @ ".cs");
		export("funk::var[\"" @ %name @ "\",*", "config\\" @ %name @ ".cs", false);
	      echo("Save complete for " @ %name @ ".");
		
	}
}
function LoadCharacter(%clientId)
{
	%clname = Client::getName(%clientId);
	%name = Client::getName(%clientId);
	%name = hashname(%name);
	%filename = %name @ ".cs";


	if(isFile("config\\" @ %filename))
	{
		//=================================================================== clear $funk::var's
		
		for(%i = 1; %i <= 30; %i++)
			$funk::var[%name, 0, %i] = "";
		for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			$funk::var[%name, 2, %i] = "";
		$funk::var[%name, 1] = "";

		//====================================================================== load character
	      echo("Loading player... " @ %name @ " ...");
		exec(%filename);
		if ($funk::var[%name , password] == $Client::info[%clientId, 5])
		{
			
			%clientId.TotalKills = $funk::var[%name, 0, 7];		
			%clientId.TotalDeaths = $funk::var[%name, 0, 8];
			%clientId.TotalScore = $funk::var[%name, 0, 9];	
			%clientId.isregistered = $funk::var[%name, 0, 10];
			%clientId.TotalConnections = $funk::var[%name, 0, 11];
			%clientId.TotalPasstry = $funk::var[%name, 0, 12];
			%clientId.spawntype = "saved";
			%clientId.SavedInfo = "True";
		}
		else
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your scores.\", 5);", 5);
			for(%i = 1; %i <= 30; %i++)
				$funk::var[%name, 0, %i] = "";
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
				$funk::var[%name, 2, %i] = "";
			$funk::var[%name, 1] = "";
			return;
		}
			
	}
	else
	{
	echo("No File in Database");
	}
	if($funk::var[%name, 0, 10] == "true")
	{
		echo("GreyBOT: "@%clname@" Is Known and Registered");
	}
   	Game::refreshClientScore(%clientId);
}

function hashname(%name)
{
	%name = escapeString(%name);
	%name = String::replace(%name, "\?", "A1");
	%name = String::replace(%name, "\\", "A2");
	%name = String::replace(%name, "\/", "A3");
	%name = String::replace(%name, "\!", "A4");
	%name = String::replace(%name, "\@", "A5");
	%name = String::replace(%name, "\#", "A6");
	%name = String::replace(%name, "\$", "A7");
	%name = String::replace(%name, "\%", "A8");
	%name = String::replace(%name, "\^", "A9");
	%name = String::replace(%name, "\&", "A0");
	%name = String::replace(%name, "\*", "B1");
	%name = String::replace(%name, "\(", "B2");
	%name = String::replace(%name, "\)", "B3");
	%name = String::replace(%name, "\+", "B4");
	%name = String::replace(%name, "\=", "B5");
	%name = String::replace(%name, "\:", "B6");
	%name = String::replace(%name, "\;", "B7");
	%name = String::replace(%name, "\<", "B8");
	%name = String::replace(%name, "\>", "B9");
	%name = String::replace(%name, "\,", "B0");
	%name = String::replace(%name, "\|", "C1");
	%name = String::replace(%name, "\`", "C2");
	%name = String::replace(%name, "\~", "C3");
	
	%name = String::replace(%name, "\"", "C4"); // PORT: a quote in a name survived into the file name and the export pattern
	%name = ("GreyBOTProfile_" @ %name);
	return %name;
}
function GreyBOT_unused_len(%string) // PORT: was String::len -- that name is an engine command in 1.50 (same result)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}

function GreyBOT_unused_replace(%string, %search, %replace) // PORT: was String::replace -- an engine command in 1.50 (replaces every match, as this did); this script copy never ended when the new text held the old
{
	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)
	{
		%lenstr = String::len(%string);
		%lenser = String::len(%search);
		%part1 = String::getSubStr(%string, 0, %loc);
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
		%string = %part1 @ "" @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}
	return %string;
}

function saveall()
{
	%numClients = getNumClients();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
            if(%cl.isregistered)
	      {
			SaveCharacter(%cl);
	      }
	      else if(!%cl.isregistered)
	      {
			client::sendmessage(%cl, 3, $adminbotname @": I cannot save your scores unless you are registered. Please do so by typing !register into your chat box. ~waccess_denied.wav");
	      }
	 }
}


exec("botinfo.cs");
