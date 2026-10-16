
$CanPilot = 1;
$CanRide = 2;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // ARMOR 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Light Male Armor 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormBaseLight] = 3;
$DamageScale[armormBaseLight, $LandingDamageType] = 1.0;
$DamageScale[armormBaseLight, $ImpactDamageType] = 1.0;
$DamageScale[armormBaseLight, $CrushDamageType] = 1.0;
$DamageScale[armormBaseLight, $BulletDamageType] = 1.2;
$DamageScale[armormBaseLight, $PlasmaDamageType] = 1.0;
$DamageScale[armormBaseLight, $EnergyDamageType] = 1.3;
$DamageScale[armormBaseLight, $ExplosionDamageType] = 1.0;
$DamageScale[armormBaseLight, $MissileDamageType] = 1.0;
$DamageScale[armormBaseLight, $DebrisDamageType] = 1.2;
$DamageScale[armormBaseLight, $ShrapnelDamageType] = 1.2;
$DamageScale[armormBaseLight, $LaserDamageType] = 1.0;
$DamageScale[armormBaseLight, $MortarDamageType] = 1.3;
$DamageScale[armormBaseLight, $BlasterDamageType] = 1.3;
$DamageScale[armormBaseLight, $ElectricityDamageType] = 1.0;
$DamageScale[armormBaseLight, $MineDamageType] = 1.2;
 //
$VehicleUse[armormBaseLight, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormBaseLight, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormBaseLight, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormBaseLight, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormBaseLight, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Light Female Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfBaseLight] = 3;
$DamageScale[armorfBaseLight, $LandingDamageType] = 1.0;
$DamageScale[armorfBaseLight, $ImpactDamageType] = 1.0;
$DamageScale[armorfBaseLight, $CrushDamageType] = 1.0;
$DamageScale[armorfBaseLight, $BulletDamageType] = 1.2;
$DamageScale[armorfBaseLight, $PlasmaDamageType] = 1.0;
$DamageScale[armorfBaseLight, $EnergyDamageType] = 1.3;
$DamageScale[armorfBaseLight, $ExplosionDamageType] = 1.0;
$DamageScale[armorfBaseLight, $MissileDamageType] = 1.0;
$DamageScale[armorfBaseLight, $ShrapnelDamageType] = 1.2;
$DamageScale[armorfBaseLight, $DebrisDamageType] = 1.2;
$DamageScale[armorfBaseLight, $LaserDamageType] = 1.0;
$DamageScale[armorfBaseLight, $MortarDamageType] = 1.3;
$DamageScale[armorfBaseLight, $BlasterDamageType] = 1.3;
$DamageScale[armorfBaseLight, $ElectricityDamageType] = 1.0;
$DamageScale[armorfBaseLight, $MineDamageType] = 1.2;
 //
$VehicleUse[armorfBaseLight, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfBaseLight, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfBaseLight, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfBaseLight, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfBaseLight, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Medium Male Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormBaseMedium] = 4;
$DamageScale[armormBaseMedium, $LandingDamageType] = 1.0;
$DamageScale[armormBaseMedium, $ImpactDamageType] = 1.0;
$DamageScale[armormBaseMedium, $CrushDamageType] = 1.0;
$DamageScale[armormBaseMedium, $BulletDamageType] = 1.0;
$DamageScale[armormBaseMedium, $PlasmaDamageType] = 0.6;
$DamageScale[armormBaseMedium, $EnergyDamageType] = 1.0;
$DamageScale[armormBaseMedium, $ExplosionDamageType] = 1.0;
$DamageScale[armormBaseMedium, $MissileDamageType] = 1.0;
$DamageScale[armormBaseMedium, $ShrapnelDamageType] = 1.0;
$DamageScale[armormBaseMedium, $DebrisDamageType] = 1.0;
$DamageScale[armormBaseMedium, $LaserDamageType] = 1.0;
$DamageScale[armormBaseMedium, $MortarDamageType] = 1.0;
$DamageScale[armormBaseMedium, $BlasterDamageType] = 1.0;
$DamageScale[armormBaseMedium, $ElectricityDamageType] = 1.0;
$DamageScale[armormBaseMedium, $MineDamageType] = 1.0;
 //
$VehicleUse[armormBaseMedium, Wraith] = $CanRide;
$VehicleUse[armormBaseMedium, Interceptor] = $CanRide;
$VehicleUse[armormBaseMedium, Scout] = $CanRide;
$VehicleUse[armormBaseMedium, LAPC] = $CanRide;
$VehicleUse[armormBaseMedium, HAPC] = $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Medium Female Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfBaseMedium] = 4;
$DamageScale[armorfBaseMedium, $LandingDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $ImpactDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $CrushDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $BulletDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $EnergyDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $PlasmaDamageType] = 0.6;
$DamageScale[armorfBaseMedium, $ExplosionDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $MissileDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $DebrisDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $LaserDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $MortarDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $BlasterDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $ElectricityDamageType] = 1.0;
$DamageScale[armorfBaseMedium, $MineDamageType] = 1.0;
 //
