// Ultra Renegades VX5 "Jman" 2.1 -- start-up settings (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod UltraVX5Jman), after the mod's own
// server.cs. It replaces the settings block of the original config\Autoexec.cs.
// Weapon switches (Run-Time Store, Nuke, MIRV, Ricochet Gun, ...) are in WeaponOps.cs, next to
// this file.

// Mod profile loaded when the server starts (case sensitive):
//   "Ultra_RenegadesVX5"  "Ultra_RenegadesVX5_OGL"  "Ultra_RenegadesVX5_NOTOR"
$Ultra_RenegadesVX5::ultravxmod = "Ultra_RenegadesVX5";

// Difficulty loaded when the server starts (case sensitive):
//   "Defaults" (single shot kills)  "MEDIUM" (4 shot kills)  "HARD" (6-8 shot kills)
$Ultra_RenegadesVX5::ultravxDIFmode = "Defaults";

// "true" lets players start a vote to change the mod profile / the difficulty.
// Admins can always change both from the Tab menu (UltraVX Mode, Difficulty).
$Ultra_RenegadesVX5::modvoting = "true";
$Ultra_RenegadesVX5::difficultyvoting = "true";

// Remote admin logon is OFF until the host sets a password of their own, for example in
// config\autoexec.cs:   $AdminPassword = "something only you know";
// No default password ships with this pack.

echo("Ultra Renegades VX5 Jman 2.1 (UltraVX5Jman) settings loaded: profile "
	@ $Ultra_RenegadesVX5::ultravxmod @ ", difficulty " @ $Ultra_RenegadesVX5::ultravxDIFmode);
