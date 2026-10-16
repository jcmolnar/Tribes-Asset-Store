//	AAOD Users Routines......
//	Routines that track Exp Etc
//	AAODplayers Data file format
//	Players Start at 100 and go to 999
//	1 Variable tracks the info for All the PLayer Stats
//	Format is PlayerName 
//	Data Block = "Admin SuperAdmin PWD AAODHelp Enabled ExpGain ExpLost TotalKills TotalDeaths #ofVisits FlagCaps" ...
//	$AAOD::ANum	=	Actual Number of Registered Players
//	$AAOD::Name100	= "Valya[AAOD]"
//	$AAOD::Stat100	= "true true Biteme false true 105.5 25.45 25 25"


$PlayerFileBusy = false;

if(isFile("config\\AAODPlayers.cs") )
{	echo("## AAOD Players File Found........................................Loading");
	exec(AAODplayers);	// Load the Experience DataBase
	$AAOD::Name[$AAOD::ANum+100]="";
	$AAOD::Stat[$AAOD::ANum+100]="";
}
else
{	$AAOD::ANum=0;
	$AAOD::Name[$AAOD::ANum+100]="";
	$AAOD::Stat[$AAOD::ANum+100]="";
}


function UserConnectCheck(%client)
{	%name=Client::getName(%client);
	$User[%client]=%name;
	if(!%client.UserID && $TrackExp!=0 )	// If Client = False & Exp Tracking is On
	{	
		for (%i=0;%i<$AAOD::ANum;%i++)
		{	if($AAOD::Name[%i+100]==%name)
			{	%Client.UserID=%i+100;
				%i=$AAOD::ANum;
			}
		}
	
		if(%Client.UserId)
		{	PlayerStats(%Client.UserId,%Client,"LoadStats");
		
			if(%client.expaqrd>0)
			{	for(%i=$MaxExpLvl;%i>0;%i--)
				{	if ($Level[%i]<=%client.expaqrd)
					{	%client.exlevel=%i;
						if($TraceExp) echo($Ver,"|Setting Players Exp Level to :",%client.exlevel);
						%i=0;
					}
					
				}
				if (%client.exlevel>1)
				{	%client.bounty=$Bty[%client.exlevel];
					%msg="<jc> **** Notice: "@%name@" is a level "@%client.exlevel@" player!! ****";
					for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					{	%pts= GetAwardPts(%client,%cl);
						%msg=%msg+"\nYou would receive "@%pts@" Exp for killing him!";
						BottomPrint(%cl,%msg);
						client::sendMessage(%cl,$msgTypeChat,"~wAAODSFX51.WAV");
					}
				}
			}
			%client.expUsed=0;
			if($TraceExp) echo($ver@"|** Known Player ",%client.UserId," : '",%name,"' Base Exp: ",%client.expaqrd," Start Level:",%client.exLevel);
			if(%client.banned=="true")
			{	echo($ver,"|****** ",%Name," is a Banned Player!! Player will be ejected in 4 Seconds");
				CenterPrint(%client,"<jc>You have been BANNED from this server for \n POOR SPORTSMANSHIP!\nIf you believe this has been done in error..\ncontact the ADMIN via email or ICQ\nYou are being AUTO Kicked!!",8);
				Client::sendMessage(%client,0,"~wAAODSFX62.wav");
				MessageAllExcept(%client, 0, %name@ " has been AUTO Kicked for being a Whiner/looser/spoilsport & or TeamKiller!~wAAODSFX62.wav");
				schedule("Net::Kick ("@%client@",\"AUTO BANNED\");",8);
				return;
			}
		}
		else if($TrackExp>1)	// User is NOT Known so If We are Tracking Exp Then....
		{	// Server will Track All PLayers Exp!!
			%name=Client::getName(%client);
			if($AAOD::ANum<=$TrackMaxUsers)
			{	%Client.UserID=$AAOD::ANum+100;
				$AAOD::Name[%client.UserId]=%name;
				$AAOD::Stat[%client.UserId]="false false none true true 0 0 0 0 1 0 0 false";
				if($TraceExp) echo($ver@"|** ADDED NEW Player: '",%name,"' User ID ",%client.UserId);
				$AAOD::ANum++;
			}
			else
			{	if($TraceExp) echo($ver@"|** UNABLE to ADD NEW Player: '",%name,"'");
				%Client.UserId=1;
				BottomPrint(%client,"<jc>The Server is Unable to Register you automatically!!\nYour Exp levels will NOT Be saved.\nERROR - Too Many registered Users..",8);
				Client::sendMessage(%client,0,"~wAAODSFX62.wav");
			}
			$AAOD::Name[$AAOD::ANum+100]="";
			$AAOD::Stat[$AAOD::ANum+100]="";

		}
		else
			%Client.UserId=1;
	}
}

