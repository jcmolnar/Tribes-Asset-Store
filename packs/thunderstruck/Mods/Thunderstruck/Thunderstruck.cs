// ThunderStruck "Lightning Death" vL-D by Hooter and Spector of the /H:H/ clan (a fork of
// NaTeDoGG's HaVoC 1.5.x) -- Modern Tribes (1.50) port, entry script.
//
// Original launch line (ThunderStruck.bat):   tribes.exe -mod ThunderStruck -dedicated
// The stock loader then ran config\ThunderStruck.cs (the mod's settings file) because it carried
// the mod name. This file is that settings file with the block below in front of it.
// Edit the settings exactly as guide.txt (docs\guide.txt) describes.

// --- port block -------------------------------------------------------------------------------
// Three things the server scripts need were tucked between functions of the mod's 1999 client.cs
// (lines 365, 578 and 590). That client.cs is not shipped (base's 1.50 client.cs runs), so they
// live here now, with the values the original had.
$MasterKey = "HaVoC156beta";       // item-favourites key (item.cs, arena.cs, server.cs ...)
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

// redUserList.cs (auto-admin by name + address) ships switched OFF and with the authors' nine
// entries commented out. server.cs execs it at start-up; edit it there to use it.
// The 51 SHBan("IP:a.b") lines further down (permanent bans of whole address ranges, from the
// authors' own 2001 server) are commented out. SHBan() itself still works for a host who wants it.

echo("ThunderStruck L-D (1.50 port) settings loaded.");
// --- end of port block; the original config\ThunderStruck.cs follows ---------------------------

//Here is where you set up all the features in ThunderStruck.
//For instructions on what these things mean, refer
//to guide.txt that came with ThunderStruck or the site as 
//they both have in depth instructions on the 
//settings in this file:

//Also take a look at the redUserList.cs file that came 
//with the ThunderStruck mod for setting up auto admins based 
//on IP.

$ThunderStruck::tkLimit = 2;
$ThunderStruck::tkClientLvl = "1";
$ThunderStruck::tkServerLvl = "1";
$ThunderStruck::tkMultiple = "3";

$ThunderStruck::BanKickTime = "999";

$ThunderStruck::Eye4anEye = TRUE;

$ThunderStruck::BaseKillWarning = 1;
$ThunderStruck::BaseKillLimit = 4;

$ThunderStruck::SADPassword[1] = "";
$ThunderStruck::SADPassword[2] = "";
$ThunderStruck::SADPassword[3] = "";
$ThunderStruck::SADPassword[4] = "";
$ThunderStruck::SADPassword[5] = "";

$ThunderStruck::MasterSADPassword[1] = "";
$ThunderStruck::MasterSADPassword[2] = "";
$ThunderStruck::MasterSADPassword[3] = "";
$ThunderStruck::MasterSADPassword[4] = "";
$ThunderStruck::MasterSADPassword[5] = "";

$ThunderStruck::PAPassword[1] = "";
$ThunderStruck::PAPassword[2] = "";
$ThunderStruck::PAPassword[3] = "";
$ThunderStruck::PAPassword[4] = "";
$ThunderStruck::PAPassword[5] = "";

$ThunderStruck::PASpecial[1] = TRUE;
$Special::PABan[1] = FALSE;
$Special::PATorture[1] = TRUE;
$Special::PAKick[1] = TRUE;
$Special::PATeamChange[1] = TRUE;
$Special::PAStartMatch[1] = TRUE;
$Special::PATimelimit[1] = FALSE;
$Special::PAMission[1] = FALSE;
$Special::PAServerOptions[1] = FALSE;
$Special::PAFairTeams[1] = FALSE;
$Special::PATeamDamage[1] = FALSE;
$Special::PATourneyMode[1] = FALSE;
$Special::PABalanceTeams[1] = FALSE;

$ThunderStruck::PASpecial[2] = TRUE;
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

