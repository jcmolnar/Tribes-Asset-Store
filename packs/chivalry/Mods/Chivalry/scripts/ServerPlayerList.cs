$Evil::Litch = "";
$Chivalry::GameTL = $Server::timeLimit;
function GetStats(%clientId)
{
if($Chivalry::Logging == true)
{

%name = Client::GetName(%clientId);
%exit = 0;
// PORT: the SAD1-3 auto super admin moved to CheckPassword (ChivalryPort::autoAdmin in Chivalry.cs):
// it was given by NAME alone, before the password test, and the shipped value "false" matched
// players named false / False / 0.
//if(%name != "" && %name == $Chivalry::SAD1 || %name == $Chivalry::SAD2 || %name == $Chivalry::SAD3)
//{
//	%clientId.isAdmin = true;
//	%clientId.isSuperAdmin = true;
//}
	for(%cnt = 0; %exit != -1; %cnt++)
	{
	if (%name == $Stats::Name[%cnt] && ($Stats::Rank[%cnt] == "TK" || $Stats::Tk[%cnt] >= $Chivalry::MaxTk))
		{
		//%deaths = $Stats::Deaths[%cnt];
		bottomPrint(%clientId,"Your dishonorable acts in past battles has earned you the rank of TeamKiller!\nThy stats have been stricken from the Scrolls of Honor.\nHonorable play and teamwork shall be thy only redemtion!",12);
		messageallexcept(%clientId,1,"TeamKiller "@%name@" has connected!  His punishment shall be your privilage!");
		%clientId.isTk = true;
		%clientId.scoreCtrlK = $Stats::CtrlK[%cnt];
		%skin = $Chivalry::TkSkin;
		Client::SetSkin(%clientId, %skin);
		schedule("CheckPassword(" @ %clientId @ ","@%cnt@");", 5, %clientId);
		%exit = -1;
		}
	
	else if (%name == $Stats::Name[%cnt])
		{
	CalcStats(%cnt,%clientId);
	%clientId.scoreCtrlK = $Stats::CtrlK[%cnt];
	if($Stats::Tk[%cnt])
	%clientId.totTk = $Stats::Tk[%cnt];
	%rank = $Stats::Rank[%cnt];
	//%kills = $Stats::Kills[%cnt];
	%score = $Stats::Score[%cnt];
	//%deaths = $Stats::Deaths[%cnt];
	CheckPassword(%clientId,%cnt);
		if($Stats::Rank[%cnt] == "Ghost")
			{
			if($Stats::CtrlK[%cnt] < 4)
			{
			$Stats::Rank[%cnt] = "Page";
			bottomPrint(%clientId,"An error occurred with your ranking!  Your score have been reset.\nWe appologoze for the inconvienience and urge you to contact the Admins so that your previous\nranking and scores may be recovered.  Thanks!");
			%rank = "Page";
			}
		else
			{
		bottomPrint(%clientId,"Welcome back to the "@ %name @"!\nThy soul is still lost and thou must roam the worlds as a Ghost.\nThe pity of the Ancients be with you!",12);
		%clientId.isGhost = true;
		//playNextAnim(%clientId);
		//Player::Kill(%clientId);
		//Observer::enterObserverMode(%clientId);
			}
			}

		else if(%name == $Evil::Litch && !%clientId.isGhost && !%clientId.isTk)
			{
	bottomPrint(%clientId,"Thou has risen from the grave many times, but this day something is different!\nThou hast become the Litch King!\nThy infernal score is "@%score@".",12);
	Player::setItemCount(%clientId,UndeadSpell,3);
	%clientId.Litch = true;
			}
	else if($Stats::Rank[%cnt] == "Undead")
			{
	bottomPrint(%clientId,"Welcome back "@%name@"!\nThine soul is still in a state of unrest as thou are destined to roam once again as the Undead!\nPerhaps this day your soul will find peace.  Good Luck!",12);
	%clientId.Undead = true;
	%skin = $Chivalry::UndeadSkin;
		%pl = Client::getOwnedObject(%clientId);
		GameBase::setTeam(%clientId,-1);
		GameBase::setAutoRepairRate(%pl,0.015);
		Client::setSkin(%clientId, %skin);
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
		Player::setArmor(%clientId,marmor);
		else
		Player::setArmor(%clientId,mfemale);
		Player::setItemCount(%clientId,RepairPack,0);
		if($Stats::Score[%cnt] == "TK")
		{
		%clientId.isTk = true;
		messageallexcept(%clientId,1,"TeamKiller "@%name@" has connected!  His punishment shall be your privilage!");
		}
		else if($Stats::Score[%cnt] == "Ghost")
		%clientId.isGhost = true;
			}
	else
	bottomPrint(%clientId,"Welcome back "@ %rank @" "@ %name @"\nThy Total Score to date is "@ %score @"\nGood luck in thy fray!",12);
	%clientId.totScore = %score;
	%clientId.rank = %rank;
	%exit = -1;
		}
	 else if ($Stats::Name[%cnt] == "false")
	{
		bottomPrint(%clientId,"Welcome "@ %name @"\nThy name hath been logged unto the scrolls!\nFight with honor, warrior, and you shall be rewarded!",12);
	%clientId.rank = "Page";
	NewPlayer(%name, %cnt, %clientId);
	%exit = -1;
		}
	
		
	}
//flushExportText();
}
}

