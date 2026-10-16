// ----- AAOD Admin Script -----
// ***********************************
// ** AAOD Server CONSOLE Functions **
// ***********************************
$TimeHrs=0;
$TimeMin=0;
$TimeSec=0;
//---------------------------------------------------------------------
function TraceAll()
{	$Console::LogMode = 1;
	echo("Turning Console Logging & Trace ON - Will Only WORK for Test Versions");
	$traceExp	= true;		// Trace Exp functions
	$tracedam	= true;		// Trace Damage Functions
	$traceveh	= true;		// Trace all vehicle functions
	$tracePwr	= true;		// Trace all Power Functions
	$traceTE	= true;		// Trace Team Energy Functions
	$traceObj	= true;		// Trace Object Creation etc.
	$trace		= true;		// All other Traces
	$testStuff	= true;		// Allows your own stuff to be killed

	$traceMsgs	= true;		// Shows all Messages in your Log...
	$traceAll	= true;		// Show All Crap That May Be affected by this Mod
}

function LogOff()
{	echo("Turning Console Logging $ Trace Off");
	$Console::LogMode = 0;
	$traceExp	= false;	// Trace Exp functions
	$tracedam	= false;	// Trace Damage Functions
	$traceveh	= false;	// Trace all vehicle functions
	$tracePwr	= false;	// Trace all Power Functions
	$traceTE	= false;	// Trace Team Energy Functions
	$traceObj	= false;	// Trace Object Creation etc.
	$trace		= false;	// All other Traces
	$testStuff	= false;	// Allows your own stuff to be killed

	$traceMsgs	= false;	//	Shows all Messages in your Log...
	$traceAll	= false;	// Show All Crap That May Be affected by this Mod

}

function LogMin()
{	echo("Turning Traces Off - Leaving Log On");
	$Console::LogMode = 1;
	$traceExp	= false;	// Trace Exp functions
	$tracedam	= false;	// Trace Damage Functions
	$traceveh	= false;	// Trace all vehicle functions
	$tracePwr	= false;	// Trace all Power Functions
	$traceTE	= false;	// Trace Team Energy Functions
	$traceObj	= false;	// Trace Object Creation etc.
	$trace		= false;	// All other Traces
	$testStuff	= false;	// Allows your own stuff to be killed

	$traceMsgs	= true;		//	Shows all Messages in your Log...
	$traceAll	= false;	// Show All Crap That May Be affected by this Mod
}

function ReConfig()
{	echo("Re-Loading the AAOD Configuration File");
	exec("AAOD_cfg.cs");
	UpdateFile();
}

function ReFreshExp()
{	echo("Re-Loading the AAOD_Players.cs Experience tracking file");
	exec("AAODPlayers.cs");
}


function SWarn()
{	%msg="<jc><f1>**** The Server is About to go Down ****\n";
	%msg=%msg@"This could be because a new Patch is being Loaded\n";
	%msg=%msg@"Quit NOW to Save your EXP Levels!!\n" ;
	%msg=%msg@"You should be Able to RE-Connect Immediately!!";
	centerprintall(%msg,8);
	UpdateFile();
}

function SBDown()
{	%msg="<jc><f1>**** The Server is About to go Down ****\n";
	%msg=%msg@"Because of problems in the MOD the SERVER\n";
	%msg=%msg@"Has Become Un-Stable\n";
	%msg=%msg@"Quit NOW to Save your EXP Levels!!\n" ;
	%msg=%msg@"Please Check back in 5-10 Minutes!!\n";
	%msg=%msg@"*** THANK YOU & PLEASE COME AGAIN ***";
	centerprintall(%msg,8);
	UpdateFile();
}

function SDown()
{	%msg="<jc><f1>**** The Server is About to go Down ****\n";
	%msg=%msg@"Probably because of other Server obligations\n";
	%msg=%msg@"This server runs most weeknights and weekends.\n";
	%msg=%msg@"Quit NOW to Track your kills & Exp!\n" ;
	%msg=%msg@"*** THANK YOU & PLEASE COME AGAIN ***";
	centerprintall(%msg,8);
	UpdateFile();
}

function Sok()
{	%msg="<jc><f1>**** ALL-RIGHT ****\n";
	%msg=%msg@"Please Let me know When is a good time\n";
	%msg=%msg@"to reset the server\n";
	%msg=%msg@"*** Thank you for your understanding ***";
	centerprintall(%msg,8);
	UpdateFile();
}

function SPlay()
{	%msg="<jc><f1>**** HEY!! ****\n";
	%msg=%msg@"Play Nice or Play somewhere else\n";
	%msg=%msg@"TeamKillers are HUNTED on this server\n";
	%msg=%msg@"You will also be tracked by your IP & ISP!" ;
	centerprintall(%msg,8);
	UpdateFile();
}

