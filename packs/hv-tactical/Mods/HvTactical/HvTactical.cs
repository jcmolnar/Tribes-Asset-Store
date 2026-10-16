// hvTactical v1 by hvPalantirion (House Vagoroth, 1999-07); grew out of PALrenegades /
// Renegades v1.3, with the Insomniax admin menus and Labrat's personal-skin game.cs.
// Modern Tribes (1.50) entry script.
//
// The original was started with  -mod hvTactical-v1  and nothing else: no settings file and no
// +exec. The client's own console.cs loads server.cs from this mod's scripts folder, so there
// is nothing to wire here. Launch with  -mod HvTactical  (add -dedicated for a server).
//
// Server-side mod: every armour, weapon, turret and pack is built from stock Tribes shapes and
// sounds, so players join without installing anything. The readme and the field guide are in
// this folder.
//
// Admin menus (Tab): the Insomniax "what may a plain admin do" switches ($Insomniax::PA*) are
// set by nothing in the mod, so every one starts OFF: a super admin has every option, a plain
// admin only the votes. A super admin turns them on per server run under
//   Tab > Server Options > Public Admin Lockouts.
// The 1.50 port enforces these switches on the server; the 1999 scripts only hid the entries.
echo(">> hvTactical v1");
