// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Death" (Anti-matter Turret) from
// the Redneck Slag Pack mod. Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ObeliskOfDeath.ArmorData.cs
//    ObeliskOfDeath.baseProjData.cs
//    ObeliskOfDeath.item.cs
//    ObeliskOfDeath.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    ObeliskOfDeath.station.cs
//    ObeliskOfDeath.turret.cs
//
// to your MiniMod/plugins directory.

$AntiMatterDamageType = 28;

BulletData AntiMatterShot
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = flashExpLarge;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $AntiMatterDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 20.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