$ThunderStruck::PABan = FALSE;
$ThunderStruck::PAKick = true;
$ThunderStruck::PATeamChange = TRUE;
$ThunderStruck::PAStartMatch = FALSE;
$ThunderStruck::PATimelimit = TRUE;
$ThunderStruck::PAMission = TRUE;
$ThunderStruck::PAServerOptions = FLASE;
$ThunderStruck::PAFairTeams = TRUE;
$ThunderStruck::PATeamDamage = TRUE;
$ThunderStruck::PATourneyMode = False;
$ThunderStruck::PABalanceTeams = TRUE;

$ThunderStruck::PVMission = True;
$ThunderStruck::PVKick = False;
$ThunderStruck::PVAdmin = FALSE;
$ThunderStruck::PVFairTeams = FALSE;
$ThunderStruck::PVTourneyMode = FALSE;
$ThunderStruck::PVStartMatch = FALSE;
$ThunderStruck::PVTeamDamage = False;
$ThunderStruck::PVTime = 11;
$ThunderStruck::PVBalanceTeams = TRUE;

$ThunderStruck::Lightning = TRUE;
$ThunderStruck::LightningStrength = "zero";
$ThunderStruck::LightningFrequency = 400;
$ThunderStruck::LightningHandicap = 3;

$ThunderStruck::DMInventories = TRUE;
$ThunderStruck::DMSniperWeapons = TRUE;
$ThunderStruck::DMMines = TRUE;
$ThunderStruck::DMFullWeapons = TRUE;

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

$ThunderStruck::AutoAssignTribe = "/H:H/";
$ThunderStruck::AutoAssignLength = 5;

$ThunderStruck::KickMessage = "Look Ma I got Kicked!";

$ThunderStruck::StationTime = "40";

$ThunderStruck::PersonalSkin = TRUE;

$ThunderStruck::TurretPoints = TRUE;

$ThunderStruck::TurretKillMessages = TRUE;

$ThunderStruck::FlagReturnTime = "50";

$ThunderStruck::FairSpawn = "1";

$ThunderStruck::AutoRespawn = 20;

$ThunderStruck::FriendlyMines = TRUE;

$ThunderStruck::RandomMissions = True;
$ThunderStruck::RandomMissionTypes["Capture the Flag"] = TRUE;
$ThunderStruck::RandomMissionTypes["Deathmatch"] = FALSE;
$ThunderStruck::RandomMissionTypes["Multiple Team"] = FALSE;
$ThunderStruck::RandomMissionTypes["Capture and Hold"] = FALSE;
$ThunderStruck::RandomMissionTypes["Find and Retrieve"] = FALSE;
$ThunderStruck::RandomMissionTypes["Defend and Destroy"] = FALSE;
$ThunderStruck::RandomMissionTypes["Kill the Rabbit"] = FALSE;
$ThunderStruck::RandomMissionTypes["Flag Hunter"] = FALSE;
$ThunderStruck::RandomMissionTypes["Team Deathmatch"] = FALSE;
$ThunderStruck::RandomMissionTypes["Balanced"] = FALSE;
$ThunderStruck::RandomMissionTypes["Open Call"] = FALSE; 
$ThunderStruck::RandomMissionTypes["Duel"] = FALSE; 
$ThunderStruck::RandomMissionTypes["DuelTournament"] = FALSE; 
$ThunderStruck::RandomMissionTypes["Tribes Racer"] = FALSE; 
$ThunderStruck::RandomMissionTypes["Tribes Arena"] = FALSE; 

$ThunderStruck::FairTeams = TRUE;

