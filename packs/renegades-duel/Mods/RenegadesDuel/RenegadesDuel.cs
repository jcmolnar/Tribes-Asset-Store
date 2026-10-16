// Renegades Duel -- Modern Tribes (1.50) entry script.
//
// The 2002 archive was a drop-over for a running Renegades server: RenDuel.cs, duelmatch.cs,
// resetduel.cs, observer.cs and Mine.cs went into base\ and 14 maps into base\missions; each map
// ends with exec(RenDuel) or exec(duelmatch), which switches the server to duel rules for that map.
// Here the same files sit in this mod folder on top of a copy of the Renegades Classic 1.1c rule
// set, so nothing has to be copied into base\.
//
// Server owners: admin passwords and vote rules are in Renegades.cs next to this file (the mod's
// own game.cs loads it on every mission). Records are kept in config\RDuelRecord.cs.
echo(">> Renegades Duel (HaVoC duel + duel tournament for Renegades, 2002-07-02) on Renegades Classic 1.1c");
