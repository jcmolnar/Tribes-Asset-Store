//====================================================================================
// ShifterCompat.cs  --  Modern Client (1.50) compatibility shim for Shifter 9-28-2000
//
// PORT NOTE (2026-09-12). Shifter is a "flat" mod: it ships its own copies of base's
// script files and wins them on the search path. Three functions that base defines,
// and that something outside Shifter still calls, disappear when that happens. They
// are restored here, verbatim or as the no-op they already were. Nothing in this
// file changes Shifter gameplay.
//
// Exec'd once from Shifter.cs at mod load.
//====================================================================================


//------------------------------------------------------------------------------------
// refreshWindowSize()
//
// Base defines this in GUI.CS. Shifter ships its own GUI.cs, so the definition is
// shadowed away -- but base's Options.cs SURVIVES under Shifter (Shifter's copy of
// Options.cs was a verbatim stock-1998 file and was dropped from this port), and it
// calls refreshWindowSize() when the video options are applied. Without this the
// Options screen raises "Unknown command" and the windowed size is never applied.
//
// Copied verbatim from base\scripts\GUI.CS.
//------------------------------------------------------------------------------------
function refreshWindowSize()
{
	if($pref::softwareRes == "")
		$pref::softwareRes = "936 702";
	if(!isFullScreenMode(MainWindow)){
		setWindowSize(MainWindow, getWord($pref::softwareRes,0), getWord($pref::softwareRes,1));
	}
}


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
