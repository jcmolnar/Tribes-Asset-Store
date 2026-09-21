//-----------------------------------------------------------------------------
// DuelRecord.cs -- default server records.
//
// duelmod.cs:196 does exec("DuelRecord.cs") at load and writes the records back
// with export("$Duel::Record*", "config\DuelRecord.cs", False) whenever one is
// beaten. config is first on the search path, so once a host has set a record
// their config\DuelRecord.cs is what loads and this file is never seen again.
//
// It exists so a FRESH install does not log "exec: invalid script file
// DuelRecord.cs" on every boot with the record variables undefined.
//
// **RecordTime is a FASTEST-win time: duelmod.cs:628 tests `%t < $Duel::RecordTime`,
//  so LOWER is better and the "no record yet" value has to be a large sentinel,
//  not 0. At 0 no duel could ever beat it and the fastest-win record would be
//  silently dead forever.** The other three records are highest-wins and an unset
//  value compares as 0, which is already the right starting point.
//-----------------------------------------------------------------------------

$Duel::RecordTime       = "9999";   // fastest win, in the mod's own time units -- lower wins
$Duel::RecordTimeHolder = "";
$Duel::RecordTimeLoser  = "";
