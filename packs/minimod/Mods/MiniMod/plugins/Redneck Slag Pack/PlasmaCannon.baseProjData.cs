// This is a MiniMod Plugin.
// This plugin is the Plasma Cannon from the Redneck Slag Pack.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    PlasmaCannon.ArmorData.cs
//    PlasmaCannon.baseProjData.cs
//    PlasmaCannon.item.cs
//    PlasmaCannon.station.cs
//
// to your MiniMod/plugins directory.

$PlasmaCannonDamageType = 21;

BulletData PlasmaCannonBlast
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = PlasmaCannonExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $PlasmaCannonDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