function logClientTk(%clientId)
{
if($Chivalry::Logging == "true" && %clientId.scoreTk >= $Chivalry::TkLimit)
{
%clientId.isKicked = true;
logClientDisconnect(%clientId);
Admin::Kick(-2,%clientId,kick);
}
}

function logClientDisconnect(%clientId)
{
if($Chivalry::Logging == true)
{
%exit = 0;
for(%cnt = 0; %exit != -1; %cnt++)
	{
	%name = Client::GetName(%clientId);
	if (%name == $Stats::Name[%cnt] && (%clientId.isKicked || $Stats::Rank[%cnt] == "TK" || %clientId.isTk || %clientId.totTk >= $Chivalry::MaxTk))
		{
		//$Stats::Kills[%cnt] = 0;
		//$Stats::Flags[%cnt] = 0;
		//$Stats::Deaths[%cnt] = %clientId.scoreDeaths;
		$Stats::Ip[%cnt] = Client::getTransportAddress(%clientId);
		if(%clientId.Undead)
		{
		$Stats::Rank[%cnt] = "Undead";
		$Stats::Score[%cnt] = "TK";
		}
		else
		{
		$Stats::Rank[%cnt] = "TK";
		$Stats::Score[%cnt] = 0;
		}
		$Stats::Tk[%cnt] += %clientId.scoreTk;
		$Stats::CtrlK[%cnt] = %clientId.scoreCtrlK;
		export("$Stats::*", "temp\\ReturnPlayers.cs", false);
		%clientId.isKicked = false;
		%exit = -1;
		}
	else if (%name == $Stats::Name[%cnt] && %clientId.isFree)
		{
		%rank = $Stats::Rank[%cnt];
		//$Stats::Kills[%cnt] += %clientId.scoreKills;
		$Stats::Score[%cnt] = 0;
		$Evil::Litch = "";
		//$Stats::Flags[%cnt] += %clientId.scoreFlags;
		//$Stats::Deaths[%cnt] += %clientId.scoreDeaths;
		$Stats::Ip[%cnt] = Client::getTransportAddress(%clientId);
		$Stats::Rank[%cnt] = %rank;
		$Stats::Tk[%cnt] += %clientId.scoreTk;
		$Stats::CtrlK[%cnt] = %clientId.scoreCtrlK;
		export("$Stats::*", "temp\\ReturnPlayers.cs", false);
		%clientId.isFree = false;
		%exit = -1;
		}
	else if (%name == $Stats::Name[%cnt] && ((%clientId.Undead && $Stats::Rank[%cnt] == "Undead") || (%clientId.Undead)))
		{
	%ip = Client::getTransportAddress(%clientId);
	$Stats::Ip[%cnt] = %ip;
	$Stats::Rank[%cnt] = "Undead";
	$Stats::CtrlK[%cnt] = %clientId.scoreCtrlK;
	if(%clientId.isGhost)
	$Stats::Score[%cnt] = "Ghost";
	export("$Stats::*", "temp\\ReturnPlayers.cs", false);
	%exit = -1;
		}
	else if(%name == $Stats::Name[%cnt] && (%clientId.isGhost || %clientId.scoreCtrlK > 5))
		{
		%ip = Client::getTransportAddress(%clientId);
	$Stats::Ip[%cnt] = %ip;
	$Stats::Rank[%cnt] = "Ghost";
	$Stats::Score[%cnt] += %clientId.score;
	$Stats::CtrlK[%cnt] = %clientId.scoreCtrlK;
	//flushExportText();
	export("$Stats::*", "temp\\ReturnPlayers.cs", false);
	%exit = -1;
		}
	else if (%name == $Stats::Name[%cnt] && !%clientId.isGhost)
		{
		if(%clientId.Litch)
		$Evil::Litch = "";
		%rank = $Stats::Rank[%cnt];
		//$Stats::Kills[%cnt] += %clientId.scoreKills;
		$Stats::Score[%cnt] += %clientId.score;
		//$Stats::Flags[%cnt] += %clientId.scoreFlags;
		//$Stats::Deaths[%cnt] += %clientId.scoreDeaths;
		$Stats::Ip[%cnt] = Client::getTransportAddress(%clientId);
		$Stats::Tk[%cnt] += %clientId.scoreTk;
		$Stats::CtrlK[%cnt] = %clientId.scoreCtrlK;
			if(!%clientId.Undead && $Stats::Rank[%cnt] == "Undead")
			$Stats::Rank[%cnt] = "";
			else $Stats::Rank[%cnt] = %rank;
		export("$Stats::*", "temp\\ReturnPlayers.cs", false);
		%clientId.isKicked = false;
		%exit = -1;
		}
	 else if ($Stats::Name[%cnt] == "false"){
		//bottomPrint(%clientId,"Unable to find your stats!",12);
	%exit = -1;
		}
		
	}

}
}

