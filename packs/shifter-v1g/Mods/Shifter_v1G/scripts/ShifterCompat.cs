//====================================================================================
// ShifterCompat.cs  --  Modern Client (1.50) shim for Shifter HC v1G (05-27-2002)
//
// PORT NOTE (2026-09-12). Shifter is a "flat" mod: it ships its own copies of base's
// script files and wins them on the search path. Two functions that base defines, and
// that something outside Shifter still calls, disappear when that happens. They are
// restored here as the stub / no-op they already were. Nothing in this file changes
// Shifter gameplay.
//
// v1G keeps its own Options.cs (it carries the 20-faves GUI work), so unlike the
// 9-28-2000 port this one does NOT need base's refreshWindowSize().
//
// Exec'd once from Shifter_v1G.cs at mod load.
//====================================================================================


//------------------------------------------------------------------------------------
// GameBase::getHeatFactor(%this)
//
// Base defines this stub in game.cs; Shifter's game.cs drops it while still calling
// GameBase::virtual(%target,"getHeatFactor") for heatseeker and rocket-turret target
// checks (turret.cs, baseProjData.cs). Shifter supplies Player:: and Vehicle::
// overrides, so only OTHER object types reach this fallback -- and with no definition
// at all the virtual dispatch yields the empty string instead of a number.
//
// Both "" and 0.0 compare false against the >= 0.5 test at every call site, so this
// restores base's stub without changing a single targeting decision.
//------------------------------------------------------------------------------------
function GameBase::getHeatFactor(%this)
{
   return 0.0;
}


//------------------------------------------------------------------------------------
// checkMaxDrop(%client, %armor)
//
// Called by Shifter's own player.cs and admin.cs on the "penis curse" admin path,
// immediately after Player::setArmor. NO version of Shifter defines it -- not the
// 9-28-2000 release and not GreyFlcn's v1G -- so on the original game it was already
// an unresolved call that printed "Unknown command" and did nothing.
//
// Defined here as the no-op it has always been, purely to keep that line out of the
// console log. Do not give it a body: what the author intended by it is not recorded
// anywhere in the shipped code, and guessing would change admin behaviour.
//------------------------------------------------------------------------------------
function checkMaxDrop(%client, %armor)
{
}
