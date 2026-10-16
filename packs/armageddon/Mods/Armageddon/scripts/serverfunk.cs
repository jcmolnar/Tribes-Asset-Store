// This is a backup server.cs file just in case one fails this is a backup (lol)
exec(admin);
exec("botinfo.cs");

$JoinSay["{||*||w00||*||}Q"] =  "Bow and have reverance <f0>* * *\n<f1> Welcome <f0>{||*||w00||*||}Q \n<f0>* * *<f1> Alas ! What we do in life, echoes in Eternity<f0> * * * ";
$JoinSay["|*|eViL iDiOt|*|"] = "Please point and laugh at <f0>|*|eViL iDiOt|*|<f1> * * * \n<f1> For he is <f2> Resident Motivator !";
$JoinSay["|*|Extra Newb|*|"] = "Please point and laugh at <f0>|*|Extra Newb|*|<f1> * * * \n<f1> For he is <f2> Resident Motivator !"; 
$JoinSay["|=(w00)=|][ron"] = "Well Damn, Look who it is <f0>|=(w00)=|][ron<f1> * * * \n<f1> Prepare to be dissed by <f2>THE FIST !";
$JoinSay["[GL] GUNDAM X0"] = "Well Damn, Look who it is <f0>" @ Client::getName(%clientId) @"<f1> * * * \n<f1> All pay heed for here comes <f2>BIG DADDY GUNDAM!";
$JoinSay["|-(w00)-|Fyre"] = "Wise man says: Live in fear of - <f0>|-(w00)-|Fyre<f1> * * * \n<f2> FOR HE SHALL KICK THY ASS !";
$JoinSay["|*|w00|*|Grey"] = "Wise man says: Live in fear of - <f0>|*|w00|*|Grey<f1> * * * \n<f2> FOR HE SHALL KICK THY ASS !";
$JoinSay["|=(w00)=| X"] = "Wise man says: I think - <f0>|=(w00)=| X is unwise !!!<f1> * * * \n<f1> For he says :<f2> Behold the power of cheese....!";
$JoinSay["=(w00)=Krillin"] = "Yo Homies give a big WASSUP to - <f0>=(w00)=Krillin<f1> * * * \n<f1> Be VERY afraid for =(w00)=Krillin is the leader of the top secret<f2> Black-Ops Sector!";
$JoinSay["=(w00)=Vegaman"] = "ENTER - <f0>=(w00)=Vegaman<f1> * * * \n<f2>THE DARK-SIDE JUST TURNED BLACK... ";
$JoinSay["|*|w00|*|Ghost K"] = "HEY HEY HEY Please Welcome - <f0>|*|w00|*|Ghost K<f1> * * * \n<f1>Ladies and Gentlemen<f2> ITS DYING TIME!!!";
$JoinSay["|*|w00|*|GFOD"] = "LOOK OUT here comes - <f0>|*|w00|*|GFOD<f1> * * * \n<f1>The GOD FATHER OF<f2> DEATH";
$JoinSay["|*|w00|*|Beast"] = "LOOK OUT here comes - <f0>|*|w00|*|Beast<f1> * * * \n<f1>Watch out for his <f2>Amazin Stuff!\n<f0>You can't say you were not warned, I'm superdeformed! Altered Beast is has arrived.";
$JoinSay["|=(w00)=|p0p"] = "Friends, Romans, Countrymen... Let me introduce - <f0>|=(w00)=|p0p<f1> * * * \n<f1>Watch out for his <f2>w00gie!\n<f0>He just Bent it";
$JoinSay["|=(w00)=|Valiant"] = "Friends, Romans, Countrymen... Let me introduce - <f0>|=(w00)=|Valiant<f1> * * * \n<f2>LORD OF THE RIFLES";
$JoinSay["[GL]VRWarper"] = "INCOMING!!! - <f0>[GL]VRWarper<f1> * * * \n<f2>Hell's doors has just opened!"; //== hehhehe i luv this one =D