function logClientFlag(%clientId)
{
if($Chivalry::Logging == "true")
%clientId.scoreFlags++;
}

function logClientFinals()
{
if($Chivalry::Logging == true)
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
	//Client::sendMessage(%cl, 0,"Updating your Stats!");
	%cl.totScore += %cl.score;
	logClientDisconnect(%cl);
	}

}
}

function DonCrown(%clientId, %player)
{
if($Chivalry::DonCrown == true)
{
%pl = Client::getName(%clientId);
if(%clientId.Litch)
	Player::setItemCount(%clientId,UndeadSpell,3);
if (%pl == $Chivalry::Warlord || %pl == $Chivalry::Paladin)
	{
	%name = Player::getClient(%clientId);
	Player::mountItem(%name, Crown, 2);
	if(%pl == $Chivalry::Paladin)
		{
		Player::setItemCount(%clientId,PaladinHeal,1); //<--Used once per life
		if(!$UsedShield) //<--Can be used only once per game/map
		Player::SetItemCount(%clientId,NoUndead,1);
		if(!$PaladinRite)  //<--Use once per map
		Player::setItemCount(%clientId,PaladinRite,1);
		}
	if(%pl == $Chivalry::Warlord)
		{
		Player::setItemCount(%clientId,WarlordShield,1);  //<--Can be used once per life
		if(!$UsedCharge)  //<--Can use only once per game/map
		Player::setItemCount(%clientId,WarlordCharge,1);
		if(!$WarlordRite)  //<--Ritual can only be attempted once per map
		Player::setItemCount(%clientId,WarlordRite,1);
		}
	}

}
else return;
}

