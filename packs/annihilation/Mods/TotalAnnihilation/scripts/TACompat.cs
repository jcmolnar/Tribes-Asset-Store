//-----------------------------------------------------------------------------
// TACompat.cs -- console commands Total Annihilation expects from the 1.4x
// plugin DLLs it ships with (TerrainInfo.dll, GeoIp, MySQL.dll) plus a handful
// of calls that are dangling in the mod's own source. Reimplemented in script
// so the modern client can host the mod without loading 1998 plugin binaries.
//
// Loaded from TotalAnnihilation.cs BEFORE the mod's own boot script.
// Same role as Mods\Annihilation\scripts\Compat.cs and
// Mods\StarWars\scripts\Compat.cs -- see those for the precedent.
//
// **HOW THIS LIST WAS BUILT -- do not "improve" it by guessing**
// Every `Namespace::Fn(` call in the mod's 304 scripts was collected with a
// MULTI-SEGMENT-AWARE pattern, then subtracted from three sets: the mod's own
// `function` definitions, base\scripts' definitions, and the 1,089 native
// commands the engine actually registers (every addCommand() string literal in
// engine\ + program\). That left 52 names; 29 are TED/mission-editor only and 1
// is datablock-namespace dispatch, leaving the 22 shimmed below.
// **A single-segment regex over-reports badly: `Ann::Clean::string`,
// `Ann::PlayerInfo::Connect` and `Duck::PullMA::Start` all look undefined if you
// only capture the LAST two segments, and all three are defined by the mod
// (comchat.cs:48, iplogger.cs:2, arenabbootcamp.cs:194).**
//-----------------------------------------------------------------------------


// --- TerrainInfo.dll -------------------------------------------------------
// Returned "cx cy w h haze perspective visible" for the loaded mission. Only
// getterrain() (tafunctions.cs:387) consumes it, taking word 6 into
// $visDistance and word 4 into $Haze; $visDistance is then the bots' SpotDist
// (annibots.cs, ~40 call sites), so returning "" would leave every bot with an
// EMPTY sight range. No engine command exposes the mission's Sky distances
// (xSky::getHaze returns a COLOUR, not a distance), so these are seeded from
// overridable globals instead of invented per-mission. 600 is the modal
// visibleDistance across this mod's own 404 missions; set $TA::VisibleDistance
// / $TA::HazeDistance in TotalAnnihilation_Settings.cs to tune.
function Terrain::getInfo()
{
   if($TA::VisibleDistance == "")
      $TA::VisibleDistance = 600;
   if($TA::HazeDistance == "")
      $TA::HazeDistance = $TA::VisibleDistance;

   return "0 0 0 0 " @ $TA::HazeDistance @ " " @ $TA::VisibleDistance @ " " @ $TA::VisibleDistance;
}


// --- MySQL.dll helper ------------------------------------------------------
// Ported verbatim from the mod's own Plugins\Scripts\MySQL.cs, which is pure
// script -- it needs no database. geoip.cs is its only caller here. The actual
// Database::/MySQL:: query layer is NOT shimmed: nothing in the 304 scripts
// calls it (checked), so a stub would be dead code.
function MySql::ParseIP(%ip)
{
   if(String::getSubStr(%ip, 0, 8) == "LOOPBACK")
      return "127.0.0.1";

   if(String::getSubStr(%ip, 0, 3) == "IP:")
   {
      %ip = String::getSubStr(%ip, 3, 16);
      %ip = String::getSubStr(%ip, 0, String::findSubStr(%ip, ":"));
   }
   else if((%col = String::findSubStr(%ip, ":")) != -1)
      %ip = String::getSubStr(%ip, 0, %col);

   return String::getSubStr(%ip, 0, 15);
}


