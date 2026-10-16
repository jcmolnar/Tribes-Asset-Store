// hvMechWarrior v1.4 by hvPalantirion and hvHelplessTarget (House Vagoroth, 2000-11)
// Modern Tribes (1.50) entry script.
//
// The original was started with  -mod hvMechWarrior-v14  and nothing else: no settings file and
// no +exec. The client's own console.cs loads server.cs from this mod's scripts folder, so there
// is nothing to wire here. Launch with  -mod HvMechWarrior  (add -dedicated for a server).
//
// Server-side mod: every mech, weapon and turret is built from stock Tribes shapes and sounds,
// so players join without installing anything.
//
// Bots: this folder ships a botbrain.cfg with an empty roster on purpose. The game's built-in
// bots are equipped from stock weapons (disc launcher, chaingun, plasma) that this mod removes,
// so they would walk around unarmed; the empty roster keeps them off under this mod only.
// Maps that carry their own AI drone paths still get the mod's drones (scripts\ai.cs).
echo(">> hvMechWarrior v1.4");