function NewPlayer(%name, %num, %clientId)
{
//messageall(0, %name @" is now player number "@ %num);
$Stats::Name[%num] = %name;
//$Stats::Kills[%num] = 0;
//$Stats::Deaths[%num] = 0;
$Stats::Score[%num] = 0;
//$Stats::Flags[%num] = 0;
$Stats::Tk[%num] = 0;
$Stats::CtrlK[%num] = 0;
$Stats::Rank[%num] = "Page";
		schedule("NewMessage("@%clientId@");",15,%clientId);
		$Stats::Password[%num] = "NEW";
		$Stats::Name[%num++] = false;
export("Stats::*", "temp\\ReturnPlayers.cs", false);
}

function CalcMax()
{
if($Stats::Name[0] == "false")
	return;
else 
	%exit = 0;
	%max = 0;
	for(%num = 0;%exit != -1;%num++)
		{
		if($Stats::Name[%num] != "false")
			{
			if($Stats::Score[%num] > %max && $Stats::Score[%num] != "TK" && $Stats::Score[%num] != "Ghost" && $Stats::Rank[%num] != "TK" && $Stats::Rank[%num] != "Ghost")
			%max = $Stats::Score[%num];
			}
		else
		%exit = -1;
		}
	//messageAll(0,"The highest score to date is "@ %max);
	return %max;
}

function CalcStats(%cnt,%clientId)
{
	//messageAll(0,"Calculating Rankings!");
	%max = CalcMax();
		if($Stats::Rank[%cnt] == "TK")
		return;
		if($Stats::Name[%cnt] != "false")
		{
			%oldRank = $Stats::Rank[%cnt];
			%score = $Stats::Score[%cnt];
				if($Stats::Rank[%cnt] == "Undead" || $Stats::Rank[%cnt] == "Ghost")
				return;
				if (%score < -100)
				{
				%evil = CheckLitch(%cnt);
					if(%evil)
					{
					%name = Client::getName(%clientId);
						if($Evil::Litch != "" && %name != $Evil::Litch && getClientByName($Evil::Litch) != -1)
						{
						%curLitch = getClientByName($Evil::Litch);
						%curLitch.Litch = false;
						Player::setItemCount(%curLitch,UndeadSpell,0);
						Client::sendMessage(%curLitch,0,"You've lost your position as Litch as another arrives to take your place!");
						}
					$Evil::Litch = %name;
					}
					else $Stats::Rank[%cnt] = "Jester";
				}
				else if(%score < -10)
				$Stats::Rank[%cnt] = "Jester";
				else if(%score >= -10 && %score <= 4)
				$Stats::Rank[%cnt] = "Page";
				else if(%score > 4 && %score < 8)
				$Stats::Rank[%cnt] = "Warrior";
				else if(%score >7 && %score <= 10)
				$Stats::Rank[%cnt] = "Man-at-Arms";
				else if(%score >= %max * 0.96)
				$Stats::Rank[%cnt] = "Knight";
			else if(%score >= %max * 0.86)
				$Stats::Rank[%cnt] = "Cavalier";
			else if(%score >= %max * 0.66)
				$Stats::Rank[%cnt] = "Knight Errant";
			else if(%score >= %max * 0.41)
				$Stats::Rank[%cnt] = "Legionnaire";
			else if(%score > 10)
				$Stats::Rank[%cnt] = "Man-at-Arms";
			else $Stats::Rank[%cnt] = "Page";
			if($Stats::Rank[%cnt] != %oldRank && $Stats::Rank[%cnt] == "Litch")
			{
			Client::SendMessage(%clientId,0,"Your deaths have transformed you into the Litch King!");
			}
			else if($Stats::Rank[%cnt] != %oldRank)
			{
			Client::SendMessage(%clientId,0,"Your deeds have earned you the rank of "@$Stats::Rank[%cnt]@"!");
			}
			Client::SendMessage(%clientId,0,"The current High Score is "@%max);
		}
}	

