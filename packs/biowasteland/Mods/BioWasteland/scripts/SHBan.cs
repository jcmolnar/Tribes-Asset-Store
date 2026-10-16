function SHLoadBanList()
{
	EvalSearchPath();
	exec("SHBanList.cs");
	echo("SHBan List Loaded");
}

function SHSaveBanList()
{
   export("$SHBanList*", "config\\SHBanList.cs", False);
	echo("SHBan List Saved");
}

function SHKickClient(%clientid)
{
	Net::kick(%clientid,"");
}

function SHBan(%addr)
{
	for(%i=0;$SHBanList[%i] != "";%i++)
	{
	}
	$SHBanList[%i] = %addr;
	SHSaveBanList();
}


SHLoadBanList();

echo("SHBan Loaded.");
