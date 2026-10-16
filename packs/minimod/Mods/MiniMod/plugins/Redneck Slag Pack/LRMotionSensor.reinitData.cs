// This is a MiniMod Plugin.
// This is the Long Range Motion Sensor from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    LRMotionSensor.ArmorData.cs
//    LRMotionSensor.item.cs
//    LRMotionSensor.reinitData.cs
//    LRMotionSensor.sensor.cs
//    LRMotionSensor.station.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ DeployableLRMotionSensorPack] = 0;
}