function CrownNew(%new,%title)
{
%newname = Client::getName(%new);
if(%newname == $Chivalry::Paladin && %title == "pal")
	return;
if(%newname == $Chivalry::Warlord && %title == "war")
	return;
for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
{
%oldname = Client::getName(%cl);
//%crown = Player::getMountedItem(%old,2);
%gender = Client::getGender(%cl);
	if($Chivalry::Paladin == %oldname && %title == "pal")
	{
	Player::SetItemCount(%cl,PaladinHeal,0);
	Player::SetItemCount(%new,PaladinHeal,1);
Player::setItemCount(%cl,Crown,0);
Player::setItemCount(%cl,Crown1,0);
Player::setItemCount(%cl,Crown2,0);
Player::setItemCount(%cl,Crown3,0);
Player::setItemCount(%cl,Crown4,0);
Player::mountItem(%new,Crown,2);
if(%gender == "Male")
	%word = "his";
else %word = "her";
messageAll(0, "Paladin "@ %oldname @" has stepped down and bequeathed "@ %word @" crown to "@ %newname @"!~wflagcapture.wav");
$Chivalry::Paladin = %newname;
export("$Chivalry::*","config\\ChivalryPrefs.cs",false);
return;
	}
if($Chivalry::Warlord == %oldname && %title == "war")
	{
	Player::SetItemCount(%cl,WarlordShield,0);
	Player::SetItemCount(%new,WarlordShield,1);
Player::setItemCount(%cl,Crown,0);
Player::setItemCount(%cl,Crown1,0);
Player::setItemCount(%cl,Crown2,0);
Player::setItemCount(%cl,Crown3,0);
Player::setItemCount(%cl,Crown4,0);
Player::mountItem(%new,Crown,2);
if(%gender == "Male")
	%word = "his";
else %word = "her";
messageAll(0, "Warlord "@ %oldname @" has stepped down and bequeathed "@ %word @" crown to "@ %newname @"!~wflagcapture.wav");
$Chivalry::Warlord = %newname;
export("$Chivalry::*","config\\ChivalryPrefs.cs",false);
return;
	}
}
if(%title == "pal")
	{
	Player::SetItemCount(%new,PaladinHeal,1);
	Player::mountItem(%new,Crown,2);
	messageAll(0, %newname @" has been crowned the new Paladin!~wflagcapture.wav");
	$Chivalry::Paladin = %newname;
	export("$Chivalry::*","config\\ChivalryPrefs.cs",false);
	return;
	}
else if(%title == "war")
	{
	Player::SetItemCount(%new,WarlordShield,1);
	Player::mountItem(%new,Crown,2);
	messageAll(0, %newname @" has been crowned the new Warlord!~wflagcapture.wav");
	$Chivalry::Warlord = %newname;
	export("$Chivalry::*","config\\ChivalryPrefs.cs",false);
	return;
	}
else messageall(0,"Error in CrownNew function!");

}

function Ceremony(%clientId)
{
GameBase::setTeam(%clientId,0);
}

function StatsMessage()
{
//messageall(0,"StatsMessage Function passed okay");
if($Chivalry::Logging && $Chivalry::Played == ($Chivalry::CalcStats - 1))
{
bottomprintall("<f5>Players Rankings and Stats will be calculated upon mission end.  The Server will appear to lag during this time.\nPlease be patient.  This may take several minutes.",10);
messageall(0,"~wLeftMissionArea.wav");
}
}

function TopPlayers()
{
%topx = $Chivalry::TopX;
for(%cnt = 0;%cnt != %topx;%cnt++)  //Initialize TopX Array
	$Top::Score[%cnt] = 0;
for(%cnt = 0;$Stats::Name[%cnt] != "false";%cnt++)
	{
		for(%num = 0;%num != %topx || %num != -1; %num++)
		{
			if($Stats::Score[%cnt] > $Top[%num])
			{
			if(%cnt++ <= %topx)
			$Top::Score[%num++] = $Top::Score[%num];
			$Top::Score[%num] = $Stats::Score[%cnt];
			$Top::Name[%num] = $Stats::Name[%cnt];
			export("$Top::*","temp\\TopX.txt",false);
			%num = -1;
			}
		}
	}

messageall(0,"TopPlayers Called");
}