function UpdateFile()
{	if($PlayerFileBusy)
	{	echo("Player File is Busy... Try Again Later");
		return;
	}
	echo($Ver,"|***** Outputting EXP Data to File *****");
	$PlayerFileBusy = true;
	$AAODDataFile = "config\\AAODPlayers.cs";
	export("AAOD::*", $AAODDataFile, false);
	schedule("$PlayerFileBusy = false;",5);
}

function DumpExp()
{	UpdateFile();
	schedule("DumpExp();",$TrackTime);
}

function VerifyAdmin(%client,%admin1,%admin2,%pwd)
{	%name=Client::getName(%client);
	Echo("Admin Rights Requested By: ",%name," Checking Password");
	if(%pwd=="none" || %pwd=="") return; // PORT (2026-10-12): a saved record with no password restores no rank (was: admin by name alone)
	if(%client.pwd==%pwd)
	{	%client.isAdmin=%admin1;
		if(%pwd=="none")				// Cannot Give Super Admin Rights to player without Verification
			%client.isSuperAdmin=false;
		else
			%client.isSuperAdmin=%admin2;
		return;
	}
	else
	{	if(%admin2==true)
		{	//	Has requested a super Admin Position But does not have the auth code
			//	Kick Ass!!
			echo($ver,"|****** ",%Name," Was Kicked for being an IMPOSTER!!");
			CenterPrint(%client,"<jc>Imposters will not be tolerated on this server!!!\nYou are being AUTO Kicked for trying to impersonate an ADMIN!!",8);
			Client::sendMessage(%client,0,"~wAAODSFX62.wav");
			MessageAllExcept(%client, 0, %name@ " has been AUTO Kicked for trying to impersonate an ADMIN!~wAAODSFX62.wav");
			schedule("Net::Kick ("@%client@",\"Impersonating an Admin\");",8);
			return;
		}
	}
}

function remoteSetPwd(%client,%pwd)
{	%name=Client::getName(%client);
	Echo("Accepting Password for '",%name,"' : ",%client);
	%client.pwd=%pwd;

}




function AAOD_joinGame(%client)
{	//if($trace) echo( $ver@"|AAOD Join Game:",%client);
	%client.inAAPC				= false;
	%client.Help				= true;
	%client.inStasis			= false;
	%client.Help				= true;
	%client.teamKills			= 0;
	%client.tkObjects			= 0;
	%client.isRegenerating		= false;
	%client.isAdmin				= false;
	%client.isSuperAdmin		= false;
	%client.LastDamBy[1]		= false;
	%client.LastDamBy[2]		= false;
	%client.exlevel				= 0;
	%client.expaqrd				= 0;
	%client.expUsed				= 0;
	%client.expGain				= 0;
	%client.expLoss				= 0;
	%client.UserId				= false;
	%client.tKills				= 0;
	%client.tDeaths				= 0;
	%Client.Visit				= 1;
	%client.fCaps				= 0;	
	%client.tkick				= 0;	
	%client.banned				= false;
	%client.bounty				= 1;	
	%client.Repair				= 0;
	%client.skill[0]			= 0;
	%client.skill[1]			= 0;
	%client.skill[2]			= 0;
	%client.skill[3]			= 0;
	%client.skill[4]			= 0;
	%client.skill[5]			= 0;
	%client.skill[6]			= 0;
	%client.skill[7]			= 0;
	%client.talent[$Spd]		= 0;
	%client.talent[$Dur]		= 0;
	%client.talent[$Flt]		= 0;
	%client.talent[$Sth]		= 0;
	%client.talent[$Acc]		= 0;
	%client.talent[$Rgn]		= 0;
	%client.talent[$Rch]		= 0;
} 

function AAOD_leaveGame(%client)
{	if($trace) echo( $ver@"|AAOD Leave Game:",%clientId," UserId:",%client.UserId," ExpTracking :",$TrackExp);
	if($TrackExp > 0 && %client.UserId > 99)
	{	PlayerStats(%client.UserId,%Client,"UpdateUser");
		if($traceExp) echo("$AAOD::Stat[",%client.UserId,"] = ",$AAOD::Stat[%client.UserId]);
	}
} 

	

function GetPlayerLevel(%Exp)
{	if (%Exp>$MaxExpPts)
		%Exp=$MaxExpPts;
	else if(%Exp<0)
		%Exp=0;
	%Lvl=0;
	if(%Exp>0)
	{	for(%i=$MaxExpLvl;%i>0;%i--)
		{	if ($Level[%i]<=%Exp)
			{	%Lvl=%i;
				%i=0;
			}
		}
	}
	return (%Lvl);
}	


