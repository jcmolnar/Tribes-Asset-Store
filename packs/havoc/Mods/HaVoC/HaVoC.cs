// HaVoC 1.6 by [HvC]NaTeDoGG (Nathan Sweet) -- Modern Tribes (1.50) port, entry script.
//
// Original launch line (install.txt):   Tribes.exe -mod HaVoC [-dedicated]
// The stock loader then ran config\HaVoC.cs (the mod's settings file) because it carried the mod
// name. This file is that settings file, unchanged, with the block below in front of it.
// Edit the settings exactly as guide.txt (docs\guide.txt) describes.

// --- port block -------------------------------------------------------------------------------
// Three things the server scripts need were tucked between functions of the mod's 1999 client.cs
// (lines 365, 578 and 590). That client.cs is not shipped (base's 1.50 client.cs runs), so they
// live here now, with the values the original had.
$MasterKey = "HaVoC16";            // item-favourites key (item.cs, arena.cs, server.cs ...)
$TeamItemMax[LaserTurret] = 4;

function whatArm(%armor) {
	if(%armor == "dmfemale" || %armor == "dmarmor") {
		return "4";
	} else if (%armor == "harmor" || %armor == "darmor") {
		return "3";
	} else if (%armor == "marmor" || %armor == "barmor" || %armor == "earmor" || %armor == "iarmor" || %armor == "mfemale" || %armor == "bfemale" || %armor == "efemale" || %armor == "ifarmor") {
		return "2";
	} else if (%armor == "larmor" || %armor == "sarmor" || %armor == "spyarmor" || %armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale") {
		return "1";
	} else {
		return false;
	}
}

// hvcUserList.cs (auto-admin by name + address) ships switched OFF and with the author's two
// sample entries commented out. server.cs execs it at start-up; edit it there to use it.

echo("HaVoC 1.6 (1.50 port) settings loaded.");
// --- end of port block; the original config\HaVoC.cs follows ----------------------------------

//Here is where you set up all the features in HaVoC.
//For instructions on what these things mean, refer
//to guide.txt that came with HaVoC or the site as 
//they both have in depth instructions on the 
//settings in this file:
//http://havoc.sirris.com

//Also take a look at the HvCUserList.cs file that came 
//with the HaVoC mod for setting up auto admins based 
//on IP.

$HaVoC::tkLimit = 2;
$HaVoC::tkClientLvl = "1";
$HaVoC::tkServerLvl = "1";
$HaVoC::tkMultiple = "3";

$HaVoC::BanKickTime = "400";

$HaVoC::Eye4anEye = TRUE;

$HaVoC::BaseKillWarning = 1;
$HaVoC::BaseKillLimit = 6;

$HaVoC::SADPassword[1] = "";
$HaVoC::SADPassword[2] = "";
$HaVoC::SADPassword[3] = "";
$HaVoC::SADPassword[4] = "";
$HaVoC::SADPassword[5] = "";

$HaVoC::MasterSADPassword[1] = "";
$HaVoC::MasterSADPassword[2] = "";
$HaVoC::MasterSADPassword[3] = "";
$HaVoC::MasterSADPassword[4] = "";
$HaVoC::MasterSADPassword[5] = "";

$HaVoC::PAPassword[1] = "";
$HaVoC::PAPassword[2] = "";
$HaVoC::PAPassword[3] = "";
$HaVoC::PAPassword[4] = "";
$HaVoC::PAPassword[5] = "";

$HaVoC::PASpecial[1] = TRUE;
$Special::PABan[1] = TRUE;
$Special::PATorture[1] = TRUE;
$Special::PAKick[1] = TRUE;
$Special::PATeamChange[1] = FALSE;
$Special::PAStartMatch[1] = FALSE;
$Special::PATimelimit[1] = FALSE;
$Special::PAMission[1] = FALSE;
$Special::PAServerOptions[1] = FALSE;
$Special::PAFairTeams[1] = FALSE;
$Special::PATeamDamage[1] = FALSE;
$Special::PATourneyMode[1] = FALSE;
$Special::PABalanceTeams[1] = FALSE;
$Special::PAIncreaseTime[1] = FALSE;

$HaVoC::PASpecial[2] = TRUE;
$Special::PABan[2] = FALSE;
$Special::PATorture[2] = FALSE;
$Special::PAKick[2] = FALSE;
$Special::PATeamChange[2] = FALSE;
$Special::PAStartMatch[2] = FALSE;
$Special::PATimelimit[2] = FALSE;
$Special::PAMission[2] = TRUE;
$Special::PAServerOptions[2] = FALSE;
$Special::PAFairTeams[2] = FALSE;
$Special::PATeamDamage[2] = FALSE;
$Special::PATourneyMode[2] = FALSE;
$Special::PABalanceTeams[2] = TRUE;
$Special::PAIncreaseTime[1] = TRUE;