function CheckLitch(%cnt)
{
	%exit = 0;
	%litch = -100;
	for(%i = 0;$Stats::Name[%i] != "false";%i++)
	{
		if($Stats::Score[%i] < %litch)
		%litch = $Stats::Score[%i];
		$Evil::Litch = $Stats::Name[%i];
	}
	//messageAll(0,"The lowest score to date is "@ %litch);
	if($Stats::Score[%cnt] == %litch)
	{
	//$Stats::Rank[%cnt] = "Litch";
	return true;
	}
	else return false;
}

function ResetServerTime()
{
	$Server::timeLimit = $Chivalry::GameTL;
}

function CheckPassword(%clientId, %num)
{
	%password = $Client::info[%clientId, 5];
	if(%password == "")
	%password = false;
	%exit = 0;
	%name = Client::GetName(%clientId);
		if($Stats::Password[%num] != "NEW" && $Stats::Password[%num] != "" && %password != false)
			{
		%info = $Stats::Password[%num];
		%exit = -1;
			}
		else if($Stats::Password[%num] == "NEW" && %password != false)
			{
		schedule("PassMessage("@%clientId@");",15,%clientId);
		$Stats::Password[%num] = %password;
		%clientId.chivNewPw = true; // PORT: recorded during this connect, see ChivalryPort::autoAdmin
		%info = $Stats::Password[%num];
		%password = %info;
		export("$Stats::*", "temp\\ReturnPlayers.cs", false);
		%exit = -1;
			}
		else if($Stats::Password[%num] == "NEW" && %password == false)
			{
		%info = $Stats::Password[%num];
		%password = %info;
		schedule("NoPassword("@%clientId@");",15,%clientId);
		%exit = -1;
			}
		else
		messageall(0,"Password Exception Error");

if(%info != -1)
	{
		if(("x" @ %info) == ("x" @ %password)) // PORT: text compare (see PORT-REPORT)
		{
		Allowed(%clientId);
		ChivalryPort::autoAdmin(%clientId, %num); // PORT: SAD1-3, only after the password test
		}
	else 
	NotAllowed(%clientId);
	}
}


function NewMessage(%clientId)
{
if(Client::getOwnedObject(%clientId) == -1)
schedule("NewMessage("@%clientId@");",8,%clientId);
else
centerPrint(%clientId,"As a security measure, please enter a password or phrase in the Other Info section on this character.\n\nThis password will be recorded the next time you connect to this server and must remain in the Other Info section in order for you to play on this name.\nIf you have any questions or comments, please contact the Server Admin or send an E-Mail to sojdev@sojdev.com\n\nThank you!",12);
return;
}

function PassMessage(%clientId)
{
if(Client::getOwnedObject(%clientId) == -1)
schedule("PassMessage("@%clientId@");",8,%clientId);
else
centerprint(%clientId,"The password recorded from your Other Info section of your character is:\n\n"@ $Client::info[%clientId, 5] @"\n\nPlease ensure that this password is present in the Other Info section of your Player Setup or you will not be allowed to play this character.",12);
return;
}

function NoPassword(%clientId)
{
if(Client::getOwnedObject(%clientId) == -1)
schedule("NoPassword("@%clientId@");",8,%clientId);
else
centerPrint(%clientId,"No password or phrase was found in your characters Other Info.  It is highly suggested that you supply one to ensure the security of your stats.",12);
return;
}

function Allowed(%clientId)
{
echo("PLAYER-> Password Accepted for "@Client::getName(%clientId) @" "@Client::getTransportAddress(%clientId));
return;
}

function NotAllowed(%clientId)
{
echo("PLAYER-> Password Rejected for "@Client::getName(%clientId)@" "@Client::getTransportAddress(%clientId));
//messageall(0,"Kicked "@Client::getName(%clientId)@" "@Client::getTransportAddress(%clientId));
Admin::Kick(-3,%clientId,kick);
return;
}