// Insomniax TRIBES Mod v0.9c (Kevin "*IX*Savage1" Savage, insomniax.net; scripts.vol dated
// 2000-04-09) -- Modern Tribes (1.50) entry script.
//
// Original launch line (README.TXT of 0.9b, the last full release; 0.9c is a scripts.vol
// update for it):
//     tribes.exe -mod insomniax
// The 1998 game then ran config\insomniax.cs, which held nothing but the IX-Admin settings.
// Here the launch is
//     -mod Insomniax
// and those settings live in InsomniaxSettings.cs next to this file (same values as the
// release's config\insomniax.cs). The console command ixSave(); writes the current settings to
// config\InsomniaxSettings.cs, and a copy there wins over the one next to this file.
// (The settings file is NOT named insomniax.cs any more: a file of that name in config\ would
// be picked up as this entry script.)
echo(">> ");
echo(">> INSOMNIAX TRIBES MOD v0.9c ");
echo(">> ");

exec("InsomniaxSettings.cs");
