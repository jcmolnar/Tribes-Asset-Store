// BaseDuel.cs -- Modern Tribes (1.50) entry script for DuelMOD by Drink|Kahlua (2000-05).
//
// The 2000 archive was a drop-in for base\ ("To install, simply unzip the file into your Tribes
// directory"): DuelMOD.cs, seven announcer sounds and four maps of mission type "Duel" whose first
// line is exec(DuelMOD). There was no launch line and no console.cs: loading a Duel map switches
// the server to duel rules, loading any other map switches it back (DuelMOD::restoreServerDefaults).
// Here the same files sit in this mod folder, so nothing is copied into base\.
//
// The announcer SoundData blocks are declared once at server creation through base's
// $Mod::ServerDataBlocks hook (scripts\DuelData.cs), so every client receives them at connect.
// In the original they were declared when a Duel map loaded, after the datablock preload.
$Mod::ServerDataBlocks = "DuelData.cs";
echo(">> DuelMOD by Drink|Kahlua (2000): load a Duel map (DuelMap, Duelmap2, Duelmap3, Duelmap4)");
