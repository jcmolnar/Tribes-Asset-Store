

//==========================================================================================================
//== Save Profile
//==========================================================================================================
function SaveCharacter(%clientId)
{
	if ($Debug) echo ("Cinfo 1" @ $Client::info[%clientId, 1] @ "");
	if ($Debug) echo ("Cinfo 2" @ $Client::info[%clientId, 2] @ "");
	if ($Debug) echo ("Cinfo 3" @ $Client::info[%clientId, 3] @ "");
	if ($Debug) echo ("Cinfo 4" @ $Client::info[%clientId, 4] @ "");
	if ($Debug) echo ("Cinfo 5" @ $Client::info[%clientId, 5] @ "");
	if ($Debug) echo ("Cinfo 6" @ $Client::info[%clientId, 6] @ "");

	if ($Client::info[%clientId, 5] == "")
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);	
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disconnect, enter a password that you would like to use in the OtherInfo field.\", 5);", 10);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Reconnect and you will be able to save your profile.\", 5);", 15);
		return;
	}
	else
	{
		%name = Client::getName(%clientId);
		%name = hashname(%name);

		//clear $funk::var's

		for(%i = 1; %i <= 30; %i++)
			$funk::var["[\"" @ %name @ "\", 0, " @ %i @ "]"] = "";
		for(%i = 1; $funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] != ""; %i++)
			$funk::var["[\"" @ %name @ "\", 2, " @ %i @ "]"] = "";
		$funk::var["[\"" @ %name @ "\", 1]"] = "";


		//the first identifier in the array is the player's name.
		//this is needed because we are using a global array ($funk::var), so if another player
		//attempts to save at the same time, then there won't be $funk::var's being overwritten

		//the second identifier in the array is either 0, 1, or 2
		//0: regular player variable
		//1: armor
		//2: weapon/item

		//the third identifier is simply for identifying which what we're saving.

		//== Set By The Player
		//
		// %clientId.spawntype 		- Players spawn type...
		// %clientId.EngMine   		- Eng Mine Settings
		// %clientId.Plastic   		- Plastique Timing
		// %clientId.Mortar    		- Mortar Settings
		// %clientId.Plasma    		- Plasma Settings
		// %clientId.gravbolt  		- Grav Gun Settings
		//
		//== Set By The Game
		// 
		// %playerId.scoreKills		- Total Kills
		// %playerId.scoreDeaths	- Total Deaths
		// %playerId.score		- Total Score 
		// %playerId.TKCount		- Team Kill Count
		// %playerId.FlagCaps		- Flag Captures
		// 

		echo("Saving player " @ %name @ " (" @ %clientId @ ")...");

		if ($debug) echo ("Spawn Type "@ %clientId.spawntypetwo @"");
		if ($debug) echo ("Eng Mine   "@ %clientId.EngMine @"");
		if ($debug) echo ("Plastic    "@ %clientId.Plastic @"");
		if ($debug) echo ("Mortar     "@ %clientId.Mortar @"");
		if ($debug) echo ("Grav Gun   "@ %clientId.gravbolt @"");
		if ($debug) echo ("Total K    "@ %clientId.TotalKills @"");
		if ($debug) echo ("Total D    "@ %clientId.TotalDeaths @"");
		if ($debug) echo ("Total S    "@ %clientId.TotalScore @"");
		if ($debug) echo ("Total Tk   "@ %clientId.TotalTKCount @"");
		if ($debug) echo ("Total Fc   "@ %clientId.TotalFlags @"");
		if ($debug) echo ("Total Mis  "@ %clientId.MissionComplete @ "");

		%playerId = %clientId;

		%clientId.TotalKills = %clientId.TotalKills + %playerId.scoreKills;
		%clientId.TotalDeaths = %clientId.TotalDeaths + %playerId.scoreDeaths;
		%clientId.TotalScore = %clientId.TotalScore + %playerId.score;
		%clientId.TotalTKCount = %clientId.TotalTKCount + %playerId.TKCount;
		%clientId.TotalFlags = %clientId.TotalFlags + %playerId.FlagCaps;

		$funk::var["[\"" @ %name @ "\", 0, 1]"] = %clientId.spawntype;
		$funk::var["[\"" @ %name @ "\", 0, 2]"] = %clientId.EngMine;
		$funk::var["[\"" @ %name @ "\", 0, 3]"] = %clientId.Plastic;
		$funk::var["[\"" @ %name @ "\", 0, 4]"] = %clientId.Mortar;
		$funk::var["[\"" @ %name @ "\", 0, 5]"] = %clientId.Plasma;
		$funk::var["[\"" @ %name @ "\", 0, 6]"] = %clientId.gravbolt;
		$funk::var["[\"" @ %name @ "\", 0, 7]"] = %clientId.TotalKills;
		$funk::var["[\"" @ %name @ "\", 0, 8]"] = %clientId.TotalDeaths;
		$funk::var["[\"" @ %name @ "\", 0, 9]"] = %clientId.TotalScore;
		$funk::var["[\"" @ %name @ "\", 0, 10]"] = %playerId.TKCount;
		$funk::var["[\"" @ %name @ "\", 0, 11]"] = %clientId.TotalFlags;
		$funk::var["[\"" @ %name @ "\", 0, 12]"] = %clientId.MissionComplete;
		$funk::var["[\"" @ %name @ "\", password]"] = $Client::info[%clientId, 5];
		$funk::var["[\"" @ %name @ "\", 0, 13]"] = %clientId.EngBeacon;
		$funk::var["[\"" @ %name @ "\", 0, 14]"] = %clientId.rocket;
		%ii = 0;

		//determine which weapons player has
		if ($debug) echo ("Armor Type = " @ checkarmor(%cliendId) @ "") ;

		%max = getNumItems();
		for (%i = 0; %i < %max; %i++)
		{
			%checkItem = getItemData(%i);
			%itemcount = Player::getItemCount(%clientId, %checkItem);

			if (%itemcount)
			{
				if ($debug) echo ("Item Count  = " @ %itemcount @ "");
				if ($debug) echo ("Item Type   = " @ %checkitem @ "");
			}

			if(%itemcount && %checkItem == checkarmor(%clientId))
			{
				if ($debug) echo("Saving armor " @ %checkItem @ " for " @ %clientId);
				$funk::var["[\"" @ %name @ "\", 1]"] = %checkItem @ "";
			}
			else if(%itemcount)
			{
				if ($debug) echo("Saving item/weapon " @ %checkItem @ " for " @ %clientId);
				%ii++;
				$funk::var["[\"" @ %name @ "\", 2, " @ %ii @ "]"] = %checkItem @ " " @ %itemcount;
			}
		}
		if ($Debug) echo("Deleting old file before save for " @ %clientId @ "...");
		File::delete("config\\" @ %name @ ".cs");
		export("funk::var[\"" @ %name @ "\",*", "config\\" @ %name @ ".cs", false);
		if ($Debug) echo("Save complete for " @ %name @ ".");
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You profile has been saved.\", 3);", 0);
		
	}
}