function showmode()
{
	if($ScanMode)
	{
		echo($adminbotname@": Mode is Currently Scanning.");
	}
	else
	{
		echo($adminbotname@": Scan Mode is currently inactive");
	}
}
function OutPutBotInfo()
{
	showserveruptime();
	%numClients = getNumClients();
	messageall(3,$adminbotname @": Version :: ["@$botversion@"] ~wmine_act.wav");
	messageall(3,$adminbotname @": Server Name :: ["@ $Server::HostName@"]~wmine_act.wav");
	messageall(3,$adminbotname @": Current Connections :: ["@%numClients@"]~wmine_act.wav");
	messageall(3,$adminbotname @": Saved Characters :: ["@$botsaved@"]~wmine_act.wav");
	messageall(3,$adminbotname @": Current Up-Time :: "@$uptime);
}
function Server::onClientConnect(%clientId)
{
      //starttimer2(%clientId);
	%clname = Client::getName(%clientId); 
	%ratio2 = floor((%clientId.TotalKills/(%clientId.TotalKills + %clientId.TotalDeaths))*100);		
	%kills2 = %clientId.TotalKills;
	%deaths2 = %clientId.TotalDeaths;		
	$TAC::KeepSmurfLog = "true";	
	$warn = false;	
	if(%clientId.connections == "")
	{
		%clientId.connections  = 1;
	}
	else
	{
		echo("Adding Connection");
		%clientId.connections  = %clientId.connections  + 1;
	}

	//== VRWarper's REMODEL!! =D
	if($JoinSay[Client::getName(%clientId)] != "")	
	{
		centerprintall("<jc><f0>* * * <f1> "@$JoinSay[Client::getName(%clientId)], 15);
	}
	if($VRBot::Enabled)
		processConClient(%clientId);

	//== Start of smurfing shit :'(
		
	if($ScanMode)
	{
		messageall(1,$adminbotname@": Scanning.........");
		ScanName(%clientId);
	}

	%clname = Client::getName(%clientId);
	%clip = Client::getTransportAddress(%clientId);
	%clip2 = Client::getTransportAddress(%clientId);
	%cl = Client::getName(%clientId);

	for(%i=0;$Grey::Number[%i] != "";%i++)
	{
	}
	$Grey::Number[%i] = %cl;

	for(%i=0;$Grey::IP[%i] != "";%i++)
	{
	}
	$Grey::IP[%i] = %clip;
	
     	%sn = "Evil's Name and Ip logger";
	$SP = "***//***-----------------------------SPACER--------------------------***\\***";   
	$GreyDawn::Connection = ""@%cl@" @ "@%clip@" ["@$CurrentTime@"] ["@$CurrentDate@"]";
	echo(%sn @ " Is Getting Information On : " @ Client::getName(%clientId));
	export("$GreyDawn::Connection", "config\\connectionlog.txt" , true);
	echo("Name and IP for : " @ %cl @ " have been logged successfully");

	if($TAC::KeepSmurfLog == "true")
   		AddSmurfRecord(Client::getName(%clientId),Client::getTransportAddress(%clientId));
		
	CheckTagBan(%clientid);
	CheckTagBan2(%clientid);
	CheckNameBan(%clientId);
	SHCheckAutoAdmins(%clientId);
	CheckName(%clientId);
	CheckIP(%clientId);
	connectionlogger(%clientId);
	
	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
	{
		// force admin the loopback dude
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	SHCheckTransportAddress(%clientid);
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

	for(%i=0;$SHBanListName[%i] != "";%i++)
	{
		if(String::findSubStr(%clname,$SHBanListName[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			messageall($adminbotname@": "@%clname@" is marked BANNED and may not enter.");
			schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
			return;
		}
	}
	if((Client::getName(%clientId)) == "-1" || (Client::getName(%clientId)) == " " || (Client::getName(%clientId)) == "  " || (Client::getName(%clientId)) == "   " || (Client::getName(%clientId)) == "    " || (Client::getName(%clientId)) == "     " || (Client::getName(%clientId)) == "      ")
	{
		schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
	}
	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey, $ModInfo);
	remoteEval(%clientId, MODInfo, "<f0>Meltdown  <f1>v w00<f2>\n<f1>Current Date: <f2>"@$CurrentDate@" <f1>Current Time: <f2>"@$CurrentTime@"\n<f1>THE<f0> MD V W00 <f1> DEVELOPMENT TEAM\n<f1>|*|w00|*|Grey <f0> || <f1>[GL]VRWarper <f0> ||<f1> ThE eViL iDiOt <f0>||<f1> [GL]JadaCyrus");

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";
	schedule("Client::Update(" @%clientId@ ");", 20);
	Game::onPlayerConnected(%clientId);
}
function scoreupdate()
{
	echo("Saving Scores");
	saveall();
}

function greybot(%clientId)
{
	%clname = Client::getName(%clientId);
	messageall(1, $adminbotname @ ": "@%clname@" is a registered user... ~wmine_act.wav");
	messageall(1, $adminbotname @ ": "@%clname@" has connected "@%clientId.TotalConnections@" times. ~wmine_act.wav");
	DisplaySmurfbot(%clientId);
	CheckClanAdmin(%clientId);
}
function greybot2(%clientId)
{
	%clname = Client::getName(%clientId);
	DisplaySmurfbot(%clientId);
	CheckClanAdmin(%clientId);
}

function DisplaySmurfbot2(%clientId)
{
	if($TAC::KeepSmurfLog = "true")
	{
			//Find smurf userid
			%name = Client::getName(%clientId);
			for(%i=1;%i < $SmurfCount+1;%i++)
			{
				if($SmurfRecord[%i,0] == %name)
				{
					%userid = %i;
					%i = $SmurfCount+2;
				}
			}

			//Get known aliases
			if($SmurfRecord[%userid,1] == "")
			{
				%exactmatch = "No Matches Found";
			}
			else
			{
				%clientId.isSmurf = true;
				%count = 1;
				for(%i=0;%i < %count;%i++)
				{
					%count++;
					if((getWord($SmurfRecord[%userid,1],%i) != "") && (getWord($SmurfRecord[%userid,1],%i) != -1))
						if(%exactmatch == "")
							%exactmatch = $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
						else
							%exactmatch = %exactmatch @ " | " @ $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
					else
						%i = %count + 1;
				}
			}
			echo($adminbotname @": "@Client::getName(%clientId)@" possible aliases are: "@ %exactmatch);
		}
	
}
function DisplaySmurfbot(%clientId)
{
	if($TAC::KeepSmurfLog = "true")
	{
			//Find smurf userid
			%name = Client::getName(%clientId);
			for(%i=1;%i < $SmurfCount+1;%i++)
			{
				if($SmurfRecord[%i,0] == %name)
				{
					%userid = %i;
					%i = $SmurfCount+2;
				}
			}

			//Get known aliases
			if($SmurfRecord[%userid,1] == "")
			{
				%exactmatch = "No Matches Found";
			}
			else
			{
				%clientId.isSmurf = true;
				%count = 1;
				for(%i=0;%i < %count;%i++)
				{
					%count++;
					if((getWord($SmurfRecord[%userid,1],%i) != "") && (getWord($SmurfRecord[%userid,1],%i) != -1))
						if(%exactmatch == "")
							%exactmatch = $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
						else
							%exactmatch = %exactmatch @ " | " @ $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
					else
						%i = %count + 1;
				}
			}
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isSuperAdmin)
				{	
					Client::Sendmessage(%cl,1,$adminbotname @": "@ Client::getName(%clientId) @ "'s possible aliases are:");
					Client::SendMessage(%cl,1,$adminbotname @": "@%exactmatch@" ~wmine_act.wav");
					echo($adminbotname @": "@Client::getName(%clientId)@" possible aliases are: "@ %exactmatch);
				}
			}
		}
	
}
function infosave(%clientId)
{
		
%kills2 = %clientId.TotalKills;
%deaths2 = %clientId.TotalDeaths;
if((%kills2 + %deaths2) >= 1) {
   %ratio2 = floor((%kills2/(%kills2 + %deaths2))*100);
   }
   	else{
   		%ratio2 = "0";
   	}
	
%clname = Client::getName(%clientId);
echo("Registered User Logged On - Displaying Info");
bottomprintall("<jc><f1>* * * <f2>"@$adminbotname@" C L I E N T  I N F O <f1>* * *\n<f0>Name: <f1>" @ %clname @ " \n<f0>Overall Kills: <f1>[ "@%kills2@" ]\n<f0>Overall Deaths: <f1>[ "@%deaths2@" ]\n<f0>Overall Efficiency : <f1>[ "@%ratio2@"% ]", 0);
}
function Client::Inform(%clientId)
{
 %clname = Client::getName(%clientId);
 bottomprintall("<jc><f1>" @ %clname @ " <f0>has had his/her name and IP logged for reference");
}
function Client::Update(%clientId)
{
 
	if ($warn == "true")
	{
	Client::Inform(%clientId);
	}
	else
	{
	}
  
}