function SNotice()
{	%msg="<jc><f1>** NOTICE **\n";
	%msg=%msg@"This Server is TESTING Mod Stuff!!\n";
	%msg=%msg@"Server May become Unstable and some things may not work\n";
	%msg=%msg@"Check OUT www.bdtech.net/aaod for info on the MOD\n";
	%msg=%msg@"Pls: Report any Bugs to Valya[AAOD]\n";
	%msg=%msg@"*** Thank you ***";
	centerprintall(%msg,8);
	UpdateFile();
}

function Ssound()
{	%msg="<jc><f1>** NOTICE **\n";
	%msg=%msg@"This Mod Has New Sounds!!\n";
	%msg=%msg@"GOTO www.bdtech.net/aaod and download the AAODSFX1 sound pack.\n";
	%msg=%msg@"to get the full experience offered by this MOD\n";
	%msg=%msg@"*** Thank you ***";
	centerprintall(%msg,8);
	UpdateFile();
}

function Status()
{	%msg="<jc><f1>** Sorry to Barge in Like this **\n";
	%msg=%msg@"I Need to know Has the Server Been running ok???\n";
	%msg=%msg@"Any wierd errors etc... If you dont tell me I cant fix them!!\n";
	%msg=%msg@"Please respond using the global Chat (usually 'T')\n";
	%msg=%msg@"*** Thank you ***";
	centerprintall(%msg,8);
}

function ExportStats()
{	ExportPlayerInfo("Good");
}

function ExportBad()
{	ExportPlayerInfo("Bad");
}

function ExportPlayerInfo(%Request)
{	if($ExportingStats==true) 
	{	echo("Unable to Export Stats Already Exporting Them!");
		return;
	}
	$ExportingStats=true;
	UpdateStats();
	
	if(%Request=="Good")
	{	echo("EXPORTING Players Stats to 'SERVERSTATS.TXT' ......................");
		$AAODExportFile="temp\\ServerStats.txt";
		$ED=";Player Name;Score;EXP Gained;EXP Lost;Base Exp;Lvl;Kills;Deaths;Caps;Repair;Notes;BOUNTY;Team Kills;";
	}
	else if(%Request=="Bad")
	{	echo("EXPORTING Players Stats to 'BadPlayers.TXT' ......................");
		$AAODExportFile="temp\\BadPlayers.txt";
		$ED=";Player Name;Notes;Team Kills;";
	}
	else
		return;

	export("ED", $AAODExportFile, false);

	for (%i=100;%i<($AAOD::ANum+100);%i++)
	{	PlayerStats(%i,"","Export"@%Request);
		if ($ED != "") 
		{	export("ED", $AAODExportFile, true);
		}
	}
	$ExportingStats=false;
	echo("Finished Exporting Player Stats .....................");
}

function purge(%num,%track,%admin,%sadmin)
{	if(%track==false || %admin==true || %sadmin==true) return %num;
	echo("Purging PLayer # ",%num);
	for(%j=%num;%j<($AAOD::ANum+100);%j++)
	{	%k=%j+1;
		$AAOD::Stat[%j]=$AAOD::Stat[%k];
		$AAOD::Name[%j]=$AAOD::Name[%k];
	}
	$AAOD::ANum--;
	%num--;
	return(%num);
}

function WhoIsUser(%userId)
{	echo("User ",%userId," is ",$AAOD::Name[%userId]);
}

function WhoIsClient(%client)
{	echo("Client ",%client," is  UserID# ",%client.UserId," Name: ",$AAOD::Name[%client.UserId]);
}

function RemoveUser(%userId)
{	echo("Purging User ",%userId," Named ",$AAOD::Name[%userId]);
	Purge(%userId,true,false,false);
}

function ResetPlayers()
{	%numPlayers = getNumClients();
	if(%numPlayers==0)
	{	for (%i=100;%i<($AAOD::ANum+100);%i++)
		{	%name=$AAOD::Name[%i];
			PlayerStats(%i,"","ReSet");
		}
		UpdateFile();
		return(true);
	}
	else
	{	echo("Unable to run RESET.. Players connected to server - Will Try Again in 5 Min");
		schedule("ResetPlayers();",300);
		return (false);
	}
		
}


function UpdateStats()
{	echo("Saving Current Players information to Player DataBase..................");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		AAOD_LeaveGame(%cl);
	
	UpdateFile();
}

function UpdatePlayers()
{	// Check for players
	echo("Updating AAODPLayers.cs File to Meet Ver ",$ver," Format");
	for (%i=100;%i<($AAOD::ANum+100);%i++)
	{	echo("Updating Player ",$AAOD::Name[%i]);
		PlayerStats(%i,"","Update");
	}
	echo("Update Complete..........writing to file.");
	UpdateFile();
}


