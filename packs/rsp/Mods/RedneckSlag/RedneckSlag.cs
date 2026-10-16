// Redneck Slag Pack (RSP) 1.18 build 0151 by HightechRedneck, patch work by [CNM] Nightwind
// (17/02/2000, for Tribes 1.10). Entry script for the Modern Tribes client (1.50).
//
// The 2000 release was started with
//     Tribes.exe -mod RedneckSlag [-dedicated]                      (RspReadme.txt)
// and its server.cs loads the settings file  config\RedneckSlag.cs  from inside createServer
// (exec(RedneckSlag); validateRSPSettings();). Under 1.50 the launch is  -mod RedneckSlag  and
// the loader runs this file (Mods\RedneckSlag\RedneckSlag.cs) first; createServer finds the
// same file again by name, so the settings below are re-read every time a server is created.
// A config\RedneckSlag.cs of your own, if you make one, wins over this file.
//
// Everything below the PORT lines is the release's settings file. Three lines were changed:
//  * $SuperAdminPassword = "";  is commented out: it would blank the SAD() password a host has
//    set in his own prefs every time a server starts. Set it here if you want one.
//  * $Console::LogMode = "0";   is commented out: it switched the console log file off.
//  * the Telnet lines were already comments in the release and stay that way.
echo("Redneck Slag Pack 1.18 (HightechRedneck) -- 1.50 port entry");
//Anti Flooding Options
$RSP::FloodKill = True; //Toggle dramitic flood measures
$RSP::FloodCount = 7; //Sets the chat line amount that will activate the anti flood procedures. Can't be less then 5
$Server::FloodProtectionEnabled = True; //Dynamix setting that toggles the basic anti flood measures within the server. Must be true if your using flood kill on your server.

//Hacking and Infecting Options
$RSP::AllowHacking = True; //Toggle hacking
$RSP::HackTime = 5; //Time that hacking/infecting takes (In seconds) Can't be less then 2 or greater then 10
$RSP::HackedTime = 900; //Time to wait before returning control to owners (In seconds) Can't be less then 900
$RSP::InfectedTime = 900; //Time to wait before virus expires (In seconds) Can't be less then 900

//Nuke Pack Options
$RSP::NukeDetTime = 30; //Fuse time on the nuke pack {In seconds) Can't be less then 15 or greater then 60

//Anti Out of Mission Area Options
$RSP::AntiOOB = True; //Enables anti out of mission area code
$RSP::AntiOOBTime = 20; //Sets time that you are allowed to be OOB (In seconds) Can't be less then 15 or greater then 60

//Anti Team Killing Options
$RSP::AntiTK = True; //Toggles anti team killing measures
$RSP::TKKickCount = 5; //Sets how many team kill incidents it takes to be kicked off the server. Can't be less then 5 or greater then 30

//Magnetic Pulse Capacitor Pack Options
$RSP::MPCPackChargeTime = 45; //Sets how long the MPC Pack lasts during each activation (In seconds) Can't be less then 45 or greater then 90
//$RSP::MPCPackCoolingTime = 60; //Sets how long the pack must cool before being able to use it again (In seconds) Can't be less then 15 or greater then 90
$RSP::MPCCoolAccordingToUse = True; //Allows the cooling time to vary according to how long a person uses the MPC Pack

//Menu Options
$RSP::ChangeTeams = False; //Toggles team specific changing
$RSP::AdminVote = True; //Toggles admin voting

// SAD() Passwords
//PORT-OFF: $SuperAdminPassword = ""; //Password for super admins to use when using the SAD(""); command

//Console Settings
//PORT-OFF: $Console::LogMode = "0"; //If = 1 then server is logging. If = 0 then server is NOT logging
$Server::FloodProtectionEnabled = True; //Dynamix settings that toggles the basic anti flood measures within the server. Must be true if your using flood kill on your server.

//Telnet Settings... Remove the //s at the beginings of the lines if you want to enable remote server administration through Telnet
//$TelnetPort = 9999;
//$TelnetPassword = telpass; //Default Password
