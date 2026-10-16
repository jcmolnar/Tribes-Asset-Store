
$CanPilot = 1;
$CanRide = 2;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // ARMOR 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // P Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$DamageScale[armorPenis, $LandingDamageType] = 0.0; 
$DamageScale[armorPenis, $ImpactDamageType] = 0.0; 
$DamageScale[armorPenis, $CrushDamageType] = 0.0; 
$DamageScale[armorPenis, $BulletDamageType] = 0.0; 
$DamageScale[armorPenis, $PlasmaDamageType] = 0.0; 
$DamageScale[armorPenis, $EnergyDamageType] = 0.0; 
$DamageScale[armorPenis, $ExplosionDamageType] = 0.0; 
$DamageScale[armorPenis, $MissileDamageType] = 0.0; 
$DamageScale[armorPenis, $DebrisDamageType] = 0.0; 
$DamageScale[armorPenis, $ShrapnelDamageType] = 0.0; 
$DamageScale[armorPenis, $LaserDamageType] = 0.0; 
$DamageScale[armorPenis, $MortarDamageType] = 0.0; 
$DamageScale[armorPenis, $BlasterDamageType] = 0.0; 
$DamageScale[armorPenis, $ElectricityDamageType] = 0.0; 
$DamageScale[armorPenis, $MineDamageType] = 0.0; 
$DamageScale[armorPenis, $ForceDamageType] = 0.0; 
$DamageScale[armorPenis, $NukeDamageType] = 0.0; 
$DamageScale[armorPenis, $LTurretDamageType] = 0.0; 
$DamageScale[armorPenis, $CTurretDamageType] = 0.0; 
$DamageScale[armorPenis, $ETurretDamageType] = 0.0; 
$DamageScale[armorPenis, $KamikazeDamageType] = 0.0;
$DamageScale[armorPenis, $IonDamageType] = 0.0;
$DamageScale[armorPenis, $FusionDamageType] = 0.0;
 //
$VehicleUse[armorPenis, Wraith] = $CanRide;
$VehicleUse[armorPenis, Interceptor] = $CanRide;
$VehicleUse[armorPenis, Scout] = $CanRide;
$VehicleUse[armorPenis, LAPC] = $CanRide;
$VehicleUse[armorPenis, HAPC] = $CanRide;
$VehicleUse[armorPenis, B2] = $CanRide;
$VehicleUse[armorPenis, FusionMarker] = $CanRide;
$VehicleUse[armorPenis, Runner] = $CanRide;
$VehicleUse[armorPenis, Scorcher] = $CanRide;
$VehicleUse[armorPenis, Scrambler] = $CanRide;
$VehicleUse[armorPenis, Mini] = $CanRide;
$VehicleUse[armorPenis, Bouncer] = $CanRide; 

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
$DamageScale[dmarmor, $ShotgunDamageType] = 1.0;
$DamageScale[dmarmor, $DebrisDamageType] = 1.0;
$DamageScale[dmarmor, $LaserDamageType] = 1.0;
$DamageScale[dmarmor, $MortarDamageType] = 1.0;
$DamageScale[dmarmor, $BlasterDamageType] = 1.0;
$DamageScale[dmarmor, $ElectricityDamageType] = 1.0;
$DamageScale[dmarmor, $MineDamageType] = 1.0;
$DamageScale[dmarmor, $SniperDamageType] = 1.0;
$DamageScale[dmarmor, $FlashDamageType] = 1.0;
$DamageScale[dmarmor, $KamikazeDamageType] = 2.0;
$DamageScale[dmarmor, $IonDamageType] = 1.0;
$DamageScale[dmarmor, $FusionDamageType] = 1.0;
 //
$VehicleUse[dmarmor, Wraith] = $CanRide;
$VehicleUse[dmarmor, Interceptor] = $CanRide;
$VehicleUse[dmarmor, Scout] = $CanRide;
$VehicleUse[dmarmor, LAPC] = $CanRide;
$VehicleUse[dmarmor, HAPC] = $CanRide;
$VehicleUse[dmarmor, B2] = $CanRide;
$VehicleUse[dmarmor, FusionMarker] = $CanRide;
$VehicleUse[dmarmor, Runner] = $CanRide;
$VehicleUse[dmarmor, Scorcher] = $CanRide;
$VehicleUse[dmarmor, Scrambler] = $CanRide;
$VehicleUse[dmarmor, Mini] = $CanRide;
$VehicleUse[dmarmor, Bouncer] = $CanRide; 

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
$DamageScale[dmfemale, $ShotgunDamageType] = 1.0;
$DamageScale[dmfemale, $DebrisDamageType] = 1.0;
$DamageScale[dmfemale, $LaserDamageType] = 1.0;
$DamageScale[dmfemale, $MortarDamageType] = 1.0;
$DamageScale[dmfemale, $BlasterDamageType] = 1.0;
$DamageScale[dmfemale, $ElectricityDamageType] = 1.0;
$DamageScale[dmfemale, $MineDamageType] = 1.0;
$DamageScale[dmfemale, $SniperDamageType] = 1.0;
$DamageScale[dmfemale, $FlashDamageType] = 1.0;
$DamageScale[dmfemale, $KamikazeDamageType] = 2.0;
$DamageScale[dmfemale, $IonDamageType] = 1.0;
$DamageScale[dmfemale, $FusionDamageType] = 1.0;
 //
$VehicleUse[dmfemale, Wraith] = $CanRide;
$VehicleUse[dmfemale, Interceptor] = $CanRide;
$VehicleUse[dmfemale, Scout] = $CanRide;
$VehicleUse[dmfemale, LAPC] = $CanRide;
$VehicleUse[dmfemale, HAPC] = $CanRide;
$VehicleUse[dmfemale, B2] = $CanRide;
$VehicleUse[dmfemale, FusionMarker] = $CanRide;
$VehicleUse[dmfemale, Runner] = $CanRide;
$VehicleUse[dmfemale, Scorcher] = $CanRide;
$VehicleUse[dmfemale, Scrambler] = $CanRide;
$VehicleUse[dmfemale, Mini] = $CanRide;
$VehicleUse[dmfemale, Bouncer] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Scout Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormScout] = 3;
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
$DamageScale[armormScout, $ShotgunDamageType] = 1.2;
$DamageScale[armormScout, $LaserDamageType] = 1.2;
$DamageScale[armormScout, $MortarDamageType] = 1.3;
$DamageScale[armormScout, $BlasterDamageType] = 1.3;
$DamageScale[armormScout, $ElectricityDamageType] = 1.0;
$DamageScale[armormScout, $MineDamageType] = 1.2;
$DamageScale[armormScout, $SniperDamageType] = 1.0;
$DamageScale[armormScout, $FlashDamageType] = 1.0;
$DamageScale[armormScout, $KamikazeDamageType] = 3.0;
$DamageScale[armormScout, $IonDamageType] = 1.3;
$DamageScale[armormScout, $FusionDamageType] = 1.3;
 //
$VehicleUse[armormScout, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormScout, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormScout, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormScout, B2] = $CanPilot | $CanRide;
$VehicleUse[armormScout, FusionMarker] =  $CanPilot | $CanRide;
$VehicleUse[armormScout, Runner] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Mini] = $CanPilot | $CanRide;
$VehicleUse[armormScout, Bouncer] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Scout Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfScout] = 3;
$DamageScale[armorfScout, $LandingDamageType] = 0.5;
$DamageScale[armorfScout, $ImpactDamageType] = 0.5;
$DamageScale[armorfScout, $CrushDamageType] = 0.5;
$DamageScale[armorfScout, $BulletDamageType] = 1.2;
$DamageScale[armorfScout, $PlasmaDamageType] = 1.0;
$DamageScale[armorfScout, $EnergyDamageType] = 1.3;
$DamageScale[armorfScout, $ExplosionDamageType] = 1.0;
$DamageScale[armorfScout, $MissileDamageType] = 1.0;
$DamageScale[armorfScout, $ShrapnelDamageType] = 1.2;
$DamageScale[armorfScout, $ShotgunDamageType] = 1.2;
$DamageScale[armorfScout, $DebrisDamageType] = 1.2;
$DamageScale[armorfScout, $LaserDamageType] = 1.0;
$DamageScale[armorfScout, $MortarDamageType] = 1.3;
$DamageScale[armorfScout, $BlasterDamageType] = 1.3;
$DamageScale[armorfScout, $ElectricityDamageType] = 1.0;
$DamageScale[armorfScout, $MineDamageType] = 1.2;
$DamageScale[armorfScout, $SniperDamageType] = 1.0;
$DamageScale[armorfScout, $FlashDamageType] = 1.0;
$DamageScale[armorfScout, $KamikazeDamageType] = 3.0;
$DamageScale[armorfScout, $IonDamageType] = 1.3;
$DamageScale[armorfScout, $FusionDamageType] = 1.3;
 //