function LoadSmurfRecord()
{
	
	exec("smurflog.cs");
	echo("Smurf Logger Active");
	%smurfcount = 2;
	for(%i=1;%i < %smurfcount;%i++)
	{
		if($SmurfRecord[%i,0] != "")
		{
			%smurfcount++;
		}
	}
	$SmurfCount = %smurfcount - 2;
}

function AddSmurfRecord(%name,%ip)
{
	TACSmurfTimer(false);
	echo("Active - Smurf Logger");
	if(!String::NCompare(%ip, "LOOPBACK", 8))
	{
		//Ignore Loopback dude
	}
	else
	{
		%rawip = TACConvertIP(%ip);

		//If Current User already exists replace & update data
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] == %name)
			{
				%currentid = %i;
				%i = %counter + 1;
			}
			else if($CurrentSmurfRecord[%i,0] == "")
			{
				%currentid = %i;
				%i = %counter + 1;
			}
		}
		$CurrentSmurfRecord[%currentid,0] = %name;
		$CurrentSmurfRecord[%currentid,1] = %rawip;
		$CurrentSmurfRecord[%currentid,2] = $Gametimersixth+6;

		//Compare Other Current Smurfs and add to record if match
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] != "")
			{
				if(CompareSmurfRecords(%currentid, %ip, %i))
				{
					AddNewSmurfMatch(%currentid, %i);
					%i = %counter + 1;
				}
			}
			else
			{
				%i = %counter + 1;
			}
		}
	}
}

