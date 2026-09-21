function CheckSavedStats(%client)
{
	%name = client::getname(%client);
	%name = unRetardTheName(%name);
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
	////%filename = client::getname(%client);
	//if(isFile("temp\\" @ %name@".cs"))
	//{
	//	return true;
	//}
	//else {
		return false;
	//}

	//echo(%name @" Check savedstats");
	for(%x = 0; %x < $SavedStatsTotal+10; %x++)
	{
		if(%name == $SavedStats[%x])
		{
			return true;
		}
	}
	//%name = unRetardTheName(client::getname(%client));
	//exec(%name@".cs");
	//if($StoredStats[5])
	//{
	//	StoredStatsClear();
	//	return true;
	//}
	return false;
}
function Stats::DeleteProfile(%client)
{
	%name = client::getname(%client);
	%name = unRetardTheName(%name);

	%filename = %name @ ".cs";

	File::delete("temp\\" @ %filename);


	%clientId.observerMode = "";
   	Client::setGuiMode(%clientId, $GuiModePlay);
   	Stats::Reboot(%client);
   	%client.loaded = false;
	StoredStatsClear();
	Stats::RemoveFromList(%client);

	Observer::enterObserverMode(%client);
	Game::refreshClientScore(%client);
	centerprint(%client, "<jc><f2>Press tab and select a player to duel!!!\n\n<f1>" @ $Server::JoinMOTD @ "\n\n<jc><f2>Press tab and select a player to duel!!!", 12);


	client::sendmessage(%client, $Red, "Stats have been cleared.");

}
function FindInvalidChar(%name)
{
	for(%a = 1; %a <= String::len($invalidChars); %a++)
	{
		%b = String::getSubStr($invalidChars, %a-1, 1);
		if(String::findSubStr(%name, %b) != -1)
		{
			return %a-1;
		}
	}
	return "";
}
$invalidChars = " ><?\\\"{}[]+=:;/.,~!@#$%^&*()|`-";
$validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
//42
function as()
{
	%name = "Lestat--++";
	//echo(unRetardTheName(%name));
	 %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
      UpdateClientTimes(%curTimeLeft);
}
function CheckValid(%char)
{
	//%retval = FindInvalidChar(%name);
	for(%x = 0; %x < 43; %x++)
	{
		%valid = String::getSubStr($validChars, %x, 1);
		//%m = GetWord($validChars, %x);
		//echo(%x @" invalid list: "@%valid@" Character: "@%char);
		//echo(%x@" Valid Char: "@%valid@" Character: "@%char);
		//echo("valid-"@%valid@" char-"@%char);
		if(%valid == %char)
		{
			//echo("Fuck Yeah!");
			return true ;
		}
	}
	//echo("fuck no");
	return false ;
}
function FindInvalidChar(%name)
{
	//dbecho($dbechoMode, "FindInvalidChar(" @ %name @ ")");

	//looks for invalid characters in player's name
	for(%a = 1; %a <= String::len($invalidChars); %a++)
	{
		%b = String::getSubStr($invalidChars, %a-1, 1);
		if(String::findSubStr(%name, %b) != -1)
		{
			return %a-1;
		}
	}
	return "";
}
function unRetardTheName(%name)
{
	return %name;
	//echo("start unretard "@%name);
	//%retval = FindInvalidChar(%name);
	%newname = "";
   for(%x = 0; (%char = String::getSubStr(%name, %x, 1)) != ""; %x++)
   {
	  // echo("Name: "@%name@" Character: "@%char@" Good or Bad?: "@GoodLetter(%char)@" RPG ONE "@FindInvalidChar(%name));
		if(FindInvalidChar(%char) == "")
		{
			%newname = %newname @ %char ;

			//echo("First Change "@%newname);
		}
		else {
			if(%char != "a" || %char != "b" || %char != "c" || %char != "d" || %char != "e" || %char != "f" || %char != "g" || %char != "h" || %char != "i" || %char != "j" || %char != "k" || %char != "l" || %char != "m" || %char != "n" || %char != "o" || %char != "p" || %char != "q" || %char != "r" || %char != "s" || %char != "t" || %char != "u" || %char != "v" || %char != "w" || %char != "x" || %char != "y" || %char != "z" || %char != "A" || %char != "B" || %char != "C" || %char != "D" || %char != "E" || %char != "F" || %char != "G" || %char != "H" || %char != "I" || %char != "J" || %char != "K" || %char != "L" || %char != "M" || %char != "N" || %char != "O" || %char != "P" || %char != "Q" || %char != "R" || %char != "S" || %char != "T" || %char != "U" || %char != "V" || %char != "W" || %char != "X" || %char != "Y" || %char != "Z")
			{
				%newname = %newname @ SubChar(%char) ;
				//echo("Second Change "@%newname);
			}
		}
	}
	return %newname ;
}
function GoodLetter(%char)
{
	//echo("Good Letter Char "@%char);
	if(%char != "a" && %char != "b" && %char != "c" && %char != "d" && %char != "e" && %char != "f" && %char != "g" && %char != "h" && %char != "i" && %char != "j" && %char != "k" && %char != "l" && %char != "m" && %char != "n" && %char != "o" && %char != "p" && %char != "q" && %char != "r" && %char != "s" && %char != "t" && %char != "u" && %char != "v" && %char != "w" && %char != "x" && %char != "y" && %char != "z" && %char != "A" && %char != "B" && %char != "C" && %char != "D" && %char != "E" && %char != "F" && %char != "G" && %char != "H" && %char != "I" && %char != "J" && %char != "K" && %char != "L" && %char != "M" && %char != "N" && %char != "O" && %char != "P" && %char != "Q" && %char != "R" && %char != "S" && %char != "T" && %char != "U" && %char != "V" && %char != "W" && %char != "X" && %char != "Y" && %char != "Z" && %char != "1" && %char != "2" && %char != "3" && %char != "4" && %char != "5" && %char != "6" && %char != "7" && %char != "8" && %char != "9" && %char != "0")
	{
		return false;
	}
	return true;
}
function SavePassword(%client)
{
	StoredStatsClear();
	%ip = HoldIPTrim(Client::getTransportAddress(%client));
	%name = client::getname(%client);
	%name = unRetardTheName(%name);
	exec(%name);
	$StoredStats[3] = %client.password;
	export("$StoredStats*", "temp\\" @ %name @ ".cs", false);
	StoredStatsClear();
}
function Stats::RemoveFromList(%client)
{
	return;
	%here = "";
	$ConsoleWorld::DefaultSearchPath = $ConsoleWorld::DefaultSearchPath;
	%filename = "StatList.cs";
	if(isFile("temp\\" @ %filename))
	{
		echo("Loading SetupList...");
		exec(%filename);
	}
	else {
		echo("No List Found");
		return;
	}
	%amount = Stats::CountThem()+10;
	%name = client::getname(%client);
	%name = unRetardTheName(%name);
	%count = 0;
	%newcnt = -1;
	for(%x = -1; %x < %amount; %x++)
	{
		//echo($SavedStats[%x]@" "@%name);
		if($SavedStats[%x] == %name)
		{
			echo("found one");
		}
		if($SavedStats[%x] != %name)
		{
			%temp[%count++] = $SavedStats[%x];
			echo("count "@%count);
		}
		else {
			$SavedStats[%x] = "";
		}
	}
	deleteVariables("$SavedStats");
	for(%x = -1; %x < %amount; %x++)
	{
		if(%temp[%x] != %name && %temp[%x] != "" && %temp[%x] != "-1")
		{
			$SavedStats[%x] = %temp[%x];
		}
	}


	//$SavedStats[Stats::CountThem()] = %name;
	$SavedStatsTotal = Stats::CountThem()+1 ;

	export("$SavedStats*", "temp\\StatList.cs", false);
}
function SaveStats(%client)
{
	if(%client.password == "" && !CheckSavedStats(%client))
	{
		client::sendmessage(%client, $White, "You must first set a password in case your IP Address changes.");
		return;
	}
	%ip = HoldIPTrim(Client::getTransportAddress(%client));
	%name = client::getname(%client);
	%name = unRetardTheName(%name);

	$StoredStats[1] = %ip;
	$StoredStats[2] = %name;
	$StoredStats[3] = %client.password;
	$StoredStats[4] = HoldScoreString(%client);
	$StoredStats[5] = true;
	if(!CheckSavedStats(%client))
	{
		Stats::AddToList(%client);
		//messageall(1, CheckSavedStats(%client));
	}

	export("$StoredStats*", "temp\\" @ %name @ ".cs", false);
	StoredStatsClear();
	echo("Saved Player Stats: "@%name@".cs");
}
function LoadStats(%client, %skip)
{
	echo("Load Stats "@client::getname(%client));
	%ip = HoldIPTrim(Client::getTransportAddress(%client));
	%name = client::getname(%client);
	%name = unRetardTheName(%name);

	if(CheckSavedStats(%client))
	{
		exec(%name);
		if($StoredStats[5])
		{
			if(%ip == $StoredStats[1] || %skip)
			{
				%client.password = $StoredStats[3];
				RestoreScore(%client, $StoredStats[4]);
				//client::sendmessage(%client, $White, "Stats Loaded.~wmine_act.wav");
			}
			else {
				%client.enterpw = true;
				client::sendmessage(%client, $Red, "Your IP address has changed.");
				client::sendmessage(%client, $Red, "Enter your password or type \"quit\".");
			}

		}
		else {
			client::sendmessage(%client, $Red, "No stat file found!");
			//Stats::Reboot(%client);
			//SaveStats(%client);
		}
		StoredStatsClear();
	}
	else {
		client::sendmessage(%client, $Red, "You do not have any stats to load!");
	}
}

function PermClearStats(%client)
{
	%name = client::getname(%client);
	%name = unRetardTheName(%name);
	%filename = %name @ ".cs";
	File::delete("temp\\" @ %filename);
	ResetClientStats(%client);
}
$loaded["TDSave.cs"] = true;