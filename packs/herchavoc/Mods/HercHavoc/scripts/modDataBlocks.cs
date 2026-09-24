//----------------------------------------------------------------------------
// Herc Havoc -- server-side datablocks.
// Exec'd from base\scripts\server.cs via $Mod::ServerDataBlocks, after the
// stock datablock scripts (overrides win the last-wins race) and before
// preloadServerDataBlocks() (so everything declared here registers).
//
// Order is load-bearing:
//   HHWeapons  weapon/projectile datablocks + the per-weapon damage table
//   HHTwins    Crippled (leg-crit) twin PlayerData -- full copies
//   HHChassis  1:1 stat dot-assignments on the herc armors + twins, registry
//   MechPilot  Last Stand pilot armor + kit
//----------------------------------------------------------------------------

exec(HHWeapons);
exec(HHTwins);
exec(HHChassis);
exec(MechPilot);
exec(HHSystemsData);   // special-component pack (pack key)
exec(HHMapData);       // Starsiege map buildings (tools/hh_ss_mission.py)

$HercHavoc::DataBlocksLoaded = 1;
echo("[HERC] modDataBlocks.cs exec'd (pre-preload hook OK).");
