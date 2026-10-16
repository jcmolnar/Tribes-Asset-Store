//=======================================================
// Sex Mod By Plasmatic
// Copyright May, 2001.  By Steve Madden
// n3ppvw@home.com or ziptiezmail@netscape.net
// icq# 77161332
//=======================================================
//=======================================================
//
// Sex Mod is not a copy-cat mod, and is not based on 
// any other mod besides base mod that ships with tribes ;)
// Special thanks to Sevnn and Scavenger of the Annihilation mod 
// And all the others that helped me hunt down bugs.
//
//=======================================================
//
// Usage- For non dedicated servers- 
// Not recomended for network servers, great for practice, or small LAN games.
// Right click on tribes.exe in C:\Dynamix\TRIBES and create shortcut.
// Right click your new shortcut and add " -mod sex" to the target line.
// Hit apply, and ok. Double click to run.
// Rename and drag to desktop for ease of use.
// You will be admin automatically with this setup.
//
//=======================================================
//
// Usage- For dedicated servers-
// Recomended for public servers, or LAN games
// Right click InfiniteSpawn.exe in C:\Dynamix\TRIBES and create shortcut.
// Right click your new shortcut and add " *tribes.exe -mod sex -dedicated" 
// to the target line.
// Hit apply, and ok. Double click to run.
// Rename and drag to desktop, copy and place in 'Startup' if you like
// -C:\WINDOWS\Start Menu\Programs\StartUp.
//
//=======================================================
// edit adminuserslist.cs in config to your liking.
//=======================================================
// ALL connecting players are logged in connect.log in config directory.
//=======================================================
//
// Server will automatically admin local clients
// -ip address 192.168.0.1 and 192.168.0.2 on your local network
// If you have a router or if server is set up as a dhcp server this should work.
// If not, admin yourself with adminuserslist.cs
// Your connecting ip address will be in connect.log after you join server. 
//
//=======================================================
// Known issues.
// Players hogging control of Rocket turrets at command stations can cause server lag.
// Only after there are ALOT of rockets in air.
// Firing plasma turrets will have the same effect, but not so pronounced.
// Rock launcher no longer lags in this manner as it does NO damage to players.
// Most lag issues will arise from servers connection, not actual server lag.
// Contact me if you have questions.
//=======================================================

// reset the server on last client disconnect?
$resetserver = false;

// mission server starts on, and resets to.
//PORT-OFF: $pref::LastMission = "Broadside";

// records admin and vote actions.. you wanna know whats going on in yer server, right?
$AdminLog = true;

// connect message.
$plasmatic = "-Confuse, Annoy and Destroy your foe.\n<f1>SEX mod NC17 By: <f2>.:(A):.Armagedon\n<f3>Testical Server!";

//What they see when they first get into game, before initial spawn
$Server::JoinMOTD = "<jc><f1>Welcome to <f2>SEX mod NC17<f1>\nContact Plasmatic at n3ppvw@home.com or Armageddon at ArmageddonHatesU@Aol.com if you have questions or comments\nWebsite: http://plasmatica.tribes-universe.com/ & www.Sex.666Clan.org\n<f1>Spank your mouse to join.";

//==========================================

//ADVANCED SEX MOD OPTIONS
//These options may be toggled by admin also.	
// Reset these on map change?
$reset = true;
//  Base damage. True for no destroyable station and generators.
$BaseRapeDefault = false;
$BaseRape = false;
$BaseHeal = true;
$personalskins = true;
//  Builder mode. True and deployable packs don't dissappear on deploy.
//  Also changes spawn weapons and Soul Sucker weapon properties.
$BuildDefault = false; 	
//  No kill zone -player damage. True and players don't take damage.
$NoDamageDefault = false;
//Fair teams? Do you want players to be able to switch teams. 
$FairTeamsDefault = true;
//  Builder mode voteable? Not toggleable by admin, may only be changed here.
$VBuild = false;
//===============================================


$novote = true;
$Server::AutoAssignTeams = "true";
//PORT-OFF: $Server::CurrentMaster = "0";

// better change these, for admin programs like tricon.
//PORT-OFF: $TelnetPort="2001";
//PORT-OFF: $TelnetPassword="sexrox";

// what players can admnin themselves by typing "sad("$AdminPassword");" into the console
//PORT-OFF: $AdminPassword = "dikhed";
//not a good idea to let this one out. You might want to change it too.. ;)

//PORT-OFF: $pref::PacketRate = "10";
//PORT-OFF: $pref::PacketSize = "200";

$Server::FloodProtectionEnabled = "false";
//PORT-OFF: $Server::HostName = "|| .:(A):.-Hole || |_|Testing|_| (No Entry)";
//PORT-OFF: $Server::HostPublicGame = "true";

//admin votes count more..
$Server::AdminWinMargin = "4";

$Server::VoteFailTime = "30";
$Server::VoteWinMargin = "0.549999";
$Server::VotingTime = "20";
$Server::warmupTime = "1";

$Server::Info = "<jc><f3>SEX.v.NC17 Created By: <f2>.:(A):.Armagedon\n<f3>Admin: <f2>.:(A):.\n<f3>Original SEX mod Email: <f2>n3ppvw@home.com<f1>||<f3>SEX.v.NC17 Info: <f2>www.Sex.666clan.org\n<f3>SEX mod Website: <f2>plasmatica.cjb.net";

//How many players can your INTERNET CONNECTION handle.
//PORT-OFF: $Server::MaxPlayers = "3";



// How long of a wait after they get killed, in seconds
$Server::respawnTime = "0.1"; //lower numbers mean more fun time.. 

// start server with team damage on? 0=off 1=on
$Server::TeamDamageScale = "0"; //See above

$Server::timeLimit = "30";
$Server::TourneyMode = "false";

//Name of teams.
$Server::teamName0 = "Pan";
$Server::teamName1 = "Satyr";
$Server::teamName2 = "Children of the Phoenix";
$Server::teamName3 = "Starwolf";
$Server::teamName4 = "Generic 1";
$Server::teamName5 = "Generic 2";
$Server::teamName6 = "Generic 3";
$Server::teamName7 = "Generic 4";

//skins are enabled in this mod, no need to change this.
$Server::teamSkin0 = "beagle";
$Server::teamSkin1 = "dsword";
$Server::teamSkin2 = "cphoenix";
$Server::teamSkin3 = "swolf";
$Server::teamSkin4 = "base";
$Server::teamSkin5 = "base";
$Server::teamSkin6 = "base";
$Server::teamSkin7 = "base";

//No need to mess with this..
//PORT-OFF: $Server::numMasters = "3";
//PORT-OFF: $Server::Port = "28001";

function remotePlayFakeDeath(%client,%anim)
{
Playnextanim(%client);
}

$Console::LogMode = "1"; 
//---------------- new
//use your best judgement here 
// vote percent needed to admin
$Server::VoteAdminWinMargin = 0.8;
// min votes needed to vote admin
$Server::AdminMinVotes = 4;
// percent needed to pass any vote besides admin vote
$Server::VoteWinMargin = 0.6;
// Min votes to pass
$Server::MinVotes = "1";
// min votes percentage of total players
$Server::MinVotesPct = 0.5;
// vote time in seconds 
$Server::MinVoteTime = "180"; 
$obsAlert = true;
$NoVoteAdmin = true;
//PORT-OFF: $CPU::estimatedSpeed = "1800";
