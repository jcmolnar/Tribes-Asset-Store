//---------------------------------------------------------------------------------------------
// NovaMorpher 0.821 (VRWarper, 2002) -- server options. Tribes 1.50 port, 2026-10-12.
//
// This file is the mod's own "NovaMorpher.cs" options file, rewritten in plain ASCII for the
// port. The game runs it when the mod loads and the mod runs it again twice while the server
// starts ("refresh values", needed for the bots), so it must only SET values.
//
// Every game option below has the value the 0.821 release shipped with. What changed:
//   * host name, public / private, player limit, time limit, team damage, telnet and console
//     log lines are gone: set those in the Host Game screen.
//   * every password is EMPTY. An empty password switches that door off.
//   * the scripts\server line at the end is gone (the game starts the server itself).
//---------------------------------------------------------------------------------------------

//--- NovaMorpher options ---------------------------------------------------------------------
$NovaMorpher::AdvanceID = "True";        // "advanced identification": name / address log, announces a joiner's other names
$NovaMorpher::FriendlyMines = "True";    // friendly mines
$NovaMorpher::TDBackDamage = "True";     // team damage is returned to the shooter
$NovaMorpher::AccidentRange = "10";      // team hits closer than this count as an accident
$NovaMorpher::FlagReturnTime = "30";     // seconds before a dropped flag returns
$NovaMorpher::RespwanTime = "0";         // respawn delay in seconds, 0 = none
$NovaMorpher::ItemRespwanTime = "1";     // respawn time of repair packs, kits ...
$NovaMorpher::TurretsKill = "True";      // a turret's kills score for the player who deployed it
$NovaMorpher::TkSAD = "100";             // team kills charged for team-killing a super admin
$NovaMorpher::LastDelDate = "Sept 5, 2002";  // text shown to a player whose saved profile is gone
$NovaMorpher::AllowClient = "true";      // load the two key-bind commands (ToggleMorph, ToggleWepSetting)
$NovaMorpher::EvenTeams = "true";        // balanced teams (admin can switch off in the Tab menu)
$NovaMorpher::VotedAdminTime = 300;      // seconds a voted admin stays admin
$NovaMorpher::GracePeriod = "true";      // invincible at spawn
$NovaMorpher::GraceTime = 10;            // ... for this many seconds
$NovaMorpher::EnableSpoonBot = "True";   // SpoonBot bots instead of the stock ones
$NovaMorpher::AllowOInfo = "false";      // (was: report this server to the author's web site. Removed in the port.)
$NovaMorpher::UsePersonalSkin = "1";     // 0 = team skins, 1 = personal skins, 2 = each player picks on joining
$NovaMorpher::BanTime = "1800";          // ban length in seconds
$NovaMorpher::Gravity = "1";             // "bumpy" gravity strength, 0 = off
$NovaMorpher::EnablePatch = "True";      // load *.NMPatch.cs add-on files the host has installed
$NovaMorpher::Meteoriod = "True";        // random bombs from the sky
$NovaMorpher::MeteoroidAddTime = "20";   // seconds added to the random 0-60 s between them
$NovaMorpher::flagToStandTime = "120";   // seconds a flag carrier has to capture
$NovaMorpher::JetSmoke = "True";         // jet smoke
$NovaMorpher::JetSmokeRate = 1;          // how often the server checks for jetting (0 and 1 = default)
$NovaMorpher::noLeaveArea = "2";         // out of bounds: 0 nothing, 1 zap back, 2 bounce back, 3 slow death

// the hack gun (an in-game weapon that turns enemy equipment to your team for a while)
$NovaMorpher::HackTime = "15";           // seconds a hack takes
$NovaMorpher::HackedTime = "90";         // seconds before a hacked object goes back to its team
$NovaMorpher::AllowHacking = "true";

//--- Admin passwords -------------------------------------------------------------------------
// Chat line "#admin <password>" (only when ComChatAdmin is true) gives the first rank whose
// password matches: padmin = public admin, saadmin = super admin. The last entry of each list
// must stay "false". Leave a password empty to switch it off. The release shipped the
// placeholders "change me please" and "pick your password wisely" here: do not use those.
$NovaMorpher::ComChatAdmin = "false";
$NovaMorpher::padmin[0]  = "";
$NovaMorpher::padmin[1]  = "false";
$NovaMorpher::saadmin[0] = "";
$NovaMorpher::saadmin[1] = "false";

// The release shipped a public default password for these two; the port ignores both (the
// "goodies" commands are super admin only, the remote modder console is not shipped).
$NovaMorpher::AdminItemPass = "";
$NovaMorpher::ModderPass = "";
$NovaMorpher::ModderFile = "False";

//--- SpoonBot options ------------------------------------------------------------------------
$Spoonbot::DebugMode = False;
$BotTree::DebugMode = False;
$SpoonBot::EvilWeapons = False;          // very strong weapons for bots
$Spoonbot::AutoSpawn = true;             // spawn the bots listed in AutoSpawnBotConfig.cs on every map
$Spoonbot::BotTree_Design = false;       // bot route design mode
$SpoonBot::BotTree_MaxAutoCalc = 20;     // above this many route points automatic routes are off
$BotTree::AutoTree = True;               // False = place every route point by hand
$Spoonbot::UserMenu = False;             // True = any player may add / remove bots from the Tab menu
$Spoonbot::BotChat = True;               // bot chat lines
$Spoonbot::RespawnDelay = 10;            // seconds before a dead bot respawns (must be above ThinkingInterval)
$Spoonbot::DelOnSpawn = false;           // delete the old body before the respawn
$Spoonbot::IQ = 543345;                  // skill multiplier, never 0
$Spoonbot::ThinkingInterval = 1.3;       // seconds between bot decisions (raise on a slow host)
$Spoonbot::MovementInterval = 1.2;       // seconds between movement updates (below ThinkingInterval)
$Spoonbot::RetreatDamageLevel = 0.6;     // bots retreat above this damage, 1.0 = never
$BotHUD::ToggleKey = "b";

//--- do not change below ---------------------------------------------------------------------
$Spoonbot::SPOONBOTCSLOADED = True;
$debug = false;