$VehicleUse[armorfScout, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, B2] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Runner] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armorfScout, Mini] = $CanPilot | $CanRide; 
$VehicleUse[armorfScout, Bouncer] = $CanPilot | $CanRide;

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
$DamageScale[armormSpy, $ShotgunDamageType] = 1.3;
$DamageScale[armormSpy, $LaserDamageType] = 1.0;
$DamageScale[armormSpy, $MortarDamageType] = 1.3;
$DamageScale[armormSpy, $BlasterDamageType] = 1.3;
$DamageScale[armormSpy, $ElectricityDamageType] = 1.0;
$DamageScale[armormSpy, $MineDamageType] = 1.2;
$DamageScale[armormSpy, $SniperDamageType] = 1.0;
$DamageScale[armormSpy, $FlashDamageType] = 1.0;
$DamageScale[armormSpy, $KamikazeDamageType] = 3.0;
$DamageScale[armormSpy, $IonDamageType] = 1.3;
$DamageScale[armormSpy, $FusionDamageType] = 1.3;
 //
$VehicleUse[armormSpy, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, B2] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Runner] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Mini] = $CanPilot | $CanRide;
$VehicleUse[armormSpy, Bouncer] = $CanPilot | $CanRide;

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
$DamageScale[armorfSpy, $ShotgunDamageType] = 1.3;
$DamageScale[armorfSpy, $LaserDamageType] = 1.0;
$DamageScale[armorfSpy, $MortarDamageType] = 1.3;
$DamageScale[armorfSpy, $BlasterDamageType] = 1.3;
$DamageScale[armorfSpy, $ElectricityDamageType] = 1.0;
$DamageScale[armorfSpy, $MineDamageType] = 1.2;
$DamageScale[armorfSpy, $SniperDamageType] = 1.0;
$DamageScale[armorfSpy, $FlashDamageType] = 1.0;
$DamageScale[armorfSpy, $KamikazeDamageType] = 3.0;
$DamageScale[armorfSpy, $IonDamageType] = 1.3;
$DamageScale[armorfSpy, $FusionDamageType] = 1.3;
 // 
$VehicleUse[armorfSpy, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, B2] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Runner] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Mini] = $CanPilot | $CanRide;
$VehicleUse[armorfSpy, Bouncer] = $CanPilot | $CanRide; 

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
$DamageScale[armormSniper, $ShotgunDamageType] = 1.2;
$DamageScale[armormSniper, $LaserDamageType] = 1.0;
$DamageScale[armormSniper, $MortarDamageType] = 1.3;
$DamageScale[armormSniper, $BlasterDamageType] = 1.3;
$DamageScale[armormSniper, $ElectricityDamageType] = 1.0;
$DamageScale[armormSniper, $MineDamageType] = 1.2;
$DamageScale[armormSniper, $SniperDamageType] = 1.0;
$DamageScale[armormSniper, $FlashDamageType] = 1.0;
$DamageScale[armormSniper, $KamikazeDamageType] = 3.0;
$DamageScale[armormSniper, $IonDamageType] = 1.3;
$DamageScale[armormSniper, $FusionDamageType] = 1.3;
 //
$VehicleUse[armormSniper, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, B2] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Runner] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Mini] = $CanPilot | $CanRide;
$VehicleUse[armormSniper, Bouncer] = $CanPilot | $CanRide; 

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
$DamageScale[armorfSniper, $ShotgunDamageType] = 1.2;
$DamageScale[armorfSniper, $DebrisDamageType] = 1.2;
$DamageScale[armorfSniper, $LaserDamageType] = 1.0;
$DamageScale[armorfSniper, $MortarDamageType] = 1.3;
$DamageScale[armorfSniper, $BlasterDamageType] = 1.3;
$DamageScale[armorfSniper, $ElectricityDamageType] = 1.0;
$DamageScale[armorfSniper, $MineDamageType] = 1.2;
$DamageScale[armorfSniper, $SniperDamageType] = 1.0;
$DamageScale[armorfSniper, $FlashDamageType] = 1.0;
$DamageScale[armorfSniper, $KamikazeDamageType] = 3.0;
$DamageScale[armorfSniper, $IonDamageType] = 1.3;
$DamageScale[armorfSniper, $FusionDamageType] = 1.3;
 //
$VehicleUse[armorfSniper, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, B2] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Runner] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Mini] = $CanPilot | $CanRide;
$VehicleUse[armorfSniper, Bouncer] = $CanPilot | $CanRide;

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
$DamageScale[armormMercenary, $ShotgunDamageType] = 1.0;
$DamageScale[armormMercenary, $DebrisDamageType] = 1.0;
$DamageScale[armormMercenary, $LaserDamageType] = 1.0;
$DamageScale[armormMercenary, $MortarDamageType] = 1.0;
$DamageScale[armormMercenary, $BlasterDamageType] = 1.0;
$DamageScale[armormMercenary, $ElectricityDamageType] = 1.0;
$DamageScale[armormMercenary, $MineDamageType] = 1.0;
$DamageScale[armormMercenary, $SniperDamageType] = 1.0;
$DamageScale[armormMercenary, $FlashDamageType] = 1.0;
$DamageScale[armormMercenary, $KamikazeDamageType] = 2.0;
$DamageScale[armormMercenary, $IonDamageType] = 1.0;
$DamageScale[armormMercenary, $FusionDamageType] = 1.0;
 //
$VehicleUse[armormMercenary, Wraith] = $CanRide;
$VehicleUse[armormMercenary, Interceptor] = $CanRide;
$VehicleUse[armormMercenary, Scout] = $CanRide;
$VehicleUse[armormMercenary, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormMercenary, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormMercenary, B2] = $CanPilot | $CanRide;
$VehicleUse[armormMercenary, FusionMarker] = $CanRide;
$VehicleUse[armormMercenary, Runner] = $CanRide;
$VehicleUse[armormMercenary, Scorcher] = $CanRide;
$VehicleUse[armormMercenary, Scrambler] = $CanRide;
$VehicleUse[armormMercenary, Mini] = $CanRide; 
$VehicleUse[armormMercenary, Bouncer] = $CanRide;

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
$DamageScale[armorfMercenary, $ShotgunDamageType] = 1.0;
$DamageScale[armorfMercenary, $DebrisDamageType] = 1.0;
$DamageScale[armorfMercenary, $LaserDamageType] = 1.0;
$DamageScale[armorfMercenary, $MortarDamageType] = 1.0;
$DamageScale[armorfMercenary, $BlasterDamageType] = 1.0;
$DamageScale[armorfMercenary, $ElectricityDamageType] = 1.0;
$DamageScale[armorfMercenary, $MineDamageType] = 1.0;
$DamageScale[armorfMercenary, $SniperDamageType] = 1.0;
$DamageScale[armorfMercenary, $FlashDamageType] = 1.0;
$DamageScale[armorfMercenary, $KamikazeDamageType] = 2.0;
$DamageScale[armorfMercenary, $IonDamageType] = 1.0;
$DamageScale[armorfMercenary, $FusionDamageType] = 1.0;
 //
$VehicleUse[armorfMercenary, Wraith] = $CanRide;
$VehicleUse[armorfMercenary, Interceptor] = $CanRide;
$VehicleUse[armorfMercenary, Scout] = $CanRide;
$VehicleUse[armorfMercenary, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfMercenary, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfMercenary, B2] = $CanPilot | $CanRide;
$VehicleUse[armorfMercenary, FusionMarker] = $CanRide;
$VehicleUse[armorfMercenary, Runner] = $CanRide;
$VehicleUse[armorfMercenary, Scorcher] = $CanRide;
$VehicleUse[armorfMercenary, Scrambler] = $CanRide;
$VehicleUse[armorfMercenary, Mini] = $CanRide; 
$VehicleUse[armorfMercenary, Bouncer] = $CanRide;

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
$DamageScale[armormEngineer, $ShotgunDamageType] = 1.0;
$DamageScale[armormEngineer, $DebrisDamageType] = 1.0;
$DamageScale[armormEngineer, $LaserDamageType] = 1.0;
$DamageScale[armormEngineer, $MortarDamageType] = 1.0;
$DamageScale[armormEngineer, $BlasterDamageType] = 1.0;
$DamageScale[armormEngineer, $ElectricityDamageType] = 1.0;
$DamageScale[armormEngineer, $MineDamageType] = 1.0;
$DamageScale[armormEngineer, $SniperDamageType] = 1.0;
$DamageScale[armormEngineer, $FlashDamageType] = 1.0;
$DamageScale[armormEngineer, $KamikazeDamageType] = 2.0;
$DamageScale[armormEngineer, $IonDamageType] = 1.0;
$DamageScale[armormEngineer, $FusionDamageType] = 1.0;
 //
$VehicleUse[armormEngineer, Wraith] = $CanRide;
$VehicleUse[armormEngineer, Interceptor] = $CanRide;
$VehicleUse[armormEngineer, Scout] = $CanRide;
$VehicleUse[armormEngineer, LAPC] = $CanRide;
$VehicleUse[armormEngineer, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormEngineer, B2] = $CanPilot | $CanRide;
$VehicleUse[armormEngineer, FusionMarker] = $CanRide;
$VehicleUse[armormEngineer, Runner] = $CanRide;
$VehicleUse[armormEngineer, Scorcher] = $CanRide;
$VehicleUse[armormEngineer, Scrambler] = $CanRide;
$VehicleUse[armormEngineer, Mini] = $CanRide;
$VehicleUse[armormEngineer, Bouncer] = $CanRide;

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
$DamageScale[armorfEngineer, $ShotgunDamageType] = 1.0;
$DamageScale[armorfEngineer, $DebrisDamageType] = 1.0;
$DamageScale[armorfEngineer, $LaserDamageType] = 1.0;
$DamageScale[armorfEngineer, $MortarDamageType] = 1.0;
$DamageScale[armorfEngineer, $BlasterDamageType] = 1.0;
$DamageScale[armorfEngineer, $ElectricityDamageType] = 1.0;
$DamageScale[armorfEngineer, $MineDamageType] = 1.0;
$DamageScale[armorfEngineer, $SniperDamageType] = 1.0;
$DamageScale[armorfEngineer, $FlashDamageType] = 1.0;
$DamageScale[armorfEngineer, $KamikazeDamageType] = 2.0;
$DamageScale[armorfEngineer, $IonDamageType] = 1.0;
$DamageScale[armorfEngineer, $FusionDamageType] = 1.0;
 //
