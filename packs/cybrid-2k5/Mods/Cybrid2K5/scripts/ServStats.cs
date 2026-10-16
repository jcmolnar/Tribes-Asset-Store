function CreateVars(%clientId, %name)
{
	%id = $TotalIDs;
	$StatsClient[%id,Name] = %Name;
	$StatsClient[%id,Kills] = 0;
	$StatsClient[%id,Deaths] = 0;
	$StatsClient[%id,Suicides] = 0;
	$StatsClient[%id,FlagCaps] = 0;
	$StatsClient[%id,FlagReturns] = 0;
	$StatsClient[%id,Ratio] = 0;
	$StatsClient[%id,Rank] = 0;

	%clientId.Kills = "0";
	%clientId.Deaths = "0";
	%clientId.Suicides = "0";
	%clientId.FlagCaps = "0";
	%clientId.FlagReturns = "0";
	%clientId.Rank = "0";
	%clientId.Ratio = "0";

	$StatsClient["[\"" @ %id @ "\", Name]"] = $StatsClient[%id,Name];
	$StatsClient["[\"" @ %id @ "\", Kills]"] = $StatsClient[%id,Deaths];
	$StatsClient["[\"" @ %id @ "\", Deaths]"] = $StatsClient[%id,Deaths];
	$StatsClient["[\"" @ %id @ "\", Suicides]"] = $StatsClient[%id,Suicides];
	$StatsClient["[\"" @ %id @ "\", FlagCaps]"] = $StatsClient[%id,FlagCaps];
	$StatsClient["[\"" @ %id @ "\", FlagReturns]"] = $StatsClient[%id,FlagReturns];
	$StatsClient["[\"" @ %id @ "\", Ratio]"] = $StatsClient[%id,Ratio];
	$StatsClient["[\"" @ %id @ "\", Rank]"] = $StatsClient[%id,Rank];
	
	export("$StatsClient[\"" @ %id @ "\",*", "temp\\Stats_"@%id@".cs", false);
	$TotalIDs++;
	export("$TotalIDs", "temp\\StatId.cs", false);
	%clientId.UniqueId = %id;
	return;
}

function StatsSystem::AddStat(%clientId, %type)
{
	if(%type == "Deaths")
	{
		%clientId.Deaths = %clientId.Deaths++;
	}
	else if(%type == "Kills")
	{
		%clientId.Kills = %clientId.Kills++;
	}
	else if(%type == "Suicides")
	{
		%clientId.Suicides = %clientId.Suicides++;
	}
	else if(%type == "FlagCaps")
	{
		%clientId.FlagCaps = %clientId.FlagCaps++;
	}
	else if(%type == "FlagReturns")
	{
		%clientId.FlagReturns = %clientId.FlagReturns++;
	}
	%clientId.Ratio = TotalEfficiencyRatio(%clientId);
	$StatsClient[%clientId.UniqueId, Ratio] = %clientId.Ratio;
	%clientId.Rank = Client::findRank(%clientId);
}

function Client::findRank(%clientId)
{
	%clientId.Rank = $TotalIDs;
	if(%clientId.Ratio == "0")
	{
		echo("Ratio Not Yet Established and Rank Cannot Be Found For "@client::getName(%clientId));
		return;
	}

	for(%id = 0; %id < $TotalIDs; %id++)
	{
		if(%clientId.Ratio == $StatsClient[%id,Ratio])
		{
			//Do Nothing
		}
		else if(%clientId.Ratio > $StatsClient[%id,Ratio])
		{
			%clientId.Rank--;
			$StatsClient[%id,Rank]++;
		}
	}
	return %clientId.Rank;
}