function AddNewSmurfMatch(%currentid, %match)
{
	//If Smurf User does not exist then add them
	%name = $CurrentSmurfRecord[%currentid,0];
	%foundname = false;
	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%foundname = true;
			%userid = %i;
			%i = $SmurfCount + 1;
		}
	}
	if(!%foundname)
	{
		$SmurfCount = $SmurfCount + 1;
		%userid = $SmurfCount;
		$SmurfRecord[%userid,0] = %name;
	}

	//If Smurf Match does not exist then add them
	%name = $CurrentSmurfRecord[%match,0];
	%foundname = false;
	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%foundname = true;
			%usermatchid = %i;
			%i = $SmurfCount + 1;
		}
	}
	if(!%foundname)
	{
		$SmurfCount = $SmurfCount + 1;
		%usermatchid = $SmurfCount;
		$SmurfRecord[%usermatchid,0] = %name;
	}

	for(%i=1;%i < $SmurfCount+1;%i++)
	{
		if($SmurfRecord[%i,0] == %name)
		{
			%usermatchid = %i;
			if(!CompareKnownSmurfs(%userid, %usermatchid))
			{
				//Add all smurf ids to userid
				if($SmurfRecord[%userid,1] == "" && $SmurfRecord[%usermatchid,1] == "")
					$SmurfRecord[%userid,1] = %usermatchid;
				else if($SmurfRecord[%userid,1] == "" && $SmurfRecord[%usermatchid,1] != "")
					$SmurfRecord[%userid,1] = $SmurfRecord[%usermatchid,1] @ " " @ %usermatchid;
				else
					$SmurfRecord[%userid,1] = $SmurfRecord[%userid,1] @ " " @ %usermatchid;

				//Add userid to matched user
				if($SmurfRecord[%usermatchid,1] == "" && $SmurfRecord[%userid,1] == "")
				{
					%adduserid = %userid;
					$SmurfRecord[%usermatchid,1] = %userid;
				}
				else if($SmurfRecord[%usermatchid,1] != "" && $SmurfRecord[%userid,1] != "")
				{
					$SmurfRecord[%usermatchid,1] = $SmurfRecord[%usermatchid,1] @ " " @ %userid;
					%adduserid = %userid;
				}
				else
				{
					%adduserid = %usermatchid;
					$SmurfRecord[%usermatchid,1] = %userid;
					%count = 1;
					for(%j=0;%j < %count;%j++)
					{
						%count++;
						if((getWord($SmurfRecord[%userid,1],%j) != "") && (getWord($SmurfRecord[%userid,1],%j) != -1))
						{
							if(getWord($SmurfRecord[%userid,1],%j) != %usermatchid)
								$SmurfRecord[%usermatchid,1] = $SmurfRecord[%usermatchid,1] @ " " @ getWord($SmurfRecord[%userid,1],%j);
						}
						else
							%j = %count+1;
					}

				}


				//Add userid to all other smurf records
				%count = 1;
				for(%j=0;%j < %count;%j++)
				{
					%count++;
					if((getWord($SmurfRecord[%usermatchid,1],%j) != "") && (getWord($SmurfRecord[%usermatchid,1],%j) != -1))
					{
						if(getWord($SmurfRecord[%usermatchid,1],%j) != %userid)
							$SmurfRecord[getWord($SmurfRecord[%usermatchid,1],%j),1] = $SmurfRecord[getWord($SmurfRecord[%usermatchid,1],%j),1] @ " " @ %adduserid;
					}
					else
						%j = %count+1;
				}
			}
			%i = $SmurfCount + 1;
		}
	}
}

function remoteAbility(%client,%clientId,%smurfkey)
{
	if(%smurfkey)
		%client.SmurfKey = true; // PORT: was %clientId, an object id chosen by the caller
}

function CompareSmurfRecords(%Smurf1ID, %ip, %Smurf2ID)
{
	//This function returns the following data
	//	false = no match or same ID
	//	true = Exact IP Match

	%data = false;
	if(%Smurf1ID != %Smurf2ID)
	{
		%exactmatch = false;
		%count = 1;
		for(%i=0;%i < %count;%i++)
		{
			%count++;
			if((getWord($CurrentSmurfRecord[%Smurf2ID,1],%i) != "") && (getWord($CurrentSmurfRecord[%Smurf2ID,1],%i) != -1))
			{
				if(TACCompareIP(getWord($CurrentSmurfRecord[%Smurf2ID,1],%i),%ip))
				{
					%exactmatch = true;
					%data = true;
					%i = %count+1;
				}
			}
			else
				%i = %count+1;
		}
	}
	return %data;
}