$VehicleUse[armorfEngineer, Wraith] = $CanRide;
$VehicleUse[armorfEngineer, Interceptor] = $CanRide;
$VehicleUse[armorfEngineer, Scout] = $CanRide;
$VehicleUse[armorfEngineer, LAPC] = $CanRide;
$VehicleUse[armorfEngineer, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfEngineer, B2] = $CanPilot | $CanRide;
$VehicleUse[armorfEngineer, FusionMarker] = $CanRide;
$VehicleUse[armorfEngineer, Runner] = $CanRide;
$VehicleUse[armorfEngineer, Scorcher] = $CanRide;
$VehicleUse[armorfEngineer, Scrambler] = $CanRide;
$VehicleUse[armorfEngineer, Mini] = $CanRide;
$VehicleUse[armorfEngineer, Bouncer] = $CanRide;

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
$DamageScale[armormBurster, $ShotgunDamageType] = 1.3;
$DamageScale[armormBurster, $DebrisDamageType] = 1.0;
$DamageScale[armormBurster, $LaserDamageType] = 1.2;
$DamageScale[armormBurster, $MortarDamageType] = 0.5;
$DamageScale[armormBurster, $BlasterDamageType] = 1.2;
$DamageScale[armormBurster, $ElectricityDamageType] = 1.0;
$DamageScale[armormBurster, $MineDamageType] = 0.5;
$DamageScale[armormBurster, $SniperDamageType] = 1.0;
$DamageScale[armormBurster, $FlashDamageType] = 1.0;
$DamageScale[armormBurster, $KamikazeDamageType] = 2.0;
$DamageScale[armormBurster, $IonDamageType] = 1.1;
$DamageScale[armormBurster, $FusionDamageType] = 1.1;
 // 
$VehicleUse[armormBurster, Wraith] = $CanRide;
$VehicleUse[armormBurster, Interceptor] = $CanRide;
$VehicleUse[armormBurster, Scout] = $CanRide;
$VehicleUse[armormBurster, LAPC] = $CanRide;
$VehicleUse[armormBurster, HAPC] = $CanRide;
$VehicleUse[armormBurster, B2] = $CanRide;
$VehicleUse[armormBurster, FusionMarker] = $CanRide;
$VehicleUse[armormBurster, Runner] = $CanRide;
$VehicleUse[armormBurster, Scorcher] = $CanRide;
$VehicleUse[armormBurster, Scrambler] = $CanRide;
$VehicleUse[armormBurster, Mini] = $CanRide;
$VehicleUse[armormBurster, Bouncer] = $CanRide; 

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
$DamageScale[armorfBurster, $ShotgunDamageType] = 1.3;
$DamageScale[armorfBurster, $DebrisDamageType] = 1.0;
$DamageScale[armorfBurster, $LaserDamageType] = 1.2;
$DamageScale[armorfBurster, $MortarDamageType] = 0.5;
$DamageScale[armorfBurster, $BlasterDamageType] = 1.2;
$DamageScale[armorfBurster, $ElectricityDamageType] = 1.0;
$DamageScale[armorfBurster, $MineDamageType] = 0.5;
$DamageScale[armorfBurster, $SniperDamageType] = 1.0;
$DamageScale[armorfBurster, $FlashDamageType] = 1.0;
$DamageScale[armorfBurster, $KamikazeDamageType] = 2.0;
$DamageScale[armorfBurster, $IonDamageType] = 1.1;
$DamageScale[armorfBurster, $FusionDamageType] = 1.1;
 // 
$VehicleUse[armorfBurster, Wraith] = $CanRide;
$VehicleUse[armorfBurster, Interceptor] = $CanRide;
$VehicleUse[armorfBurster, Scout] = $CanRide;
$VehicleUse[armorfBurster, LAPC] = $CanRide;
$VehicleUse[armorfBurster, HAPC] = $CanRide;
$VehicleUse[armorfBurster, B2] = $CanRide;
$VehicleUse[armorfBurster, FusionMarker] = $CanRide;
$VehicleUse[armorfBurster, Runner] = $CanRide;
$VehicleUse[armorfBurster, Scorcher] = $CanRide;
$VehicleUse[armorfBurster, Scrambler] = $CanRide;
$VehicleUse[armorfBurster, Mini] = $CanRide;
$VehicleUse[armorfBurster, Bouncer] = $CanRide; 

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
$DamageScale[armormAlien, $ShotgunDamageType] = 1.0;
$DamageScale[armormAlien, $DebrisDamageType] = 1.0;
$DamageScale[armormAlien, $LaserDamageType] = 0.5;
$DamageScale[armormAlien, $MortarDamageType] = 1.2;
$DamageScale[armormAlien, $BlasterDamageType] = 0.5;
$DamageScale[armormAlien, $ElectricityDamageType] = 0.5;
$DamageScale[armormAlien, $MineDamageType] = 1.0;
$DamageScale[armormAlien, $SniperDamageType] = 1.0;
$DamageScale[armormAlien, $FlashDamageType] = 2.0;
$DamageScale[armormAlien, $KamikazeDamageType] = 2.0;
$DamageScale[armormAlien, $IonDamageType] = 1.0;
$DamageScale[armormAlien, $FusionDamageType] = 1.0;
 //
$VehicleUse[armormAlien, Wraith] = $CanRide;
$VehicleUse[armormAlien, Interceptor] = $CanRide;
$VehicleUse[armormAlien, Scout] = $CanRide;
$VehicleUse[armormAlien, LAPC] = $CanRide;
$VehicleUse[armormAlien, HAPC] = $CanRide;
$VehicleUse[armormAlien, B2] = $CanRide;
$VehicleUse[armormAlien, FusionMarker] = $CanRide;
$VehicleUse[armormAlien, Runner] = $CanRide;
$VehicleUse[armormAlien, Scorcher] = $CanRide;
$VehicleUse[armormAlien, Scrambler] = $CanRide;
$VehicleUse[armormAlien, Mini] = $CanRide;
$VehicleUse[armormAlien, Bouncer] = $CanRide;

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
$DamageScale[armorfAlien, $ShotgunDamageType] = 1.3;
$DamageScale[armorfAlien, $DebrisDamageType] = 1.0;
$DamageScale[armorfAlien, $LaserDamageType] = 0.5;
$DamageScale[armorfAlien, $MortarDamageType] = 1.2;
$DamageScale[armorfAlien, $BlasterDamageType] = 0.5;
$DamageScale[armorfAlien, $ElectricityDamageType] = 0.5;
$DamageScale[armorfAlien, $MineDamageType] = 1.0;
$DamageScale[armorfAlien, $SniperDamageType] = 1.0;
$DamageScale[armorfAlien, $FlashDamageType] = 2.0;
$DamageScale[armorfAlien, $KamikazeDamageType] = 2.0;
$DamageScale[armorfAlien, $IonDamageType] = 1.0;
$DamageScale[armorfAlien, $FusionDamageType] = 1.0;
 // 
$VehicleUse[armorfAlien, Wraith] = $CanRide;
$VehicleUse[armorfAlien, Interceptor] = $CanRide;
$VehicleUse[armorfAlien, Scout] = $CanRide;
$VehicleUse[armorfAlien, LAPC] = $CanRide;
$VehicleUse[armorfAlien, HAPC] = $CanRide;
$VehicleUse[armorfAlien, B2] = $CanRide;
$VehicleUse[armorfAlien, FusionMarker] = $CanRide;
$VehicleUse[armorfAlien, Runner] = $CanRide;
$VehicleUse[armorfAlien, Scorcher] = $CanRide;
$VehicleUse[armorfAlien, Scrambler] = $CanRide;
$VehicleUse[armorfAlien, Mini] = $CanRide;
$VehicleUse[armorfAlien, Bouncer] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Cyborg Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorCyborg] = 7;
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
$DamageScale[armorCyborg, $ShotgunDamageType] = 1.5;
$DamageScale[armorCyborg, $LaserDamageType] = 0.6;
$DamageScale[armorCyborg, $MortarDamageType] = 0.7;
$DamageScale[armorCyborg, $BlasterDamageType] = 0.7;
$DamageScale[armorCyborg, $ElectricityDamageType] = 0.8;
$DamageScale[armorCyborg, $MineDamageType] = 0.8;
$DamageScale[armorCyborg, $SniperDamageType] = 0.6;
$DamageScale[armorCyborg, $FlashDamageType] = 1.0;
$DamageScale[armorCyborg, $KamikazeDamageType] = 1.0;
$DamageScale[armorCyborg, $IonDamageType] = 0.7;
$DamageScale[armorCyborg, $FusionDamageType] = 0.7;
 //
