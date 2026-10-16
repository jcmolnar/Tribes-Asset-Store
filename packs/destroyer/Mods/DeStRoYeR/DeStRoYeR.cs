// Destroyer Mod by {SOF} Snake eye (Scripts.vol packed 2002-12-23) -- Modern Tribes (1.50)
// entry script.
//
// The archive was a Scripts.vol for Tribes\DeStRoYeR plus a host options file DeStRoYeR.cs for
// Tribes\Config. The mod's item loader (scripts\executeFiles.cs, hooked into interiorLight.cs)
// starts with exec(DeStRoYeR), so a file of this name must exist: this is it. It is run once
// when the game starts and once more each time a server is created.
//
// PORT: the original options file is NOT shipped. It set the same admin password ("Password")
// in three places, opened a telnet console on port 23 with the password "password", listed the
// server on the master server under the author's name and e-mail, and fixed the port, the
// player limit, the vote settings, the packet rate and eight team names and skins. Those are
// the host's choices; nothing here sets them. What the mod itself reads from that file:
//
//   $SADPassword[n]   n = 0..99   super admin passwords (empty = slot unused)
//   $PAPassword[n]    n = 0..99   public admin passwords (empty = slot unused). The original
//                                 file spelled this $PAPPassword, a name no script reads.
//   $AdminPassword                the stock admin password; in this mod it gives super admin.
//
// A host who wants them sets them in his own server config, not here: this file is replaced
// when the pack updates. The original team names were Psycics / Mortals / Immortals / UnDead
// with the skins beagle / dsword / cphoenix / swolf.
echo(">> Destroyer Mod by {SOF} Snake eye");

// the one mod setting of the original file (no script in the vol reads it; kept as written)
$ShoppingList = 1;
