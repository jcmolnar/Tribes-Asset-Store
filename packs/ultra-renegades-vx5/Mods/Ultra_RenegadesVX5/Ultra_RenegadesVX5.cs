// Ultra Renegades VX5.01 (UltraVX5, by kissiePOO / "UltraVXAuthor") -- start-up settings.
// Modern Tribes client 1.50 port.
//
// The mod loader runs this file once at start-up (-mod Ultra_RenegadesVX5), after the mod's own
// server.cs. It replaces the "Server Mod Profiles" block of the original config\Autoexec.cs.
// To change a setting for your own server, copy the line into config\autoexec.cs (that file
// runs later and wins).

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
// No default password ships with this pack (the 2002 Autoexec.cs shipped "BetterChangeMe").

echo("Ultra Renegades VX5.01 (Ultra_RenegadesVX5) settings loaded: profile "
	@ $Ultra_RenegadesVX5::ultravxmod @ ", difficulty " @ $Ultra_RenegadesVX5::ultravxDIFmode);