$HaVoC::PABan = FALSE;
$HaVoC::PAKick = TRUE;
$HaVoC::PATeamChange = FALSE;
$HaVoC::PAStartMatch = FALSE;
$HaVoC::PATimelimit = TRUE;
$HaVoC::PAMission = TRUE;
$HaVoC::PAServerOptions = FALSE;
$HaVoC::PAFairTeams = TRUE;
$HaVoC::PATeamDamage = TRUE;
$HaVoC::PATourneyMode = FALSE;
$HaVoC::PABalanceTeams = TRUE;
$HaVoC::PAIncreaseTime = TRUE;

$HaVoC::PVMission = TRUE;
$HaVoC::PVKick = TRUE;
$HaVoC::PVAdmin = FALSE;
$HaVoC::PVFairTeams = TRUE;
$HaVoC::PVTourneyMode = FALSE;
$HaVoC::PVStartMatch = FALSE;
$HaVoC::PVTeamDamage = TRUE;
$HaVoC::PVTime = 11;
$HaVoC::PVBalanceTeams = TRUE;

$HaVoC::Lightning = TRUE;
$HaVoC::LightningStrength = "zero";
$HaVoC::LightningFrequency = 400;
$HaVoC::LightningHandicap = 3;

$HaVoC::DMInventories = TRUE;
$HaVoC::DMSniperWeapons = TRUE;
$HaVoC::DMMines = TRUE;
$HaVoC::DMFullWeapons = TRUE;

$FlagHunter::Inventories = TRUE;
$FlagHunter::AltarCampingTimer = 13;
$FlagHunter::FlagFadeTime = 120;
$FlagHunter::CarryingNumber = 5;
$FlagHunter::YardSaleNumber = 10;
$FlagHunter::YardSaleTime = 30;
$FlagHunter::GreedAmount = 6;
$FlagHunter::HoardStartTime = 5;
$FlagHunter::HoardEndTime = 2;

$Rabbit::Inventories = TRUE;
$Rabbit::ScoreTimer = 5;
$Rabbit::FlagReturnTime = 8;

$Arena::GameTimeLimit = 240;
$Arena::NumberMatchLimit = 3;
$Arena::Scorelimit = 3;
$Arena::ReadyTime = TRUE;  
$Arena::AutoTeamJoin = TRUE;

$HaVoC::AutoAssignTribe = "[HvC]";
$HaVoC::AutoAssignLength = 5;

$HaVoC::KickMessage = "Go away!  You idiot!";

$HaVoC::StationTime = "40";

$HaVoC::PersonalSkin = TRUE;

$HaVoC::TurretPoints = TRUE;

$HaVoC::TurretKillMessages = TRUE;

$HaVoC::FlagReturnTime = "100";

$HaVoC::FairSpawn = "7";

$HaVoC::AutoRespawn = 20;

$HaVoC::FriendlyMines = TRUE;

$HaVoC::RandomMissions = TRUE;
$HaVoC::RandomMissionTypes["Capture the Flag"] = TRUE;
$HaVoC::RandomMissionTypes["Deathmatch"] = FALSE;
$HaVoC::RandomMissionTypes["Multiple Team"] = FALSE;
$HaVoC::RandomMissionTypes["Capture and Hold"] = FALSE;
$HaVoC::RandomMissionTypes["Find and Retrieve"] = FALSE;
$HaVoC::RandomMissionTypes["Defend and Destroy"] = FALSE;
$HaVoC::RandomMissionTypes["Kill the Rabbit"] = FALSE;
$HaVoC::RandomMissionTypes["Flag Hunter"] = FALSE;
$HaVoC::RandomMissionTypes["Team Deathmatch"] = FALSE;
$HaVoC::RandomMissionTypes["Balanced"] = FALSE;
$HaVoC::RandomMissionTypes["Open Call"] = FALSE; 
$HaVoC::RandomMissionTypes["Duel"] = FALSE; 
$HaVoC::RandomMissionTypes["DuelTournament"] = FALSE; 
$HaVoC::RandomMissionTypes["Tribes Racer"] = FALSE; 
$HaVoC::RandomMissionTypes["Tribes Arena"] = FALSE; 

$HaVoC::FairTeams = TRUE;

$HaVoC::MinPlayersForBaseRape = 0;

