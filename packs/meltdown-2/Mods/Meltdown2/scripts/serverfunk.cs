// This is a backup server.cs file just in case one fails this is a backup (lol)
exec(admin);

function Server::onClientConnect(%clientId)
{
   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
	SHCheckTransportAddress(%clientid);
	SHCheckAutoAdmins(%clientId);
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey, $ModInfo);
   remoteEval(%clientId, MODInfo, "<f2>Meltdown <f1>v2.16 Final<f2>\n<f0>Made by: <f2>INH*DynaBlade\n<f0>You can download Meltdown at dynablade.net\n<f1>Copyright © 2001 INH*DynaBlade");
   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
}

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
			return;
		}
	}
}

function SHCheckAutoAdmins(%clientid)
{
	%addr = Client::getTransportAddress(%clientId);

	for(%i=0; $Server::AutoAdmin[%i] != "" || $Server::AutoAdminAddr[%i] != "" ;%i++)
	{
		if($Server::AutoAdminAddr[%i] != "" && ($Server::AutoAdmin[%i] == "" || $Server::AutoAdmin[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::AutoAdminAddr[%i]) == 0)
		{
		   echo("AutoAdmining: " @ %clientId @ " \"" @ 
		      escapeString(Client::getName(%clientId)) @ 
		      "\" " @ Client::getTransportAddress(%clientId));
		      schedule("SHSayAutoAdmin(" @ %clientId @ ");", 1, %clientId);

		      %clientId.isAdmin = true;
		      %clientId.isSuperAdmin = true;
		      %clientId.isLevel1 = true;
		      %clientId.isIsDynaBlade = true;
		}
	}
}

SHLoadBanList();