$VehicleUse[armorfBaseMedium, Wraith] = $CanRide;
$VehicleUse[armorfBaseMedium, Interceptor] = $CanRide;
$VehicleUse[armorfBaseMedium, Scout] = $CanRide;
$VehicleUse[armorfBaseMedium, LAPC] = $CanRide;
$VehicleUse[armorfBaseMedium, HAPC] = $CanRide;


 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Heavy Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorBaseHeavy] = 5;
$DamageScale[armorBaseHeavy, $LandingDamageType] = 1.0;
$DamageScale[armorBaseHeavy, $ImpactDamageType] = 1.0;
$DamageScale[armorBaseHeavy, $CrushDamageType] = 1.0;
$DamageScale[armorBaseHeavy, $BulletDamageType] = 0.6;
$DamageScale[armorBaseHeavy, $PlasmaDamageType] = 0.4;
$DamageScale[armorBaseHeavy, $EnergyDamageType] = 0.7;
$DamageScale[armorBaseHeavy, $ExplosionDamageType] = 0.6;
$DamageScale[armorBaseHeavy, $MissileDamageType] = 0.6;
$DamageScale[armorBaseHeavy, $DebrisDamageType] = 0.8;
$DamageScale[armorBaseHeavy, $ShrapnelDamageType] = 0.8;
$DamageScale[armorBaseHeavy, $LaserDamageType] = 0.6;
$DamageScale[armorBaseHeavy, $MortarDamageType] = 0.7;
$DamageScale[armorBaseHeavy, $BlasterDamageType] = 0.7;
$DamageScale[armorBaseHeavy, $ElectricityDamageType] = 1.0;
$DamageScale[armorBaseHeavy, $MineDamageType] = 0.8;
 //
$VehicleUse[armormBaseHeavy, Wraith] = $CanRide;
$VehicleUse[armormBaseHeavy, Interceptor] = $CanRide;
$VehicleUse[armormBaseHeavy, Scout] = $CanRide;
$VehicleUse[armormBaseHeavy, LAPC] = $CanRide;
$VehicleUse[armormBaseHeavy, HAPC] = $CanRide;

function PopulateItemMax(%item, %mLI, %fLI, %mME, %fME, %HE)
{
  $ItemMax[armormBaseLight, %item] = %mLI;
  $ItemMax[armorfBaseLight, %item] = %fLI;
  $ItemMax[armormBaseMedium, %item] = %mME;
  $ItemMax[armorfBaseMedium, %item] = %fME;
  $ItemMax[armorBaseHeavy, %item] = %HE;
}

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mLI, fLI, mME, fME,  HE
 //                              ---  ---  ---  ---  ---
PopulateItemMax(Blaster,           1,   1,   1,   1,   1);
PopulateItemMax(Chaingun,          1,   1,   1,   1,   1);
PopulateItemMax(BulletAmmo,      100, 100, 150, 150, 200);
PopulateItemMax(DiscLauncher,      1,   1,   1,   1,   1);
PopulateItemMax(DiscAmmo,         15,  15,  15,  15,  15);
PopulateItemMax(EnergyRifle,       1,   1,   1,   1,   1);
PopulateItemMax(GrenadeLauncher,   1,   1,   1,   1,   1);
PopulateItemMax(GrenadeAmmo,      10,  10,  10,  10,  15);
PopulateItemMax(LaserRifle,        1,   1,   0,   0,   0);
PopulateItemMax(Mortar,            0,   0,   0,   0,   1);
PopulateItemMax(MortarAmmo,       10,  10,  10,  10,  10);
PopulateItemMax(PlasmaAmmo,       30,  30,  40,  40,  50);
PopulateItemMax(PlasmaGun,         1,   1,   1,   1,   1);
PopulateItemMax(TargetingLaser,    1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // MISC 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
PopulateItemMax(Beacon,            3,   3,   3,   3,   3);
PopulateItemMax(Grenade,           5,   5,   6,   6,   8);
PopulateItemMax(MineAmmo,          3,   3,   3,   3,   3);
PopulateItemMax(RepairKit,         1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // PACKS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
PopulateItemMax(AmmoPack,          1,   1,   1,   1,   1);
PopulateItemMax(EnergyPack,        1,   1,   1,   1,   1);
PopulateItemMax(RepairPack,        1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE SENSORS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
PopulateItemMax(CameraPack,         1,   1,   1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack, 1,  1,  1,  1,  1);
PopulateItemMax(MotionSensorPack,  1,   1,   1,   1,   1);
PopulateItemMax(PulseSensorPack,   1,   1,   1,   1,   1);
PopulateItemMax(SensorJammerPack,  1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
PopulateItemMax(TurretPack,         0,   0,   0,   0,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
PopulateItemMax(DeployableInvPack,  0,   0,   1,   1,   1);
PopulateItemMax(DeployableAmmoPack, 0,   0,   1,   1,   1);