//===========================internal mod ban list=========
//=======================add ips here to ban there ass forever
//PORT-OFF: SHBan("IP:4.41");
//PORT-OFF: SHBan("IP:151.200");
//PORT-OFF: SHBan("IP:24.252");
//PORT-OFF: SHBan("IP:24.31");
//PORT-OFF: SHBan("IP:216.175");
//PORT-OFF: SHBan("IP:24.161.212");
//PORT-OFF: SHBan("IP:64.196");
//PORT-OFF: SHBan("IP:24.0");
//PORT-OFF: SHBan("IP:216.166");
//PORT-OFF: SHBan("IP:65.9.197");
//PORT-OFF: SHBan("IP:12.87");
//PORT-OFF: SHBan("IP:208.16");
//PORT-OFF: SHBan("IP:66.20");
//PORT-OFF: SHBan("IP:12.36");
//PORT-OFF: SHBan("IP:24.253");
//PORT-OFF: SHBan("IP:24.251");
//PORT-OFF: SHBan("IP:12.83");
//PORT-OFF: SHBan("IP:4.60");
//PORT-OFF: SHBan("IP:4.17");
//PORT-OFF: SHBan("IP:66.8");
//PORT-OFF: SHBan("IP:66.91");
//PORT-OFF: SHBan("IP:12.81");
//PORT-OFF: SHBan("IP:4.23");
//PORT-OFF: SHBan("IP:24.19");
//PORT-OFF: SHBan("IP:209.248");
//PORT-OFF: SHBan("IP:24.176");
//PORT-OFF: SHBan("IP:67.8.");
//PORT-OFF: SHBan("IP:12.93");
//PORT-OFF: SHBan("IP:65.12");
//PORT-OFF: SHBan("IP:24.4");
//PORT-OFF: SHBan("IP:12.86");
//PORT-OFF: SHBan("IP:24.44");
//PORT-OFF: SHBan("IP:24.43");
//PORT-OFF: SHBan("IP:24.92.192");
//PORT-OFF: SHBan("IP:24.151");
//PORT-OFF: SHBan("IP:24.7");
//PORT-OFF: SHBan("IP:66.75");
//PORT-OFF: SHBan("IP:24.8");
//PORT-OFF: SHBan("IP:12.44");
//PORT-OFF: SHBan("IP:24.93");
//PORT-OFF: SHBan("IP:66.156");
//PORT-OFF: SHBan("IP:65.27.93");
//PORT-OFF: SHBan("IP:24.176");
//PORT-OFF: SHBan("IP:12.64");
//PORT-OFF: SHBan("IP:24.25");
//PORT-OFF: SHBan("IP:12.82");
//PORT-OFF: SHBan("IP:64.242");
//PORT-OFF: SHBan("IP:65.2");
//PORT-OFF: SHBan("IP:208.190");
//PORT-OFF: SHBan("IP:216.61");
//PORT-OFF: SHBan("IP:209.250");

//===================================RANDOM EVENT'S WEATHER====================================

$RandomEvents = "True";		//"True" Turns on random events, "False" Turns off random events
	$RandomEventTime=240;	//Seconds between random events
	$RandomTimeVariance = 0.25; //0 = no variance, 0.5 = 50% time variance, 1.0 = 100% time variance
	
	//Occasional Meteor Storms
	$Meteor="True";
		$MeteorDensity=0.5;  	//1 = normal, 0.5 = half as many meteors.
		$MeteorDuration = 120; 	//Seconds that the meteor storm lasts
		$MeteorAreaVariance = 0;//0 = Meteor count does not vary with land area for each map. 1= directly proportional to map area
		$MeteorWeight = 5;
		
	//Occasional Lightning
	$Lightning="True";
		$LightningDensity=0.5;  	//1 = normal, 0.5 = half as many strikes.
		$LightningDuration = 60; 	//Seconds that the meteor storm lasts
		$LightningAreaVariance = 0;//0 = Lightning strike count does not vary with land area for each map. 1= directly proportional to map area
		$LightningWeight = 10;   // 
	