function PurgePlayers()
{	%numPlayers = getNumClients();
	if(%numPlayers==0)
	{	for (%i=100;%i<($AAOD::ANum+100);%i++)
		{	%i=PlayerStats(%i,"","PurgeCheck");
		}
		UpdateFile();
	}
	else
	{	echo("Unable to run Purge.. Players connected to server - Will Try Again in 5 Min");
		schedule("PurgePlayers();",300);
	}
}

function Lock()
{	$Server::Password=$LockPassword;
}

function Unlock()
{	$Server::Password="";
}

function PlayerStats(%UserId,%ClientId,%Request)
{	%name=$AAOD::Name[%UserId];
	%d1=GetWord($AAOD::Stat[%UserId],0);		// Admin (true or False)
	%d2=GetWord($AAOD::Stat[%UserId],1);		// Super - Admin (true or False)
	%d3=GetWord($AAOD::Stat[%UserId],2);		// Password
	%d4=GetWord($AAOD::Stat[%UserId],3);		// AAOD Help
	%d5=GetWord($AAOD::Stat[%UserId],4);		// Tracking ... Dont Purge anyone who is set to false We dont want to have to keep resetting them
	%d6=GetWord($AAOD::Stat[%UserId],5);		// ExpGain
	%d7=GetWord($AAOD::Stat[%UserId],6);		// ExpLoss
	%d8=GetWord($AAOD::Stat[%UserId],7);		// Kills
	%d9=GetWord($AAOD::Stat[%UserId],8);		// Deaths
	%d10=GetWord($AAOD::Stat[%UserId],9);	// # of Visits
	%d11=GetWord($AAOD::Stat[%UserId],10);	// # of Flag Caps
	//------- New For Ver 1.6a
	%d12=GetWord($AAOD::Stat[%UserId],11);	// # of Team Kill Kicks
	%d13=GetWord($AAOD::Stat[%UserId],12);	// True/False Wether Player has been Banned for Teamkilling
	//------- New For Ver 1.6d
	%d14=GetWord($AAOD::Stat[%UserId],13);	// Bounty
	if(%d14 <= 0 || %d14 > $MaxBounty) %d14=1;
	//------- New For Ver 1.6e
	%d15=GetWord($AAOD::Stat[%UserId],14);	// # of Damage Points Repaired
	if(%d15 <=0) %d15=0;
	
	if(%Request=="PurgeCheck")
	{	if((%d13 != "true" && %d5 != "false") && (%d6<=$MinExp && %d7<=$MinExp))	// If PLayer has Not Been Banned or Is Not Locked then...
		{	echo($Ver,"|Removing  '",%name,"' from the Tracking DataBase");
			%UserId = Purge(%UserId,%d5,%d1,%d2);
			Return (%UserId);
		}
	}
	else if(%Request=="Update")
	{	echo($Ver,"|UPDATED Stats for '",%name,"' to Current Version ",$Ver);	
	}
	else if(%Request=="ReSet")
	{	echo($Ver,"|Resetting Exp Stats for '",%name,"'");
		%d6=0;	// ExpGain
		%d7=0;	// ExpLoss
		%d8=0;	// Kills
		%d9=0;	// Deaths
		%d11=0;	// # of Flag Caps
		%d12=0;	// Tk Kicks
		%d14=0;	// Bounty
		%d15=0;	// Repair Points
		
	}
	else if(%Request=="ExportGood")
	{	if(%d9==0 || %d8==0)
			%ratio=0;
		else
			%ratio=(%d8/%d9);
		%score=(%d6-%d7)+%ratio*55;
		%Exp = %d6-%d7;
		%lvl = GetPlayerLevel(%Exp);
		%notes="";
		if (%d1=="true") %notes="Admin ";
		if (%d2=="true") %notes=%notes@"SuperAdmin ";
		if (%d12>0) %notes=%notes@"TEAMKILLER! ";
		
		if (((%d6!=0 && %d7!=0) || $ExportAll) && %d5=="true" && %d13=="false") // If There are EXP Pts Or Export All is selected and He is not locked & not Banned
		{	$ED=";"@$AAOD::Name[%UserId]@";"@ %score @ ";" @ %d6 @ ";" @ %d7 @";"@ %Exp @";"@ %Lvl@";"@%d8@";"@%d9@";"@%d11@";"@%d15@";"@%notes@";"@%d14@";"@%d12@";";
			echo("Exporting Player Stats for:",%name);
		}
		else
			$ED="";

		return;
	}
	else if(%Request=="ExportBad")
	{	%Exp=0;
		%Score=0;
		%d6=0;	// ExpGain
		%d7=0;	// ExpLoss
		%d8=0;	// Kills
		%d9=0;	// Deaths
		%d11=0;	// # of Flag Caps
		%d12=0;	// Tk Kicks
		%d14=0;	// Bounty
		%d15=0;	// Repair Points
		%notes="";
		if (%d1=="true") %notes="Admin ";
		if (%d2=="true") %notes=%notes@"SuperAdmin ";
		if (%d12>0) %notes=%notes@"TEAMKILLER! ";
		if (%d5=="false") %notes=%notes@"EXP Not Tracked for This Player ";
		if (%d13=="true") %notes=%notes@"This PLAYER Has Been BANNED from This Server ";
		
		if (%d5=="false" || %d13=="true" || %d12>0)	// If His EXP Are Locked or He is Banned Or He has TeamKilled he/she is a bad boy!!!
		{	echo("Exporting BAD PLayer '",%name,"'");
			$ED=";"@$AAOD::Name[%UserId]@";"@ %Notes@";"@%d12@";";
		}
		else
			$ED="";

		return;
	}
	else if(%Request=="UpdateUser")
	{	echo($Ver,"|SAVING Exp Stats for User :",%UserId," '",%name,"'  client ",%clientId);
		%d1		= %clientId.isAdmin;
		%d2		= %clientId.isSuperAdmin;
		%d4		= %clientId.Help;
		%d6		= %clientId.expGain;
		%d7		= %clientId.expLoss;
		%d8		= %clientId.tKills;
		%d9		= %clientId.tDeaths;
		%d10	= %clientId.Visit;
		%d11	= %clientId.FCaps;
		%d12	= %clientId.tkick;
		%d13	= %clientId.banned;
		%d14	= %clientId.bounty;
		%d15	= %clientId.Repair;
		
	}
	else if (%Request=="LoadStats")
	{	if(%d1 || %d2)	// User Supposedly Has Admin Rights Verify.
		{	remoteEval(%clientId,"SendPwd");												// Call clients system to submit PWD
			schedule("VerifyAdmin("@%clientId@","@%d1@","@%d2@","@%d3@");",5,%clientId);	// Schedule The Verification for 5 Seconds from now... 
		}																				// (Allows time for client to process request)
		%clientId.Help		= %d4;
		%clientId.ExpGain	= %d6;
		%clientId.ExpLoss	= %d7;
		%clientId.tKills	= %d8;
		%clientId.tDeaths	= %d9;
		%clientId.visit		= %d10;
		%clientId.fCaps		= %d11;
		%clientId.tkick		= %d12;
		%clientId.bounty	= %d14;
		%clientId.banned	= %d13;
		%clientId.Repair	= %d15;

		if(%d5==false || $TrackExp==3)	// Experience is Either NOT carried forward for this Player or Globally
			%clientId.expaqrd=0;
		else							// Experience for this User is Carried forward
		{	%clientId.expaqrd	=%clientId.expGain-%clientId.expLoss;
			if (%clientId.expaqrd>$MaxExpPts)
				%clientId.expaqrd=$MaxExpPts;
			else if(%clientId.expaqrd<0)
				%clientId.expaqrd=0;
		}
		return;
	}

	$AAOD::Stat[%UserId]=%d1 @" "@ %d2 @" "@ %d3 @" "@ %d4 @" "@ %d5 @" "@ %d6 @" "@ %d7 @" "@ %d8 @" "@ %d9 @" "@ %d10 @" "@ %d11 @" "@ %d12 @" "@ %d13@" "@%d14@" "@%d15;
	
	return (%UserId);
}
	
