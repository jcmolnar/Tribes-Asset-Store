// This is a MiniMod Plugin.
// This plugin is the Plasma Cannon from the Redneck Slag Pack.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    PlasmaCannon.ArmorData.cs
//    PlasmaCannon.baseExpData.cs
//    PlasmaCannon.baseProjData.cs
//    PlasmaCannon.item.cs
//    PlasmaCannon.station.cs
//
// to your MiniMod/plugins directory.


ExplosionData PlasmaCannonExp
{
   shapeName = "fusionex.dts";
   soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.0, 0.25, 1.0 };
   colors[1]  = { 0.0, 0.25, 1.0 };
   colors[2]  = { 0.0,  0.75,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