function CompareKnownSmurfs(%Smurf1ID, %Smurf2ID)
{
	//This function returns true if this is an existing known smurf
	%existing = false;
	%count = 1;
	for(%i=0;%i < %count;%i++)
	{
		%count++;
		if((getWord($SmurfRecord[%Smurf2ID,1],%i) != "") && (getWord($SmurfRecord[%Smurf2ID,1],%i) != -1))
		{
			if(getWord($SmurfRecord[%Smurf2ID,1],%i) == %Smurf1ID)
			{
				%existing = true;
				%i = %count+1;
			}
		}
		else
			%i = %count+1;
	}
	return %existing;
}

function RotateSmurfLog(%time)
{
	if($TAC::KeepSmurfLog = "true")
	{
		//get number of smurfs in current list
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] == "")
			{
				%maxcurrent = %i-1;
				%i = %counter + 1;
			}
		}
		%counter = 2;
		for(%i=1;%i < %counter;%i++)
		{
			%counter++;
			if($CurrentSmurfRecord[%i,0] != "")
			{
				if($CurrentSmurfRecord[%i,2] < %time)
				{
					if(%i != %maxcurrent)
					{
						$CurrentSmurfRecord[%i,2] = $CurrentSmurfRecord[%maxcurrent,2];
						$CurrentSmurfRecord[%i,1] = $CurrentSmurfRecord[%maxcurrent,1];
						$CurrentSmurfRecord[%i,0] = $CurrentSmurfRecord[%maxcurrent,0];
						$CurrentSmurfRecord[%maxcurrent,2] = "";
						$CurrentSmurfRecord[%maxcurrent,1] = "";
						$CurrentSmurfRecord[%maxcurrent,0] = "";
						%maxcurrent = %maxcurrent - 1;
					}
					else
					{
						$CurrentSmurfRecord[%i,2] = "";
						$CurrentSmurfRecord[%i,1] = "";
						$CurrentSmurfRecord[%i,0] = "";
					}
				}
			}
			else
				%i = %counter + 1;
		}
	}
}

function BackupSmurfRecord()
{
	if($SmurfRecord[1,0] != "")
	{
		$SmurfDataFile = "config\\smurflog.cs";
		export("SmurfRecord*", $SmurfDataFile, False);
		echo("TAC: Smurf Record Log Saved");
	}

}

function DisplaySmurf(%adminId, %selectId)
{
	if($TAC::KeepSmurfLog = "true")
	{
		if(%adminId.isSuperAdmin)
		{
			//Find smurf userid
			%name = Client::getName(%selectId);
			for(%i=1;%i < $SmurfCount+1;%i++)
			{
				if($SmurfRecord[%i,0] == %name)
				{
					%userid = %i;
					%i = $SmurfCount+2;
				}
			}

			//Get known aliases
			if($SmurfRecord[%userid,1] == "")
			{
				%exactmatch = "  No Matches Found";
			}
			else
			{
				%count = 1;
				for(%i=0;%i < %count;%i++)
				{
					%count++;
					if((getWord($SmurfRecord[%userid,1],%i) != "") && (getWord($SmurfRecord[%userid,1],%i) != -1))
						if(%exactmatch == "")
							%exactmatch = $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
						else
							%exactmatch = %exactmatch @ " | " @ $SmurfRecord[getWord($SmurfRecord[%userid,1],%i),0];
					else
						%i = %count + 1;
				}
			}
			Client::sendMessage(%adminId, 1,Client::getName(%selectId) @ "'s possible aliases are:");
			Client::sendMessage(%adminId, 1,%exactmatch);
			echo(Client::getName(%selectId),"(",%selectId,") possible aliases are: ", %exactmatch);
		}
	}
}

function TACConvertIP(%ip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%ip,3,16);
	for(%i = 7; %i < TACStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = TACStrLen(%currentstring)+1;
		}
	}
	%ip = %currentipstring;
	return %ip;
}

function TruncateIP(%rawip)
{
	%currentipspace = TACDotToSpace(%rawip);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	%rawip = %currip[1] @ "." @ %currip[2] @ "." @ %currip[3] @ ".*";
	return %rawip;
}