// --- GeoIp plugin ----------------------------------------------------------
// Filled $GeoIP[country|regionname|city|...] for GeoIP::print. There is no
// GeoIP database in this client, so report unknown rather than stale values.
// Dead on the play path anyway -- its only caller, server.cs:356, is commented
// out upstream -- but shimmed so enabling that line does not spam the console.
function GeoIp::Lookup(%ip)
{
   $GeoIP[country]    = "";
   $GeoIP[region]     = "";
   $GeoIP[regionname] = "";
   $GeoIP[city]       = "";
   $GeoIP[latitude]   = "";
   $GeoIP[longitude]  = "";
   $GeoIP[metrocode]  = "";
   $GeoIP[areacode]   = "";
   $GeoIP[timezone]   = "";
   $GeoIP[ASN]        = "";
   return "";
}


// --- TA's own engine extensions --------------------------------------------
// GameBase::getName is this mod's alias for the engine's Object::getName;
// annibots.cs, annibotsbeacons.cs, botgear.cs, item.cs and warrior.cs all use
// it on the live path. GameBase::getDataName IS native -- getName never was.
function GameBase::getName(%obj)
{
   return Object::getName(%obj);
}

// Midair-bonus test: true when something is under the target. Returning
// "obstructed" is the conservative answer -- it withholds the midair award
// rather than granting it for every shot.
function Player::ObstructionsBelow(%obj, %height)
{
   return true;
}

// Cosmetic shockwave on a heavy landing (armor.cs:691). No visual, no side
// effects -- the damage it accompanies is applied by the caller.
function Player::Shockwave(%player)
{
   return "";
}

// TA shipped its own AI-graph builder alongside the engine's Graph::AddNode /
// LoadNode / NodeCount / PrintNode. Only ai.cs:2784 calls it, and it treats -1
// as failure; return success so the adjacency pass is a no-op instead of an
// error. This client has its own nav system (BotBrain / SpoonBot).
function Graph::buildGraph()
{
   return 0;
}

// Developer-only tracing, reached solely from dbt() in tafunctions.cs.
function Debug::functions()
{
   return "";
}


// --- GUI ------------------------------------------------------------------
// The engine registers TextList::AddLine and TextList::Clear but not
// setSelected; Control::setValue is the equivalent on this control.
function TextList::setSelected(%ctrl, %row)
{
   return Control::setValue(%ctrl, %row);
}

// Server-browser re-sort hook (gui.cs:388/408). The modern client owns its own
// browser; nothing to re-sort here.
function Server::ResortList(%ctrl)
{
   return "";
}


//-----------------------------------------------------------------------------
// Dangling in UPSTREAM's own source -- called but never defined anywhere in the
// 304 scripts, in base, or in the engine. Stubbed so they fail silently instead
// of printing "Unknown command" on every hit. **Do not "implement" these by
// guessing what they should do -- each one is a feature the mod calls for and
// never shipped.**
//-----------------------------------------------------------------------------
// BotPilot.cs is the one bot file serverAnnihilation.cs does NOT exec (it loads
// BotGear/Think/Types/Funcs/Spawn/Tree/HUD/Move), and jettopos.cs:417 has its
// exec("BotPilot") commented out -- yet game.cs:661 still calls this on every
// mission load. Stubbed rather than exec'ing the 18 KB file: reviving code the
// author disabled activates ALL of it, not just the entry point.
function BotPilot::Init_Waypoints()   { return ""; }

function Armor::onRepairKit(%player) { return ""; }   // 6 armour scripts
function Arena::MapNextFive()        { return ""; }
function Arena::VoteMapNextFive()    { return ""; }
function ArenaTD::MapNextFive()      { return ""; }
function TA::FlairShop(%client)      { return ""; }
function Boost::DeployCheck(%a, %b)  { return true; }
function BotFuncs::BotShopOff(%bot)  { return ""; }
function BotThink::Think(%bot)       { return ""; }
function Midair::onMidairDisc(%a, %b) { return ""; }
function CTFTraining::objectiveComplete(%a)       { return ""; }
function RetrievalTraining::objectiveComplete(%a) { return ""; }
function DestroyTraining::objectiveComplete(%a)   { return ""; }

echo("[TACOMPAT] Total Annihilation plugin shims loaded");