$VehicleUse[armorCyborg, Wraith] = $CanRide;
$VehicleUse[armorCyborg, Interceptor] = $CanRide;
$VehicleUse[armorCyborg, Scout] = $CanRide;
$VehicleUse[armorCyborg, LAPC] = $CanRide;
$VehicleUse[armorCyborg, HAPC] = $CanRide;
$VehicleUse[armorCyborg, B2] = $CanRide;
$VehicleUse[armorCyborg, FusionMarker] = $CanRide;
$VehicleUse[armorCyborg, Runner] = $CanRide;
$VehicleUse[armorCyborg, Scorcher] = $CanRide;
$VehicleUse[armorCyborg, Scrambler] = $CanRide;
$VehicleUse[armorCyborg, Mini] = $CanRide;
$VehicleUse[armorCyborg, Bouncer] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //Male Loader Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormLoader] = 2;
$DamageScale[armormLoader, $LandingDamageType] = 1.0;
$DamageScale[armormLoader, $ImpactDamageType] = 1.0;
$DamageScale[armormLoader, $CrushDamageType] = 1.0;
$DamageScale[armormLoader, $BulletDamageType] = 1.3;
$DamageScale[armormLoader, $PlasmaDamageType] = 0.4;
$DamageScale[armormLoader, $EnergyDamageType] = 0.5;
$DamageScale[armormLoader, $ExplosionDamageType] = 1.0;
$DamageScale[armormLoader, $MissileDamageType] = 1.0;
$DamageScale[armormLoader, $ShrapnelDamageType] = 0.6;
$DamageScale[armormloader, $ShotgunDamageType] = 1.3;
$DamageScale[armormLoader, $DebrisDamageType] = 0.6;
$DamageScale[armormLoader, $LaserDamageType] = 0.5;
$DamageScale[armormLoader, $MortarDamageType] = 1.3;
$DamageScale[armormLoader, $BlasterDamageType] = 0.7;
$DamageScale[armormLoader, $ElectricityDamageType] = 1.0;
$DamageScale[armormLoader, $MineDamageType] = 1.2;
$DamageScale[armormLoader, $SniperDamageType] = 1.0;
$DamageScale[armormLoader, $FlashDamageType] = 1.0;
$DamageScale[armormLoader, $MeltaDamageType] = 1.0;
$DamageScale[armormLoader, $DeathDamageType] = 1.0;
$DamageScale[armormLoader, $FlamerDamageType] = 1.0;
$DamageScale[armormLoader, $DDamageType] = 1.0;
$DamageScale[armormLoader, $ShurikenDamageType] = 1.0;
$DamageScale[armormLoader, $ReaperDamageType] = 1.0;
$DamageScale[armormLoader, $ShellDamageType] = 1.0;
$DamageScale[armormLoader, $PsiDamageType] = 1.0;
$DamageScale[armormLoader, $KamikazeDamageType] = 2.0;
$DamageScale[armormLoader, $IonDamageType] = 0.5;
$DamageScale[armormLoader, $FusionDamageType] = 0.5;
//
$VehicleUse[armormLoader, Wraith] = $CanRide;
$VehicleUse[armormLoader, Interceptor] = $CanRide;
$VehicleUse[armormLoader, Scout] = $CanRide;
$VehicleUse[armormLoader, LAPC] = $CanRide;
$VehicleUse[armormLoader, HAPC] = $CanRide;
$VehicleUse[armormLoader, B2] = $CanRide;
$VehicleUse[armormLoader, FusionMarker] = $CanRide;
$VehicleUse[armormLoader, Runner] = $CanRide;
$VehicleUse[armormLoader, Scorcher] = $CanRide;
$VehicleUse[armormLoader, Scrambler] = $CanRide;
$VehicleUse[armormLoader, Mini] = $CanRide;
$VehicleUse[armormLoader, Bouncer] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //Female Loader Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfLoader] = 2;
$DamageScale[armorfLoader, $LandingDamageType] = 1.0;
$DamageScale[armorfLoader, $ImpactDamageType] = 1.0;
$DamageScale[armorfLoader, $CrushDamageType] = 1.0;
$DamageScale[armorfLoader, $BulletDamageType] = 1.3;
$DamageScale[armorfLoader, $PlasmaDamageType] = 0.4;
$DamageScale[armorfLoader, $EnergyDamageType] = 0.5;
$DamageScale[armorfLoader, $ExplosionDamageType] = 1.0;
$DamageScale[armorfLoader, $MissileDamageType] = 1.0;
$DamageScale[armorfLoader, $ShrapnelDamageType] = 0.6;
$DamageScale[armorfLoader, $ShotgunDamageType] = 1.3;
$DamageScale[armorfLoader, $DebrisDamageType] = 0.6;
$DamageScale[armorfLoader, $LaserDamageType] = 0.5;
$DamageScale[armorfLoader, $MortarDamageType] = 1.3;
$DamageScale[armorfLoader, $BlasterDamageType] = 0.7;
$DamageScale[armorfLoader, $ElectricityDamageType] = 1.0;
$DamageScale[armorfLoader, $MineDamageType] = 1.2;
$DamageScale[armorfLoader, $SniperDamageType] = 1.0;
$DamageScale[armorfLoader, $FlashDamageType] = 1.0;
$DamageScale[armorfLoader, $MeltaDamageType] = 1.0;
$DamageScale[armorfLoader, $DeathDamageType] = 1.0;
$DamageScale[armorfLoader, $FlamerDamageType] = 1.0;
$DamageScale[armorfLoader, $DDamageType] = 1.0;
$DamageScale[armorfLoader, $ShurikenDamageType] = 1.0;
$DamageScale[armorfLoader, $ReaperDamageType] = 1.0;
$DamageScale[armorfLoader, $ShellDamageType] = 1.0;
$DamageScale[armorfLoader, $PsiDamageType] = 1.0;
$DamageScale[armorfLoader, $KamikazeDamageType] = 2.0;
$DamageScale[armorfLoader, $IonDamageType] = 0.5;
$DamageScale[armorfLoader, $FusionDamageType] = 0.5;
//
$VehicleUse[armorfLoader, Wraith] = $CanRide;
$VehicleUse[armorfLoader, Interceptor] = $CanRide;
$VehicleUse[armorfLoader, Scout] = $CanRide;
$VehicleUse[armorfLoader, LAPC] = $CanRide;
$VehicleUse[armorfLoader, HAPC] = $CanRide;
$VehicleUse[armorfLoader, FusionMarker] = $CanRide;
$VehicleUse[armorfLoader, Runner] = $CanRide;
$VehicleUse[armorfLoader, Scorcher] = $CanRide;
$VehicleUse[armorfLoader, Scrambler] = $CanRide;
$VehicleUse[armorfLoader, Mini] = $CanRide;
$VehicleUse[armorfLoader, Bouncer] = $CanRide;

//----------------------------------
//Sprint Armor -  Male Field Runner
//----------------------------------
$MaxWeapons[armormSprint] = 2;
$DamageScale[armormSprint, $LandingDamageType] = 0.0;
$DamageScale[armormSprint, $ImpactDamageType] = 1.0;
$DamageScale[armormSprint, $CrushDamageType] = 1.0;
$DamageScale[armormSprint, $BulletDamageType] = 1.3;
$DamageScale[armormSprint, $PlasmaDamageType] = 1.0;
$DamageScale[armormSprint, $EnergyDamageType] = 1.0;
$DamageScale[armormSprint, $ExplosionDamageType] = 1.0;
$DamageScale[armormSprint, $MissileDamageType] = 1.0;
$DamageScale[armormSprint, $ShrapnelDamageType] = 1.0;
$DamageScale[armormSprint, $ShotgunDamageType] = 1.3;
$DamageScale[armormSprint, $DebrisDamageType] = 1.0;
$DamageScale[armormSprint, $LaserDamageType] = 1.0;
$DamageScale[armormSprint, $MortarDamageType] = 1.0;
$DamageScale[armormSprint, $BlasterDamageType] = 1.0;
$DamageScale[armormSprint, $ElectricityDamageType] = 1.0;
$DamageScale[armormSprint, $MineDamageType] = 1.2;
$DamageScale[armormSprint, $SniperDamageType] = 1.0;
$DamageScale[armormSprint, $FlashDamageType] = 1.0;
$DamageScale[armormSprint, $KamikazeDamageType] = 3.0;
$DamageScale[armormSprint, $IonDamageType] = 1.0;
$DamageScale[armormSprint, $FusionDamageType] = 1.0;
//
$VehicleUse[armormSprint, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Runner] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Mini] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Bouncer] = $CanPilot | $CanRide;

