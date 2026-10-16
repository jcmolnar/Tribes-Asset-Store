// Phobiax Expansion Mod 1.09 by Ben Ross (Dreadnaught), 2000-11-29: an expansion of the
// Insomniax.net TRIBES Mod 0.9c by Kevin "*IX*Savage1" Savage, and a complete replacement for
// it -- Modern Tribes (1.50) entry script. Not part of the original release.
//
// Original launch line (ReadMe_Phobiax.txt):
//     tribes.exe -mod phobiax
// The 1998 game then ran config\phobiax.cs, which held nothing but the PX-Admin settings.
// Here the launch is
//     -mod Phobiax
// and those settings live in PhobiaxSettings.cs next to this file (same values as the
// release's config\phobiax.cs). The console command ixSave(); writes the current settings to
// config\PhobiaxSettings.cs, and a copy there wins over the one next to this file.
// (The settings file is NOT named phobiax.cs any more: a file of that name in config\ would be
// picked up as this entry script.)
//
// pxUserList.cs next to this file is the mod's user list (name + password + address masks ->
// admin level). It ships switched OFF and empty; the release shipped it switched on and empty.
echo(">> ");
echo(">> PHOBIAX EXPANSION MOD v1.09 (Insomniax 0.9c) ");
echo(">> ");

$MODInfo = "Phobiax Expansion Mod 1.09 by Dreadnaught\nan expansion of the Insomniax.net mod 0.9c by *IX*Savage1";

exec("PhobiaxSettings.cs");