function checkarmor(%clientId)
{
	%playerarmor = Player::getArmor(%clientId);
	%armor = $ArmorName[%playerarmor];
	if ($Debug) echo ("Armor = " @ %armor @ "");
	if (%armor == "LightArmor" ||%armor == "MediumArmor" ||%armor == "HeavyArmor" ||%armor == "ScoutArmor" ||%armor == "StimArmor" ||%armor == "BursterArmor" ||%armor == "EngArmor" ||%armor == "DragArmor" ||%armor == "SpArmor" ||%armor == "AlArmor" ||%armor == "Juggernaught")
	{
		if (%armor == "StimArmor")
			%armor = "ScoutArmor";
			
		if (%armor == "StimArmor")
			%armor = "ScoutAmror";
			
		if ($debug) echo ("Armor saved...");
		return %armor;
	}
	else
	{
		if ($debug) echo ("Could not verify armor type.");
		return "marmor";
	}
}

//==========================================================================================================
//== Load Profile
//==========================================================================================================
function LoadCharacter(%clientId)
{
	%name = Client::getName(%clientId);
	%name = hashname(%name);
	
	%filename = %name @ ".cs";
	%playerId = %clientId;

	if ($Debug) echo ("Cinfo 1" @ $Client::info[%clientId, 1] @ "");
	if ($Debug) echo ("Cinfo 2" @ $Client::info[%clientId, 2] @ "");
	if ($Debug) echo ("Cinfo 3" @ $Client::info[%clientId, 3] @ "");
	if ($Debug) echo ("Cinfo 4" @ $Client::info[%clientId, 4] @ "");
	if ($Debug) echo ("Cinfo 5" @ $Client::info[%clientId, 5] @ "");
	if ($Debug) echo ("Cinfo 6" @ $Client::info[%clientId, 6] @ "");

	if(isFile("config\\" @ %filename))
	{
		//=================================================================== clear $funk::var's
		
		for(%i = 1; %i <= 30; %i++)
			$funk::var[%name, 0, %i] = "";
		for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			$funk::var[%name, 2, %i] = "";
		$funk::var[%name, 1] = "";

		//====================================================================== load character
		
		if ($debug) echo("Loading player... " @ %name @ " (" @ %clientId @ ")...");

		exec(%filename);


		if ($funk::var[%name , password] == $Client::info[%clientId, 5])
		{
			if ($debug) echo("Correct password is = " @ $funk::var[%name , password] @ "");
			if ($debug) echo("Correct password is = " @ $Client::info[%clientId, 5] @ "");		
			if ($debug) echo("Loading player... Password is good. " @ %name @ "...");

			%clientId.spawntypetwo = $funk::var[%name, 0, 1];
			%clientId.EngMine = $funk::var[%name, 0, 2];
			%clientId.Plastic = $funk::var[%name, 0, 3];
			%clientId.Mortar = $funk::var[%name, 0, 4];
			%clientId.Plasma = $funk::var[%name, 0, 5];
			%clientId.gravbolt = $funk::var[%name, 0, 6];
			%clientId.TotalKills = $funk::var[%name, 0, 7];		
			%clientId.TotalDeaths = $funk::var[%name, 0, 8];
			%clientId.TotalScore = $funk::var[%name, 0, 9];
			%clientId.TotalTKCount = $funk::var[%name, 0, 10];
			%clientId.TotalFlags = $funk::var[%name, 0, 11];
			%clientId.MissionComplete = $funk::var[%name, 0, 12];
			%clientId.EngBeacon = $funk::var[%name, 0, 13];
			%clientId.rocket = $funk::var[%name, 0, 14];
			
			if ($debug) echo ("Spawn Type "@ %clientId.spawntypetwo @"");
			if ($debug) echo ("Eng Mine   "@ %clientId.EngMine @"");
			if ($debug) echo ("Plastic    "@ %clientId.Plastic @"");
			if ($debug) echo ("Mortar     "@ %clientId.Mortar @"");
			if ($debug) echo ("Grav Gun   "@ %clientId.gravbolt @"");
			if ($debug) echo ("Total K    "@ %clientId.TotalKills @"");
			if ($debug) echo ("Total D    "@ %clientId.TotalDeaths @"");
			if ($debug) echo ("Total S    "@ %clientId.TotalScore @"");
			if ($debug) echo ("Total Tk   "@ %clientId.TotalTKCount @"");
			if ($debug) echo ("Total Fc   "@ %clientId.TotalFlags @"");
			if ($debug) echo ("Total Mis  "@ %clientId.MissionComplete @ "");

			%playerId.scoreKills = 0;
			%playerId.scoreDeaths = 0;  
			%playerId.score = 0;
			%playerId.TKCount = 0;
			%playerId.FlagCaps = 0;

			%clientId.spawntype = "saved";

			$spawnBuyList[%clientId, 0] = $funk::var[%name, 1];
			%clientId.SavedList[0] = $funk::var[%name, 1];

			if ($Debug) echo("Loading armor " @ $spawnBuyList[%clientId, 0] @ " for " @ %clientId);
			for(%i = 1; $funk::var[%name, 2, %i] != ""; %i++)
			{
				$spawnBuyList[%clientId, %i] = $funk::var[%name, 2, %i];
				%clientId.SavedList[%i] = $funk::var[%name, 2, %i];
				echo("Spawning item/weapon " @ $spawnBuyList[%clientId, %i] @ " for " @ %clientId);

			}
	
			if ($Debug) echo("Load complete.");
			%clientId.SavedInfo = "True";
		}
		else
		{
			if ($debug) echo("Password is not good. " @ %name @ "...");
			if ($debug) echo("Correct password is   = " @ $funk::var[%name , password] @ "");
			if ($debug) echo("InCorrect password is = " @ $Client::info[%clientId, 5] @ "");
			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);
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
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You must specify a password in the OtherInfo field in your player profile.\", 5);", 0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>If you would like to save your profile.\", 5);", 5);

		//================================================================= give defaults

		echo("Giving defaults to new player " @ %clientId);
		%clientId.spawntype = "random";
		%clientId.EngMine = "0";
		%clientId.Plastic = "15"; 
		%clientId.Mortar =  "0";
		%clientId.Plasma =  "0";
		%clientId.gravbolt = "0";
		%clientId.scoreKills = "0";
		%clientId.scoreDeaths = "0";
		%clientId.score =  "0";
		%clientId.TKCount =  "0";
		%clientId.FlagCaps = "0";
		%clientId.rocket = "0";
		%clientId.EngBeacon = "0";
		for(%i = 0; $spawnBuyList[%clientId, %i] != ""; %i++)
			$spawnBuyList[%clientId, %i] = "";

	}

   	Game::refreshClientScore(%clientId);
}


