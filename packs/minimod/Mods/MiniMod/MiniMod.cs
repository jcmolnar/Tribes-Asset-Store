// MiniMod v1.0 (Dewy and the MiniMod Team, December 1999) -- Modern Tribes (1.50) entry script.
//
// The original was started with one of the two shortcuts in the release zip:
//     tribes -mod MiniMod-v1
//     tribes -mod MiniMod-v1 -dedicated
// and the game then ran MiniMod-v1.cs from the mod folder. That file is the framework: it loads
// the plugin core, every plugin datablock, and replaces createServer so the server-side plugin
// files load when a server starts. It ships unchanged in name as scripts\MiniMod-v1.cs.
//
// PLUGINS
//   A plugin is a set of files under plugins\ named <anything>.<Kind>.cs (Kind = Item, ArmorData,
//   CodeFusion, Station, Turret, ...). Every such file found under plugins\ is loaded; there is
//   no list to edit. To turn a plugin off, move its folder out of plugins\ (the original manager
//   program moved it to a "storage" folder next to plugins\). All plugins that came enabled in the
//   v1.0 full release are enabled here.
//
// SETTINGS
//   MiniMod.Prefs.cs in this folder: admin list, votes, bots, weapon options.
//
// BOT ROUTES
//   BT_<map>.cs in this folder. Routes a host designs in game are saved to config\BT_<map>.cs
//   and win over the ones here.
echo(">> MiniMod v1.0");
exec("MiniMod-v1.cs");