function TACSmurfTimer(%repeat)
{
	if(($StartSmurfTimerRunning) || (%repeat))
	{
		$StartSmurfTimerRunning = false;
		$Gametimer = $Gametimer + 60;
		if($Gametimer >= 600)
		{
			$Gametimer = 0;
			$Gametimersixth++;
			RotateSmurfLog($Gametimersixth);
		}
		schedule("TACSmurfTimer(true);",60);
	}
}
function TACCompareIP(%userlistip,%currentip)
{
	//convert current IP:*.*.*.*:1422 into *.*.*.*
	%currentstring = String::getSubStr(%currentip,3,16);
	for(%i = 7; %i < TACStrLen(%currentstring)+1; %i++)
	{
		if(String::getSubStr(%currentstring,%i,1) == ":")
		{
			%currentipstring = String::getSubStr(%currentstring,0,%i);
			%i = TACStrLen(%currentstring)+1;
		}
	}
	//convert currentip into 4 variables
	%currentipspace = TACDotToSpace(%currentipstring);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%currip[%argnum] = getWord(%currentipspace, %argnum-1);
	}
	//convert userlistip into 4 variables
	%userlistipspace = TACDotToSpace(%userlistip);
	for(%argnum = 1; %argnum < 5; %argnum++)
	{
		%userip[%argnum] = getWord(%userlistipspace, %argnum-1);
	}
	//Compare variables
	%result = true;
	for(%i = 1; %i < 5; %i++)
	{
		if(%userip[%i] != "*")
			if(%currip[%i] != %userip[%i])
				%result = false;
	}
	return %result;
}

function TACDotToSpace(%string)
{
	%x = 0;
	%i = 0;
	while(%x<3 && %i < 64) // PORT: bounded; an address with fewer than 3 dots never ended this loop
	{
		%char = String::getSubStr(%string,%i,1);
		if(!String::ICompare(%char, "."))		{
			%left = String::getSubStr(%string,0,%i);
			%right = String::getSubStr(%string,%i+1,(TACStrLen(%string)-%i));
			%string = strcat(%left," ",%right);
			%x++;
		}
		%i++;
	}
	return %string;
}

function TACStrLen(%string)
{
	for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++)
		%length = %i;
	%length++;
	return %length;
}

if($TAC::KeepSmurfLog == "true")
{
	$StartSmurfTimerRunning = true;
	LoadSmurfRecord();
	$SmurfInitialCheck = false;
}


SHLoadBanList();
################################################################################################################
#//==========================================================================================================//#
#//          ANYTHING BEYOND THIS LINE IS BY VRWARPER!! ANYTHING BEYOND THIS LINE IS BY VRWARPER!!           //#
#//==========================================================================================================//#
################################################################################################################

function processConClient(%clientId)
{
	//== Add client
	addUser(%clientId);

	%name = Client::getName(%clientId);
	%nick = aquireNicks(%name);

	messageAll(3, $adminbotname @ ": Inputting new data for: "@%name@"~wmine_act.wav");
	echo($adminbotname @ ": Inputting new data for: "@%name);
	if(%clientId.isImposter)
	{
		echo($adminbotname @": -->>WARNING! WARNING!<<-- (>"@%name@"<) is an IMPOSTER");
		schedule("messageAll(1, $adminbotname @ \": Warning -->> IMPOSTER <<-- \");",3);
	}
}

function getIP(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	%ip = String::replace(%ip, ":", " ");
	%ip = getWord(%ip, 1);
	return %ip;
}

