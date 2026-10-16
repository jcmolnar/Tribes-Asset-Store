// Asylum 2.5 ("Asylum2", www.planetstarsiege.com/asylum, files dated 2000-06-19)
// Modern Tribes (1.50) entry script. Plain ASCII.
//
// The release was a flat folder of scripts with no readme, no shortcut and no settings file:
// the game's own console.cs loaded the mod's copies of the stock script names (ArmorData, item,
// game, player, station, staticshape, turret, vehicle, mine, baseExpData, baseProjData) from the
// mod folder. Nothing else was exec'd, so nothing else is exec'd here.
echo(">> Asylum 2.5 (Asylum2) -- 1.50 port entry");

// PORT: the mod's game.cs is older than the stock flag timer. base objectives.cs (which this
// pack does not replace) reads $flagToStandTime when a neutral flag is picked up; with the mod's
// game.cs loaded nothing sets it. 180 is the stock value.
$flagToStandTime = 180;
