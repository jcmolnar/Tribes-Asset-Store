// in game mod changer by {187}George W.

exec("league.cs");
exec("ve.cs");
exec("notor.cs");
exec("jimsmod.cs");
if($Server::Mod=="") $Server::Mod=1;
function LoadMod()
{
	if($Server::Mod==1)
	{
		veOFF();
		notorOFF();
		vx4aOFF();
		leagueON();
	}
	else if($Server::Mod==2)
	{
		leagueOFF();
		notorOFF();
		vx4aOFF();
		veON();
	}
	else if($Server::Mod==3)
	{
		leagueOFF();
		veOFF();
		vx4aOFF();
		notorON();
	}
	else if($Server::Mod==4)
	{
		leagueOFF();
		veOFF();
		notorOFF();
		vx4aON();
	}
	else
	{
		echo("Unsupported mod ("@$Server::Mod@") attempted.");
		messageall(0, "Unsupported mod ("@$Server::Mod@") attempted.");
	}
	for(%i=client::getfirst(); %i!=-1; %i=client::getnext(%i))
		remoteEval(%i, SVInfo, version(), $Server::Hostname, $modlist, $Server::Info, $ItemFavoritesKey);
	return;
}
$UComp::ModLabel="Ultra_Competition (League)";
if($Server::Mod!=1) LoadMod();