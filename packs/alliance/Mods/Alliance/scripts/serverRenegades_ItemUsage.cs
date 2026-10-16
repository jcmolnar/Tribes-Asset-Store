
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
PopulateItemMax(GaussGun,          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0); // <<
PopulateItemMax(GrenadeLauncher,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(GrenadeAmmo,      10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  20,  20,  10,  10,  15);
PopulateItemMax(HyperB,            1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(IonGun,            1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(LaserRifle,        1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MassDriver,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(MassAmmo,         20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(Mortar,            1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(MortarAmmo,        5,   5,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,   5,   5,  10,  10,  10);
PopulateItemMax(Omega,             1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(PlasmaGun,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(PlasmaAmmo,       40,  40,  30,  30,  30,  30,  30,  30,  40,  40,  40,  40,  50,  50,  40,  40,  50);
PopulateItemMax(Railgun,           1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(RailAmmo,         10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10);
PopulateItemMax(RocketLauncher,    1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(RocketAmmo,        5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,  10,  10,   5,   5,  10);
PopulateItemMax(Silencer,          1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SilencerAmmo,     25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25);
PopulateItemMax(SniperRifle,       1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperAmmo,       15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15);
PopulateItemMax(TargetingLaser,    0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(TractorDevice,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TranqGun,          1,   1,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TranqAmmo,        10,  10,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(Vulcan,            1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(VulcanAmmo,      150, 150, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 200);
PopulateItemMax(WaveGun,           1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // MISC 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Boost,             4,   4,   5,   5,   3,   3,   3,   3,   4,   4,   4,   4,   4,   4,   4,   4,   5); // <<
PopulateItemMax(Beacon,            1,   1,   3,   3,   3,   3,   1,   1,   3,   3,   1,   1,   4,   4,   3,   3,   3);  
PopulateItemMax(Grenade,           5,   5,   5,   5,   3,   3,   3,   3,   6,   6,   6,   6,   6,   6,   5,   5,   3);
PopulateItemMax(MineAmmo,          3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   6,   6,   3,   3,   5);
PopulateItemMax(Plastique,         1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0); // <<
PopulateItemMax(RepairKit,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // PACKS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,          1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(CloakingDevice,    0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(EnergyPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(FcgPack,           0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1); // <<
PopulateItemMax(ImRecPack,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1); // <<
PopulateItemMax(Laptop,            0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(LightningPack,     1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0); // <<
PopulateItemMax(OpticPack,         0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0); // <<
PopulateItemMax(RegenerationPack,  1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(RepairPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(SensorJammerPack,  0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(SMRPack,           1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1); // <<
PopulateItemMax(StealthShieldPack, 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(SuicidePack,       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);

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
 //                              mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(IonTurretPack,     0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(LaserTurretPack,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(MortarTurretPack,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(PlasmaTurretPack,  0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(RailTurretPack,    1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(RocketPack,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(ShockTurretPack,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(VulcanTurretPack,  1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                    mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                                    ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AcceleratorDevicePack,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(BlastWallPack,           0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableAmmoPack,      1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(DeployableComPack,       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(DeployableInvPack,       1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(DetPack,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(ForceFieldPack,          1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(LargeForceFieldPack,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(MannequinPack,           1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MechPack,                0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PackOMen,                1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PlatformPack,            0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(SpringPack,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(TeleportPack,            1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(TreePack,                0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TRACKING WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                    mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY
 //                                    ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(TargetMarkLaser,         0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(PhotonPack,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(TrackerMissilePack,      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(TrackerMissileAmmo,      0,   0,   5,   5,   5,   5,   5,   5,   7,   7,   7,   7,   7,   7,   7,   7,   8);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TEAM ITEM MAXs
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$TeamItemMax[IonTurretPack] = 5;
$TeamItemMax[LaserTurretPack] = 4;
$TeamItemMax[RocketPack] = 3;
$TeamItemMax[MortarTurretPack] = 2;
$TeamItemMax[PlasmaTurretPack] = 3;
$TeamItemMax[RailTurretPack] = 3;
$TeamItemMax[SatchelPack] = 25;
$TeamItemMax[ShockTurretPack] = 4;
$TeamItemMax[VulcanTurretPack] = 3;

$TeamItemMax[AcceleratorDevice] = 3;
$TeamItemMax[BlastWallPack] = 8; 
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[ForceFieldPack] = 8; 
$TeamItemMax[LargeForceFieldPack] = 2; 
$TeamItemMax[Mannequin] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[PlatformPack] = 10; 
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableComPack] = 5; 
$TeamItemMax[DeployableInvPack] = 10; 
$TeamItemMax[Springboard] = 3;
$TeamItemMax[TreePack] = 10; 