//-----------------------------------
//Sprint Armor - Female Field Runner
//-----------------------------------
$MaxWeapons[armorfSprint] = 2;
$DamageScale[armorfSprint, $LandingDamageType] = 0.0;
$DamageScale[armorfSprint, $ImpactDamageType] = 1.0;
$DamageScale[armorfSprint, $CrushDamageType] = 1.0;
$DamageScale[armorfSprint, $BulletDamageType] = 1.3;
$DamageScale[armorfSprint, $PlasmaDamageType] = 1.0;
$DamageScale[armorfSprint, $EnergyDamageType] = 1.0;
$DamageScale[armorfSprint, $ExplosionDamageType] = 1.0;
$DamageScale[armorfSprint, $MissileDamageType] = 1.0;
$DamageScale[armorfSprint, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfSprint, $ShotgunDamageType] = 1.3;
$DamageScale[armorfSprint, $DebrisDamageType] = 1.0;
$DamageScale[armorfSprint, $LaserDamageType] = 1.0;
$DamageScale[armorfSprint, $MortarDamageType] = 1.0;
$DamageScale[armorfSprint, $BlasterDamageType] = 1.0;
$DamageScale[armorfSprint, $ElectricityDamageType] = 1.0; //line 700
$DamageScale[armorfSprint, $MineDamageType] = 1.2;
$DamageScale[armorfSprint, $SniperDamageType] = 1.0;
$DamageScale[armorfSprint, $FlashDamageType] = 1.0;
$DamageScale[armorfSprint, $KamikazeDamageType] = 3.0;
$DamageScale[armorfSprint, $IonDamageType] = 1.0;
$DamageScale[armorfSprint, $FusionDamageType] = 1.0;
//
$VehicleUse[armorfSprint, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, HAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, FusionMarker] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Runner] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Scorcher] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Scrambler] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Mini] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Bouncer] = $CanPilot | $CanRide;

