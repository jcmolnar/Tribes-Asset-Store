// Beginner Mod (Dustin Bruce, August - November 2003) -- Modern Tribes (1.50) entry script.
//
// The release zip is one folder, "Beginner_Mod", with no readme and no shortcut: it was started with
//    tribes -mod Beginner_Mod
// and nothing else was exec'd. The client's own console.cs loads server.cs from this mod's scripts
// folder, and server.cs loads the rest:
//    Special_Functs.cs               createWeapon / createBackPack / createMisc / createDeployable /
//                                    createArmor / AmmoPack::addAmmo / ReInit::Add / deployItemX
//    ProjectileData\*.cs  ArmorData\*.cs  BackPacks\*.cs  Weapons\*.cs  Deployables\*.cs
//    Turrets\*.cs  Misc\*.cs         one file per stock item
//
// It is a starting point for mod makers: stock Tribes 1.11 with every armour, weapon, pack and
// deployable moved into its own file and registered through one helper call. A player sees stock
// Tribes. The mod's admin.cs, game.cs and comchat.cs were reformatted copies of the stock files and
// are not shipped: the 1.50 ones are used.
echo(">> Beginner Mod");