function StartClock()
{	ShowClock();
}

function ShowClock()
{	AAOD_TimeStamp();
	schedule("ShowClock();",300);
}
			
//$LastTime=0;

function AAOD_TimeStamp()	// PORT: was TimeStamp -- timeStamp is an engine command in 1.50 (build date); this one prints the server up-time
{	%TimeMin=0;
	%TimeHrs=0;
	%TimeSec=GetSimTime();
	%i=String::findSubStr(%TimeSec, ".");
	if(%i > 0)
		%TimeSec=String::getSubStr(%TimeSec,0,%i);
	%Timemin=(%TimeSec/60);
	%i=String::findSubStr(%Timemin, ".");
	if(%i >0)
		%Timemin=String::getSubStr(%Timemin,0,%i);
	if (%Timemin>0)
	{	%TimeSec=%TimeSec-%Timemin*60;
		%Timehrs=%TimeMin/60;
		%i=String::findSubStr(%TimeHrs, ".");
		if(%i > 0)
			%TimeHrs=String::getSubStr(%TimeHrs,0,%i);
		if (%Timehrs>0)
			%TimeMin=%TimeMin-%TimeHrs*60;
	}

	echo($Ver,"|************ TIME STAMP SERVER TIME (Hrs:Min:Sec) ",%TimeHrs,":",%TimeMin,":",%TimeSec," ***************");
	//$LastTime=GetSimTime();
}
			