$backUpCount = 0;
function addUser(%clientId)
{
	%ip = getIP(%clientId);
	%name = Client::getName(%clientId);
	%hashName = VRBot::hashname(%name);
	%checkExist = checkExist(%name, %ip);
	%Exist = getWord(%checkExist, 0);

	addSecurityCon(%ip, %name);

	if(%Exist != 10)
	{
		if(%Exist >= 8)
		{
			%mainId = getWord(%checkExist, 1);
			%mainName = $VRWarperBot::ConLog[%mainId];
			%mainHashName = VRBot::hashname(%mainName);
			if($VRWarperBot::ConLogName2Id[%hashName] != %mainId)
			{
				$VRWarperBot::ConLogNick[%mainHashName] = $VRWarperBot::ConLogNick[%mainHashName] $+ ", " $+ %name;
				$VRWarperBot::ConLogName2Id[%hashName] = %mainId;
				$VRWarperBot::ConLogTimes[%hashName] = 0;
			}

			$VRWarperBot::ConLogTimes[%hashName]++;
			$VRWarperBot::ConLogAllTimes[%mainHashName]++;
			addNickCon(%clientId);
		}
		else if(%Exist == "Imposter")
		{
			if($VRWarperBot::ConLogIp2Name[VRBot::hashname(%ip)] != "")
			{
				%mainId = getWord(%checkExist, 1);
				%mainName = $VRWarperBot::ConLog[%mainId];
				%mainHashName = VRBot::hashname(%mainName);
				%name = "(IMPOSTER)" $+ %name;
				%clientId.isImposter = true;
				%hashName = VRBot::hashname(%name);
				$VRWarperBot::ConLogNick[%mainHashName] = $VRWarperBot::ConLogNick[%mainHashName] $+ ", " $+ %name;
				$VRWarperBot::ConLogName2Id[%hashName] = %mainId;
				$VRWarperBot::ConLogTimes[%hashName]++;
			}
		}
		else
		{
			%newId = getOpenPlacement();
			%hashName = VRBot::hashname(%name);

			$VRWarperBot::ConLog[%newId] = %name;
			$VRWarperBot::ConLogName2Id[%hashName] = %newId;
			$VRWarperBot::ConLogIp[%hashName] = %ip;
			$VRWarperBot::ConLogIp2Name[VRBot::hashname(%ip)] = %name;
			$VRWarperBot::ConLogNick[%hashName] = %name;
			$VRWarperBot::ConLogTimes[%hashName]++;
			$VRWarperBot::ConLogAllTimes[%hashName]++;
			addNickCon(%clientId);
		}
	}
	else if(%Exist == 10)
	{
		$VRWarperBot::ConLogTimes[%hashName]++;
		$VRWarperBot::ConLogAllTimes[%hashName]++;
	}

	if(%mainHashName != "")
		$VRWarperBot::ConLogLastIp[%mainHashName] = %ip;
	else
		$VRWarperBot::ConLogLastIp[%hashName] = %ip;

	if($backUpCount == 10)
	{
		$backUpCount = 0;
		updateLogFile();
	}
	else
		$backUpCount++;

	return true;
}

function addSecurityCon(%ip, %name)
{
	%ipLength = String::len(%ip);
	%whiteSpaces = 17 - %ipLength;
	for(%i = 1; %i <= %whiteSpaces; %i++)
		%Spaces = %Spaces @ " ";

	$IncomingConnection = %ip@%Spaces@"-->  "@%name;
	export("IncomingConnection", "temp\\ConnectionLog.txt", true);
	$IncomingConnection = ""; //== Erase inputString
}

function outPutSpecInfo(%finderCl, %name)
{
	%id = aquirePossibleId(%name);
	if(%id == "TMIDF")
	{
		Client::sendMessage(%finderCl, 1, $adminbotname @ ": Too many results, please narrow your search.~waccess_denied.wav");
	}
	else if(%id == "NIDF")
	{
		Client::sendMessage(%finderCl, 1, $adminbotname @ ": No connections with the name of \""@%name@"\" were found.~waccess_denied.wav");
	}
	else
	{
		%name = $VRWarperBot::ConLogAll[%id];
		%hashName = VRBot::hashname(%name);
		%mainId = $VRWarperBot::ConLogName2Id[%hashName];
		%mainName = $VRWarperBot::ConLog[%mainId];
		%mainHashName = VRBot::hashname(%mainName);
		%usedNicks = $VRWarperBot::ConLogNick[%mainHashName];
		%connectTime = $VRWarperBot::ConLogAllTimes[%mainHashName];
		%connectMTime = $VRWarperBot::ConLogTimes[%hashName];
		%ip = $VRWarperBot::ConLogLastIp[%mainHashName];
		Client::sendMessage(%finderCl, 3, $adminbotname @ ": Looking up information on: "@%name@"~wmine_act.wav");
		Client::sendMessage(%finderCl, 3, $adminbotname @ ": MAIN Times Connected: "@%connectTime);
		Client::sendMessage(%finderCl, 3, $adminbotname @ ": Number of Connections: "@%connectMTime);
		Client::sendMessage(%finderCl, 3, $adminbotname @ ": Other TRIBES Names: "@%usedNicks);
		Client::sendMessage(%finderCl, 3, $adminbotname @ ": Last seen IP: "@%ip);
	}
}

function aquireNicks(%name)
{
	%hashName = VRBot::hashname(%name);
	%mainId = $VRWarperBot::ConLogName2Id[%hashName];
	if(%mainId != "")
	{
		%mainName = $VRWarperBot::ConLog[%mainId];
		%mainHashName = VRBot::hashname(%mainName);
		%nicks = $VRWarperBot::ConLogNick[%mainHashName];
		return %nicks;
	}
	else
	{
		return "-->>>>Unknown Error<<<<--";
	}
}

