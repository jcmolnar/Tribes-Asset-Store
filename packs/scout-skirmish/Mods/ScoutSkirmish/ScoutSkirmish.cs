// Scout Skirmish -- entry script for the Modern Tribes client (exec'd by ExecModScripts).
//
// The mod itself is the six scripts in scripts\ and the two maps in missions\ (dxScout, shScout).
// Nothing has to be wired here: base's own exec sites pick up scripts\item.cs, baseProjData.cs,
// station.cs, vehicle.cs and game.cs, and the two maps exec arena.cs themselves.
//
// PORT NOTE: scripts\item.cs is the HaVoC 1.59c item file, but Scout Skirmish never shipped
// HaVoC's server.cs / player.cs, so three helpers that file calls were never defined and every
// call printed "Unknown command". They are defined here as no-ops: the behaviour is exactly what
// the mod always had (no kickback, no lock warning), without the console spam.

function ixApplyKickback(%player, %strength, %lift)
{
}

function ixLockWarning(%clientId, %target, %targetType)
{
}

function doneposs(%cl)
{
}
