// ModX 3.0 Open Source ("Version 3.0R2", build date 11-14-04) by Vage aka Jacob B. Gohlke
// -- Modern Tribes (1.50) entry script AND the mod's settings file.
//
// This file is the release's own ModX.cs (same settings, same values) with three changes, each marked
// PORT. The original was started with   tribes -mod ModX   ; the game execs <mod word>.cs, which is how
// these settings were loaded then and are loaded now. Nothing else was exec'd: server.cs (in scripts\)
// loads the rest.
echo(">> ModX 3.0 Open Source");

// Server Settings
$ModXServerLANOnly = false;         //set to true to have a LAN only server.

// Options
$DeployablePowerRange = 300;        //meters
$DeployGunRange = 150;              //meters
$VehicleStationRange = 35;          //meters

$DeployFloodProtect = true;         //boolean
$DeployFloodProtectTime = 10;       //seconds
$DeployFloodProtectFrequency = 6;   //interval

$ModXHelpDelay = 120;               //seconds

$MaximumDeployCap = 750;            //Safe Value, anything over your on your own!

// In-Game Messages
// Where Used: %1 = Admin's Name, %2 = Victim's Name
$LlamaMsg[0]  = "BLEEAAAT!";
$LlamaMsg[1]  = "ORGLE!";           //Any String
$LlamaMsg[2]  = "MOO... UM, BLEAT!";
$LlamaMsgs = 3;                     //Total Messages in the LlamaMsg Array

$SlayMessage[1] = "You've been slayed by %1.";

$SlapMessage[1] = "You've been slapped by %1!";

$BlindMessage[1] = "You've been blinded by %1! Normal sight will return... Eventually.";
$BlindTime = 30;                    //seconds

$ContKillMessage[1] = "You've been stuck in the blender by %1, you'll get out soon!";
$ContKillTime = 60;                 //seconds

$ToggleToolsMessage[0] = "You've had your Tool-Usage Access enabled by %1.";
$ToggleToolsMessage[1] = "You've had your Tool-Usage Access disabled by %1!";

$GagMessage[0] = "Your vocal cords have been surgically replaced by %1.";
$GagMessage[1] = "Your vocal cords have been torn out by %1!";

$LlamaMessage[0] = "Your vocal cords have been replaced to original form by %1.";
$LlamaMessage[1] = "Your vocal cords have been changed into a Llama's by %1!";

// Admins
// A player becomes admin (or super admin) at join when BOTH are true:
//   - the player's NAME is in $Admins[] (or $SuperAdmins[]), and
//   - Player Setup field 5 holds the code $AdminPassword (or $SuperAdminPassword).
// The 1998 client called field 5 "Other Info"; the 1.50 client labels the same box "RPG password".
// A name can be typed by anyone, so the code is the only secret: choose your own and keep it private.
//
// PORT 1: the release shipped the codes "1Il" and "lI1". They are published with the mod, so they are
//         not set here. With no code set, nobody is made admin this way (scripts\server.cs tests it).
// PORT 2: the release shipped $SuperAdmins[0] = "Vage" (the author). Together with the published code
//         that made anyone using that name a super admin on every server. The list is empty here.
// PORT 3: the release's banlist.cs (two permanent address bans of the author's) is not shipped.
// The host (loopback) is always admin and super admin.
//
// $AdminPassword = "your-own-code";
// $SuperAdminPassword = "your-own-other-code";

$Admins[0] = "";
$Admins[1] = "";

$SuperAdmins[0] = "";
$SuperAdmins[1] = "";