function PopulateItemMax(%item, %PA, %mDM, %fDM, %mSC, %fSC, %mSP, %fSP, %mSN, %fSN, %mME, %fME, %mEN, %fEN, %mBU, %fBU, %mAL, %fAL, %CY, %mLO, %fLO, %mST, %fST)
{
  $ItemMax[armorPenis, %item] = %PA;
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
  $ItemMax[armormLoader, %item] = %mLO;
  $ItemMax[armorfLoader, %item] = %fLO; 
  $ItemMax[armormSprint, %item] = %mST;
  $ItemMax[armorfSprint, %item] = %fST; 
}

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
 // WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- // line 600
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(FlareGun,          0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(SoundRipper,       0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(CloakGun,          0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TractorDevice,     0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1,   0,   0);
PopulateItemMax(Fixit,             0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(TargetingLaser,    0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(ClusterBomb,       0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Breaker,           0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Mortar,            0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(RocketLauncher,    0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(QuadRocket,        0,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,  10,   0,   0,   5,   5);
PopulateItemMax(MassCannon,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(FireMortar,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(DiskHammer,        0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(EnergyDisk,        0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Sword,             0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   1,   1,   0,   0);
PopulateItemMax(IonRocket,         0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(Plas,              0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Blaster,           0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(Bolt,              0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0);
PopulateItemMax(Chaingun,          0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(Disclauncher,      0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   1,   1);
PopulateItemMax(EnergyRifle,       0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(Flamer,            0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(GrenadeLauncher,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(HyperB,            0,   1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(IonGun,            0,   1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(LaserRifle,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Omega,             0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(PlasmaGun,         0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   1,   1);
PopulateItemMax(Railgun,           0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Silencer,          0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperRifle,       0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TranqGun,          0,   1,   1,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(Vulcan,            0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(WaveGun,           0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   0,   0,   0,   0);
PopulateItemMax(HyperLaser,        0,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(DeathLaser,        0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0);
PopulateItemMax(Shotgun,           0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   0,   0,   1,   1);
PopulateItemMax(ELF,               0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(DiskBolt,          0,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,  10,  10,  10,  10,   5,   5,  10,   5,   5,   5,   5);
PopulateItemMax(QRL,               0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Volter,            0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(MineLauncher,      0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(ClusterBomb,       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(Clay,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(IonDisk,           0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(AlienLaser,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(Pistol,            0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(FlareAmmo,         0,   0,   0,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2);
PopulateItemMax(SoundAmmo,         0,   0,   0,   0,   0,  10,  10,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10,  10,  15,  15);
PopulateItemMax(BulletAmmo,        0, 150, 150, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 150, 150, 150, 100, 100);
PopulateItemMax(DiscAmmo,          0,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  30,  30,  15,  15,  15,  15,  15,  15,  15);
PopulateItemMax(GrenadeAmmo,       0,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  20,  20,  10,  10,  15,  15,  15,  10,  10);
PopulateItemMax(MortarAmmo,        0,   5,   5,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,   5,   5,  10,  10,  10,  10,  10,   5,   5);
PopulateItemMax(PlasmaAmmo,        0,  40,  40,  30,  30,  30,  30,  30,  30,  40,  40,  40,  40,  50,  50,  40,  40,  50,  50,  50,  20,  20);
PopulateItemMax(RailAmmo,          0,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,   5,   5);
PopulateItemMax(RocketAmmo,        0,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,  10,  10,   5,   5,  10,  10,  10,   5,   5);
PopulateItemMax(SilencerAmmo,      0,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  20,  20,  10,  10);
PopulateItemMax(SniperAmmo,        0,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  10,  10,   5,   5);
PopulateItemMax(TranqAmmo,         0,  10,  10,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  10,  10);
PopulateItemMax(VulcanAmmo,        0, 150, 150, 100, 100, 100, 100, 100, 100, 150, 150, 150, 150, 150, 150, 150, 150, 300, 300, 300,  50,  50);
PopulateItemMax(MassCAmmo,         0,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,  15,   8,   8,  15,  15,  20,  20,  20,   5,   5);
PopulateItemMax(ShotgunAmmo,       0,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  20,  20,  20,  20,  20,  20,  30,  20,  20,  10,  10); 
PopulateItemMax(MinelAmmo,         0,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   8,   8,   5,   5,   5,   5,   5,   5,   5);
PopulateItemMax(BreakerAmmo,       0,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   5,   8,   5,   5,   5,   5);
PopulateItemMax(ClusterShell,      0,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   3,   2,   2,   1,   1);
PopulateItemMax(ClayAmmo,          0,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   2,   3,   3,   2,   2,   5,   2,   2,   2,   2); // line 800
PopulateItemMax(CycloneBolt,       0,  20,  20,  20,  20,  20,  20,  20,  20,  30,  30,  40,  40,  50,  50,  20,  20,  60,  20,  20,   5,   5);
PopulateItemMax(PistolAmmo,        0,  50,  50,   0,   0,  50,  50,  50,  50,  50,  50,   0,   0,  50,  50,   0,   0,  50,   0,   0,   0,   0);
PopulateItemMax(PlasAmmo,          0,  10,  10,   0,   0,   0,   0,   0,   0,  10,  10,   0,   0,  10,  10,   0,   0,  15,   0,   0,   0,   0);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-  
 // MISC           
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-     
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Beacon,            0,   1,   1,   3,   3,   3,   3,   1,   1,   3,   3,   1,   1,   4,   4,   3,   3,   3,   2,   2,   2,   2);  
PopulateItemMax(Grenade,           0,   5,   5,   5,   5,   3,   3,   3,   3,   6,   6,   6,   6,   6,   6,   5,   5,   3,   0,   0,   5,   5);
PopulateItemMax(MineAmmo,          0,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   6,   6,   3,   3,   5,   4,   4,   2,   2);
PopulateItemMax(RepairKit,         0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(BoosterMine,       0,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   5,   5,   3,   3,   6,   3,   3,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-  
 // PACKS  
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Penis,             1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(WienerPack,        0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(KamikazePack,	     0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(AmmoPack,          0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(EnergyPack,        0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RepairPack,        0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(SensorJammerPack,  0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   1,   1);
PopulateItemMax(WeinerPack,        0,   1,   0,   1,   0,   1,   0,   1,   0,   1,   0,   1,   0,   1,   0,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(EnergizerPack,     0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(HammerPack,        0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   0,   0,   0,   0);
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE SENSORS  
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Beacon,		     0,   5,   5,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3);
PopulateItemMax(DeployableTarget,  0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(BaseAlarm,	     0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(CameraPack,        0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(DeployableSensorJammerPack,  0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MotionSensorPack,  0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PulseSensorPack,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(TripMine,  	     0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   0,   0);
PopulateItemMax(FlameTurretPack,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(FlakPack,          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(AGravPack,         0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(HGravTurretPack,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(IonTurretPack,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DeployableAmmoPack,0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(BlastWallPack,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);  
PopulateItemMax(ForceFieldPack,    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(LargeForceFieldPack,    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(PlatformPack,      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(AcceleratorDevicePack,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(MannequinPack,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(DeployableComPack, 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(DeployableInvPack, 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(SpringPack,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(TeleportPack,      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(TreePack,          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(DoorPack,          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(LargeAirPlatPack,  0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(AirPlatformPack,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(airbase,           0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(BunkerPack,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(LargeDoorPack,     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(DoorPack,          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TARGETING SYSTEMS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                               PA, mDM, fDM, mSC, fSC, mSP, fSP, mSN, fSN, mME, fME, mEN, fEN, mBU, fBU, mAL, fAL,  CY, mLO, fLO, mST, fST
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---    
PopulateItemMax(TargetMarkLaser,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(PhotonPack,        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(TrackerMissilePack,0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0,   0,   0);
PopulateItemMax(TrackerMissileAmmo,0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15,   0,   0,   0,   0);



 // "Base" armor
$ItemMax[armormSniper, HGravTurretPack] = 0; // Light 
$ItemMax[armorfSniper, HGravTurretPack] = 0; 
$ItemMax[armormMercenary, HGravTurretPack] = 0; // Medium 
$ItemMax[armorfMercenary, HGravTurretPack] = 0; 
$ItemMax[harmor, HGravTurretPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, HGravTurretPack] = 0;
$ItemMax[armormScout, HGravTurretPack] = 0; // Scout
$ItemMax[armorfScout, HGravTurretPack] = 0; 
$ItemMax[armormSpy, HGravTurretPack] = 0; // Spy
$ItemMax[armorfSpy, HGravTurretPack] = 0; 
$ItemMax[armormBurster, HGravTurretPack] = 0; // Burster
$ItemMax[armorfBurster, HGravTurretPack] = 0; 
$ItemMax[armormEngineer, HGravTurretPack] = 0; // Engineer
$ItemMax[armorfEngineer, HGravTurretPack] = 0; 
$ItemMax[armormAlien, HGravTurretPack] = 0; // Alien
$ItemMax[armorfAlien, HGravTurretPack] = 0; 
$ItemMax[armorCyborg, HGravTurretPack] = 0; // Cyborg
$ItemMax[armormLoader, HGravTurretPack] = 1; // Loader
$ItemMax[armorfLoader, HGravTurretPack] = 1;
$ItemMax[armormSprint, HGravTurretPack] = 0; //Sprint
$ItemMax[armorfSprint, HGravTurretPack] = 0;

$ItemMax[dmarmor, BaseAlarm] = 0; // Deathmatch
$ItemMax[dmfemale, BaseAlarm] = 0;

 // "Base" armor
$ItemMax[armormSniper, BaseAlarm] = 0; // Light 
$ItemMax[armorfSniper, BaseAlarm] = 0; 
$ItemMax[armormMercenary, BaseAlarm] = 0; // Medium 
$ItemMax[armorfMercenary, BaseAlarm] = 0; 
$ItemMax[harmor, BaseAlarm] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, BaseAlarm] = 0;
$ItemMax[armormScout, BaseAlarm] = 0; // Scout
$ItemMax[armorfScout, BaseAlarm] = 0; 
$ItemMax[armormSpy, BaseAlarm] = 0; // Spy
$ItemMax[armorfSpy, BaseAlarm] = 0; 
$ItemMax[armormBurster, BaseAlarm] = 0; // Burster
$ItemMax[armorfBurster, BaseAlarm] = 0; 
$ItemMax[armormEngineer, BaseAlarm] = 0; // Engineer
$ItemMax[armorfEngineer, BaseAlarm] = 0; 
$ItemMax[armormAlien, BaseAlarm] = 0; // Alien
$ItemMax[armorfAlien, BaseAlarm] = 0; 
$ItemMax[armorCyborg, BaseAlarm] = 0; // Cyborg
$ItemMax[armormLoader, BaseAlarm] = 1; // Loader
$ItemMax[armorfLoader, BaseAlarm] = 1;
$ItemMax[armormSprint, BaseAlarm] = 0; //Sprint
$ItemMax[armorfSprint, BaseAlarm] = 0;

$ItemMax[dmarmor, BaseAlarm] = 0; // Deathmatch
$ItemMax[dmfemale, BaseAlarm] = 0;


 // "Base" armor
$ItemMax[armormSniper, AcceleratorDevicePack] = 0; // Light 
$ItemMax[armorfSniper, AcceleratorDevicePack] = 0; 
$ItemMax[armormMercenary, AcceleratorDevicePack] = 0; // Medium 
$ItemMax[armorfMercenary, AcceleratorDevicePack] = 0; 
$ItemMax[harmor, AcceleratorDevicePack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, AcceleratorDevicePack] = 0;
$ItemMax[armormScout, AcceleratorDevicePack] = 0; // Scout
$ItemMax[armorfScout, AcceleratorDevicePack] = 0; 
$ItemMax[armormSpy, AcceleratorDevicePack] = 0; // Spy
$ItemMax[armorfSpy, AcceleratorDevicePack] = 0; 
$ItemMax[armormBurster, AcceleratorDevicePack] = 0; // Burster
$ItemMax[armorfBurster, AcceleratorDevicePack] = 0; 
$ItemMax[armormEngineer, AcceleratorDevicePack] = 0; // Engineer
$ItemMax[armorfEngineer, AcceleratorDevicePack] = 0; 
$ItemMax[armormAlien, AcceleratorDevicePack] = 0; // Alien
$ItemMax[armorfAlien, AcceleratorDevicePack] = 0; 
$ItemMax[armorCyborg, AcceleratorDevicePack] = 0; // Cyborg
$ItemMax[armormLoader, AcceleratorDevicePack] = 1; // Loader
$ItemMax[armorfLoader, AcceleratorDevicePack] = 1;
$ItemMax[armormSprint, AcceleratorDevicePack] = 0; //Sprint
$ItemMax[armorfSprint, AcceleratorDevicePack] = 0;

$ItemMax[dmarmor, AcceleratorDevicePack] = 0; // Deathmatch
$ItemMax[dmfemale, AcceleratorDevicePack] = 0;

 // "Base" armor
$ItemMax[armormSniper, BlastWallPack] = 0; // Light 
$ItemMax[armorfSniper, BlastWallPack] = 0; 
$ItemMax[armormMercenary, BlastWallPack] = 0; // Medium 
$ItemMax[armorfMercenary, BlastWallPack] = 0; 
$ItemMax[harmor, BlastWallPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, BlastWallPack] = 0;
$ItemMax[armormScout, BlastWallPack] = 0; // Scout
$ItemMax[armorfScout, BlastWallPack] = 0; 
$ItemMax[armormSpy, BlastWallPack] = 0; // Spy
$ItemMax[armorfSpy, BlastWallPack] = 0; 
$ItemMax[armormBurster, BlastWallPack] = 0; // Burster
$ItemMax[armorfBurster, BlastWallPack] = 0; 
$ItemMax[armormEngineer, BlastWallPack] = 0; // Engineer
$ItemMax[armorfEngineer, BlastWallPack] = 0; 
$ItemMax[armormAlien, BlastWallPack] = 0; // Alien
$ItemMax[armorfAlien, BlastWallPack] = 0; 
$ItemMax[armorCyborg, BlastWallPack] = 0; // Cyborg
$ItemMax[armormLoader, BlastWallPack] = 1; // Loader
$ItemMax[armorfLoader, BlastWallPack] = 1;
$ItemMax[armormSprint, BlastWallPack] = 0; // Sprint
$ItemMax[armorfSprint, BlastWallPack] = 0;

$ItemMax[dmarmor, BlastWallPack] = 0; // Deathmatch
$ItemMax[dmfemale, BlastWallPack] = 0;


 
 // "Base" armor
$ItemMax[armormSniper, ForceFieldPack] = 1; // Light 
$ItemMax[armorfSniper, ForceFieldPack] = 1; 
$ItemMax[armormMercenary, ForceFieldPack] = 1; // Medium 
$ItemMax[armorfMercenary, ForceFieldPack] = 1; 
$ItemMax[harmor, ForceFieldPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, ForceFieldPack] = 0; 
$ItemMax[armormScout, ForceFieldPack] = 1; // Scout
$ItemMax[armorfScout, ForceFieldPack] = 1; 
$ItemMax[armormSpy, ForceFieldPack] = 1; // Spy
$ItemMax[armorfSpy, ForceFieldPack] = 1; 
$ItemMax[armormBurster, ForceFieldPack] = 1; // Burster
$ItemMax[armorfBurster, ForceFieldPack] = 1; 
$ItemMax[armormEngineer, ForceFieldPack] = 0; // Engineer
$ItemMax[armorfEngineer, ForceFieldPack] = 0; 
$ItemMax[armormAlien, ForceFieldPack] = 1; // Alien
$ItemMax[armorfAlien, ForceFieldPack] = 1; 
$ItemMax[armorCyborg, ForceFieldPack] = 1; // Cyborg
$ItemMax[armormLoader, ForceFieldPack] = 1; // Loader
$ItemMax[armorfLoader, ForceFieldPack] = 1;
$ItemMax[armormSprint, ForceFieldPack] = 0; // Sprint 
$ItemMax[armorfSprint, ForceFieldPack] = 0;

$ItemMax[dmarmor, ForceFieldPack] = 1; // Deathmatch
$ItemMax[dmfemale, ForceFieldPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, LargeForceFieldPack] = 0; // Light 
$ItemMax[armorfSniper, LargeForceFieldPack] = 0; 
$ItemMax[armormMercenary, LargeForceFieldPack] = 0; // Medium 
$ItemMax[armorfMercenary, LargeForceFieldPack] = 0; 
$ItemMax[harmor, LargeForceFieldPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, LargeForceFieldPack] = 0; 
$ItemMax[armormScout, LargeForceFieldPack] = 0; // Scout
$ItemMax[armorfScout, LargeForceFieldPack] = 0; 
$ItemMax[armormSpy, LargeForceFieldPack] = 0; // Spy
$ItemMax[armorfSpy, LargeForceFieldPack] = 0; 
$ItemMax[armormBurster, LargeForceFieldPack] = 0; // Burster
$ItemMax[armorfBurster, LargeForceFieldPack] = 0; 
$ItemMax[armormEngineer, LargeForceFieldPack] = 0; // Engineer
$ItemMax[armorfEngineer, LargeForceFieldPack] = 0; 
$ItemMax[armormAlien, LargeForceFieldPack] = 0; // Alien
$ItemMax[armorfAlien, LargeForceFieldPack] = 0; 
$ItemMax[armorCyborg, LargeForceFieldPack] = 1; // Cyborg
$ItemMax[armormLoader, LargeForceFieldPack] = 1; // Loader
$ItemMax[armorfLoader, LargeForceFieldPack] = 1;
$ItemMax[armormSprint, LargeForceFieldPack] = 0; // Sprint 
$ItemMax[armorfSprint, LargeForceFieldPack] = 0;

$ItemMax[dmarmor, LargeForceFieldPack] = 0; // Deathmatch
$ItemMax[dmfemale, LargeForceFieldPack] = 0;

 // "Base" armor
$ItemMax[armormSniper, MannequinPack] = 1; // Light 
$ItemMax[armorfSniper, MannequinPack] = 1; 
$ItemMax[armormMercenary, MannequinPack] = 1; // Medium 
$ItemMax[armorfMercenary, MannequinPack] = 1; 
$ItemMax[harmor, MannequinPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, MannequinPack] = 0; 
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
$ItemMax[armormLoader, MannequinPack] = 1; // Loader
$ItemMax[armorfLoader, MannequinPack] = 1;
$ItemMax[armormSprint, MannequinPack] = 1; // Sprint
$ItemMax[armorfSprint, MannequinPack] = 1;

$ItemMax[dmarmor, MannequinPack] = 1; // Deathmatch
$ItemMax[dmfemale, MannequinPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, PlatformPack] = 0; // Light 
$ItemMax[armorfSniper, PlatformPack] = 0; 
$ItemMax[armormMercenary, PlatformPack] = 0; // Medium 
$ItemMax[armorfMercenary, PlatformPack] = 0; 
$ItemMax[harmor, PlatformPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, PlatformPack] = 0; 
$ItemMax[armormScout, PlatformPack] = 0; // Scout
$ItemMax[armorfScout, PlatformPack] = 0; 
$ItemMax[armormSpy, PlatformPack] = 0; // Spy
$ItemMax[armorfSpy, PlatformPack] = 0; 
$ItemMax[armormBurster, PlatformPack] = 0; // Burster
$ItemMax[armorfBurster, PlatformPack] = 0; 
$ItemMax[armormEngineer, PlatformPack] = 0; // Engineer
$ItemMax[armorfEngineer, PlatformPack] = 0; 
$ItemMax[armormAlien, PlatformPack] = 0; // Alien
$ItemMax[armorfAlien, PlatformPack] = 0; 
$ItemMax[armorCyborg, PlatformPack] = 0; // Cyborg
$ItemMax[armormLoader, PlatformPack] = 1; // Loader
$ItemMax[armorfLoader, PlatformPack] = 1;
$ItemMax[armormSprint, PlatformPack] = 1; // Sprint
$ItemMax[armorfSprint, PlatformPack] = 1;

$ItemMax[dmarmor, AcceleratorDevicePack] = 1; // Deathmatch
$ItemMax[dmfemale, AcceleratorDevicePack] = 1;

 // "Base" armor
$ItemMax[armormSniper, DeployableComPack] = 0; // Light 
$ItemMax[armorfSniper, DeployableComPack] = 0; 
$ItemMax[armormMercenary, DeployableComPack] = 0; // Medium 
$ItemMax[armorfMercenary, DeployableComPack] = 0; 
$ItemMax[harmor, DeployableComPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, DeployableComPack] = 0; 
$ItemMax[armormScout, DeployableComPack] = 0; // Scout
$ItemMax[armorfScout, DeployableComPack] = 0; 
$ItemMax[armormSpy, DeployableComPack] = 0; // Spy
$ItemMax[armorfSpy, DeployableComPack] = 0; 
$ItemMax[armormBurster, DeployableComPack] = 0; // Burster
$ItemMax[armorfBurster, DeployableComPack] = 0; 
$ItemMax[armormEngineer, DeployableComPack] = 0; // Engineer
$ItemMax[armorfEngineer, DeployableComPack] = 0; 
$ItemMax[armormAlien, DeployableComPack] = 0; // Alien
$ItemMax[armorfAlien, DeployableComPack] = 0; 
$ItemMax[armorCyborg, DeployableComPack] = 1; // Cyborg
$ItemMax[armormLoader, DeployableComPack] = 1; // Loader
$ItemMax[armorfLoader, DeployableComPack] = 1;
$ItemMax[armormSprint, DeployableComPack] = 0;
$ItemMax[armorfSprint, DeployableComPack] = 0;

$ItemMax[dmarmor, DeployableComPack] = 0; // Deathmatch
$ItemMax[dmfemale, DeployableComPack] = 0;

 // "Base" armor
$ItemMax[armormSniper, DeployableInvPack] = 0; // Light 
$ItemMax[armorfSniper, DeployableInvPack] = 0; 
$ItemMax[armormMercenary, DeployableInvPack] = 0; // Medium 
$ItemMax[armorfMercenary, DeployableInvPack] = 0; 
$ItemMax[harmor, DeployableInvPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, DeployableInvPack] = 0; 
$ItemMax[armormScout, DeployableInvPack] = 0; // Scout
$ItemMax[armorfScout, DeployableInvPack] = 0; 
$ItemMax[armormSpy, DeployableInvPack] = 0; // Spy
$ItemMax[armorfSpy, DeployableInvPack] = 0; 
$ItemMax[armormBurster, DeployableInvPack] = 0; // Burster
$ItemMax[armorfBurster, DeployableInvPack] = 0; 
$ItemMax[armormEngineer, DeployableInvPack] = 0; // Engineer
$ItemMax[armorfEngineer, DeployableInvPack] = 0; 
$ItemMax[armormAlien, DeployableInvPack] = 0; // Alien
$ItemMax[armorfAlien, DeployableInvPack] = 0; 
$ItemMax[armorCyborg, DeployableInvPack] = 0; // Cyborg
$ItemMax[armormLoader, DeployableInvPack] = 1; // Loader
$ItemMax[armorfLoader, DeployableInvPack] = 1;
$ItemMax[armormSprint, DeployableInvPack] = 0;
$ItemMax[armorfSprint, DeployableInvPack] = 0;

$ItemMax[dmarmor, DeployableInvPack] = 1; // Deathmatch
$ItemMax[dmfemale, DeployableInvPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, SpringPack] = 0; // Light 
$ItemMax[armorfSniper, SpringPack] = 0; 
$ItemMax[armormMercenary, SpringPack] = 0; // Medium 
$ItemMax[armorfMercenary, SpringPack] = 0; 
$ItemMax[harmor, SpringPack] = 0; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, SpringPack] = 0; 
$ItemMax[armormScout, SpringPack] = 0; // Scout
$ItemMax[armorfScout, SpringPack] = 0; 
$ItemMax[armormSpy, SpringPack] = 0; // Spy
$ItemMax[armorfSpy, SpringPack] = 0; 
$ItemMax[armormBurster, SpringPack] = 0; // Burster
$ItemMax[armorfBurster, SpringPack] = 0; 
$ItemMax[armormEngineer, SpringPack] = 0; // Engineer
$ItemMax[armorfEngineer, SpringPack] = 0; 
$ItemMax[armormAlien, SpringPack] = 0; // Alien
$ItemMax[armorfAlien, SpringPack] = 0; 
$ItemMax[armorCyborg, SpringPack] = 0; // Cyborg
$ItemMax[armormLoader, SpringPack] = 1; // Loader
$ItemMax[armorfLoader, SpringPack] = 1;
$ItemMax[armormSprint, SpringPack] = 0;
$ItemMax[armorfSprint, SpringPack] = 0;

$ItemMax[dmarmor, SpringPack] = 1; // Deathmatch
$ItemMax[dmfemale, SpringPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, TeleportPack] = 0; // Light 
$ItemMax[armorfSniper, TeleportPack] = 0; 
$ItemMax[armormMercenary, TeleportPack] = 0; // Medium 
$ItemMax[armorfMercenary, TeleportPack] = 0; 
$ItemMax[harmor, TeleportPack] = 1; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, TeleportPack] = 0; 
$ItemMax[armormScout, TeleportPack] = 0; // Scout
$ItemMax[armorfScout, TeleportPack] = 0; 
$ItemMax[armormSpy, TeleportPack] = 0; // Spy
$ItemMax[armorfSpy, TeleportPack] = 0; 
$ItemMax[armormBurster, TeleportPack] = 0; // Burster
$ItemMax[armorfBurster, TeleportPack] = 0; 
$ItemMax[armormEngineer, TeleportPack] = 0; // Engineer
$ItemMax[armorfEngineer, TeleportPack] = 0; 
$ItemMax[armormAlien, TeleportPack] = 0; // Alien
$ItemMax[armorfAlien, TeleportPack] = 0; 
$ItemMax[armorCyborg, TeleportPack] = 0; // Cyborg
$ItemMax[armormLoader, TeleportPack] = 1; // Loader
$ItemMax[armorfLoader, TeleportPack] = 1;
$ItemMax[armormSprint, TeleportPack] = 0;
$ItemMax[armorfSprint, TeleportPack] = 0;

$ItemMax[dmarmor, TeleportPack] = 1; // Deathmatch
$ItemMax[dmfemale, TeleportPack] = 1;

 // "Base" armor
$ItemMax[armormSniper, TreePack] = 1; // Light 
$ItemMax[armorfSniper, TreePack] = 1; 
$ItemMax[armormMercenary, TreePack] = 0; // Medium 
$ItemMax[armorfMercenary, TreePack] = 0; 
$ItemMax[harmor, TreePack] = 0; // Heavy 

 // "XKmod" armor
$ItemMax[armorPenis, TreePack] = 0; 
$ItemMax[armormScout, TreePack] = 0; // Scout
$ItemMax[armorfScout, TreePack] = 0; 
$ItemMax[armormSpy, TreePack] = 0; // Spy
$ItemMax[armorfSpy, TreePack] = 0; 
$ItemMax[armormSniper, TreePack] = 1; // Sniper
$ItemMax[armorfSniper, TreePack] = 1;
$ItemMax[armormBurster, TreePack] = 0; // Burster
$ItemMax[armorfBurster, TreePack] = 0; 
$ItemMax[armormEngineer, TreePack] = 1; // Engineer
$ItemMax[armorfEngineer, TreePack] = 1; 
$ItemMax[armormMercenary, TreePack] = 1; // Mercenary
$ItemMax[armorfMercenary, TreePack] = 1;
$ItemMax[armormAlien, TreePack] = 0; // Alien
$ItemMax[armorfAlien, TreePack] = 0; 
$ItemMax[armorCyborg, TreePack] = 0; // Cyborg
$ItemMax[armormLoader, TreePack] = 1; // Loader
$ItemMax[armorfLoader, TreePack] = 1;
$ItemMax[armormSprint, TreePack] = 1; 
$ItemMax[armorfSprint, TreePack] = 1;

$ItemMax[dmarmor, TreePack] = 0; // Deathmatch
$ItemMax[dmfemale, TreePack] = 0;

$ItemMax[armormSniper, MechPack] = 0; 
$ItemMax[armormMercenary, MechPack] = 0; 
$ItemMax[harmor, MechPack] = 0; 
$ItemMax[armorfSniper, MechPack] = 0; 
$ItemMax[armorfMercenary, MechPack] = 0; 
$ItemMax[armorPenis, MechPack] = 0; 
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
$ItemMax[armormSprint, MechPack] = 0;
$ItemMax[armorfSprint, MechPack] = 0;

$ItemMax[armormMercenary, DetPack] = 0; 
$ItemMax[armormSniper, DetPack] = 0; 
$ItemMax[harmor, DetPack] = 0; 
$ItemMax[armorfSniper, DetPack] = 0; 
$ItemMax[armorfMercenary, DetPack] = 0; 
$ItemMax[armorPenis, DetPack] = 0; 
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
$ItemMax[armormSprint, DetPack] = 0;
$ItemMax[armorfSprint, DetPack] = 0;

 // "Base" armor
$ItemMax[armormSniper, PackOMen] = 1; // Light 
$ItemMax[armorfSniper, PackOMen] = 1; 
$ItemMax[armormMercenary, PackOMen] = 1; // Medium 
$ItemMax[armorfMercenary, PackOMen] = 1; 
$ItemMax[harmor, PackOMen] = 1; // Heavy 

// TargetMarkLaser
$ItemMax[armorPenis, TargetMarkLaser] = 0; // Scout
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
$ItemMax[armorPenis, PhotonPack] = 0; // Scout
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
$ItemMax[armorPenis, TrackerMissilePack] = 0; // Scout
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
$ItemMax[armorPenis, TrackerMissileAmmo] = 5; // Scout
$ItemMax[armormScout, TrackerMissileAmmo] = 5; // Scout
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
$ItemMax[armorCyborg, TrackerMissileAmmo] = 15; // Cyborg

$ItemMax[dmarmor, TrackerMissileAmmo] = 0; // Deathmatch
$ItemMax[dmfemale, TrackerMissileAmmo] = 0;

// Tracker Missile Pack
$ItemMax[armorPenis, TreePack] = 0; // Penis
$ItemMax[armormScout, TreePack] = 1; // Scout
$ItemMax[armorfScout, TreePack] = 1; 
$ItemMax[armormSpy, TreePack] = 1; // Spy
$ItemMax[armorfSpy, TreePack] = 1; 
$ItemMax[armormBurster, TreePack] = 1; // Burster
$ItemMax[armorfBurster, TreePack] = 1; 
$ItemMax[armormEngineer, TreePack] = 1; // Engineer
$ItemMax[armorfEngineer, TreePack] = 1; 
$ItemMax[armormAlien, TreePack] = 1; // Alien
$ItemMax[armorfAlien, TreePack] = 1; 
$ItemMax[armorCyborg, TreePack] = 1; // Cyborg

$ItemMax[dmarmor, TreePack] = 1; // Deathmatch
$ItemMax[dmfemale, TreePack] = 1;

// Tractor Device
$ItemMax[armorPenis, TractorDevice] = 0; // Penis
$ItemMax[armormScout, TractorDevice] = 0; // Scout
$ItemMax[armorfScout, TractorDevice] = 0; 
$ItemMax[armormSpy, TractorDevice] = 0; // Spy
$ItemMax[armorfSpy, TractorDevice] = 0; 
$ItemMax[armormBurster, TractorDevice] = 1; // Burster
$ItemMax[armorfBurster, TractorDevice] = 1; 
$ItemMax[armormEngineer, TractorDevice] = 1; // Engineer
$ItemMax[armorfEngineer, TractorDevice] = 1; 
$ItemMax[armormAlien, TractorDevice] = 0; // Alien
$ItemMax[armorfAlien, TractorDevice] = 0; 
$ItemMax[armorCyborg, TractorDevice] = 1;// Cyborg
$ItemMax[armormSprint, TractorDevice] = 0;
$ItemMax[armorfSprint, TractorDevice] = 0;

$ItemMax[dmarmor, TractorDevice] = 0; // Deathmatch
$ItemMax[dmfemale, TractorDevice] = 0;

// Kamikaze Pack
$ItemMax[armorPenis, KamikazePack] = 0; // Penis
$ItemMax[armormScout, KamikazePack] = 0; // Scout
$ItemMax[armorfScout, KamikazePack] = 0; 
$ItemMax[armormSpy, KamikazePack] = 1; // Spy
$ItemMax[armorfSpy, KamikazePack] = 1; 
$ItemMax[armormBurster, KamikazePack] = 1; // Burster
$ItemMax[armorfBurster, KamikazePack] = 1; 
$ItemMax[armormEngineer, KamikazePack] = 1; // Engineer
$ItemMax[armorfEngineer, KamikazePack] = 1; 
$ItemMax[armormMercenary, KamikazePack] = 1; //Mercenary
$ItemMax[armorfMercenary, KamikazePack] = 1;
$ItemMax[armormAlien, KamikazePack] = 0; // Alien
$ItemMax[armorfAlien, KamikazePack] = 0; 
$ItemMax[armorCyborg, KamikazePack] = 0;// Cyborg
$ItemMax[armormSprint, KamikazePack] = 0;
$ItemMax[armorfSprint, KamikazePack] = 0;

$ItemMax[dmarmor, KamikazePack] = 0; // Deathmatch
$ItemMax[dmfemale, KamikazePack] = 0;

// Tracker Missile Pack
$ItemMax[armorPenis, DeployableTarget] = 1; // Penis
$ItemMax[armormScout, DeployableTarget] = 1; // Scout
$ItemMax[armorfScout, DeployableTarget] = 1; 
$ItemMax[armormSpy, DeployableTarget] = 1; // Spy
$ItemMax[armorfSpy, DeployableTarget] = 1; 
$ItemMax[armormBurster, DeployableTarget] = 1; // Burster
$ItemMax[armorfBurster, DeployableTarget] = 1; 
$ItemMax[armormEngineer, DeployableTarget] = 1; // Engineer
$ItemMax[armorfEngineer, DeployableTarget] = 1; 
$ItemMax[armormAlien, DeployableTarget] = 1; // Alien
$ItemMax[armorfAlien, DeployableTarget] = 1; 
$ItemMax[armorCyborg, DeployableTarget] = 1; // Cyborg

$ItemMax[dmarmor, DeployableTarget] = 1; // Deathmatch
$ItemMax[dmfemale, DeployableTarget] = 1;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TEAM ITEM MAXs
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$TeamItemMax[kamikaze] = 5;
$TeamItemMax[TripMine] = 3;
$TeamItemMax[HGravTurretPack] = 3;
$TeamItemMax[IonTurretPack] = 5;
$TeamItemMax[LaserTurretPack] = 5;
$TeamItemMax[RocketPack] = 5;
$TeamItemMax[MortarTurretPack] = 5;
$TeamItemMax[PlasmaTurretPack] = 5;
$TeamItemMax[RailTurretPack] = 3;
$TeamItemMax[SatchelPack] = 10;
$TeamItemMax[ShockTurretPack] = 3;
$TeamItemMax[VulcanTurretPack] = 3;
$TeamItemMax[DeployableFlameTurret] = 5;
$TeamItemMax[DeployableTarget] = 3;
$TeamItemMax[BaseAlarm] = 10;
$TeamItemMax[AcceleratorDevice] = 4;
$TeamItemMax[BlastWallPack] = 100; 
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[ForceFieldPack] = 6; 
$TeamItemMax[LargeForceFieldPack] = 6; 
$TeamItemMax[Mannequin] = 40;
$TeamItemMax[MotionSensorPack] = 20;
$TeamItemMax[PlatformPack] = 100; 
$TeamItemMax[PulseSensorPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 5;
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableComPack] = 10; 
$TeamItemMax[DeployableInvPack] = 20; 
$TeamItemMax[Springboard] = 10;
$TeamItemMax[TreePack] = 10;
$TeamItemMax[airbase] = 2;