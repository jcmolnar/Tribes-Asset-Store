function SHLoadBanList()
{
	EvalSearchPath();
	exec(SHBanList @ $Server::Port);
	echo("Ban List Loaded");
}
function SHSaveBanList()
{
   export("$SHBanList*", "config\\SHBanList" @ $Server::Port @ ".cs", False);
   echo("Ban List Saved");
}

function SHKickClient(%clientid)
{
	Net::kick(%clientid, "     " @ $KickMessage);
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}

function SHSayAutoAdmin(%clientid)
{
	BottomPrint(%clientid,"<F1><jc>You have been chosen by <f0>" @ $CurAdminName @ "<f1> to be Auto-Admined.",5);
}

function SHCheckTransportAddress(%clientid)
{
	%name = Client::getName(%clientId);
	%addr = Client::getTransportAddress(%clientId);
	echo(%clientid @ " <- " @ %addr);

	if(String::getSubStr(%addr,0,8) == "LOOPBACK")
		return;

	if(String::getSubStr(%addr,0,3) != "IP:" && String::getSubStr(%addr,0,4) != "IPX:" )
	{
		echo(%clientid @ " is not correct address form, kicking");
		schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
		return ;
	}

	for(%i=0;$SHBanList[%i] != "";%i++)
	{
		if(String::findSubStr(%addr,$SHBanList[%i]) == 0)
		{
			echo(%clientid @ " is banned");
			schedule("SHKickClient(" @ %clientid @ ");",0.1,%clientid);
			SHBanName(%name);
			Banlist::add(%addr);
			return;
		}
	}
}
function SHBanReset()
{
	for(%i=0;%i != "100";%i++)
	{
		$SHBanList[%i] = "";
	}
	SHSaveBanList();
}
function SHClearBanlist()
{
    for(%i=1;$SHBanList[%i] != "";%i++)
    {
        $SHBanList[%i-1] = "";
    }
    $SHBanList[%i-1] = "";
    EvalSearchPath();
    SHSaveBanList();
    SHClearBanListName();
}
function SHClearBanlistName()
{
    
    for(%i=0;$SHBanListName[%i] != "";%i++)
    {
        $SHBanListName[%i] = "";
    }
    $SHBanListName[%i] = "";
    EvalSearchPath();
    SHSaveBanList();
}

function GBClearTagBanList()
{
    File::delete("config\\TagBanList.cs");
    for(%i = 0; $TagBAN2[%i] != "";%i++)
    {
        $TagBAN2[%i] = "";
    }
    $TagBAN2[%i] = "";
    EvalSearchPath();
    SaveTagBanList();

}
function GBClearNameBanList()
{
    File::delete("config\\NameBanList.cs");
    for(%i=1;$NameBAN2[%i] != "";%i++)
    {
        $NameBAN2[%i-1] = "";
    }
    $NameBAN2[%i-1] = "";
    EvalSearchPath();
    SaveNameBanList();
}

function SHBanName(%name)
{
	for(%i=0;$SHBanListName[%i] != "";%i++)
	{
	}
	$SHBanListName[%i] = %name;
	SHSaveBanList();
}

function SHCheckAutoAdmins(%clientid)
{
	%name = Client::getName(%clientId);
	%addr = Client::getTransportAddress(%clientId);
	echo($adminbotname @": -->> Checking Auto-Admin <<--");
	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && (String::findSubStr(%addr, $Server::AutoAdminAddr[%i]) == 0) && ($Server::AutoAdmin[%i] == Client::getName(%clientId)))
		{
		   messageall(3, $adminbotname@": Welcome "@%name@" he has been granted Super-Admin.");
		   echo("AutoAdmining: " @ %clientId @ " \"" @  escapeString(Client::getName(%clientId)) @  "\" " @ Client::getTransportAddress(%clientId));
		   schedule("SHSayAutoAdmin(" @ %clientId @ ");", 31, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;

		}	
		else 	if((String::findSubStr(%addr, $Server::AutoAdminAddr[%i]) != 0) && ($Server::AutoAdmin[%i] == Client::getName(%clientId)))
		{
		echo($adminbotname@": Not Admining ->> Correct Name ->> Wrong IP ->> "@%addr@"");
		}
	}
}


SHLoadBanList();