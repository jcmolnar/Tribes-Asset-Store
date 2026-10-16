
$CanPilot = 1;
$CanRide = 2;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // ARMOR 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Deathmatch
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[dmarmor] = 4;
$DamageScale[dmarmor, $LandingDamageType] = 1.0;
$DamageScale[dmarmor, $ImpactDamageType] = 1.0;
$DamageScale[dmarmor, $CrushDamageType] = 1.0;
$DamageScale[dmarmor, $BulletDamageType] = 1.0;
$DamageScale[dmarmor, $PlasmaDamageType] = 1.0;
$DamageScale[dmarmor, $EnergyDamageType] = 1.0;
$DamageScale[dmarmor, $ExplosionDamageType] = 1.0;
$DamageScale[dmarmor, $MissileDamageType] = 1.0;
$DamageScale[dmarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[dmarmor, $DebrisDamageType] = 1.0;
$DamageScale[dmarmor, $LaserDamageType] = 1.0;
$DamageScale[dmarmor, $MortarDamageType] = 1.0;
$DamageScale[dmarmor, $BlasterDamageType] = 1.0;
$DamageScale[dmarmor, $ElectricityDamageType] = 1.0;
$DamageScale[dmarmor, $MineDamageType] = 1.0;
$DamageScale[dmarmor, $SniperDamageType] = 1.0;
$DamageScale[dmarmor, $FlashDamageType] = 1.0;
$DamageScale[dmarmor, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[dmarmor, Wraith] = $CanRide;
$VehicleUse[dmarmor, Interceptor] = $CanRide;
$VehicleUse[dmarmor, Scout] = $CanRide;
$VehicleUse[dmarmor, LAPC] = $CanRide;
$VehicleUse[dmarmor, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Deathmatch
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[dmfemale] = 4;
$DamageScale[dmfemale, $LandingDamageType] = 1.0;
$DamageScale[dmfemale, $ImpactDamageType] = 1.0;
$DamageScale[dmfemale, $CrushDamageType] = 1.0;
$DamageScale[dmfemale, $BulletDamageType] = 1.0;
$DamageScale[dmfemale, $PlasmaDamageType] = 1.0;
$DamageScale[dmfemale, $EnergyDamageType] = 1.0;
$DamageScale[dmfemale, $ExplosionDamageType] = 1.0;
$DamageScale[dmfemale, $MissileDamageType] = 1.0;
$DamageScale[dmfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[dmfemale, $DebrisDamageType] = 1.0;
$DamageScale[dmfemale, $LaserDamageType] = 1.0;
$DamageScale[dmfemale, $MortarDamageType] = 1.0;
$DamageScale[dmfemale, $BlasterDamageType] = 1.0;
$DamageScale[dmfemale, $ElectricityDamageType] = 1.0;
$DamageScale[dmfemale, $MineDamageType] = 1.0;
$DamageScale[dmfemale, $SniperDamageType] = 1.0;
$DamageScale[dmfemale, $FlashDamageType] = 1.0;
$DamageScale[dmfemale, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[dmfemale, Wraith] = $CanRide;
$VehicleUse[dmfemale, Interceptor] = $CanRide;
$VehicleUse[dmfemale, Scout] = $CanRide;
$VehicleUse[dmfemale, LAPC] = $CanRide;
$VehicleUse[dmfemale, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Scout Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormScout] = 2;
$DamageScale[armormScout, $LandingDamageType] = 0.5;
$DamageScale[armormScout, $ImpactDamageType] = 0.5;
$DamageScale[armormScout, $CrushDamageType] = 0.5;
$DamageScale[armormScout, $BulletDamageType] = 1.2;
$DamageScale[armormScout, $PlasmaDamageType] = 1.0;
$DamageScale[armormScout, $EnergyDamageType] = 1.3;
$DamageScale[armormScout, $ExplosionDamageType] = 1.0;
$DamageScale[armormScout, $MissileDamageType] = 1.0;
$DamageScale[armormScout, $DebrisDamageType] = 1.2;
$DamageScale[armormScout, $ShrapnelDamageType] = 1.2;
$DamageScale[armormScout, $LaserDamageType] = 1.2;
$DamageScale[armormScout, $MortarDamageType] = 1.3;
$DamageScale[armormScout, $BlasterDamageType] = 1.3;
$DamageScale[armormScout, $ElectricityDamageType] = 1.0;
$DamageScale[armormScout, $MineDamageType] = 1.2;
$DamageScale[armormScout, $SniperDamageType] = 1.0;
$DamageScale[armormScout, $FlashDamageType] = 1.0;
$DamageScale[armormScout, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armormScout, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormScout, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormScout, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Scout Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfScout] = 2;
$DamageScale[armorfScout, $LandingDamageType] = 0.5;
$DamageScale[armorfScout, $ImpactDamageType] = 0.5;
$DamageScale[armorfScout, $CrushDamageType] = 0.5;
$DamageScale[armorfScout, $BulletDamageType] = 1.2;
$DamageScale[armorfScout, $PlasmaDamageType] = 1.0;
$DamageScale[armorfScout, $EnergyDamageType] = 1.3;
$DamageScale[armorfScout, $ExplosionDamageType] = 1.0;
$DamageScale[armorfScout, $MissileDamageType] = 1.0;
$DamageScale[armorfScout, $ShrapnelDamageType] = 1.2;
$DamageScale[armorfScout, $DebrisDamageType] = 1.2;
$DamageScale[armorfScout, $LaserDamageType] = 1.0;
$DamageScale[armorfScout, $MortarDamageType] = 1.3;
$DamageScale[armorfScout, $BlasterDamageType] = 1.3;
$DamageScale[armorfScout, $ElectricityDamageType] = 1.0;
$DamageScale[armorfScout, $MineDamageType] = 1.2;
$DamageScale[armorfScout, $SniperDamageType] = 1.0;
$DamageScale[armorfScout, $FlashDamageType] = 1.0;
$DamageScale[armorfScout, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armorfScout, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Spy Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormSpy] = 3;
$DamageScale[armormSpy, $LandingDamageType] = 1.0;
$DamageScale[armormSpy, $ImpactDamageType] = 1.0;
$DamageScale[armormSpy, $CrushDamageType] = 1.0;
$DamageScale[armormSpy, $BulletDamageType] = 0.5;
$DamageScale[armormSpy, $PlasmaDamageType] = 1.2;
$DamageScale[armormSpy, $EnergyDamageType] = 1.3;
$DamageScale[armormSpy, $ExplosionDamageType] = 1.2;
$DamageScale[armormSpy, $MissileDamageType] = 1.3;
$DamageScale[armormSpy, $DebrisDamageType] = 1.3;
$DamageScale[armormSpy, $ShrapnelDamageType] = 1.3;
$DamageScale[armormSpy, $LaserDamageType] = 1.0;
$DamageScale[armormSpy, $MortarDamageType] = 1.3;
$DamageScale[armormSpy, $BlasterDamageType] = 1.3;
$DamageScale[armormSpy, $ElectricityDamageType] = 1.0;
$DamageScale[armormSpy, $MineDamageType] = 1.2;
$DamageScale[armormSpy, $SniperDamageType] = 1.0;
$DamageScale[armormSpy, $FlashDamageType] = 1.0;
$DamageScale[armormSpy, $ShotgunDamageType] = 1.0;


 //
$VehicleUse[armormSpy, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Spy Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfSpy] = 3;
$DamageScale[armorfSpy, $LandingDamageType] = 1.0;
$DamageScale[armorfSpy, $ImpactDamageType] = 1.0;
$DamageScale[armorfSpy, $CrushDamageType] = 1.0;
$DamageScale[armorfSpy, $BulletDamageType] = 0.5;
$DamageScale[armorfSpy, $PlasmaDamageType] = 1.2;
$DamageScale[armorfSpy, $EnergyDamageType] = 1.3;
$DamageScale[armorfSpy, $ExplosionDamageType] = 1.2;
$DamageScale[armorfSpy, $MissileDamageType] = 1.3;
$DamageScale[armorfSpy, $DebrisDamageType] = 1.3;
$DamageScale[armorfSpy, $ShrapnelDamageType] = 1.3;
$DamageScale[armorfSpy, $LaserDamageType] = 1.0;
$DamageScale[armorfSpy, $MortarDamageType] = 1.3;
$DamageScale[armorfSpy, $BlasterDamageType] = 1.3;
$DamageScale[armorfSpy, $ElectricityDamageType] = 1.0;
$DamageScale[armorfSpy, $MineDamageType] = 1.2;
$DamageScale[armorfSpy, $SniperDamageType] = 1.0;
$DamageScale[armorfSpy, $FlashDamageType] = 1.0;
$DamageScale[armorfSpy, $ShotgunDamageType] = 1.0;

 // 
$VehicleUse[armorfSpy, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Sniper Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormSniper] = 3;
$DamageScale[armormSniper, $LandingDamageType] = 1.0;
$DamageScale[armormSniper, $ImpactDamageType] = 1.0;
$DamageScale[armormSniper, $CrushDamageType] = 1.0;
$DamageScale[armormSniper, $BulletDamageType] = 1.2;
$DamageScale[armormSniper, $PlasmaDamageType] = 1.0;
$DamageScale[armormSniper, $EnergyDamageType] = 1.3;
$DamageScale[armormSniper, $ExplosionDamageType] = 1.0;
$DamageScale[armormSniper, $MissileDamageType] = 1.0;
$DamageScale[armormSniper, $DebrisDamageType] = 1.2;
$DamageScale[armormSniper, $ShrapnelDamageType] = 1.2;
$DamageScale[armormSniper, $LaserDamageType] = 1.0;
$DamageScale[armormSniper, $MortarDamageType] = 1.3;
$DamageScale[armormSniper, $BlasterDamageType] = 1.3;
$DamageScale[armormSniper, $ElectricityDamageType] = 1.0;
$DamageScale[armormSniper, $MineDamageType] = 1.2;
$DamageScale[armormSniper, $SniperDamageType] = 1.0;
$DamageScale[armormSniper, $FlashDamageType] = 1.0;
$DamageScale[armormSniper, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armormSniper, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Sniper Armor 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfSniper] = 3;
$DamageScale[armorfSniper, $LandingDamageType] = 1.0;
$DamageScale[armorfSniper, $ImpactDamageType] = 1.0;
$DamageScale[armorfSniper, $CrushDamageType] = 1.0;
$DamageScale[armorfSniper, $BulletDamageType] = 1.2;
$DamageScale[armorfSniper, $PlasmaDamageType] = 1.0;
$DamageScale[armorfSniper, $EnergyDamageType] = 1.3;
$DamageScale[armorfSniper, $ExplosionDamageType] = 1.0;
$DamageScale[armorfSniper, $MissileDamageType] = 1.0;
$DamageScale[armorfSniper, $ShrapnelDamageType] = 1.2;
$DamageScale[armorfSniper, $DebrisDamageType] = 1.2;
$DamageScale[armorfSniper, $LaserDamageType] = 1.0;
$DamageScale[armorfSniper, $MortarDamageType] = 1.3;
$DamageScale[armorfSniper, $BlasterDamageType] = 1.3;
$DamageScale[armorfSniper, $ElectricityDamageType] = 1.0;
$DamageScale[armorfSniper, $MineDamageType] = 1.2;
$DamageScale[armorfSniper, $SniperDamageType] = 1.0;
$DamageScale[armorfSniper, $FlashDamageType] = 1.0;
$DamageScale[armorfSniper, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armorfSniper, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Mercenary Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormMercenary] = 5;
$DamageScale[armormMercenary, $LandingDamageType] = 1.0;
$DamageScale[armormMercenary, $ImpactDamageType] = 1.0;
$DamageScale[armormMercenary, $CrushDamageType] = 1.0;
$DamageScale[armormMercenary, $BulletDamageType] = 1.0;
$DamageScale[armormMercenary, $PlasmaDamageType] = 1.0;
$DamageScale[armormMercenary, $EnergyDamageType] = 1.0;
$DamageScale[armormMercenary, $ExplosionDamageType] = 1.0;
$DamageScale[armormMercenary, $MissileDamageType] = 1.0;
$DamageScale[armormMercenary, $ShrapnelDamageType] = 1.0;
$DamageScale[armormMercenary, $DebrisDamageType] = 1.0;
$DamageScale[armormMercenary, $LaserDamageType] = 1.0;
$DamageScale[armormMercenary, $MortarDamageType] = 1.0;
$DamageScale[armormMercenary, $BlasterDamageType] = 1.0;
$DamageScale[armormMercenary, $ElectricityDamageType] = 1.0;
$DamageScale[armormMercenary, $MineDamageType] = 1.0;
$DamageScale[armormMercenary, $SniperDamageType] = 1.0;
$DamageScale[armormMercenary, $FlashDamageType] = 1.0;
$DamageScale[armormMercenary, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armormMercenary, Wraith] = $CanRide;
$VehicleUse[armormMercenary, Interceptor] = $CanRide;
$VehicleUse[armormMercenary, Scout] = $CanRide;
$VehicleUse[armormMercenary, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormMercenary, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Mercenary Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfMercenary] = 5;
$DamageScale[armorfMercenary, $LandingDamageType] = 1.0;
$DamageScale[armorfMercenary, $ImpactDamageType] = 1.0;
$DamageScale[armorfMercenary, $CrushDamageType] = 1.0;
$DamageScale[armorfMercenary, $BulletDamageType] = 1.0;
$DamageScale[armorfMercenary, $EnergyDamageType] = 1.0;
$DamageScale[armorfMercenary, $PlasmaDamageType] = 1.0;
$DamageScale[armorfMercenary, $ExplosionDamageType] = 1.0;
$DamageScale[armorfMercenary, $MissileDamageType] = 1.0;
$DamageScale[armorfMercenary, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfMercenary, $DebrisDamageType] = 1.0;
$DamageScale[armorfMercenary, $LaserDamageType] = 1.0;
$DamageScale[armorfMercenary, $MortarDamageType] = 1.0;
$DamageScale[armorfMercenary, $BlasterDamageType] = 1.0;
$DamageScale[armorfMercenary, $ElectricityDamageType] = 1.0;
$DamageScale[armorfMercenary, $MineDamageType] = 1.0;
$DamageScale[armorfMercenary, $SniperDamageType] = 1.0;
$DamageScale[armorfMercenary, $FlashDamageType] = 1.0;
$DamageScale[armorfMercenary, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armorfMercenary, Wraith] = $CanRide;
$VehicleUse[armorfMercenary, Interceptor] = $CanRide;
$VehicleUse[armorfMercenary, Scout] = $CanRide;
$VehicleUse[armorfMercenary, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfMercenary, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Engineer Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormEngineer] = 3;
$DamageScale[armormEngineer, $LandingDamageType] = 1.0;
$DamageScale[armormEngineer, $ImpactDamageType] = 1.0;
$DamageScale[armormEngineer, $CrushDamageType] = 1.0;
$DamageScale[armormEngineer, $BulletDamageType] = 1.0;
$DamageScale[armormEngineer, $PlasmaDamageType] = 1.0;
$DamageScale[armormEngineer, $EnergyDamageType] = 1.0;
$DamageScale[armormEngineer, $ExplosionDamageType] = 1.0;
$DamageScale[armormEngineer, $MissileDamageType] = 1.0;
$DamageScale[armormEngineer, $ShrapnelDamageType] = 1.0;
$DamageScale[armormEngineer, $DebrisDamageType] = 1.0;
$DamageScale[armormEngineer, $LaserDamageType] = 1.0;
$DamageScale[armormEngineer, $MortarDamageType] = 1.0;
$DamageScale[armormEngineer, $BlasterDamageType] = 1.0;
$DamageScale[armormEngineer, $ElectricityDamageType] = 1.0;
$DamageScale[armormEngineer, $MineDamageType] = 1.0;
$DamageScale[armormEngineer, $SniperDamageType] = 1.0;
$DamageScale[armormEngineer, $FlashDamageType] = 1.0;
$DamageScale[armormEngineer, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armormEngineer, Wraith] = $CanRide;
$VehicleUse[armormEngineer, Interceptor] = $CanRide;
$VehicleUse[armormEngineer, Scout] = $CanRide;
$VehicleUse[armormEngineer, LAPC] = $CanRide;
$VehicleUse[armormEngineer, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Engineer Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfEngineer] = 3;
$DamageScale[armorfEngineer, $LandingDamageType] = 1.0;
$DamageScale[armorfEngineer, $ImpactDamageType] = 1.0;
$DamageScale[armorfEngineer, $CrushDamageType] = 1.0;
$DamageScale[armorfEngineer, $BulletDamageType] = 1.0;
$DamageScale[armorfEngineer, $EnergyDamageType] = 1.0;
$DamageScale[armorfEngineer, $PlasmaDamageType] = 1.0;
$DamageScale[armorfEngineer, $ExplosionDamageType] = 1.0;
$DamageScale[armorfEngineer, $MissileDamageType] = 1.0;
$DamageScale[armorfEngineer, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfEngineer, $DebrisDamageType] = 1.0;
$DamageScale[armorfEngineer, $LaserDamageType] = 1.0;
$DamageScale[armorfEngineer, $MortarDamageType] = 1.0;
$DamageScale[armorfEngineer, $BlasterDamageType] = 1.0;
$DamageScale[armorfEngineer, $ElectricityDamageType] = 1.0;
$DamageScale[armorfEngineer, $MineDamageType] = 1.0;
$DamageScale[armorfEngineer, $SniperDamageType] = 1.0;
$DamageScale[armorfEngineer, $FlashDamageType] = 1.0;
$DamageScale[armorfEngineer, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armorfEngineer, Wraith] = $CanRide;
$VehicleUse[armorfEngineer, Interceptor] = $CanRide;
$VehicleUse[armorfEngineer, Scout] = $CanRide;
$VehicleUse[armorfEngineer, LAPC] = $CanRide;
$VehicleUse[armorfEngineer, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Burster Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormBurster] = 4;
$DamageScale[armormBurster, $LandingDamageType] = 1.0;
$DamageScale[armormBurster, $ImpactDamageType] = 1.0;
$DamageScale[armormBurster, $CrushDamageType] = 1.0;
$DamageScale[armormBurster, $BulletDamageType] = 1.3;
$DamageScale[armormBurster, $PlasmaDamageType] = 0.5;
$DamageScale[armormBurster, $EnergyDamageType] = 1.1;
$DamageScale[armormBurster, $ExplosionDamageType] = 0.5;
$DamageScale[armormBurster, $MissileDamageType] = 0.5;
$DamageScale[armormBurster, $ShrapnelDamageType] = 0.5;
$DamageScale[armormBurster, $DebrisDamageType] = 1.0;
$DamageScale[armormBurster, $LaserDamageType] = 1.2;
$DamageScale[armormBurster, $MortarDamageType] = 0.5;
$DamageScale[armormBurster, $BlasterDamageType] = 1.2;
$DamageScale[armormBurster, $ElectricityDamageType] = 1.0;
$DamageScale[armormBurster, $MineDamageType] = 0.5;
$DamageScale[armormBurster, $SniperDamageType] = 1.0;
$DamageScale[armormBurster, $FlashDamageType] = 1.0;
$DamageScale[armormBurster, $ShotgunDamageType] = 1.0;

 // 
$VehicleUse[armormBurster, Wraith] = $CanRide;
$VehicleUse[armormBurster, Interceptor] = $CanRide;
$VehicleUse[armormBurster, Scout] = $CanRide;
$VehicleUse[armormBurster, LAPC] = $CanRide;
$VehicleUse[armormBurster, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Burster Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfBurster] = 4;
$DamageScale[armorfBurster, $LandingDamageType] = 1.0;
$DamageScale[armorfBurster, $ImpactDamageType] = 1.0;
$DamageScale[armorfBurster, $CrushDamageType] = 1.0;
$DamageScale[armorfBurster, $BulletDamageType] = 1.3;
$DamageScale[armorfBurster, $PlasmaDamageType] = 0.5;
$DamageScale[armorfBurster, $EnergyDamageType] = 1.1;
$DamageScale[armorfBurster, $ExplosionDamageType] = 0.5;
$DamageScale[armorfBurster, $MissileDamageType] = 0.5;
$DamageScale[armorfBurster, $ShrapnelDamageType] = 0.5;
$DamageScale[armorfBurster, $DebrisDamageType] = 1.0;
$DamageScale[armorfBurster, $LaserDamageType] = 1.2;
$DamageScale[armorfBurster, $MortarDamageType] = 0.5;
$DamageScale[armorfBurster, $BlasterDamageType] = 1.2;
$DamageScale[armorfBurster, $ElectricityDamageType] = 1.0;
$DamageScale[armorfBurster, $MineDamageType] = 0.5;
$DamageScale[armorfBurster, $SniperDamageType] = 1.0;
$DamageScale[armorfBurster, $FlashDamageType] = 1.0;
$DamageScale[armorfBurster, $ShotgunDamageType] = 1.0;

 // 
$VehicleUse[armorfBurster, Wraith] = $CanRide;
$VehicleUse[armorfBurster, Interceptor] = $CanRide;
$VehicleUse[armorfBurster, Scout] = $CanRide;
$VehicleUse[armorfBurster, LAPC] = $CanRide;
$VehicleUse[armorfBurster, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Alien Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormAlien] = 4;
$DamageScale[armormAlien, $LandingDamageType] = 0.5;
$DamageScale[armormAlien, $ImpactDamageType] = 1.0;
$DamageScale[armormAlien, $CrushDamageType] = 1.0;
$DamageScale[armormAlien, $BulletDamageType] = 1.0;
$DamageScale[armormAlien, $PlasmaDamageType] = 2.0;
$DamageScale[armormAlien, $EnergyDamageType] = 1.0;
$DamageScale[armormAlien, $ExplosionDamageType] = 1.0;
$DamageScale[armormAlien, $MissileDamageType] = 1.0;
$DamageScale[armormAlien, $ShrapnelDamageType] = 1.0;
$DamageScale[armormAlien, $DebrisDamageType] = 1.0;
$DamageScale[armormAlien, $LaserDamageType] = 0.5;
$DamageScale[armormAlien, $MortarDamageType] = 1.2;
$DamageScale[armormAlien, $BlasterDamageType] = 0.5;
$DamageScale[armormAlien, $ElectricityDamageType] = 0.5;
$DamageScale[armormAlien, $MineDamageType] = 1.0;
$DamageScale[armormAlien, $SniperDamageType] = 1.0;
$DamageScale[armormAlien, $FlashDamageType] = 2.0;
$DamageScale[armormAlien, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armormAlien, Wraith] = $CanRide;
$VehicleUse[armormAlien, Interceptor] = $CanRide;
$VehicleUse[armormAlien, Scout] = $CanRide;
$VehicleUse[armormAlien, LAPC] = $CanRide;
$VehicleUse[armormAlien, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Alien Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfAlien] = 4;
$DamageScale[armorfAlien, $LandingDamageType] = 0.5;
$DamageScale[armorfAlien, $ImpactDamageType] = 1.0;
$DamageScale[armorfAlien, $CrushDamageType] = 1.0;
$DamageScale[armorfAlien, $BulletDamageType] = 1.0;
$DamageScale[armorfAlien, $PlasmaDamageType] = 2.0;
$DamageScale[armorfAlien, $EnergyDamageType] = 1.0;
$DamageScale[armorfAlien, $ExplosionDamageType] = 1.0;
$DamageScale[armorfAlien, $MissileDamageType] = 1.0;
$DamageScale[armorfAlien, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfAlien, $DebrisDamageType] = 1.0;
$DamageScale[armorfAlien, $LaserDamageType] = 0.5;
$DamageScale[armorfAlien, $MortarDamageType] = 1.2;
$DamageScale[armorfAlien, $BlasterDamageType] = 0.5;
$DamageScale[armorfAlien, $ElectricityDamageType] = 0.5;
$DamageScale[armorfAlien, $MineDamageType] = 1.0;
$DamageScale[armorfAlien, $SniperDamageType] = 1.0;
$DamageScale[armorfAlien, $FlashDamageType] = 2.0;
$DamageScale[armorfAlien, $ShotgunDamageType] = 1.0;

 // 
$VehicleUse[armorfAlien, Wraith] = $CanRide;
$VehicleUse[armorfAlien, Interceptor] = $CanRide;
$VehicleUse[armorfAlien, Scout] = $CanRide;
$VehicleUse[armorfAlien, LAPC] = $CanRide;
$VehicleUse[armorfAlien, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Cyborg Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorCyborg] = 6;
$DamageScale[armorCyborg, $LandingDamageType] = 0.8;
$DamageScale[armorCyborg, $ImpactDamageType] = 0.8;
$DamageScale[armorCyborg, $CrushDamageType] = 0.8;
$DamageScale[armorCyborg, $BulletDamageType] = 0.5;
$DamageScale[armorCyborg, $PlasmaDamageType] = 0.7;
$DamageScale[armorCyborg, $EnergyDamageType] = 0.7;
$DamageScale[armorCyborg, $ExplosionDamageType] = 0.6;
$DamageScale[armorCyborg, $MissileDamageType] = 0.6;
$DamageScale[armorCyborg, $DebrisDamageType] = 0.8;
$DamageScale[armorCyborg, $ShrapnelDamageType] = 0.8;
$DamageScale[armorCyborg, $LaserDamageType] = 0.6;
$DamageScale[armorCyborg, $MortarDamageType] = 0.7;
$DamageScale[armorCyborg, $BlasterDamageType] = 0.7;
$DamageScale[armorCyborg, $ElectricityDamageType] = 0.8;
$DamageScale[armorCyborg, $MineDamageType] = 0.8;
$DamageScale[armorCyborg, $SniperDamageType] = 0.6;
$DamageScale[armorCyborg, $FlashDamageType] = 1.0;
$DamageScale[armorCyborg, $ShotgunDamageType] = 1.0;

 //
$VehicleUse[armorCyborg, Wraith] = $CanRide;
$VehicleUse[armorCyborg, Interceptor] = $CanRide;
$VehicleUse[armorCyborg, Scout] = $CanRide;
$VehicleUse[armorCyborg, LAPC] = $CanRide;
$VehicleUse[armorCyborg, HAPC] = $CanRide;

function PopulateItemMax(%item, %mDM, %fDM, %mSC, %fSC, %mSP, %fSP, %mSN, %fSN, %mME, %fME, %mEN, %fEN, %mBU, %fBU, %mAL, %fAL, %CY)
{
  $ItemMax[dmarmor, %item] = %mDM;
  $ItemMax[dmfemale, %item] = %fDM;
  $ItemMax[armormScout, %item] = %mSC;
  $ItemMax[armorfScout, %item] = %fSC;
  $ItemMax[armormSpy, %item] = %mSP;
  $ItemMax[armorfSpy, %item] = %fSP;
  $ItemMax[armormSniper, %item] = %mSN;
  $ItemMax[armorfSniper, %item] = %fSN;
  $ItemMax[armormMercenary, %item] = %mME;
  $ItemMax[armorfMercenary, %item] = %fME;
  $ItemMax[armormEngineer, %item] = %mEN;
  $ItemMax[armorfEngineer, %item] = %fEN;
  $ItemMax[armormBurster, %item] = %mBU;
  $ItemMax[armorfBurster, %item] = %fBU;
  $ItemMax[armormAlien, %item] = %mAL;
  $ItemMax[armorfAlien, %item] = %fAL;
  $ItemMax[armorCyborg, %item] = %CY;  
}

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Blaster,           1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1);
PopulateItemMax(Bolt,              1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(Chaingun,          1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(BulletAmmo,      150, 150, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 150);
PopulateItemMax(DeathLaser,        1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   1);
PopulateItemMax(DiscLauncher,      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(DiscAmmo,         15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  30,  30,  15,  15,  15);
PopulateItemMax(EnergyRifle,       1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1);
PopulateItemMax(Fixit,             0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(Flamer,            1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(GrenadeLauncher,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(GrenadeAmmo,      10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  20,  20,  10,  10,  15);
PopulateItemMax(HyperB,            1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(IonGun,            1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(LaserRifle,        1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MassDriver,        1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(MassAmmo,         20,  20,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  20);
PopulateItemMax(Mortar,            1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(MortarAmmo,        5,   5,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,   5,   5,  10,  10,  10);
PopulateItemMax(Omega,             1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(PlasmaGun,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(PlasmaAmmo,       40,  40,  30,  30,  30,  30,  30,  30,  40,  40,  40,  40,  50,  50,  40,  40,  50);
PopulateItemMax(Railgun,           1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(RailAmmo,         10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  15,  15,  10,  10,  10,  10,  10);
PopulateItemMax(RocketLauncher,    1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(RocketAmmo,        5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,  10,  10,   5,   5,  10);
PopulateItemMax(Shotgun,           1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0);
PopulateItemMax(ShotGunShells,    15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15);
PopulateItemMax(Silencer,          1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SilencerAmmo,     25,  25,  25,  25,  35,  35,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25);
PopulateItemMax(SniperRifle,       1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperAmmo,       15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15);
PopulateItemMax(TargetingLaser,    0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(TranqGun,          1,   1,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TranqAmmo,        10,  10,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(Vulcan,            1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(VulcanAmmo,      150, 150, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 400);
PopulateItemMax(WaveGun,           1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1);


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // MISC 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Beacon,            1,   1,   3,   3,   3,   3,   1,   1,   3,   3,   1,   1,   4,   4,   3,   3,   3);  
PopulateItemMax(Grenade,           5,   5,   5,   5,   3,   3,   3,   3,   6,   6,   6,   6,   6,   6,   5,   5,   3);
PopulateItemMax(MineAmmo,          3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   6,   6,   3,   3,   5);
PopulateItemMax(RepairKit,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // PACKS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,          1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(EnergyPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RepairPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(SensorJammerPack,  0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE SENSORS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,        0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack,  0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MotionSensorPack,  0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PulseSensorPack,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DeployableAmmoPack,1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);

$ItemMax[armormSniper, Boost] = 3;
$ItemMax[armormSniper, Plastique] = 0;
$ItemMax[armormSniper, LaserTurretPack] = 1;
$ItemMax[armormSniper, RocketPack] = 0;
$ItemMax[armormSniper, PlasmaTurretPack] = 0;
$ItemMax[armormSniper, CloakingDevice] = 0;
$ItemMax[armormSniper, StealthShieldPack] = 0;
$ItemMax[armormSniper, MortarTurretPack] = 0;
$ItemMax[armormSniper, Laptop] = 0;
$ItemMax[armormSniper, ShockTurretPack] = 0;
$ItemMax[armormSniper, SuicidePack] = 0;
$ItemMax[armormSniper, RegenerationPack] = 0;
$ItemMax[armormSniper, LightningPack] = 0;
$ItemMax[armormSniper, OpticPack] = 1;
$ItemMax[armormSniper, SMRPack] = 0;
$ItemMax[armormSniper, RailTurretPack] = 0;
$ItemMax[armormSniper, VulcanTurretPack] = 0;
$ItemMax[armormSniper, ImRecPack] = 1;
$ItemMax[armorfSniper, Boost] = 3;
$ItemMax[armorfSniper, Plastique] = 0;
$ItemMax[armorfSniper, Gaussgun] = 0;
$ItemMax[armorfSniper, LaserTurretPack] = 1;
$ItemMax[armorfSniper, RocketPack] = 0;
$ItemMax[armorfSniper, PlasmaTurretPack] = 0;
$ItemMax[armorfSniper, CloakingDevice] = 0;
$ItemMax[armorfSniper, StealthShieldPack] = 0;
$ItemMax[armorfSniper, MortarTurretPack] = 0;
$ItemMax[armorfSniper, Laptop] = 0;
$ItemMax[armorfSniper, ShockTurretPack] = 0;
$ItemMax[armorfSniper, SuicidePack] = 0;
$ItemMax[armorfSniper, RegenerationPack] = 0;
$ItemMax[armorfSniper, LightningPack] = 0;
$ItemMax[armorfSniper, OpticPack] = 1;
$ItemMax[armorfSniper, SMRPack] = 0;
$ItemMax[armorfSniper, RailTurretPack] = 0;
$ItemMax[armorfSniper, VulcanTurretPack] = 0;

$ItemMax[armormScout, Boost] = 5;
$ItemMax[armormScout, Plastique] = 0;
$ItemMax[armormScout, Gaussgun] = 0;
$ItemMax[armormScout, LaserTurretPack] = 0;
$ItemMax[armormScout, RocketPack] = 0;
$ItemMax[armormScout, PlasmaTurretPack] = 0;
$ItemMax[armormScout, CloakingDevice] = 0;
$ItemMax[armormScout, StealthShieldPack] = 0;
$ItemMax[armormScout, MortarTurretPack] = 0;
$ItemMax[armormScout, Laptop] = 0;
$ItemMax[armormScout, ShockTurretPack] = 0;
$ItemMax[armormScout, SuicidePack] = 0;
$ItemMax[armormScout, RegenerationPack] = 0;
$ItemMax[armormScout, LightningPack] = 0;
$ItemMax[armormScout, OpticPack] = 0;
$ItemMax[armormScout, SMRPack] = 0;
$ItemMax[armormScout, RailTurretPack] = 0;
$ItemMax[armormScout, VulcanTurretPack] = 0;

$ItemMax[armormMercenary, Boost] = 4;
$ItemMax[armormMercenary, Plastique] = 0;
$ItemMax[armormMercenary, LaserTurretPack] = 0;
$ItemMax[armormMercenary, RocketPack] = 0;
$ItemMax[armormMercenary, PlasmaTurretPack] = 0;
$ItemMax[armormMercenary, CloakingDevice] = 0;
$ItemMax[armormMercenary, StealthShieldPack] = 0;
$ItemMax[armormMercenary, MortarTurretPack] = 0;
$ItemMax[armormMercenary, Laptop] = 0;
$ItemMax[armormMercenary, ShockTurretPack] = 0;
$ItemMax[armormMercenary, SuicidePack] = 0;
$ItemMax[armormMercenary, RegenerationPack] = 0;
$ItemMax[armormMercenary, LightningPack] = 0;
$ItemMax[armormMercenary, OpticPack] = 0;
$ItemMax[armormMercenary, SMRPack] = 0;
$ItemMax[armormMercenary, RailTurretPack] = 0;
$ItemMax[armormMercenary, VulcanTurretPack] = 0;
$ItemMax[armormMercenary, ImRecPack] = 1;
$ItemMax[armorfMercenary, Boost] = 4;
$ItemMax[armorfMercenary, Plastique] = 0;
$ItemMax[armorfMercenary, Gaussgun] = 0;
$ItemMax[armorfMercenary, LaserTurretPack] = 0;
$ItemMax[armorfMercenary, RocketPack] = 0;
$ItemMax[armorfMercenary, PlasmaTurretPack] = 0;
$ItemMax[armorfMercenary, CloakingDevice] = 0;
$ItemMax[armorfMercenary, StealthShieldPack] = 0;
$ItemMax[armorfMercenary, MortarTurretPack] = 0;
$ItemMax[armorfMercenary, Laptop] = 0;
$ItemMax[armorfMercenary, ShockTurretPack] = 0;
$ItemMax[armorfMercenary, SuicidePack] = 0;
$ItemMax[armorfMercenary, RegenerationPack] = 0;
$ItemMax[armorfMercenary, LightningPack] = 0;
$ItemMax[armorfMercenary, OpticPack] = 0;
$ItemMax[armorfMercenary, SMRPack] = 0;
$ItemMax[armorfMercenary, RailTurretPack] = 0;
$ItemMax[armorfMercenary, VulcanTurretPack] = 0;

$ItemMax[armormBurster, Boost] = 4;
$ItemMax[armormBurster, Plastique] = 0;
$ItemMax[armormBurster, LaserTurretPack] = 0;
$ItemMax[armormBurster, RocketPack] = 1;
$ItemMax[armormBurster, PlasmaTurretPack] = 0;
$ItemMax[armormBurster, CloakingDevice] = 0;
$ItemMax[armormBurster, StealthShieldPack] = 0;
$ItemMax[armormBurster, MortarTurretPack] = 0;
$ItemMax[armormBurster, Laptop] = 0;
$ItemMax[armormBurster, ShockTurretPack] = 0;
$ItemMax[armormBurster, SuicidePack] = 1;
$ItemMax[armormBurster, RegenerationPack] = 0;
$ItemMax[armormBurster, LightningPack] = 0;
$ItemMax[armormBurster, OpticPack] = 0;
$ItemMax[armormBurster, SMRPack] = 0;
$ItemMax[armormBurster, RailTurretPack] = 0;
$ItemMax[armormBurster, VulcanTurretPack] = 0;

$ItemMax[armorCyborg, Boost] = 5;
$ItemMax[armorCyborg, Plastique] = 0;
$ItemMax[armorCyborg, LaserTurretPack] = 1;
$ItemMax[armorCyborg, RocketPack] = 0;
$ItemMax[armorCyborg, PlasmaTurretPack] = 0;
$ItemMax[armorCyborg, CloakingDevice] = 0;
$ItemMax[armorCyborg, StealthShieldPack] = 1;
$ItemMax[armorCyborg, FgcPack] = 1;
$ItemMax[armorCyborg, MortarTurretPack] = 0;
$ItemMax[armorCyborg, Laptop] = 0;
$ItemMax[armorCyborg, ShockTurretPack] = 0;
$ItemMax[armorCyborg, SuicidePack] = 0;
$ItemMax[armorCyborg, RegenerationPack] = 0;
$ItemMax[armorCyborg, LightningPack] = 0;
$ItemMax[armorCyborg, OpticPack] = 0;
$ItemMax[armorCyborg, SMRPack] = 1;
$ItemMax[armorCyborg, RailTurretPack] = 0;
$ItemMax[armorCyborg, VulcanTurretPack] = 0;
$ItemMax[armorCyborg, ImRecPack] = 1;

$ItemMax[armorfScout, Boost] = 5;
$ItemMax[armorfScout, Plastique] = 0;
$ItemMax[armorfScout, Gaussgun] = 0;
$ItemMax[armorfScout, LaserTurretPack] = 0;
$ItemMax[armorfScout, RocketPack] = 0;
$ItemMax[armorfScout, PlasmaTurretPack] = 0;
$ItemMax[armorfScout, CloakingDevice] = 0;
$ItemMax[armorfScout, StealthShieldPack] = 0;
$ItemMax[armorfScout, MortarTurretPack] = 0;
$ItemMax[armorfScout, Laptop] = 0;
$ItemMax[armorfScout, ShockTurretPack] = 0;
$ItemMax[armorfScout, SuicidePack] = 0;
$ItemMax[armorfScout, RegenerationPack] = 0;
$ItemMax[armorfScout, LightningPack] = 0;
$ItemMax[armorfScout, OpticPack] = 0;
$ItemMax[armorfScout, SMRPack] = 0;
$ItemMax[armorfScout, RailTurretPack] = 0;
$ItemMax[armorfScout, VulcanTurretPack] = 0;

$ItemMax[armorfBurster, Boost] = 4;
$ItemMax[armorfBurster, Plastique] = 0;
$ItemMax[armorfBurster, LaserTurretPack] = 0;
$ItemMax[armorfBurster, RocketPack] = 1;
$ItemMax[armorfBurster, PlasmaTurretPack] = 0;
$ItemMax[armorfBurster, CloakingDevice] = 0;
$ItemMax[armorfBurster, StealthShieldPack] = 0;
$ItemMax[armorfBurster, MortarTurretPack] = 0;
$ItemMax[armorfBurster, Laptop] = 0;
$ItemMax[armorfBurster, ShockTurretPack] = 0;
$ItemMax[armorfBurster, SuicidePack] = 1;
$ItemMax[armorfBurster, RegenerationPack] = 0;
$ItemMax[armorfBurster, LightningPack] = 0;
$ItemMax[armorfBurster, OpticPack] = 0;
$ItemMax[armorfBurster, SMRPack] = 0;
$ItemMax[armorfBurster, RailTurretPack] = 0;
$ItemMax[armorfBurster, VulcanTurretPack] = 0;

$ItemMax[armormSpy, Boost] = 3;
$ItemMax[armormSpy, Plastique] = 0;
$ItemMax[armormSpy, Gaussgun] = 0;
$ItemMax[armormSpy, LaserTurretPack] = 0;
$ItemMax[armormSpy, RocketPack] = 0;
$ItemMax[armormSpy, PlasmaTurretPack] = 1;
$ItemMax[armormSpy, CloakingDevice] = 1;
$ItemMax[armormSpy, StealthShieldPack] = 0;
$ItemMax[armormSpy, Laptop] = 1;
$ItemMax[armormSpy, MortarTurretPack] = 0;
$ItemMax[armormSpy, ShockTurretPack] = 0;
$ItemMax[armormSpy, SuicidePack] = 0;
$ItemMax[armormSpy, RegenerationPack] = 0;
$ItemMax[armormSpy, LightningPack] = 0;
$ItemMax[armormSpy, OpticPack] = 0;
$ItemMax[armormSpy, SMRPack] = 0;
$ItemMax[armormSpy, RailTurretPack] = 0;
$ItemMax[armormSpy, VulcanTurretPack] = 0;
$ItemMax[armorfSpy, Boost] = 3;
$ItemMax[armorfSpy, Plastique] = 0;
$ItemMax[armorfSpy, Gaussgun] = 0;
$ItemMax[armorfSpy, LaserTurretPack] = 0;
$ItemMax[armorfSpy, RocketPack] = 0;
$ItemMax[armorfSpy, PlasmaTurretPack] = 1;
$ItemMax[armorfSpy, CloakingDevice] = 1;
$ItemMax[armorfSpy, StealthShieldPack] = 0;
$ItemMax[armorfSpy, Laptop] = 1;
$ItemMax[armorfSpy, MortarTurretPack] = 0;
$ItemMax[armorfSpy, ShockTurretPack] = 0;
$ItemMax[armorfSpy, SuicidePack] = 0;
$ItemMax[armorfSpy, RegenerationPack] = 0;
$ItemMax[armorfSpy, LightningPack] = 0;
$ItemMax[armorfSpy, OpticPack] = 0;
$ItemMax[armorfSpy, SMRPack] = 0;
$ItemMax[armorfSpy, RailTurretPack] = 0;
$ItemMax[armorfSpy, VulcanTurretPack] = 0;

$ItemMax[armormEngineer, Boost] = 4;
$ItemMax[armormEngineer, Plastique] = 0;
$ItemMax[armormEngineer, Gaussgun] = 0;
$ItemMax[armormEngineer, LaserTurretPack] = 1;
$ItemMax[armormEngineer, RocketPack] = 1;
$ItemMax[armormEngineer, PlasmaTurretPack] = 1;
$ItemMax[armormEngineer, CloakingDevice] = 0;
$ItemMax[armormEngineer, StealthShieldPack] = 0;
$ItemMax[armormEngineer, Laptop] = 1;
$ItemMax[armormEngineer, ShockTurretPack] = 1;
$ItemMax[armormEngineer, MortarTurretPack] = 1;
$ItemMax[armormEngineer, SuicidePack] = 0;
$ItemMax[armormEngineer, RegenerationPack] = 0;
$ItemMax[armormEngineer, LightningPack] = 0;
$ItemMax[armormEngineer, OpticPack] = 0;
$ItemMax[armormEngineer, SMRPack] = 0;
$ItemMax[armormEngineer, RailTurretPack] = 1;
$ItemMax[armormEngineer, VulcanTurretPack] = 1;
$ItemMax[armorfEngineer, Boost] = 4;
$ItemMax[armorfEngineer, Plastique] = 0;
$ItemMax[armorfEngineer, Gaussgun] = 0;
$ItemMax[armorfEngineer, LaserTurretPack] = 1;
$ItemMax[armorfEngineer, RocketPack] = 1;
$ItemMax[armorfEngineer, PlasmaTurretPack] = 1;
$ItemMax[armorfEngineer, CloakingDevice] = 0;
$ItemMax[armorfEngineer, StealthShieldPack] = 0;
$ItemMax[armorfEngineer, Laptop] = 1;
$ItemMax[armorfEngineer, ShockTurretPack] = 1;
$ItemMax[armorfEngineer, MortarTurretPack] = 1;
$ItemMax[armorfEngineer, SuicidePack] = 0;
$ItemMax[armorfEngineer, RegenerationPack] = 0;
$ItemMax[armorfEngineer, LightningPack] = 0;
$ItemMax[armorfEngineer, OpticPack] = 0;
$ItemMax[armorfEngineer, SMRPack] = 0;
$ItemMax[armorfEngineer, RailTurretPack] = 1;
$ItemMax[armorfEngineer, VulcanTurretPack] = 1;

$ItemMax[armormAlien, Boost] = 4;
$ItemMax[armormAlien, Plastique] = 0;
$ItemMax[armormAlien, LaserTurretPack] = 0;
$ItemMax[armormAlien, RocketPack] = 0;
$ItemMax[armormAlien, PlasmaTurretPack] = 0;
$ItemMax[armormAlien, CloakingDevice] = 0;
$ItemMax[armormAlien, StealthShieldPack] = 0;
$ItemMax[armormAlien, MortarTurretPack] = 0;
$ItemMax[armormAlien, Laptop] = 0;
$ItemMax[armormAlien, ShockTurretPack] = 0;
$ItemMax[armormAlien, SuicidePack] = 0;
$ItemMax[armormAlien, RegenerationPack] = 1;
$ItemMax[armormAlien, LightningPack] = 1;
$ItemMax[armormAlien, OpticPack] = 0;
$ItemMax[armormAlien, SMRPack] = 0;
$ItemMax[armormAlien, RailTurretPack] = 0;
$ItemMax[armormAlien, VulcanTurretPack] = 0;
$ItemMax[armorfAlien, Boost] = 4;
$ItemMax[armorfAlien, Plastique] = 0;
$ItemMax[armorfAlien, LaserTurretPack] = 0;
$ItemMax[armorfAlien, RocketPack] = 0;
$ItemMax[armorfAlien, PlasmaTurretPack] = 0;
$ItemMax[armorfAlien, CloakingDevice] = 0;
$ItemMax[armorfAlien, StealthShieldPack] = 0;
$ItemMax[armorfAlien, MortarTurretPack] = 0;
$ItemMax[armorfAlien, Laptop] = 0;
$ItemMax[armorfAlien, ShockTurretPack] = 0;
$ItemMax[armorfAlien, SuicidePack] = 0;
$ItemMax[armorfAlien, RegenerationPack] = 1;
$ItemMax[armorfAlien, LightningPack] = 1;
$ItemMax[armorfAlien, OpticPack] = 0;
$ItemMax[armorfAlien, SMRPack] = 0;
$ItemMax[armorfAlien, RailTurretPack] = 0;
$ItemMax[armorfAlien, VulcanTurretPack] = 0;

$ItemMax[dmarmor, Boost] = 4;
$ItemMax[dmarmor, Plastique] = 1;
$ItemMax[dmarmor, IonTurretPack] = 0;
$ItemMax[dmarmor, LaserTurretPack] = 0;
$ItemMax[dmarmor, RocketPack] = 0;
$ItemMax[dmarmor, PlasmaTurretPack] = 0;
$ItemMax[dmarmor, CloakingDevice] = 0;
$ItemMax[dmarmor, StealthShieldPack] = 0;
$ItemMax[dmarmor, MortarTurretPack] = 0;
$ItemMax[dmarmor, Laptop] = 0;
$ItemMax[dmarmor, ShockTurretPack] = 0;
$ItemMax[dmarmor, SuicidePack] = 0;
$ItemMax[dmarmor, RegenerationPack] = 1;
$ItemMax[dmarmor, LightningPack] = 1;
$ItemMax[dmarmor, OpticPack] = 1;
$ItemMax[dmarmor, SMRPack] = 1;
$ItemMax[dmarmor, RailTurretPack] = 1;
$ItemMax[dmarmor, VulcanTurretPack] = 1;
$ItemMax[dmfemale, Boost] = 4;
$ItemMax[dmfemale, Plastique] = 1;
$ItemMax[dmfemale, IonTurretPack] = 0;
$ItemMax[dmfemale, LaserTurretPack] = 0;
$ItemMax[dmfemale, RocketPack] = 0;
$ItemMax[dmfemale, PlasmaTurretPack] = 0;
$ItemMax[dmfemale, CloakingDevice] = 0;
$ItemMax[dmfemale, StealthShieldPack] = 0;
$ItemMax[dmfemale, MortarTurretPack] = 0;
$ItemMax[dmfemale, Laptop] = 0;
$ItemMax[dmfemale, ShockTurretPack] = 0;
$ItemMax[dmfemale, SuicidePack] = 0;
$ItemMax[dmfemale, RegenerationPack] = 1;
$ItemMax[dmfemale, LightningPack] = 1;
$ItemMax[dmfemale, OpticPack] = 1;
$ItemMax[dmfemale, SMRPack] = 1;
$ItemMax[dmfemale, RailTurretPack] = 1;
$ItemMax[dmfemale, VulcanTurretPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, AcceleratorDevicePack] = 0; // Light 
$ItemMax[armorfSniper, AcceleratorDevicePack] = 0; 
$ItemMax[armormMercenary, AcceleratorDevicePack] = 0; // Medium 
$ItemMax[armorfMercenary, AcceleratorDevicePack] = 0; 
$ItemMax[harmor, AcceleratorDevicePack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, AcceleratorDevicePack] = 0; // Scout
$ItemMax[armorfScout, AcceleratorDevicePack] = 0; 
$ItemMax[armormSpy, AcceleratorDevicePack] = 0; // Spy
$ItemMax[armorfSpy, AcceleratorDevicePack] = 0; 
$ItemMax[armormBurster, AcceleratorDevicePack] = 0; // Burster
$ItemMax[armorfBurster, AcceleratorDevicePack] = 0; 
$ItemMax[armormEngineer, AcceleratorDevicePack] = 1; // Engineer
$ItemMax[armorfEngineer, AcceleratorDevicePack] = 1; 
$ItemMax[armormAlien, AcceleratorDevicePack] = 0; // Alien
$ItemMax[armorfAlien, AcceleratorDevicePack] = 0; 
$ItemMax[armorCyborg, AcceleratorDevicePack] = 0; // Cyborg

$ItemMax[dmarmor, AcceleratorDevicePack] = 0; // Deathmatch
$ItemMax[dmfemale, AcceleratorDevicePack] = 0;

 // "Base" armor
$ItemMax[armormSniper, BlastWallPack] = 0; // Light 
$ItemMax[armorfSniper, BlastWallPack] = 0; 
$ItemMax[armormMercenary, BlastWallPack] = 0; // Medium 
$ItemMax[armorfMercenary, BlastWallPack] = 0; 
$ItemMax[harmor, BlastWallPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, BlastWallPack] = 0; // Scout
$ItemMax[armorfScout, BlastWallPack] = 0; 
$ItemMax[armormSpy, BlastWallPack] = 0; // Spy
$ItemMax[armorfSpy, BlastWallPack] = 0; 
$ItemMax[armormBurster, BlastWallPack] = 0; // Burster
$ItemMax[armorfBurster, BlastWallPack] = 0; 
$ItemMax[armormEngineer, BlastWallPack] = 1; // Engineer
$ItemMax[armorfEngineer, BlastWallPack] = 1; 
$ItemMax[armormAlien, BlastWallPack] = 0; // Alien
$ItemMax[armorfAlien, BlastWallPack] = 0; 
$ItemMax[armorCyborg, BlastWallPack] = 0; // Cyborg

$ItemMax[dmarmor, BlastWallPack] = 0; // Deathmatch
$ItemMax[dmfemale, BlastWallPack] = 0;

$ItemMax[armormSniper, IonTurretPack] = 0; 
$ItemMax[armormMercenary, IonTurretPack] = 1; 
$ItemMax[harmor, IonTurretPack] = 1; 
$ItemMax[armorfSniper, IonTurretPack] = 0;
$ItemMax[armorfMercenary, IonTurretPack] = 1; 
$ItemMax[armormScout, IonTurretPack] = 0; 
$ItemMax[armormBurster, IonTurretPack] = 0; 
$ItemMax[armorCyborg, IonTurretPack] = 1; 
$ItemMax[armorfScout, IonTurretPack] = 0; 
$ItemMax[armorfBurster, IonTurretPack] = 0; 
$ItemMax[armormSpy, IonTurretPack] = 0; 
$ItemMax[armorfSpy, IonTurretPack] = 0; 
$ItemMax[armormEngineer, IonTurretPack] = 1;
$ItemMax[armorfEngineer, IonTurretPack] = 1;
$ItemMax[armormAlien, IonTurretPack] = 1; 
$ItemMax[armorfAlien, IonTurretPack] = 1; 

 // "Base" armor
$ItemMax[armormSniper, ForceFieldPack] = 1; // Light 
$ItemMax[armorfSniper, ForceFieldPack] = 1; 
$ItemMax[armormMercenary, ForceFieldPack] = 1; // Medium 
$ItemMax[armorfMercenary, ForceFieldPack] = 1; 
$ItemMax[harmor, ForceFieldPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, ForceFieldPack] = 1; // Scout
$ItemMax[armorfScout, ForceFieldPack] = 1; 
$ItemMax[armormSpy, ForceFieldPack] = 1; // Spy
$ItemMax[armorfSpy, ForceFieldPack] = 1; 
$ItemMax[armormBurster, ForceFieldPack] = 1; // Burster
$ItemMax[armorfBurster, ForceFieldPack] = 1; 
$ItemMax[armormEngineer, ForceFieldPack] = 1; // Engineer
$ItemMax[armorfEngineer, ForceFieldPack] = 1; 
$ItemMax[armormAlien, ForceFieldPack] = 1; // Alien
$ItemMax[armorfAlien, ForceFieldPack] = 1; 
$ItemMax[armorCyborg, ForceFieldPack] = 1; // Cyborg

$ItemMax[dmarmor, ForceFieldPack] = 1; // Deathmatch
$ItemMax[dmfemale, ForceFieldPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, LargeForceFieldPack] = 0; // Light 
$ItemMax[armorfSniper, LargeForceFieldPack] = 0; 
$ItemMax[armormMercenary, LargeForceFieldPack] = 0; // Medium 
$ItemMax[armorfMercenary, LargeForceFieldPack] = 0; 
$ItemMax[harmor, LargeForceFieldPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, LargeForceFieldPack] = 0; // Scout
$ItemMax[armorfScout, LargeForceFieldPack] = 0; 
$ItemMax[armormSpy, LargeForceFieldPack] = 0; // Spy
$ItemMax[armorfSpy, LargeForceFieldPack] = 0; 
$ItemMax[armormBurster, LargeForceFieldPack] = 0; // Burster
$ItemMax[armorfBurster, LargeForceFieldPack] = 0; 
$ItemMax[armormEngineer, LargeForceFieldPack] = 1; // Engineer
$ItemMax[armorfEngineer, LargeForceFieldPack] = 1; 
$ItemMax[armormAlien, LargeForceFieldPack] = 0; // Alien
$ItemMax[armorfAlien, LargeForceFieldPack] = 0; 
$ItemMax[armorCyborg, LargeForceFieldPack] = 1; // Cyborg

$ItemMax[dmarmor, LargeForceFieldPack] = 0; // Deathmatch
$ItemMax[dmfemale, LargeForceFieldPack] = 0;

 // "Base" armor
$ItemMax[armormSniper, MannequinPack] = 1; // Light 
$ItemMax[armorfSniper, MannequinPack] = 1; 
$ItemMax[armormMercenary, MannequinPack] = 1; // Medium 
$ItemMax[armorfMercenary, MannequinPack] = 1; 
$ItemMax[harmor, MannequinPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, MannequinPack] = 1; // Scout
$ItemMax[armorfScout, MannequinPack] = 1; 
$ItemMax[armormSpy, MannequinPack] = 1; // Spy
$ItemMax[armorfSpy, MannequinPack] = 1; 
$ItemMax[armormBurster, MannequinPack] = 1; // Burster
$ItemMax[armorfBurster, MannequinPack] = 1; 
$ItemMax[armormEngineer, MannequinPack] = 1; // Engineer
$ItemMax[armorfEngineer, MannequinPack] = 1; 
$ItemMax[armormAlien, MannequinPack] = 1; // Alien
$ItemMax[armorfAlien, MannequinPack] = 1; 
$ItemMax[armorCyborg, MannequinPack] = 1; // Cyborg

$ItemMax[dmarmor, MannequinPack] = 1; // Deathmatch
$ItemMax[dmfemale, MannequinPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, PlatformPack] = 0; // Light 
$ItemMax[armorfSniper, PlatformPack] = 0; 
$ItemMax[armormMercenary, PlatformPack] = 0; // Medium 
$ItemMax[armorfMercenary, PlatformPack] = 0; 
$ItemMax[harmor, PlatformPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, PlatformPack] = 0; // Scout
$ItemMax[armorfScout, PlatformPack] = 0; 
$ItemMax[armormSpy, PlatformPack] = 0; // Spy
$ItemMax[armorfSpy, PlatformPack] = 0; 
$ItemMax[armormBurster, PlatformPack] = 0; // Burster
$ItemMax[armorfBurster, PlatformPack] = 0; 
$ItemMax[armormEngineer, PlatformPack] = 1; // Engineer
$ItemMax[armorfEngineer, PlatformPack] = 1; 
$ItemMax[armormAlien, PlatformPack] = 0; // Alien
$ItemMax[armorfAlien, PlatformPack] = 0; 
$ItemMax[armorCyborg, PlatformPack] = 0; // Cyborg

$ItemMax[dmarmor, AcceleratorDevicePack] = 1; // Deathmatch
$ItemMax[dmfemale, AcceleratorDevicePack] = 1;

 // "Base" armor
$ItemMax[armormSniper, DeployableComPack] = 0; // Light 
$ItemMax[armorfSniper, DeployableComPack] = 0; 
$ItemMax[armormMercenary, DeployableComPack] = 0; // Medium 
$ItemMax[armorfMercenary, DeployableComPack] = 0; 
$ItemMax[harmor, DeployableComPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, DeployableComPack] = 0; // Scout
$ItemMax[armorfScout, DeployableComPack] = 0; 
$ItemMax[armormSpy, DeployableComPack] = 0; // Spy
$ItemMax[armorfSpy, DeployableComPack] = 0; 
$ItemMax[armormBurster, DeployableComPack] = 0; // Burster
$ItemMax[armorfBurster, DeployableComPack] = 0; 
$ItemMax[armormEngineer, DeployableComPack] = 1; // Engineer
$ItemMax[armorfEngineer, DeployableComPack] = 1; 
$ItemMax[armormAlien, DeployableComPack] = 0; // Alien
$ItemMax[armorfAlien, DeployableComPack] = 0; 
$ItemMax[armorCyborg, DeployableComPack] = 1; // Cyborg

$ItemMax[dmarmor, DeployableComPack] = 0; // Deathmatch
$ItemMax[dmfemale, DeployableComPack] = 0;

 // "Base" armor
$ItemMax[armormSniper, DeployableInvPack] = 0; // Light 
$ItemMax[armorfSniper, DeployableInvPack] = 0; 
$ItemMax[armormMercenary, DeployableInvPack] = 0; // Medium 
$ItemMax[armorfMercenary, DeployableInvPack] = 0; 
$ItemMax[harmor, DeployableInvPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, DeployableInvPack] = 0; // Scout
$ItemMax[armorfScout, DeployableInvPack] = 0; 
$ItemMax[armormSpy, DeployableInvPack] = 0; // Spy
$ItemMax[armorfSpy, DeployableInvPack] = 0; 
$ItemMax[armormBurster, DeployableInvPack] = 0; // Burster
$ItemMax[armorfBurster, DeployableInvPack] = 0; 
$ItemMax[armormEngineer, DeployableInvPack] = 1; // Engineer
$ItemMax[armorfEngineer, DeployableInvPack] = 1; 
$ItemMax[armormAlien, DeployableInvPack] = 0; // Alien
$ItemMax[armorfAlien, DeployableInvPack] = 0; 
$ItemMax[armorCyborg, DeployableInvPack] = 0; // Cyborg

$ItemMax[dmarmor, DeployableInvPack] = 1; // Deathmatch
$ItemMax[dmfemale, DeployableInvPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, SpringPack] = 0; // Light 
$ItemMax[armorfSniper, SpringPack] = 0; 
$ItemMax[armormMercenary, SpringPack] = 0; // Medium 
$ItemMax[armorfMercenary, SpringPack] = 0; 
$ItemMax[harmor, SpringPack] = 0; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, SpringPack] = 0; // Scout
$ItemMax[armorfScout, SpringPack] = 0; 
$ItemMax[armormSpy, SpringPack] = 0; // Spy
$ItemMax[armorfSpy, SpringPack] = 0; 
$ItemMax[armormBurster, SpringPack] = 0; // Burster
$ItemMax[armorfBurster, SpringPack] = 0; 
$ItemMax[armormEngineer, SpringPack] = 1; // Engineer
$ItemMax[armorfEngineer, SpringPack] = 1; 
$ItemMax[armormAlien, SpringPack] = 0; // Alien
$ItemMax[armorfAlien, SpringPack] = 0; 
$ItemMax[armorCyborg, SpringPack] = 0; // Cyborg

$ItemMax[dmarmor, SpringPack] = 1; // Deathmatch
$ItemMax[dmfemale, SpringPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, TeleportPack] = 0; // Light 
$ItemMax[armorfSniper, TeleportPack] = 0; 
$ItemMax[armormMercenary, TeleportPack] = 0; // Medium 
$ItemMax[armorfMercenary, TeleportPack] = 0; 
$ItemMax[harmor, TeleportPack] = 1; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, TeleportPack] = 0; // Scout
$ItemMax[armorfScout, TeleportPack] = 0; 
$ItemMax[armormSpy, TeleportPack] = 0; // Spy
$ItemMax[armorfSpy, TeleportPack] = 0; 
$ItemMax[armormBurster, TeleportPack] = 0; // Burster
$ItemMax[armorfBurster, TeleportPack] = 0; 
$ItemMax[armormEngineer, TeleportPack] = 1; // Engineer
$ItemMax[armorfEngineer, TeleportPack] = 1; 
$ItemMax[armormAlien, TeleportPack] = 0; // Alien
$ItemMax[armorfAlien, TeleportPack] = 0; 
$ItemMax[armorCyborg, TeleportPack] = 0; // Cyborg

$ItemMax[dmarmor, TeleportPack] = 1; // Deathmatch
$ItemMax[dmfemale, TeleportPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, TreePack] = 1; // Light 
$ItemMax[armorfSniper, TreePack] = 1; 
$ItemMax[armormMercenary, TreePack] = 0; // Medium 
$ItemMax[armorfMercenary, TreePack] = 0; 
$ItemMax[harmor, TreePack] = 0; // Heavy 

 // "Renegades" armor
$ItemMax[armormScout, TreePack] = 0; // Scout
$ItemMax[armorfScout, TreePack] = 0; 
$ItemMax[armormSpy, TreePack] = 0; // Spy
$ItemMax[armorfSpy, TreePack] = 0; 
$ItemMax[armormBurster, TreePack] = 0; // Burster
$ItemMax[armorfBurster, TreePack] = 0; 
$ItemMax[armormEngineer, TreePack] = 1; // Engineer
$ItemMax[armorfEngineer, TreePack] = 1; 
$ItemMax[armormAlien, TreePack] = 0; // Alien
$ItemMax[armorfAlien, TreePack] = 0; 
$ItemMax[armorCyborg, TreePack] = 0; // Cyborg

$ItemMax[dmarmor, TreePack] = 0; // Deathmatch
$ItemMax[dmfemale, TreePack] = 0;

$ItemMax[armormSniper, MechPack] = 0; 
$ItemMax[armormMercenary, MechPack] = 0; 
$ItemMax[harmor, MechPack] = 0; 
$ItemMax[armorfSniper, MechPack] = 0; 
$ItemMax[armorfMercenary, MechPack] = 0; 
$ItemMax[armormScout, MechPack] = 1; 
$ItemMax[armormBurster, MechPack] = 0; 
$ItemMax[armorCyborg, MechPack] = 0; 
$ItemMax[armorfScout, MechPack] = 1; 
$ItemMax[armorfBurster, MechPack] = 0; 
$ItemMax[armormSpy, MechPack] = 0; 
$ItemMax[armorfSpy, MechPack] = 0; 
$ItemMax[armormEngineer, MechPack] = 0; 
$ItemMax[armorfEngineer, MechPack] = 0; 
$ItemMax[armormAlien, MechPack] = 0; 
$ItemMax[armorfAlien, MechPack] = 0; 
$ItemMax[dmarmor, MechPack] = 0; 
$ItemMax[dmfemale, MechPack] = 0; 

$ItemMax[armormMercenary, DetPack] = 0; 
$ItemMax[armormSniper, DetPack] = 0; 
$ItemMax[harmor, DetPack] = 0; 
$ItemMax[armorfSniper, DetPack] = 0; 
$ItemMax[armorfMercenary, DetPack] = 0; 
$ItemMax[armormScout, DetPack] = 0; 
$ItemMax[armormBurster, DetPack] = 0; 
$ItemMax[armorCyborg, DetPack] = 0; 
$ItemMax[armorfScout, DetPack] = 0; 
$ItemMax[armorfBurster, DetPack] = 0;
$ItemMax[armormSpy, DetPack] = 0;  
$ItemMax[armorfSpy, DetPack] = 0; 
$ItemMax[armormEngineer, DetPack] = 1; 
$ItemMax[armorfEngineer, DetPack] = 1; 
$ItemMax[armormAlien, DetPack] = 0; 
$ItemMax[armorfAlien, DetPack] = 0; 
$ItemMax[dmarmor, DetPack] = 0; 
$ItemMax[dmfemale, DetPack] = 0; 


// TargetMarkLaser
$ItemMax[armormScout, TargetMarkLaser] = 0; // Scout
$ItemMax[armorfScout, TargetMarkLaser] = 0; 
$ItemMax[armormSpy, TargetMarkLaser] = 0; // Spy
$ItemMax[armorfSpy, TargetMarkLaser] = 0; 
$ItemMax[armormBurster, TargetMarkLaser] = 0; // Burster
$ItemMax[armorfBurster, TargetMarkLaser] = 0; 
$ItemMax[armormEngineer, TargetMarkLaser] = 0; // Engineer
$ItemMax[armorfEngineer, TargetMarkLaser] = 0; 
$ItemMax[armormAlien, TargetMarkLaser] = 0; // Alien
$ItemMax[armorfAlien, TargetMarkLaser] = 0; 
$ItemMax[armorCyborg, TargetMarkLaser] = 1; // Cyborg

$ItemMax[dmarmor, TargetMarkLaser] = 0; // Deathmatch
$ItemMax[dmfemale, TargetMarkLaser] = 0;

// PhotonPack
$ItemMax[armormScout, PhotonPack] = 0; // Scout
$ItemMax[armorfScout, PhotonPack] = 0; 
$ItemMax[armormSpy, PhotonPack] = 0; // Spy
$ItemMax[armorfSpy, PhotonPack] = 0; 
$ItemMax[armormBurster, PhotonPack] = 0; // Burster
$ItemMax[armorfBurster, PhotonPack] = 0; 
$ItemMax[armormEngineer, PhotonPack] = 0; // Engineer
$ItemMax[armorfEngineer, PhotonPack] = 0; 
$ItemMax[armormAlien, PhotonPack] = 0; // Alien
$ItemMax[armorfAlien, PhotonPack] = 0; 
$ItemMax[armorCyborg, PhotonPack] = 1; // Cyborg

$ItemMax[dmarmor, PhotonPack] = 0; // Deathmatch
$ItemMax[dmfemale, PhotonPack] = 0;

// Tracker Missile Pack
$ItemMax[armormScout, TrackerMissilePack] = 0; // Scout
$ItemMax[armorfScout, TrackerMissilePack] = 0; 
$ItemMax[armormSpy, TrackerMissilePack] = 0; // Spy
$ItemMax[armorfSpy, TrackerMissilePack] = 0; 
$ItemMax[armormBurster, TrackerMissilePack] = 0; // Burster
$ItemMax[armorfBurster, TrackerMissilePack] = 0; 
$ItemMax[armormEngineer, TrackerMissilePack] = 0; // Engineer
$ItemMax[armorfEngineer, TrackerMissilePack] = 0; 
$ItemMax[armormAlien, TrackerMissilePack] = 0; // Alien
$ItemMax[armorfAlien, TrackerMissilePack] = 0; 
$ItemMax[armorCyborg, TrackerMissilePack] = 1; // Cyborg

$ItemMax[dmarmor, TrackerMissilePack] = 0; // Deathmatch
$ItemMax[dmfemale, TrackerMissilePack] = 0;

// Tracker Missiles
$ItemMax[armormScout, TrackerMissileAmmo] = 5; // Scout
$ItemMax[armorfScout, TrackerMissileAmmo] = 5; 
$ItemMax[armormSpy, TrackerMissileAmmo] = 5; // Spy
$ItemMax[armorfSpy, TrackerMissileAmmo] = 5; 
$ItemMax[armormBurster, TrackerMissileAmmo] = 7; // Burster
$ItemMax[armorfBurster, TrackerMissileAmmo] = 7; 
$ItemMax[armormEngineer, TrackerMissileAmmo] = 7; // Engineer
$ItemMax[armorfEngineer, TrackerMissileAmmo] = 7; 
$ItemMax[armormAlien, TrackerMissileAmmo] = 7; // Alien
$ItemMax[armorfAlien, TrackerMissileAmmo] = 7; 
$ItemMax[armorCyborg, TrackerMissileAmmo] = 10; // Cyborg

$ItemMax[dmarmor, TrackerMissileAmmo] = 0; // Deathmatch
$ItemMax[dmfemale, TrackerMissileAmmo] = 0;


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TEAM ITEM MAXs
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$TeamItemMax[IonTurretPack] = 6;
$TeamItemMax[LaserTurretPack] = 6;
$TeamItemMax[RocketPack] = 3;
$TeamItemMax[MortarTurretPack] = 2;
$TeamItemMax[PlasmaTurretPack] = 4;
$TeamItemMax[RailTurretPack] = 2;
$TeamItemMax[ShockTurretPack] = 4;
$TeamItemMax[VulcanTurretPack] = 2;

$TeamItemMax[AcceleratorDevice] = 2;
$TeamItemMax[BlastWallPack] = 10; 
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[ForceFieldPack] = 12; 
$TeamItemMax[LargeForceFieldPack] = 2; 
$TeamItemMax[Mannequin] = 6;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[PlatformPack] = 12; 
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableComPack] = 5; 
$TeamItemMax[DeployableInvPack] = 10; 
$TeamItemMax[Springboard] = 3;
$TeamItemMax[TreePack] = 6; 