$sin[0]=0;
$sin[1]=0;
$sin[2]=1;
$sin[3]=0;
$sin[4]=0;
$sin[5]=0;
$sin[6]=0;
$sin[7]=0;
$sin[8]=1;
$sin[9]=0;
$sin[10]=0;
$sin[11]=0;
$sin[12]=1;
$sin[13]=0;
$sin[14]=1;
$sin[15]=0;
$sin[16]=0;
$sin[17]=0;
$sin[18]=0;
$sin[19]=0;
$sin[20]=0;
$sin[21]=0;
$sin[22]=0;
$sin[23]=0;
$sin[24]=0;
$sin[25]=1;
$sin[26]=1;
$sin[27]=0;
$sin[28]=0;
$sin[29]=1;
$sin[30]=0;
$sin[31]=0;
$sin[32]=0;
$sin[33]=1;
$sin[34]=1;
$sin[35]=1;
$sin[36]=1;
$sin[37]=2;
$sin[38]=1;
$sin[39]=1;
$sin[40]=2;
$sin[41]=2;
$sin[42]=2;
$sin[43]=2;
$sin[44]=2;
$sin[45]=2;
$sin[46]=3;
$sin[47]=3;
$sin[48]=4;
$sin[49]=3;
$sin[50]=3;
$sin[51]=5;
$sin[52]=5;
$sin[53]=4;
$sin[54]=5;
$sin[55]=5;
$sin[56]=5;
$sin[57]=6;
$sin[58]=6;
$sin[59]=6;
$sin[60]=6;
$sin[61]=7;
$sin[62]=7;
$sin[63]=7;
$sin[64]=8;
$sin[65]=9;
$sin[66]=8;
$sin[67]=10;
$sin[68]=9;
$sin[69]=10;
$sin[70]=10;
$sin[71]=10;
$sin[72]=10;
$sin[73]=11;
$sin[74]=11;
$sin[75]=11;
$sin[76]=12;
$sin[77]=13;
$sin[78]=13;
$sin[79]=12;
$sin[80]=13;
$sin[81]=13;
$sin[82]=13;
$sin[83]=13;
$sin[84]=14;
$sin[85]=14;
$sin[86]=14;
$sin[87]=14;
$sin[88]=15;
$sin[89]=15;
$sin[90]=14;
$sin[91]=14;
$sin[92]=15;
$sin[93]=14;
$sin[94]=15;
$sin[95]=14;
$sin[96]=14;
$sin[97]=13;
$sin[98]=13;
$sin[99]=13;
$sin[100]=14;
$sin[101]=13;
$sin[102]=12;
$sin[103]=13;
$sin[104]=12;
$sin[105]=12;
$sin[106]=11;
$sin[107]=11;
$sin[108]=11;
$sin[109]=10;
$sin[110]=10;
$sin[111]=10;
$sin[112]=9;
$sin[113]=9;
$sin[114]=9;
$sin[115]=8;
$sin[116]=8;
$sin[117]=8;
$sin[118]=7;
$sin[119]=7;
$sin[120]=7;
$sin[121]=6;
$sin[122]=6;
$sin[123]=6;
$sin[124]=5;
$sin[125]=5;
$sin[126]=5;
$sin[127]=4;
$sin[128]=4;
$sin[129]=5;
$sin[130]=5;
$sin[131]=3;
$sin[132]=3;
$sin[133]=4;
$sin[134]=3;
$sin[135]=2;
$sin[136]=2;
$sin[137]=2;
$sin[138]=2;
$sin[139]=2;
$sin[140]=3;
$sin[141]=1;
$sin[142]=2;
$sin[143]=1;
$sin[144]=1;
$sin[145]=2;
$sin[146]=1;
$sin[147]=1;
$sin[148]=1;
$sin[149]=1;
$sin[150]=0;
$sin[151]=0;
$sin[152]=0;
$sin[153]=0;
$sin[154]=0;
$sin[155]=0;
$sin[156]=0;
$sin[157]=0;
$sin[158]=0;
$sin[159]=0;
$sin[160]=1;
$sin[161]=0;
$sin[162]=0;
$sin[163]=1;
$sin[164]=0;
$sin[165]=0;
$sin[166]=0;
$sin[167]=1;
$sin[168]=0;
$sin[169]=0;
$sin[170]=0;
$sin[171]=0;
$sin[172]=0;
$sin[173]=1;
$sin[174]=0;
$sin[175]=0;
$sin[176]=0;
$sin[177]=0;
$sin[178]=0;
$sin[179]=0;
$sin[180]=0;

//=======================================================end of config setup============================



