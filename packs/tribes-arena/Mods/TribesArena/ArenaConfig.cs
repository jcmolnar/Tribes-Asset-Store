// Tribes Arena v3.0 -- settings.  PORT (Modern Tribes 1.50): written for the port from the
// archive's config\ServerConfig-example.cs. The entry script execs it once at start-up.
// Left out on purpose (the example set them and would overwrite the host's own): the super
// admin password, telnet port and password, packet rate / size, console log mode, the mission
// list (the pack's missions\ folder is the list) and the start-up Server::loadMission.
// No password ships with the pack. Lists: set the count, then entries 1..count.
// __________________________________________________________________________

// Super Admin ('S'): the stock $AdminPassword. It is NOT set here. While it is empty the
// admin-password box does nothing at all (trusted / regular passwords included).

// Trusted Admin passwords ('M')
$TrustedAdminCount = 0;
// $TrustedAdminPassword[1] = "";

// Regular Admin passwords ('A')
$RegularAdminCount = 0;
// $RegularAdminPassword[1] = "";

// Admin password name restriction: with it on, only the listed names (or the listed
// addresses) can use an admin password.
$AdminPasswordNameLookupEnable = 0;
$AdminPasswordNameLookupCount = 0;
// $AdminPasswordNameLookup[1] = "Complete Player Name";
$AdminPasswordNameLookupExceptionIPCount = 0;
// $AdminPasswordNameLookupExceptionIP[1] = "IP:aa.bb.cc.dd";

// "Unadmin myself" password ("" = off) and "kick myself" passwords
$UnadminPassword = "";
$KickMyselfCount = 0;
// $KickMyselfPassword[1] = "";

// Address lists (a sub-string of the address, e.g. "IP:10.1.2.")
$AutoKickIPListCount = 0;          // kicked on join
// $AutoKickIPList[1] = "IP:aa.bb.cc.dd";
$AutoKickIPListDuration = 86400;
$NoAdminIPListCount = 0;           // can never be admin
// $NoAdminIPList[1] = "IP:aa.bb.cc.dd";
$AutoAdminIPListCount = 0;         // given 'A' admin on join
// $AutoAdminIPList[1] = "IP:aa.bb.cc.dd";
$ProtectedIPListCount = 0;         // cannot be kicked or banned
// $ProtectedIPList[1] = "IP:aa.bb.cc.dd";

// Admin options
$MapDuelOnlySuperAdmin = 0;                 // only super admins change / vote to Duel missions
$TrustedAdminCanSetServerPassword = 0;      // trusted admins may change the join password
$TrustedAdminCanStripRegularAdmin = 1;      // trusted admins may strip regular admins
$TrustedAdminCanNotBeKicked = 1;            // regular admins cannot kick trusted admins
$AdminKickTimeSeconds = 180;                // a kick lasts this long
$AdminKickPasswordTimeSeconds = 180;        // ... when the player used a kick-myself password
$AdminBanTimeSeconds = 86400;               // a ban lasts this long
$AdminPermaBanTimeSeconds = 86400000;       // a perma-ban lasts this long
$OnlySuperAdminCanChangeReadyUp = 1;        // only super admins switch the ready-up timer
$OnlySuperAdminCanChangeAutoJoin = 1;       // only super admins switch auto team join
$OnlySuperAdminCanChangeTimeLimit = 1;      // only super admins change the time limit
$OnlySuperAdminCanResetServer = 1;          // only super admins reset the server defaults
$AllAdminsCanChangeLockedPlayerTeam = 1;    // any admin can unlock a player
$AllAdminsCanVoteMaps = 1;                  // admins can also start a map vote
$WarnAdminsWhenTKer = 1;                    // tell the admins about a bad team killer
$KickBlankPlayers = 1;                      // kick players whose name is all blanks
$KickBlankPlayersDuration = 600;
$MapVoteIncrementalDelay = 30;              // growing delay before the same player can re-vote a map
$RegularPlayersCanNotVoteMapsPubMode = 0;   // 1: players cannot start map votes in Public Mode
$PubAdminsMayNotChangePubMatchMode = 1;     // regular admins cannot switch Public <-> Match mode
$ReplaceTabMenuPlayerInfoByStats = 1;       // Tab player info shows statistics (needs LizStats)
$UseNewScoringSystem = 1;                   // kill / death scoring instead of the old score
$DisplayTeamStatsInTabMenu = 1;             // kills and deaths per team in the score list
$SniperRifleLimitInPubMode = 3;             // laser rifles per team in Public Mode (0 = no limit)
$AutoObsAFKers = 1;                         // idle players go to observer in Public Mode
$DisableReadyUpTimer = 1;                   // no ready-up timer in Public Mode
$TabMenuExploitKickTimeSeconds = 1200;      // kick length for a forged team-menu code
$ArenaFixedWinningScore = 1;                // winning score cannot be changed in Public Mode
$ArenaMaxNumberOfAdmins = 3;                // -1 = no limit, 0 = admins cannot admin anyone
$ArenaAutoEvenTeams = 1;                    // even the teams automatically

// LizStats (map and server statistics; written to config\lizStatisticsServer.cs and
// config\lizStatisticsMap.cs after every map)
$LizStatsEnable = 1;         // master switch
$LizStatsMap = 1;            // keep map stats
$LizStatsServer = 1;         // keep server stats
$LizStatsSaveAfterMap = 1;   // save after every map (the original's save-on-quit hook is not in the port)

// Server options
$WarnTKersWithTheirTotalTKCount = 1;                     // tell team killers their count
$FixInventorySpamExploit = 1;                            // cap purchases per station visit
$FixInventorySpamExploitMaxBuyCountPerInvenVisit = 75;
