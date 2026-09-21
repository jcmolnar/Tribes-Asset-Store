//-----------------------------------------------------------------------------
// serverConfig.cs -- Duel Tournament server settings.
//
// duelmod.cs execs this by name near the end of its own load (it was called
// "arghs.cs" upstream, after the =Argh!= server this build was taken from).
// EVERYTHING an operator is expected to change lives here and nowhere else.
//
// A host may override this file wholesale by dropping a copy at
// config\serverConfig.cs -- config is first on the search path and wins, so your
// settings survive a pack update.
//
// The upstream file shipped the live =Argh!= server's real credentials in it
// (join password, two admin passwords, a super-admin password, the telnet
// password, and the operator's admin roster). Those are removed. Set your own
// below before hosting publicly.
//-----------------------------------------------------------------------------

//
// IDENTITY
//
$Server::HostName      = "Duel Tournament";
$Server::Info          = "Duel Tournament -- 1v1 and team duels, arenas and tournaments.\nPress TAB for the duel menu, then pick a player to challenge.";
$Server::MaxPlayers    = 16;
$Server::HostPublicGame = true;

// Join password. Leave empty for an open server -- only set one if you want to
// keep people OUT.
$Server::Password      = "";

//
// ADMIN
//
// $adminpassword  -- normal admin. Empty disables admin login entirely.
// $AboveAdmin     -- "super admin": can act on other admins (kick/ban/mute them)
//                    and is exempt from the admin-vs-admin guards in TDMenu.
//                    Leave empty unless you actually want that tier.
//
// **Set these before you host publicly. An empty password disables the tier;
//  it does NOT mean "anyone may log in".**
//
$AllowAdminMods = true;
$adminpassword  = "";
$AboveAdmin     = "";

// Named admins -- these players get admin without typing a password, matched on
// exact player name. Name matching is spoofable on a public server; prefer the
// password. Set $TrustedAdmins to the number of entries you filled in.
$TrustedAdmins  = 0;
// $TrustedAdmin[0] = "Your Name Here";
// $TrustedAdmin[1] = "Someone Else";

//
// MATCH
//
$Server::timeLimit   = 35;      // minutes per map
$Server::warmupTime  = 1;       // seconds after a map change before "startmatch"
$TeamDuel::Master    = true;    // team-duel ladder / challenge system
$TeamDuel::Arena     = true;    // arena duels

//
// CHAT FLOOD GUARD
//
// Read by the 1998 server binary's own throttle, which the Modern Client does
// not implement -- the script-side guard that DOES run is AntiCrash.cs. Kept so
// an operator editing this file sees every knob upstream exposed.
$SPAM::window   = 1;
$SPAM::throttle = 512;

//
// TELNET -- the 1998 remote console. The Modern Client has no telnet listener,
// so these are inert here; left in place for operators running this mod on an
// original 1.x dedicated server.
//
$telnetpassword = "";
$telnetport     = "";

//
// IRC -- upstream auto-joined irc.tribalwar.com on boot. Off by default: a mod
// pack should not open an outbound connection nobody asked for.
//
$IRC::ConnectOnStartup = false;

//
// DEBUG
//
// $TDebug = true;   // very chatty: logs every TD menu/function entry
// $fastmap = true;  // 1-second map rotation, for testing only

function FastMap()
{
   $fastmap = 1;
   $qq = 1;
   $server::timelimit = 1;
}
if($fastmap)
   FastMap();

// Lets a client confirm it is talking to a Duel Tournament server.
function remoteTest(%clientId)
{
   client::sendmessage(%clientId, 0, "yougotitpadre");
}

echo("[Duel] serverConfig.cs loaded -- host \"" @ $Server::HostName @ "\"");
