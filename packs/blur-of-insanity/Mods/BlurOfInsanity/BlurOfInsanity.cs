// Blur of Insanity (SipHoN, 2002) -- entry script of the Modern Tribes (1.50) port.
//
// The release was one folder, "BlurofInsanity", with eight loose scripts and a Help.txt:
//    "type in tribes.exe -mod blurofinsanity"
// Nothing else was exec'd. The eight scripts are in scripts\ and load in place of the stock files
// of the same names (armordata, baseexpdata, baseProjData, game, item, station, turret, vehicle);
// everything else is the 1.50 base.
//
// item.cs, turret.cs and station.cs are HaVoC 1.59c files, but the release never had HaVoC's
// server.cs / player.cs / vehicle.cs, so the helpers below were never defined on a Blur of
// Insanity server and every call printed "Unknown command".

echo(">> Blur of Insanity");

// item.cs line 1 is "$ItemFavoritesKey = $MasterKey;". HaVoC sets $MasterKey in a settings file
// this release never had, so the key was empty = the STOCK favourites key: a client's stock
// shopping favourites (stored as item numbers) were applied to this mod's different item list.
// A key of its own keeps the two lists apart.
$MasterKey = "BlurOfInsanity";

// item.cs, 6 calls (weapon recoil) and 1 call (missile lock message): no-ops, which is what the
// release did. No recoil is added by the port.
function ixApplyKickback(%player, %strength, %lift)
{
}

function ixLockWarning(%clientId, %target, %targetType)
{
}

// item.cs x2, turret.cs x1: ends HaVoC's admin "possess" state. This mod has no possess option,
// so there is never anything to end.
function doneposs(%cl)
{
}

// turret.cs (the Satchel charge): two seconds after a player's satchel goes off, his view is
// handed back from the blast camera to his own body. Without this function the view stayed on
// the camera. Text of HaVoC 1.59c vehicle.cs.
function checkEm(%cl, %pl, %obj)
{
   if(Client::getControlObject(%cl) == %obj && Client::getOwnedObject(%cl) != -1)
   {
      Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      doneposs(%cl);
   }
   %cl.booyah = false;
}

// station.cs ixStationEjectPlayer (only used when a host sets $HaVoC::StationTime, which the
// release never does): the three maths helpers of HaVoC 1.59c server.cs.
function ixDotProd(%vec, %scalar)
{
   return Vector::dot(%vec, %scalar @ " 0 0") @ " " @ Vector::dot(%vec, "0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec, "0 0 " @ %scalar);
}

function ixSin(%theta)
{
   return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
   return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
