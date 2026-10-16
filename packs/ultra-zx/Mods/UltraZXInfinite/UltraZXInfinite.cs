// Ultra-ZX Infinite by {TAS}KINDS (originally Ultra-ZX by *DK*SlipKnot) -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraZXInfinite). The mod itself is the
// flat script set in scripts\ (its own server.cs, admin.cs, item.cs ...). The original launch
// line was
//     Tribes.exe +exec ServerPrefs.cs +exec URZX.cs -mod UltraZX_Infinite
// ServerPrefs.cs held ordinary server prefs (host name, team names, master servers); none of
// that is stamped by this pack: set it the usual way. The mod's own switches are in
// SettingsURZX.cs next to this file; scripts\server.cs execs it every time the server starts.
//
// Admin log-on (the SAD password box) is OFF until the host sets a password of their own in
// SettingsURZX.cs. The archive shipped the word "change" for all three levels; no password
// ships with this pack. The host's own (listen-server) client is super admin.

echo("Ultra-ZX Infinite (UltraZXInfinite): settings are in Mods\\UltraZXInfinite\\SettingsURZX.cs");