function SaveClientStats(%clientId)
{
	%name = client::getName(%clientId);
	%id = %clientId.UniqueID;
	%kills = %clientId.Kills;
	%deaths = %clientId.Deaths;
	%suicides = %clientId.Suicides;
	%flagcaps = %clientId.FlagCaps;
	%flagreturns = %clientId.FlagReturns;
	%ratio = %clientId.Ratio;
	%rank = %clientId.Rank;

	$StatsClient[%id,Name] = %name;
	$StatsClient[%id,Kills] = %kills;
	$StatsClient[%id,Deaths] = %deaths;
	$StatsClient[%id,Suicides] = %suicides;
	$StatsClient[%id,FlagCaps] = %flagcaps;
	$StatsClient[%id,FlagReturns] = %flagreturns;
	$StatsClient[%id,Ratio] = %ratio;
	$StatsClient[%id,Rank] = %rank;
			
	$StatsClient["[\"" @ %id @ "\", Name]"] = $StatsClient[%id,Name];
	$StatsClient["[\"" @ %id @ "\", Kills]"] = $StatsClient[%id,Kills];
	$StatsClient["[\"" @ %id @ "\", Deaths]"] = $StatsClient[%id,Deaths];
	$StatsClient["[\"" @ %id @ "\", Suicides]"] = $StatsClient[%id,Suicides];
	$StatsClient["[\"" @ %id @ "\", FlagCaps]"] = $StatsClient[%id,FlagCaps];
	$StatsClient["[\"" @ %id @ "\", FlagReturns]"] = $StatsClient[%id,FlagReturns];
	$StatsClient["[\"" @ %id @ "\", Ratio]"] = $StatsClient[%id,Ratio];
	$StatsClient["[\"" @ %id @ "\", Rank]"] = $StatsClient[%id,Rank];
		
	export("$StatsClient[\"" @ %id @ "\",*", "temp\\Stats_"@%id@".cs", false);

	echo("Saved "@%name@"'s Stats");
	
}

function ServStatClient(%clientId)
{
	%name = client::getName(%clientId);
	%kills = %clientId.Kills;
	%deaths = %clientId.Deaths;
	%suicides = %clientId.Suicides;
	%flagcaps = %clientId.FlagCaps;
	%flagreturns = %clientId.FlagReturns;
	%ratio = TotalEfficiencyRatio(%clientId);
	if(%clientId.Rank != "0")
	{
		%rank = %clientId.Rank;
	}
	else if(%clientId.Rank == "0")
	{
		%rank = "Not Established";
	}
	bottomprint(%clientId, "<jc><F1>Your Stats Are\n<jc><F0>Kills: <F2>"@%kills@"\n<jc><f0>Deaths: <F2>"@%deaths@"\n<jc><f0>Suicides: <f2>"@%suicides@"\n<jc><f0>Flag-Returns: <f2>"@%flagreturns@"\n<jc><f0>Flag-Caps: <F2>"@%flagcaps@"\n<jc><f0>Ratio: <F2>"@%ratio@"\n<jc><f0>Rank: <F2>"@%rank, 10);
}

function ExecStatsFiles()
{

	echo("Loading Stats");
	exec("StatID.cs");
	if($TotalIDs == "" || $TotalIDs == -1)
	{
		echo("Creating TotalID's File");
		$TotalIDs = "0";
		export("$TotalIDs", "temp\\StatID.cs", true);
	}

	for(%k = 0; %k < $TotalIDs; %k++)
	{
		exec("Stats_"@%k@".cs");
	}
}

function SaveStats()
{
	echo("Saving Statistics");
	for(%cl = client::getFirst(); %cl != -1; %cl = client::getNext(%cl))
	{
		%clientId = player::getClient(%cl);
		SaveClientStats(%clientId);
	}
	echo("All Stats Saved");
}

function TotalEfficiencyRatio(%clientId) 
{ 
   if((%clientId.Kills + %clientId.Deaths) > 4) 
   { 
      %ratio = floor((%clientId.Kills/(%clientId.Kills + %clientId.Deaths))*100);       
      return %ratio; 
   } 
   return "0"; 
}

ExecStatsFiles();
