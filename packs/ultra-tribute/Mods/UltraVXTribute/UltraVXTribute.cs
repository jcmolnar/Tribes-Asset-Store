// Ultra Renegades VX "-Tribute-" by LeGeND -- entry script (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVXTribute). The mod itself is the flat
// script set in scripts\ (its own server.cs, admin.cs, item.cs, menu.cs ...). The original launch
// line was
//     Tribes.exe +exec VXConfig -mod Ultra_RenegadesVX -Tribute-
// VXConfig.cs only held ordinary server prefs (host name, team names, time limit, the two admin
// passwords, a telnet port); none of that is stamped by this pack: set it the usual way.
//
// The values below are the mod's own switches. The original kept them at the top of its
// serverDefaults.cs, which this pack does not ship (the 1.50 client's own serverDefaults.cs is
// used). Each is set only when the host has not set it already.

// Unlimited boost / air-brake grenades and repair kits. Admins can flip Boosts/Brakes from the Tab menu.
if($UnlimitedBoostBrake == "") $UnlimitedBoostBrake = true;
if($UnlimitedRepairKits == "") $UnlimitedRepairKits = true;

// true: super admins are copied on every private message (a player with someone selected in the
// Tab score list sends chat to that player only).
if($AdminViewPM == "") $AdminViewPM = true;

// IP tracker ("smurf log"): one line per address with the names seen from it, kept in the file
// below and shown to super admins when a player connects or is selected in the Tab list.
if($IPTracker::File == "")        $IPTracker::File = "config\\ipinfo.cs";
if($IPTracker::Exec == "")        $IPTracker::Exec = "ipinfo";
if($IPTracker::ETricon == "")     $IPTracker::ETricon = true;       // echo ADMINMSG lines to the console
if($IPTracker::ESuperAdmin == "") $IPTracker::ESuperAdmin = true;   // bottom-print to super admins
if($IPTracker::EConsole == "")    $IPTracker::EConsole = true;      // plain console echo
if($IPTracker::OnTabSelect == "") $IPTracker::OnTabSelect = true;   // show on Tab-list select

// Mod profile and difficulty are set at the top of scripts\server.cs
// ($Ultra_RenegadesVX5::ultravxmod, ::ultravxDIFmode, ::modvoting, ::difficultyvoting); admins change
// both from the Tab menu (UltraVX Mode: Settings, Difficulty: Settings).
//
// Admin log-on (the SAD password box) is OFF until the host sets a password of their own, for
// example in config\autoexec.cs:
//     $AdminPassword      = "something only you know";   // super admin
//     $MatchAdminPassword = "another one";               // public admin
// No password ships with this pack. The host's own (listen-server) client is super admin.

echo("Ultra Renegades VX -Tribute- (UltraVXTribute) settings loaded.");