function hashname(%name)
{
	%name = escapeString(%name);
	%name = StarMod_replace(%name, "\?", "A1"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\\", "A2"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\/", "A3"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\!", "A4"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\@", "A5"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\#", "A6"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\$", "A7"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\%", "A8"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\^", "A9"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\&", "A0"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\*", "B1"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\(", "B2"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\)", "B3"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\+", "B4"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\=", "B5"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\:", "B6"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\;", "B7"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\<", "B8"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\>", "B9"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\,", "B0"); //echo (" Name = " @ %name @ "");
	%name = StarMod_replace(%name, "\|", "B1"); //echo (" Name = " @ %name @ "");
	
	%name = ("ShifterProfile_" @ %name);
	return %name;
}
function StarMod_len(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++)
		%length++;

	return %length;
}
function StarMod_replace(%string, %search, %replace)
{
	//if ($Debug) echo ("St " @ %string @ "");
	//if ($Debug) echo ("Sr " @ %search @ "");
	//if ($Debug) echo ("Rp " @ %replace @ "");

	%loc = String::findSubStr(%string, %search);
	for(%loc; %loc != -1; %i++)
	{
		%lenstr = StarMod_len(%string);
		%lenser = StarMod_len(%search);
		%part1 = String::getSubStr(%string, 0, %loc - 1);
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);
		%string = %part1 @ "" @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}
	return %string;
}

function saveall()
{
	if ($Debug) echo("*** Saving All Player Info!");
	

	%numClients = getNumClients();
	%numCl = ((2049 + %numClients) + 20);
	%linenum = 10;

	for(%k = 0 ; %k < %numClients; %k++) 
		%clientList[%k] = getClientByIndex(%k);


	for(%k= 0 ; %k < %numClients; %k++)
	{
		if ($Debug) echo ("Client # " @ %clientList[%k] @ "");
		
		if($missionComplete == "True")
		{
			if ($Debug) echo ("Incrementing Mission For " @ %clientList[%k] @".");
			%clientList[%k].MissionComplete++;
		}
		SaveCharacter(%clientList[%k]);
	}
}