function aquirePossibleId(%name) 
{ 
     for(%i = 0; $VRWarperBot::ConLogAll[%i] != ""; %i++) 
     { 
          if((String::findSubStr(String::replace($VRWarperBot::ConLogAll[%i], ".1", ""), %name) != "-1")) 
          { 
               %Id = %i; 
               %count++; 
          } 
          if($VRWarperBot::ConLogAll[%i] == %name)
 		return %i; 
     } 
     if(%count == 1) 
          return %Id; 
     else if(%count > 1) 
          return "TMIDF"; 
 
     return "NIDF"; 
}

function updateLogFile()
{
	echo("Notice: Updating log file!");
	export("VRWarperBot::ConLo*", "config\\VRBotConLog.cs", false);
}

function getOpenPlacement()
{
	for(%i = 0; $VRWarperBot::ConLog[%i] != ""; %i++){}
	return %i;
}

function checkExist(%name, %ip)
{
	for(%i = 0; $VRWarperBot::ConLog[%i] != ""; %i++)
	{
		%curName = VRBot::hashname($VRWarperBot::ConLog[%i]);
		%clHashName = VRBot::hashname(%name);
		%curIp = $VRWarperBot::ConLogIp[%curName];
		%ipComp = compareFinalIP(%ip, %curIp);

		if(%curName == %clHashName)
		{
			if(%ipComp > 18)
				return "10 " $+ %i;
			else
				%wrong = true;
		}
		else if(%curIp == %ip && !%wrong)
			return "9 " $+ %i;
		else if(%ipComp == 18 && !%wrong)
			return "8 " $+ %i;
		else if(%ipComp > 18 && %wrong)
			return "Imposter " $+ %i;
	}
	return false;
}

function addNickCon(%clientId)
{
	%name = Client::getName(%clientId);
	if(!checkNickExist(%name))
	{
		%id = getOpenNickPlacement();
		$VRWarperBot::ConLogAll[%id] = %name;
	}
}

function getOpenNickPlacement()
{
	for(%i = 0; $VRWarperBot::ConLogAll[%i] != ""; %i++){}
	return %i;
}

function checkNickExist(%name)
{
	for(%i = 0; $VRWarperBot::ConLogAll[%i] != ""; %i++)
	{
		%curName = VRBot::hashname($VRWarperBot::ConLogAll[%i]);
		%clHashName = VRBot::hashname(%name);
		if(%curName == %clHashName)
		{
			return true;
		}
	}
	return false;
}

function compareFinalIP(%clientIP, %checkIP)
{
	%clientIP = String::replace(%clientIP, ".", " ");
	for(%i = 0; %i < 3; %i++)
		%clientIPNode[%i] = getWord(%clientIP, %i);

	%checkIP = String::replace(%checkIP, ".", " ");
	for(%i = 0; %i < 3; %i++)
		%checkIPNode[%i] = getWord(%checkIP, %i);

	%levelCor = 20;
	for(%i = 0; %i < 3; %i++)
	{
		if(%clientIPNode[%i] != %checkIPNode[%i] && %checkIPNode[%i] != "*")
			%levelCor -= 8-((%i+1)*2);
	}

	return %levelCor;
}

function VRBot::hashname(%name)
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
	%name = String::replace(%name, "\]", "C3");
	%name = String::replace(%name, "\[", "C4");
	%name = String::replace(%name, "\}", "C5");
	%name = String::replace(%name, "\{", "C6");
	%name = String::replace(%name, " ", "C7");
	%name = String::replace(%name, ".", "C8");
	%name = String::replace(%name, "\>", "C9");
	%name = String::replace(%name, "_", "D1");
	%name = String::replace(%name, "\-", "D2");
	%name = String::replace(%name, "\'", "D3");
	%name = String::replace(%name, "\"", "D4"); // PORT: a quote in a name survived into file names and export patterns



	return %name;
}
function connectionlogger(%clientId)
{  
	updatetime();
	%clname = Client::getName(%clientId);
	%clip = Client::getTransportAddress(%clientId);
	%clip2 = Client::getTransportAddress(%clientId);
	%cl = Client::getName(%clientId);
	for(%i=0;$Grey::Number[%i] != "";%i++)
	{
	}
	$Grey::Number[%i] = %cl;
	for(%i=0;$Grey::IP[%i] != "";%i++)
	{
	}
	$Grey::IP[%i] = %clip;
	
	
     		$DateTime = "------- ["@$CurrentTime@"] ===== ["@$CurrentDate@"] -------";
		$GreyDawn::ClientName = %cl;
		$GreyDawn::ClientIp = %clip;
		%clip = Client::getTransportAddress(%clientId);
		export("$GreyDawn::ClientName", "config\\ipandnamelist.txt" , true);
		export("$GreyDawn::ClientIp", "config\\ipandnamelist.txt" , true);
		export("$DateTime" , "config\\ipandnamelist.txt" , true);
}
exec(VRBotConLog);
