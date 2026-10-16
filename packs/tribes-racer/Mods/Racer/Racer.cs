// Tribes Racer - Retribution (v3.0) by Josef Jahn, 1999-12-20 -- entry script
// (Modern Tribes client 1.50 port).
//
// The mod loader runs this file once at start-up (-mod Racer).
// Tribes Racer is a GAME TYPE: its two maps (TribesRacer, TribesRacer_Retribution) end with
// exec(TribesRacer), which loads scripts\TribesRacer.cs -- the race rules (three lap stations,
// 10 rounds to win, a kill = +1 round for the killer and -1 for the victim) and the re-statted
// vehicles (faster Scout with a chaingun, LPC with rockets, HPC with heavy shells).
// The original was unzipped into base\ ; it had no launch line and no settings file.
//
// The mod word is "Racer", not "TribesRacer": the maps exec a script named TribesRacer, and an
// entry script of that name would be found first.
// Host TribesRacer or TribesRacer_Retribution.

echo("Tribes Racer - Retribution (Racer): host the map TribesRacer or TribesRacer_Retribution.");
