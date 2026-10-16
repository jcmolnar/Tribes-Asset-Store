// WWII Mod by Roma (Roman Kudinov / C-- / ISR_BROOD), scripts.vol dated 2011-08-22.
// Modern Tribes (1.50) entry script.
//
// The original was installed by renaming base\ to WWII\ and replacing the game's console.cs and
// scripts.vol. Here it is an ordinary mod folder: launch with  -mod WWIIMod  and the client's
// own console.cs picks up this mod's server.cs / game.cs, which load the rest (WWIIload.cs).
//
// Host settings live in this folder:
//   WWII.cs          join messages, the advert loop, the welcome text, the admin passwords
//   WWII_MapList.cs  map rotation and the player count each map needs
// A copy of either file placed in config\ wins over the one here.
echo(">> WWII Mod");
