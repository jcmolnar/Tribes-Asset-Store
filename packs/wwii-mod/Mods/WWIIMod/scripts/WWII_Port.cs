// WWII Mod -- Modern Tribes (1.50) port glue.
// Loaded last by WWIIload.cs on every createServer, after all of the mod's own scripts.
// Nothing here changes gameplay; it holds what the port had to add.
echo(">> WWII Mod: port glue loaded");

// The mod keeps team points in $WWII::TeamPoints[<team NAME>] and reads them back as
// $WWII::TeamPoints[Allied] / [Axis] in about forty places, so the two team names are part of
// the mod, not a host preference (the original instructions say the same). They are set here,
// at server start, because the saved server prefs are loaded after the mod entry script.
$Server::teamName0 = "Allied";
$Server::teamName1 = "Axis";

function WWIIPort::deny(%cl, %what)
{
	echo("WWII PORT: refused menu option " @ %what @ " from client " @ %cl @ " (admin level " @ %cl.adminLVL @ ")");
}

// A menu code comes from the client. The mod pastes parts of it into eval() and schedule()
// strings (spawn point, player id, map name), so anything but plain words must never get in.
// Every code the mod itself sends is letters, digits, spaces, "_", "-" and "!".
function WWIIPort::codeIsClean(%code)
{
	%ok = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 _-!";
	for(%i = 0; %i < 120; %i++)
	{
		%c = String::getSubStr(%code, %i, 1);
		if(String::ICompare(%c, "") == 0)
			return true;
		if(String::findSubStr(%ok, %c) == -1)
			return false;
	}
	return false;
}

// The mod's own menu.cs is not shipped (it would replace the 1.50 client's menu functions).
// This is its server half: the same dispatch to M::<menu>(), plus the check above.
function remoteMenuSelect(%clientId, %code)
{
	if($WWII::TraceClients)
		%clientId.remotecall++;
	Security::AntiSpam(%clientId, "RemoteMenuSelect");

	%mm = %clientId.menuMode;
	if(%mm == "")
		return;
	if(!WWIIPort::codeIsClean(%code))
	{
		WWIIPort::deny(%clientId, "(unsafe characters)");
		return;
	}

	%evalString = "M::" @ %mm @ "(" @ %clientId @ ", \"" @ %code @ "\");";
	%clientId.menuMode = "";
	%clientId.menuLock = "";
	dbecho(2, "MENU: " @ %clientId @ "- " @ %evalString);
	eval(%evalString);
	if(%clientId.menuMode == "")
	{
		Client::setMenuScoreVis(%clientId, false);
		%clientId.selClient = "";
	}
}
