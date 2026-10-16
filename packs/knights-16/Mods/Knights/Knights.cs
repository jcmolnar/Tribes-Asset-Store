// Knights v1.6 by }KR{Dark Knight (scripts.vol dated 2003-09-09) -- Modern Tribes (1.50) entry
// script. Not part of the original release. The original was one scripts.vol in tribes\Knights
// plus a serverConfig.cs in tribes\config (server name, passwords, team names, auto-admin names).
// Launch here:  -mod Knights
echo(">> Knights v1.6");

$MODInfo = "Knights v1.6 by }KR{Dark Knight";

// The one mod setting the release's serverConfig.cs carried that the scripts read:
// true = a joining player is asked "Use Personal Skin / Use Team's Skin" before the first spawn
// (game.cs). Set it to false for a stock join.
$Knights::UsePersonalSkin = True;
