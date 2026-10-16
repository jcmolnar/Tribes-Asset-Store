// This is a MiniMod Plugin.
// This is the Base Alarm from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    BaseAlarm.ArmorData.cs
//    BaseAlarm.item.cs
//    BaseAlarm.reinitData.cs
//    BaseAlarm.staticshape.cs
//    BaseAlarm.station.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ BaseAlarm] = 0;
}

for(%i = -1; %i < 8; %i++)
{
		$totalNumAlarms[%i] = 0;
}
