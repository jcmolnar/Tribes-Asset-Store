//----------------------------------------------------------------------------
// Herc Havoc -- boot script.
//
// The authentic-Starsiege fork of Mech Mayhem: 1:1 Starsiege scale (speeds,
// velocities, ranges, blast radii, mass), health and damage / 100, each
// HERC's own default configuration and reactor, no heat, no shutdown, no jets.
// Mech Mayhem is untouched and still ships as its own mod.
//
// Exec'd by ExecModScripts (console.cs) when "-mod HercHavoc" is on the
// command line / modlist.txt -- before any createServer, so the flags below
// gate datablock registration at the correct time.
//
// Generated scripts (do not hand-edit; tools/hh_gen.py):
//   scripts\HHWeapons.cs  scripts\HHChassis.cs  scripts\HHTwins.cs  botbrain.cfg
//----------------------------------------------------------------------------

// Register the Starsiege HERC armors: ArmorData.cs execs MechArmorData.cs
// behind this flag, inside createServer, BEFORE preloadServerDataBlocks().
$MechPack::Enable = 1;

// Generic pre-preload datablock hook in base\scripts\server.cs.
$Mod::ServerDataBlocks = "modDataBlocks.cs";

// Prefer the .glb HERC shapes (correct per-mesh winding) over .dts.
$pref::gltfShapes = 1;

// First person = the Starsiege cockpit: the pilot eye sits on each HERC's `cam`
// node (Mods\HercHavoc\Starsiege shape copies) and the cockpit cage is drawn,
// pitching with the view (engine: Player::cockpitPostAnimate). Seeded ONCE --
// this mod's prefs live in config\HercHavoc\ClientPrefs.cs, so a pilot who turns
// it off keeps it off, and Mech Mayhem's own setting is untouched.
if ($pref::hhCockpitSeeded == "") {
   $pref::mechCockpit3D = 1;
   $pref::hhCockpitSeeded = 1;
}

// Starsiege soundtrack. FileMusic reads $Music::Dir (a mod's own folder) when
// console.cs opens music, which runs AFTER this script. Track 2 = menu theme
// (Starsiege's disc track 2, as with the stock soundtrack); the mission cues
// deal across the rest.
$Music::Dir = "Mods\\HercHavoc\\music";
$Music::Track2 = "Track02.ogg";

// Cockpit HUD: Herc Havoc's REACTOR / systems / mines readout lives in the
// "Mech Cockpit" ModernHUD pack (it switches to Herc Havoc mode when the server
// sends HHState). Select it for this mod ONCE -- Config::apply(...,1) writes
// config\HercHavoc\curconfig.txt, so a pilot who picks another HUD keeps it, and
// no other mod's HUD choice is touched. Deferred to the main menu: the pack
// system is not up while mod scripts execute at boot.
function HercHavoc::seedHud()
{
   if ($pref::hhHudSeeded != "")
      return;
   $pref::hhHudSeeded = 1;
   Config::apply("ModernHUD:mechcockpit", 1);
   echo("[HERC] cockpit HUD selected for Herc Havoc (Mech Cockpit pack).");
}
if (!$dedicated && $pref::hhHudSeeded == "")
   schedule("HercHavoc::seedHud();", 3);

$HercHavoc::Loaded = 1;
echo("[HERC] Herc Havoc boot: HERC pack enabled, datablock hook armed, glTF shapes on.");
