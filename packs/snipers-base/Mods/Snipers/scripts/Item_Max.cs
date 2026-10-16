exec(Item_Weapons);
exec(Item_MiscWeapons);
exec(Item_Deployables);
exec(Item_DeployableSensors);
exec(Item_DeployableTurrets);
exec(Item_DeployableMisc);
exec(Item_DeployablePlatforms);
exec(Item_Packs);
exec(Item_Misc);

//----------------------------------------------------------------------
//
//	POPULATE ITEM MAX
//
//----------------------------------------------------------------------
$CanPilot = 1;
$CanRide = 2;

//----------------------------------------------------------------------------
// Penis Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[Pmale] = 0;
$DamageScale[Pmale, $LandingDamageType] = 1.0;
$DamageScale[Pmale, $ImpactDamageType] = 1.0;
$DamageScale[Pmale, $CrushDamageType] = 1.0;
$DamageScale[Pmale, $ShotgunDamageType] = 1.2;
$DamageScale[Pmale, $PlasmaDamageType] = 1.0;
$DamageScale[Pmale, $EnergyDamageType] = 1.3;
$DamageScale[Pmale, $ExplosionDamageType] = 1.0;
$DamageScale[Pmale, $MissileDamageType] = 1.0;
$DamageScale[Pmale, $DebrisDamageType] = 1.2;
$DamageScale[Pmale, $ShrapnelDamageType] = 1.2;
$DamageScale[Pmale, $LaserDamageType] = 1.0;
$DamageScale[Pmale, $MortarDamageType] = 1.3;
$DamageScale[Pmale, $BlasterDamageType] = 1.3;
$DamageScale[Pmale, $ElectricityDamageType] = 1.0;
$DamageScale[Pmale, $MineDamageType] = 1.2;
$DamageScale[Pmale, $PoisonDamageType] = 1.0;
$DamageScale[Pmale, $FlashDamageType] = 1.0;
$DamageScale[Pmale, $BlindDamageType] = 1.0;
$DamageScale[Pmale, $PlasmaDamageType] = 1.0;
$DamageScale[Pmale, $KamikazeDamageType] = 1.0;
$DamageScale[Pmale, $MeleeDamageType] = 1.0;
$DamageScale[Pmale, $IceDamageType] = 1.0;
//
$VehicleUse[Pmale, Scout] = $CanRide;
$VehicleUse[Pmale, Interceptor] = $CanRide;
$VehicleUse[Pmale, Wraith] = $CanRide;
$VehicleUse[Pmale, LAPC] = $CanRide;
$VehicleUse[Pmale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Penis Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[Pfemale] = 0;
$DamageScale[Pfemale, $LandingDamageType] = 1.0;
$DamageScale[Pfemale, $ImpactDamageType] = 1.0;	
$DamageScale[Pfemale, $CrushDamageType] = 1.0;	
$DamageScale[Pfemale, $ShotgunDamageType] = 1.2;
$DamageScale[Pfemale, $PlasmaDamageType] = 1.0;
$DamageScale[Pfemale, $EnergyDamageType] = 1.3;
$DamageScale[Pfemale, $ExplosionDamageType] = 1.0;
$DamageScale[Pfemale, $MissileDamageType] = 1.0;
$DamageScale[Pfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[Pfemale, $DebrisDamageType] = 1.2;
$DamageScale[Pfemale, $LaserDamageType] = 1.0;
$DamageScale[Pfemale, $MortarDamageType] = 1.3;
$DamageScale[Pfemale, $BlasterDamageType] = 1.3;
$DamageScale[Pfemale, $ElectricityDamageType] = 1.0;
$DamageScale[Pfemale, $MineDamageType] = 1.2;
$DamageScale[Pfemale, $PoisonDamageType] = 1.0;
$DamageScale[Pfemale, $FlashDamageType] = 1.0;
$DamageScale[Pfemale, $BlindDamageType] = 1.0;
$DamageScale[Pfemale, $PlasmaDamageType] = 1.0;
$DamageScale[Pfemale, $KamikazeDamageType] = 1.0;
$DamageScale[Pfemale, $MeleeDamageType] = 1.0;
$DamageScale[Pfemale, $IceDamageType] = 1.0;
//
$VehicleUse[Pfemale, Scout] = $CanRide;
$VehicleUse[Pfemale, Interceptor] = $CanRide;
$VehicleUse[Pfemale, Wraith] = $CanRide;
$VehicleUse[Pfemale, LAPC] = $CanRide;
$VehicleUse[Pfemale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// DM Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[DMmale] = 5;
$DamageScale[DMmale, $LandingDamageType] = 1.0;
$DamageScale[DMmale, $ImpactDamageType] = 1.0;
$DamageScale[DMmale, $CrushDamageType] = 1.0;
$DamageScale[DMmale, $ShotgunDamageType] = 1.2;
$DamageScale[DMmale, $PlasmaDamageType] = 1.0;
$DamageScale[DMmale, $EnergyDamageType] = 1.3;
$DamageScale[DMmale, $ExplosionDamageType] = 1.0;
$DamageScale[DMmale, $MissileDamageType] = 1.0;
$DamageScale[DMmale, $DebrisDamageType] = 1.2;
$DamageScale[DMmale, $ShrapnelDamageType] = 1.2;
$DamageScale[DMmale, $LaserDamageType] = 1.0;
$DamageScale[DMmale, $MortarDamageType] = 1.3;
$DamageScale[DMmale, $BlasterDamageType] = 1.3;
$DamageScale[DMmale, $ElectricityDamageType] = 1.0;
$DamageScale[DMmale, $MineDamageType] = 1.2;
$DamageScale[DMmale, $PoisonDamageType] = 1.0;
$DamageScale[DMmale, $FlashDamageType] = 1.0;
$DamageScale[DMmale, $BlindDamageType] = 1.0;
$DamageScale[DMmale, $PlasmaDamageType] = 1.0;
$DamageScale[DMmale, $KamikazeDamageType] = 1.0;
$DamageScale[DMmale, $MeleeDamageType] = 1.0;
$DamageScale[DMmale, $IceDamageType] = 1.0;
//
$VehicleUse[DMmale, Scout] = $CanRide;
$VehicleUse[DMmale, Interceptor] = $CanRide;
$VehicleUse[DMmale, Wraith] = $CanRide;
$VehicleUse[DMmale, LAPC] = $CanRide;
$VehicleUse[DMmale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// DM Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[DMfemale] = 5;
$DamageScale[DMfemale, $LandingDamageType] = 1.0;
$DamageScale[DMfemale, $ImpactDamageType] = 1.0;	
$DamageScale[DMfemale, $CrushDamageType] = 1.0;	
$DamageScale[DMfemale, $ShotgunDamageType] = 1.2;
$DamageScale[DMfemale, $PlasmaDamageType] = 1.0;
$DamageScale[DMfemale, $EnergyDamageType] = 1.3;
$DamageScale[DMfemale, $ExplosionDamageType] = 1.0;
$DamageScale[DMfemale, $MissileDamageType] = 1.0;
$DamageScale[DMfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[DMfemale, $DebrisDamageType] = 1.2;
$DamageScale[DMfemale, $LaserDamageType] = 1.0;
$DamageScale[DMfemale, $MortarDamageType] = 1.3;
$DamageScale[DMfemale, $BlasterDamageType] = 1.3;
$DamageScale[DMfemale, $ElectricityDamageType] = 1.0;
$DamageScale[DMfemale, $MineDamageType] = 1.2;
$DamageScale[DMfemale, $PoisonDamageType] = 1.0;
$DamageScale[DMfemale, $FlashDamageType] = 1.0;
$DamageScale[DMfemale, $BlindDamageType] = 1.0;
$DamageScale[DMfemale, $PlasmaDamageType] = 1.0;
$DamageScale[DMfemale, $KamikazeDamageType] = 1.0;
$DamageScale[DMfemale, $MeleeDamageType] = 1.0;
$DamageScale[DMfemale, $IceDamageType] = 1.0;
//
$VehicleUse[DMfemale, Scout] = $CanRide;
$VehicleUse[DMfemale, Interceptor] = $CanRide;
$VehicleUse[DMfemale, Wraith] = $CanRide;
$VehicleUse[DMfemale, LAPC] = $CanRide;
$VehicleUse[DMfemale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Flight Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[farmor] = 3;
$DamageScale[farmor, $LandingDamageType] = 1.0;
$DamageScale[farmor, $ImpactDamageType] = 1.0;
$DamageScale[farmor, $CrushDamageType] = 1.0;
$DamageScale[farmor, $ShotgunDamageType] = 1.2;
$DamageScale[farmor, $PlasmaDamageType] = 1.0;
$DamageScale[farmor, $EnergyDamageType] = 1.3;
$DamageScale[farmor, $ExplosionDamageType] = 1.0;
$DamageScale[farmor, $MissileDamageType] = 1.0;
$DamageScale[farmor, $DebrisDamageType] = 1.2;
$DamageScale[farmor, $ShrapnelDamageType] = 1.2;
$DamageScale[farmor, $LaserDamageType] = 1.0;
$DamageScale[farmor, $MortarDamageType] = 1.3;
$DamageScale[farmor, $BlasterDamageType] = 1.3;
$DamageScale[farmor, $ElectricityDamageType] = 1.0;
$DamageScale[farmor, $MineDamageType] = 1.2;
$DamageScale[farmor, $PoisonDamageType] = 1.0;
$DamageScale[farmor, $FlashDamageType] = 1.0;
$DamageScale[farmor, $BlindDamageType] = 1.0;
$DamageScale[farmor, $PlasmaDamageType] = 1.0;
$DamageScale[farmor, $KamikazeDamageType] = 1.0;
$DamageScale[farmor, $MeleeDamageType] = 1.0;
$DamageScale[farmor, $IceDamageType] = 1.0;
//
$VehicleUse[farmor, Scout] = $CanRide;
$VehicleUse[farmor, Interceptor] = $CanRide;
$VehicleUse[farmor, Wraith] = $CanRide;
$VehicleUse[farmor, LAPC] = $CanRide;
$VehicleUse[farmor, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Engineer Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[Earmor] = 4;
$DamageScale[Earmor, $LandingDamageType] = 1.0;
$DamageScale[Earmor, $ImpactDamageType] = 1.0;
$DamageScale[Earmor, $CrushDamageType] = 1.0;
$DamageScale[Earmor, $ShotgunDamageType] = 1.2;
$DamageScale[Earmor, $PlasmaDamageType] = 1.0;
$DamageScale[Earmor, $EnergyDamageType] = 1.3;
$DamageScale[Earmor, $ExplosionDamageType] = 1.0;
$DamageScale[Earmor, $MissileDamageType] = 1.0;
$DamageScale[Earmor, $DebrisDamageType] = 1.2;
$DamageScale[Earmor, $ShrapnelDamageType] = 1.2;
$DamageScale[Earmor, $LaserDamageType] = 1.0;
$DamageScale[Earmor, $MortarDamageType] = 1.3;
$DamageScale[Earmor, $BlasterDamageType] = 1.3;
$DamageScale[Earmor, $ElectricityDamageType] = 1.0;
$DamageScale[Earmor, $MineDamageType] = 1.2;
$DamageScale[Earmor, $PoisonDamageType] = 1.0;
$DamageScale[Earmor, $FlashDamageType] = 1.0;
$DamageScale[Earmor, $BlindDamageType] = 1.0;
$DamageScale[Earmor, $PlasmaDamageType] = 1.0;
$DamageScale[Earmor, $KamikazeDamageType] = 1.0;
$DamageScale[Earmor, $MeleeDamageType] = 1.0;
$DamageScale[Earmor, $IceDamageType] = 1.0;
//
$VehicleUse[Earmor, Scout] = $CanRide;
$VehicleUse[Earmor, Interceptor] = $CanRide;
$VehicleUse[Earmor, Wraith] = $CanRide;
$VehicleUse[Earmor, LAPC] = $CanRide;
$VehicleUse[Earmor, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Engineer Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[Efemale] = 4;
$DamageScale[Efemale, $LandingDamageType] = 1.0;
$DamageScale[Efemale, $ImpactDamageType] = 1.0;	
$DamageScale[Efemale, $CrushDamageType] = 1.0;	
$DamageScale[Efemale, $ShotgunDamageType] = 1.2;
$DamageScale[Efemale, $PlasmaDamageType] = 1.0;
$DamageScale[Efemale, $EnergyDamageType] = 1.3;
$DamageScale[Efemale, $ExplosionDamageType] = 1.0;
$DamageScale[Efemale, $MissileDamageType] = 1.0;
$DamageScale[Efemale, $ShrapnelDamageType] = 1.2;
$DamageScale[Efemale, $DebrisDamageType] = 1.2;
$DamageScale[Efemale, $LaserDamageType] = 1.0;
$DamageScale[Efemale, $MortarDamageType] = 1.3;
$DamageScale[Efemale, $BlasterDamageType] = 1.3;
$DamageScale[Efemale, $ElectricityDamageType] = 1.0;
$DamageScale[Efemale, $MineDamageType] = 1.2;
$DamageScale[Efemale, $PoisonDamageType] = 1.0;
$DamageScale[Efemale, $FlashDamageType] = 1.0;
$DamageScale[Efemale, $BlindDamageType] = 1.0;
$DamageScale[Efemale, $PlasmaDamageType] = 1.0;
$DamageScale[Efemale, $KamikazeDamageType] = 1.0;
$DamageScale[Efemale, $MeleeDamageType] = 1.0;
$DamageScale[Efemale, $IceDamageType] = 1.0;
//
$VehicleUse[Efemale, Scout] = $CanRide;
$VehicleUse[Efemale, Interceptor] = $CanRide;
$VehicleUse[Efemale, Wraith] = $CanRide;
$VehicleUse[Efemale, LAPC] = $CanRide;
$VehicleUse[Efemale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Flight Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[farmor] = 3;
$DamageScale[farmor, $LandingDamageType] = 1.0;
$DamageScale[farmor, $ImpactDamageType] = 1.0;
$DamageScale[farmor, $CrushDamageType] = 1.0;
$DamageScale[farmor, $ShotgunDamageType] = 1.2;
$DamageScale[farmor, $PlasmaDamageType] = 1.0;
$DamageScale[farmor, $EnergyDamageType] = 1.3;
$DamageScale[farmor, $ExplosionDamageType] = 1.0;
$DamageScale[farmor, $MissileDamageType] = 1.0;
$DamageScale[farmor, $DebrisDamageType] = 1.2;
$DamageScale[farmor, $ShrapnelDamageType] = 1.2;
$DamageScale[farmor, $LaserDamageType] = 1.0;
$DamageScale[farmor, $MortarDamageType] = 1.3;
$DamageScale[farmor, $BlasterDamageType] = 1.3;
$DamageScale[farmor, $ElectricityDamageType] = 1.0;
$DamageScale[farmor, $MineDamageType] = 1.2;
$DamageScale[farmor, $PoisonDamageType] = 1.0;
$DamageScale[farmor, $FlashDamageType] = 1.0;
$DamageScale[farmor, $BlindDamageType] = 1.0;
$DamageScale[farmor, $PlasmaDamageType] = 1.0;
$DamageScale[farmor, $KamikazeDamageType] = 1.0;
$DamageScale[farmor, $MeleeDamageType] = 1.0;
$DamageScale[farmor, $IceDamageType] = 1.0;
//
$VehicleUse[farmor, Scout] = $CanRide;
$VehicleUse[farmor, Interceptor] = $CanRide;
$VehicleUse[farmor, Wraith] = $CanRide;
$VehicleUse[farmor, LAPC] = $CanRide;
$VehicleUse[farmor, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Flight Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[ffemale] = 3;
$DamageScale[ffemale, $LandingDamageType] = 1.0;
$DamageScale[ffemale, $ImpactDamageType] = 1.0;	
$DamageScale[ffemale, $CrushDamageType] = 1.0;	
$DamageScale[ffemale, $ShotgunDamageType] = 1.2;
$DamageScale[ffemale, $PlasmaDamageType] = 1.0;
$DamageScale[ffemale, $EnergyDamageType] = 1.3;
$DamageScale[ffemale, $ExplosionDamageType] = 1.0;
$DamageScale[ffemale, $MissileDamageType] = 1.0;
$DamageScale[ffemale, $ShrapnelDamageType] = 1.2;
$DamageScale[ffemale, $DebrisDamageType] = 1.2;
$DamageScale[ffemale, $LaserDamageType] = 1.0;
$DamageScale[ffemale, $MortarDamageType] = 1.3;
$DamageScale[ffemale, $BlasterDamageType] = 1.3;
$DamageScale[ffemale, $ElectricityDamageType] = 1.0;
$DamageScale[ffemale, $MineDamageType] = 1.2;
$DamageScale[ffemale, $PoisonDamageType] = 1.0;
$DamageScale[ffemale, $FlashDamageType] = 1.0;
$DamageScale[ffemale, $BlindDamageType] = 1.0;
$DamageScale[ffemale, $PlasmaDamageType] = 1.0;
$DamageScale[ffemale, $KamikazeDamageType] = 1.0;
$DamageScale[ffemale, $MeleeDamageType] = 1.0;
$DamageScale[ffemale, $IceDamageType] = 1.0;
//
$VehicleUse[ffemale, Scout] = $CanRide;
$VehicleUse[ffemale, Interceptor] = $CanRide;
$VehicleUse[ffemale, Wraith] = $CanRide;
$VehicleUse[ffemale, LAPC] = $CanRide;
$VehicleUse[ffemale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Light Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[larmor] = 3;
$DamageScale[larmor, $LandingDamageType] = 1.0;
$DamageScale[larmor, $ImpactDamageType] = 1.0;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $ShotgunDamageType] = 1.2;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $EnergyDamageType] = 1.3;
$DamageScale[larmor, $ExplosionDamageType] = 1.0;
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $DebrisDamageType] = 1.2;
$DamageScale[larmor, $ShrapnelDamageType] = 1.2;
$DamageScale[larmor, $LaserDamageType] = 1.0;
$DamageScale[larmor, $MortarDamageType] = 1.3;
$DamageScale[larmor, $BlasterDamageType] = 1.3;
$DamageScale[larmor, $ElectricityDamageType] = 1.0;
$DamageScale[larmor, $MineDamageType] = 1.2;
$DamageScale[larmor, $PoisonDamageType] = 1.0;
$DamageScale[larmor, $FlashDamageType] = 1.0;
$DamageScale[larmor, $BlindDamageType] = 1.0;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $KamikazeDamageType] = 1.0;
$DamageScale[larmor, $MeleeDamageType] = 1.0;
$DamageScale[larmor, $IceDamageType] = 1.0;
//
$VehicleUse[larmor, Scout] = $CanPilot | $CanRide;
$VehicleUse[larmor, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[larmor, Wraith] = $CanPilot | $CanRide;
$VehicleUse[larmor, LAPC] = $CanPilot | $CanRide;
$VehicleUse[larmor, HAPC] = $CanPilot | $CanRide;

//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[lfemale] = 3;
$DamageScale[lfemale, $LandingDamageType] = 1.0;
$DamageScale[lfemale, $ImpactDamageType] = 1.0;	
$DamageScale[lfemale, $CrushDamageType] = 1.0;	
$DamageScale[lfemale, $ShotgunDamageType] = 1.2;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $EnergyDamageType] = 1.3;
$DamageScale[lfemale, $ExplosionDamageType] = 1.0;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[lfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[lfemale, $DebrisDamageType] = 1.2;
$DamageScale[lfemale, $LaserDamageType] = 1.0;
$DamageScale[lfemale, $MortarDamageType] = 1.3;
$DamageScale[lfemale, $BlasterDamageType] = 1.3;
$DamageScale[lfemale, $ElectricityDamageType] = 1.0;
$DamageScale[lfemale, $MineDamageType] = 1.2;
$DamageScale[lfemale, $PoisonDamageType] = 1.0;
$DamageScale[lfemale, $FlashDamageType] = 1.0;
$DamageScale[lfemale, $BlindDamageType] = 1.0;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $KamikazeDamageType] = 1.0;
$DamageScale[lfemale, $MeleeDamageType] = 1.0;
$DamageScale[lfemale, $IceDamageType] = 1.0;
//
$VehicleUse[lfemale, Scout] = $CanPilot | $CanRide;
$VehicleUse[lfemale, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[lfemale, Wraith] = $CanPilot | $CanRide;
$VehicleUse[lfemale, LAPC] = $CanPilot | $CanRide;
$VehicleUse[lfemale, HAPC] = $CanPilot | $CanRide;

//----------------------------------------------------------------------------
// Medium Male Armor
//----------------------------------------------------------------------------
$MaxWeapons[marmor] = 4;
$DamageScale[marmor, $LandingDamageType] = 1.0;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $ShotgunDamageType] = 1.0;
$DamageScale[marmor, $PlasmaDamageType] = 0.6;
$DamageScale[marmor, $EnergyDamageType] = 1.0;
$DamageScale[marmor, $ExplosionDamageType] = 1.0;
$DamageScale[marmor, $MissileDamageType] = 1.0;
$DamageScale[marmor, $ShrapnelDamageType] = 1.0;
$DamageScale[marmor, $DebrisDamageType] = 1.0;
$DamageScale[marmor, $LaserDamageType] = 1.0;
$DamageScale[marmor, $MortarDamageType] = 1.0;
$DamageScale[marmor, $BlasterDamageType] = 1.0;
$DamageScale[marmor, $ElectricityDamageType] = 1.0;
$DamageScale[marmor, $MineDamageType] = 1.0;
$DamageScale[marmor, $PoisonDamageType] = 1.0;
$DamageScale[marmor, $FlashDamageType] = 1.0;
$DamageScale[marmor, $BlindDamageType] = 1.0;
$DamageScale[marmor, $PlasmaDamageType] = 1.0;
$DamageScale[marmor, $KamikazeDamageType] = 1.0;
$DamageScale[marmor, $MeleeDamageType] = 1.0;
$DamageScale[marmor, $IceDamageType] = 1.0;
//
$VehicleUse[marmor, Scout] = $CanRide;
$VehicleUse[marmor, Interceptor] = $CanRide;
$VehicleUse[marmor, Wraith] = $CanRide;
$VehicleUse[marmor, LAPC] = $CanRide;
$VehicleUse[marmor, HAPC] = $CanRide;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$MaxWeapons[mfemale] = 4;
$DamageScale[mfemale, $LandingDamageType] = 1.0;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $ShotgunDamageType] = 1.0;
$DamageScale[mfemale, $EnergyDamageType] = 1.0;
$DamageScale[mfemale, $PlasmaDamageType] = 0.6;
$DamageScale[mfemale, $ExplosionDamageType] = 1.0;
$DamageScale[mfemale, $MissileDamageType] = 1.0;
$DamageScale[mfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[mfemale, $DebrisDamageType] = 1.0;
$DamageScale[mfemale, $LaserDamageType] = 1.0;
$DamageScale[mfemale, $MortarDamageType] = 1.0;
$DamageScale[mfemale, $BlasterDamageType] = 1.0;
$DamageScale[mfemale, $ElectricityDamageType] = 1.0;
$DamageScale[mfemale, $MineDamageType] = 1.0;
$DamageScale[mfemale, $PoisonDamageType] = 1.0;
$DamageScale[mfemale, $FlashDamageType] = 1.0;
$DamageScale[mfemale, $BlindDamageType] = 1.0;
$DamageScale[mfemale, $PlasmaDamageType] = 1.0;
$DamageScale[mfemale, $KamikazeDamageType] = 1.0;
$DamageScale[mfemale, $MeleeDamageType] = 1.0;
$DamageScale[mfemale, $IceDamageType] = 1.0;
//
$VehicleUse[mfemale, Scout] = $CanRide;
$VehicleUse[mfemale, Interceptor] = $CanRide;
$VehicleUse[mfemale, Wraith] = $CanRide;
$VehicleUse[mfemale, LAPC] = $CanRide;
$VehicleUse[mfemale, HAPC] = $CanRide;

//----------------------------------------------------------------------------
//	POPULATE
//----------------------------------------------------------------------------
function PopulateItemMax(%item, %Pm, %Pf, %DMm, %DMf, %mE, %fE, %mf, %ff, %mL, %fL, %mM, %fM)
{
	$ItemMax[Pmale, %item] = %Pm;
	$ItemMax[Pfemale, %item] = %Pf;
	$ItemMax[DMmale, %item] = %DMm;
	$ItemMax[DMfemale, %item] = %DMf;
	$ItemMax[Earmor, %item] = %mE;
	$ItemMax[Efemale, $item] = %fE;
	$ItemMax[farmor, %item] = %mf;
	$ItemMax[ffemale, $item] = %ff;
	$ItemMax[larmor, %item] = %mL;
	$ItemMax[lfemale, %item] = %fL;
	$ItemMax[marmor, %item] = %mM;
	$ItemMax[mfemale, %item] = %fM;
}

//---------------------------------------------------
//	WEAPONS & AMMO
//---------------------------------------------------
//                                Pm,  Pf, DMm, DMf,  mE,  fE,  mf,  ff,  mL,  fL,  mM,  fM
//                               ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Shotgun,	     0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(ShotgunAmmo,	     0,   0,  10,  10,  10,  10,  10,  10,   0,   0,  10,  10);
PopulateItemMax(Railgun,	     0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(RailAmmo,	     0,   0,  10,  10,   0,   0,   0,   0,   0,   0,   8,   8);
PopulateItemMax(SniperRifle,	     0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0);
PopulateItemMax(SniperAmmo,	     0,   0,  15,  15,   0,   0,   8,   8,  15,  15,   0,   0);
PopulateItemMax(LaserRifle,	     0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0);
PopulateItemMax(AlienLaser,	     0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(HCRifle,	     0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(HCAmmo,		     0,   0,   0,   0,   5,   5,   5,   5,   0,   0,   5,   5);
PopulateItemMax(TranqGun,	     0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(TranqAmmo,	     0,   0,  10,  10,  10,  10,   5,   5,  10,  10,   0,   0);
PopulateItemMax(HyperLaser,	     0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   1);
PopulateItemMax(ELF,    	     0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(FlameRifle,        0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(FlameAmmo,         0,   0,  10,  10,   0,   0,   0,   0,   0,   0,  10,  10);
PopulateItemMax(ShockRifle,        0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(BoosterCharge,     0,   0, 200, 200,   0,   0,   0,   0,   0,   0, 200, 200);
PopulateItemMax(HvyThruster,       0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(MedThruster,       0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(RocketBooster,     0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(CuttingLaser,      0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(Repeater,          0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(RepeaterAmmo,      0,   0,  10,  10,   0,   0,   0,   0,   0,   0,  10,  10);

//---------------------------------------------------
//	MISC WEAPONS
//---------------------------------------------------
//                                Pm,  Pf, DMm, DMf,  mE,  fE,  mf,  ff,  mL,  fL,  mM,  fM
//                               ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(TargetingLaser,    0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RepairRifle,       0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(CloakGun,	     0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(AntiGrav,   	     0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(TractorDevice,     0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(JailGun,           0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(HHRepairGun,       0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0);

//---------------------------------------------------
//	MISC
//---------------------------------------------------
//                                Pm,  Pf, DMm, DMf,  mE,  fE,  mf,  ff,  mL,  fL,  mM,  fM
//                               ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MineAmmo,          0,   0,   0,   0,   4,   4,   3,   3,   3,   3,   3,   3);
PopulateItemMax(Grenade,           0,   0,   5,   5,   4,   4,   5,   5,   3,   3,   3,   3);
PopulateItemMax(Beacon,            0,   0,   3,   3,   3,   3,   2,   2,   3,   3,   3,   3);
PopulateItemMax(RepairKit,         0,   0,   1,   1,   2,   2,   1,   1,   1,   1,   1,   1);
PopulateItemMax(Smoker,            0,   0,   3,   0,   0,   0,   3,   3,   0,   0,   3,   3);

//---------------------------------------------------
//	PACKS
//---------------------------------------------------
//                                Pm,  Pf, DMm, DMf,  mE,  fE,  mf,  ff,  mL,  fL,  mM,  fM
//                               ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(TreePack,          0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   1,   1);
PopulateItemMax(EnergyPack,        0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RepairPack,        0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   1,   1);
PopulateItemMax(SensorJammerPack,  0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(AmmoPack,          0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1);
PopulateItemMax(LaserPack,         0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(LightningPack,     0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(AntiGravPack,      0,   0,   1,   1,   1,   1,   0,   0,   1,   1,   1,   1);
PopulateItemMax(FakeFlag,          0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1);
PopulateItemMax(CommPack,          0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(KamikazePack,      0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0);
PopulateItemMax(SuicidePack,       0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(Laptop,            0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1);

//---------------------------------------------------
//	DEPLOYABLES
//---------------------------------------------------
//                                Pm,  Pf, DMm, DMf,  mE,  fE,  mf,  ff,  mL,  fL,  mM,  fM
//                               ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MotionSensorPack,  0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PulseSensorPack,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableSensorJammerPack,  0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(CameraPack,        0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(TurretPack,        0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableInvPack, 0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableAmmoPack,0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(BaseAlarm,         0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(WatchdogPack,      0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MiniELF,           0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(RailTurret,        0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(HoloPack,          0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(JailCapPack,       0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(JailPack,          0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(IceTurretPack,     0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(HGravTurretPack,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TeleportPack,      0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(RocketPack,        0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PlatformPack,      0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PortableTree,      0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1);
PopulateItemMax(AirPlatformPack,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1);
PopulateItemMax(LargeAirPlatPack,  0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(AirPlasmaFloorPack,0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0);
PopulateItemMax(FlakPack,          0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0);

//----------------------------------------------------------------------------
// List of all items available to buy from inventory station
$InvList[TargetingLaser] = 1;
$InvList[MineAmmo] = 1;
$InvList[Grenade] = 1;
$InvList[Beacon] = 1;
$InvList[Smoker] = 3;



//----------------------------------------------------------------------------

// List of all items available to buy from Remote Station
$RemoteInvList[TargetingLaser] = 1;
$RemoteInvList[MineAmmo] = 1;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[Beacon] = 1;
$RemoteInvList[Smoker] = 3;
  


//----------------------------------------------------------------------------
// List of all items available to buy from Vehicle station
$VehicleInvList[ScoutVehicle] = 1;
$VehicleInvList[LAPCVehicle] = 1;
$VehicleInvList[HAPCVehicle] = 1;

$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;

$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;

//----------------------------------------------------------------------------
// Limit on number of special Items you can buy
$TeamItemMax[PortableTree] = 3;
$TeamItemMax[DeployableFlak] = 3;
$TeamItemMax[AirPlasmaFloorPack] = 4;
$TeamItemMax[LargeAirPlatPack] = 4;
$TeamItemMax[AirPlatformPack] = 4;
$TeamItemMax[PlatformPack] = 6;
$TeamItemMax[RocketPack] = 2;
$TeamItemMax[DeployableMissileTurret] = 2;
$TeamItemMax[DeployableRocket] = 2;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[HGravTurretPack] = 4;
$TeamItemMax[IceTurretPack] = 4;
$TeamItemMax[FakeFlag] = 5;
$TeamItemMax[jailpack] = 1;
$TeamItemMax[JailCapPack] = 5;
$TeamItemMax[HoloPack] = 10;
$TeamItemMax[HoloGram] = 10;
$TeamItemMax[RailTurret] = 5;
$TeamItemMax[TreePack] = 40;
$TeamItemMax[MiniELF] = 5;
$TeamItemMax[WatchdogPack] = 10;
$TeamItemMax[BaseAlarm] = 10;
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;

//----------------------------------------------------------------------------
function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,HCRifle,HCAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,Shotgun,ShotgunAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,HvyThruster,BoosterCharge,200);
	%cnt = %cnt + AmmoStation::resupply(%player,MedThruster,BoosterCharge,200);
	%cnt = %cnt + AmmoStation::resupply(%player,RocketBooster,BoosterCharge,200);
	%cnt = %cnt + AmmoStation::resupply(%player,Repeater,RepeaterAmmo,20);
	return %cnt;
}