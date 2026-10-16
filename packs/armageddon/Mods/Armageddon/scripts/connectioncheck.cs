// Designed and Coded by |*|w00|*|Grey.

function CheckTagBan(%clientid)
{
	
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	echo($adminbotname @": Checking TagBAN");
	for(%i=0; $TagBAN[%i] != "";%i++)
	{
		if((String::findSubStr(%name, $TagBAN[%i]) != "-1"))
		{
			
			echo($adminbotname @": -->>WARNING<<-- TAGBAN : " @ %name);
			SHBan(%ip);
			BanList::add(%ip, 259200);
			SHBanName(%name);
			messageall(3, $adminbotname@": -->> "@%name@" <<-- is Tag-Banned. He may not enter."); 
			return;
		}
	}
				echo($adminbotname @": Check Complete");
}


function CheckTagBan2(%clientid)
{
	
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	echo($adminbotname @": Checking TagBAN From GreyBOT List");
	for(%i = 0; $TagBAN2[%i] != "";%i++)
	{
		if((String::findSubStr(%name, $TagBAN2[%i]) != "-1"))
		{
			echo($adminbotname @": -->>WARNING<<-- TAGBAN : " @ %name);
			SHBan(%ip);
			BanList::add(%ip, 259200);
			SHBanName(%name);
			messageall(3, $adminbotname@": -->> "@%name@" <<-- is Tag-Banned. He may not enter."); 
			return;
		}
	}
				echo($adminbotname @": Check Complete");	
}
function CheckName(%clientid)
{
	
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	echo($adminbotname @": Checking Name for Vulgarity");
	for(%i=0; $BadNAME[%i] != "" ;%i++)
	{
		if((String::findSubStr(%name, $BadNAME[%i]) != "-1"))
		{
			
			echo($adminbotname @": -->>WARNING<<-- Name contains vulgarity : " @ %name);
			schedule("SHKickClient(" @ %clientid @ ");",0.5,%clientid);
			messageall(3, $adminbotname@": -->> "@%name@" <<-- has a vulgar name which I will NOT tolerate. He may not enter."); 
			
			return;
		}
		
	}
				echo($adminbotname @": Check Complete");
		


}
function CheckIP(%clientid)
{
	
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	echo($adminbotname @": Checking IP");
	for(%i=0; $IPBAN[%i] != "" ;%i++)
	{
		if((String::findSubStr(%ip, $IPBAN[%i]) != "-1"))
		{
			
			echo($adminbotname @": -->>WARNING<<-- IP is BANNED: " @ %name);
			schedule("SHKickClient(" @ %clientid @ ");",0.5,%clientid);
			messageall(3, $adminbotname@": -->> "@%name@" <<-- has a banned IP address. He may not enter."); 
			SHBan(%ip);
			BanList::add(%ip, 259200);
			SHBanName(%name);
			return;
		}
		
	}
				echo($adminbotname @": Check Complete");
		


}

function CheckNameBan(%clientId)
{
	
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	echo($adminbotname @": Checking NameBAN");
	for(%i=0; $NameBAN[%i] != "" ;%i++)
	{
		if((String::findSubStr(%name, $NameBAN[%i]) != "-1"))
		{
			echo($adminbotname @": -->>WARNING<<-- NAMEBAN : " @ %name);
			SHBan(%ip);
			BanList::add(%ip, 259200);
			SHBanName(%name);
			messageall(3, $adminbotname@": -->> "@%name@" <<-- is Name-Banned. He may not enter.");
			return;
		}
		

	}
	
	echo($adminbotname @": Check Complete");
		


}
function CheckClanAdmin(%clientId)
{
	updatetime();
	$SP = "***//***-----------------------------SPACER--------------------------***\\***";
	%name = Client::getName(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	$GreyBOT::ClanAdmin = %name;
	$GreyBOT::ClanAdminIP = %ip;
	$GreyBOT::TIMEDATE = "["@$CurrentTime@"] ["@$CurrentDate@"]";
	echo($adminbotname @": Checking Clan-Admin Rights");
	for(%i=0; $TagADMIN[%i] != "" ;%i++)
	{
		if((String::findSubStr(%name, $TagADMIN[%i]) != "-1") && !%clientId.isSmurf)
		{
			echo($adminbotname @": -->>WELCOME<<-- Clan Admin : " @ %name);
			%clientId.isAdmin = true;
			messageall(3, $adminbotname@": -->> "@%name@" <<-- is recognised as an ally in the Meltdown Empire. Enter worthy minion! ~wmale1.whello.wav");
			export("$GreyBOT::ClanAdmin", "config\\clanadminlog.txt" , true);
			export("$GreyBOT::ClanAdminIP", "config\\clanadminlog.txt" , true);
			export("$GreyBOT::TIMEDATE" , "config\\clanadminlog.txt" , true);
			export("$SP" , "config\\clanadminlog.txt" , true);
			return;
		}
		else if((String::findSubStr(%name, $TagADMIN[%i]) != "-1") && %clientId.isSmurf)
		{
			echo($adminbotname @": ->>WARNING<<- "@%name@" is a Clan-Admin IMPOSTER");
		}
	}
	

}
function ScanName(%clientId)
{
	echo($adminbotname @": Scanning Entry");
	%name = Client::getName(%clientId);
	for(%i=0; $TagADMIN[%i] != "" ;%i++)
	{
		if((String::findSubStr(%name, $TagADMIN[%i]) != "-1"))
		{
			echo($adminbotname @": -->>WELCOME<<-- Clan Admin : " @ %name);
			%clientId.isAdmin = true;
			messageall(3, $adminbotname@": -->> "@%name@" <<-- is recognised as an ally in the Meltdown Empire. Enter worthy minion!");
			%clientid.isnokick = true;
			return;
		}
		
	}
	schedule("scanning("@%clientId@");", 5);

}
function scanning(%clientId)
{
	%name = Client::getName(%clientId);
	for(%i=0; $TagADMIN[%i] != "" ;%i++)
	{
		if((String::findSubStr(%name, $TagADMIN[%i]) == "-1") && !%clientId.isnokick)
		{
			if(%count == "")
			{
				%count = 1;
			}
			else
			{
				%count++;
			}
			schedule("SHKickClient("@%clientId@");", 0.1);
			if(%count == "1")
			{
				echo($adminbotname @": ->> Scan Mode ACTIVE <<- "@%name@" has been kicked");
				messageall(1, $adminbotname@": "@%name@" does not have the required clan tag. He has been kicked");
			}
	
		}
	}
		
}