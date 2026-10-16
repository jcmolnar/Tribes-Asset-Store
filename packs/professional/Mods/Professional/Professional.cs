// Tribes Professional by Desrtfox (February 2000) -- Modern Tribes (1.50) entry script.
// Everything below the echo is the author's professional.cs, unchanged: the server settings
// the readme describes (match rules, random events, random missions, team-kill limits).
// Auto-admin (scripts\AutoAdmin.cs, by Shane Hyde) is off until the host sets
// $Server::AutoAdmin[0] = "name"; and $Server::AutoAdminAddr[0] = "IP:a.b.c.d"; -- always set
// the address too: a name on its own makes anyone who uses that name a super admin.
// See Professional-readme.txt. Launch here:  -mod Professional
echo(">> Tribes Professional");

//$motd is the message of the day that is displayed on each clients connection.
$motd = "<f1><jc>Welcome to Dfox's server\n<f1><jc>Please download the Balanced and Opencall maps at either www.tribesplayers.com or www.primenet.com/~desrtfox\n<f1><jc>This server will be making heavy use of these maps.";	

$SHAntiTeamKillWarnKills = 1;
$SHAntiTeamKillBanTime = 600;
$SHAntiTeamKillMaxKills = 3;
$SHAntiTeamKillProximity = 50;

$TurretScore = "False"; //"True" Indicates players score points from their turret player kills.  "False" indicates being killed by a turret does not
                       //score points for the deployer of the turret.

$ActiveVotes = "False"; //True = Only yea's or nea's count.  Abstinations are ignored.  False = normal voting.

$match = "True";  //Set to True for match rules
	$SuicideSpawnPenaltyTime = 30;  //Seconds a player must wait to respawn if they suicided.
	$FlagValue = 20;
	$PreventionValue= 5;		//Bonus points for returning your flag.
	$KillValue = 1;
	$SwitchValue = 10;
	$MaximumScore = 0;	//Set to the number of points necc. to win.  Set to 0 for no limit.
	$LockedServer = "False";


$RandomEvents = "True";		//"True" Turns on random events, "False" Turns off random events
	$RandomEventTime=600;	//Seconds between random events
	$RandomTimeVariance = 0.25; //0 = no variance, 0.5 = 50% time variance, 1.0 = 100% time variance
	
	//Occasional Meteor Storms
	$Meteor="True";
		$MeteorDensity=0.5;  	//1 = normal, 0.5 = half as many meteors.
		$MeteorDuration = 120; 	//Seconds that the meteor storm lasts
		$MeteorAreaVariance = 0;//0 = Meteor count does not vary with land area for each map. 1= directly proportional to map area
		$MeteorWeight = 5;
		
	//Occasional radiation flares
	$SolarFlare="True";
		$SolarFlareDuration = 30;
		$SolarFlareWeight = 10;
	
	//Occasional Lightning
	$Lightning="True";
		$LightningDensity=0.5;  	//1 = normal, 0.5 = half as many strikes.
		$LightningDuration = 60; 	//Seconds that the lightning storm lasts
		$LightningAreaVariance = 0;//0 = Lightning strike count does not vary with land area for each map. 1= directly proportional to map area
		$LightningWeight = 10;   // 
	
$HaVoC::RandomMissions = TRUE;
$HaVoC::RandomMissionTypes["Capture the Flag"] = TRUE;
$HaVoC::RandomMissionTypes["Deathmatch"] = FALSE;
$HaVoC::RandomMissionTypes["Balanced"] = TRUE;
$HaVoC::RandomMissionTypes["Open Call"] = TRUE;
$HaVoC::RandomMissionTypes["Multiple Team"] = FALSE;
$HaVoC::RandomMissionTypes["Capture and Hold"] = FALSE;
$HaVoC::RandomMissionTypes["Find and Retrieve"] = FALSE;
$HaVoC::RandomMissionTypes["Defend and Destroy"] = FALSE;
$HaVoC::RandomMissionTypes["Kill the Rabbit"] = FALSE;
$HaVoC::RandomMissionTypes["Flag Hunter"] = FALSE;
$HaVoC::RandomMissionTypes["Team Deathmatch"] = FALSE;


$RestrictedMissions = "False";
$AllowedMission[Annihilator]=True;
$AllowedMission[CanyonCrusade]=True;
$AllowedMission[DarkAurora]=True;
$AllowedMission[MidnightMayhem]=True;
$AllowedMission[NightSlide]=True;
$AllowedMission[OlympusMons]=True;
$AllowedMission[OneSmallStep]=True;
$AllowedMission[PeakPerformance]=True;
$AllowedMission[Raindance]=True;
$AllowedMission[Rollercoaster]=True;
$AllowedMission[Stonehenge]=True;
$AllowedMission[SkaraBrae]=True;
$AllowedMission[Sulfurious]=True;
$AllowedMission["Spartacus'sGauntlet"]=True;
$AllowedMission[Supercross_2]=True;
$AllowedMission[TheLongWalk]=True;
$AllowedMission[Turbulence]=True;
$AllowedMission[TempleOfDoom]=True;
$AllowedMission[Valhalla]=True;


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

//$RandomNum::Number[0] = 0.1;
//$RandomNum::Number[1] = 0.1;
//$RandomNum::Number[2] = 0.1;
//$RandomNum::Number[3] = 0.1;
//$RandomNum::Number[4] = 0.1;
//$RandomNum::Number[5] = 0.1;
//$RandomNum::Number[6] = 0.1;
//$RandomNum::Number[7] = 0.1;