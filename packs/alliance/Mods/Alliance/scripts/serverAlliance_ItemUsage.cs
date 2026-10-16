
$CanPilot = 1;
$CanRide = 2;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // ARMOR 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Deathmatch
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormDeathmatch] = 5;
$DamageScale[armormDeathmatch, $LandingDamageType] = 1.0;
$DamageScale[armormDeathmatch, $ImpactDamageType] = 1.0;
$DamageScale[armormDeathmatch, $CrushDamageType] = 1.0;
$DamageScale[armormDeathmatch, $BulletDamageType] = 1.0;
$DamageScale[armormDeathmatch, $PlasmaDamageType] = 1.0;
$DamageScale[armormDeathmatch, $EnergyDamageType] = 1.0;
$DamageScale[armormDeathmatch, $ExplosionDamageType] = 1.0;
$DamageScale[armormDeathmatch, $MissileDamageType] = 1.0;
$DamageScale[armormDeathmatch, $DebrisDamageType] = 1.0;
$DamageScale[armormDeathmatch, $ShrapnelDamageType] = 1.0;
$DamageScale[armormDeathmatch, $LaserDamageType] = 1.0;
$DamageScale[armormDeathmatch, $MortarDamageType] = 1.0;
$DamageScale[armormDeathmatch, $BlasterDamageType] = 1.0;
$DamageScale[armormDeathmatch, $ElectricityDamageType] = 1.0;
$DamageScale[armormDeathmatch, $MineDamageType] = 1.0;
$DamageScale[armormDeathmatch, $SniperDamageType] = 1.0;
$DamageScale[armormDeathmatch, $FlashDamageType] = 1.0;
 //
$VehicleUse[armormDeathmatch, Wraith] = $CanRide;
$VehicleUse[armormDeathmatch, Interceptor] = $CanRide;
$VehicleUse[armormDeathmatch, Scout] = $CanRide;
$VehicleUse[armormDeathmatch, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormDeathmatch, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Deathmatch
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfDeathmatch] = 5;
$DamageScale[armorfDeathmatch, $LandingDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $ImpactDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $CrushDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $BulletDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $PlasmaDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $EnergyDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $ExplosionDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $MissileDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $DebrisDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $LaserDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $MortarDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $BlasterDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $ElectricityDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $MineDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $SniperDamageType] = 1.0;
$DamageScale[armorfDeathmatch, $FlashDamageType] = 1.0;
 //
$VehicleUse[armorfDeathmatch, Wraith] = $CanRide;
$VehicleUse[armorfDeathmatch, Interceptor] = $CanRide;
$VehicleUse[armorfDeathmatch, Scout] = $CanRide;
$VehicleUse[armorfDeathmatch, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfDeathmatch, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Sprint Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormSprint] = 3;
$DamageScale[armormSprint, $LandingDamageType] = 0.8;
$DamageScale[armormSprint, $ImpactDamageType] = 0.8;
$DamageScale[armormSprint, $CrushDamageType] = 1.0;
$DamageScale[armormSprint, $BulletDamageType] = 1.2;
$DamageScale[armormSprint, $PlasmaDamageType] = 1.0;
$DamageScale[armormSprint, $EnergyDamageType] = 1.3;
$DamageScale[armormSprint, $ExplosionDamageType] = 1.0;
$DamageScale[armormSprint, $MissileDamageType] = 1.0;
$DamageScale[armormSprint, $DebrisDamageType] = 1.2;
$DamageScale[armormSprint, $ShrapnelDamageType] = 1.2;
$DamageScale[armormSprint, $LaserDamageType] = 1.0;
$DamageScale[armormSprint, $MortarDamageType] = 1.3;
$DamageScale[armormSprint, $BlasterDamageType] = 1.3;
$DamageScale[armormSprint, $ElectricityDamageType] = 1.0;
$DamageScale[armormSprint, $MineDamageType] = 1.2;
$DamageScale[armormSprint, $SniperDamageType] = 1.0;
$DamageScale[armormSprint, $FlashDamageType] = 1.0;
 //
$VehicleUse[armormSprint, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, Scout] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormSprint, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Sprint Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfSprint] = 3;
$DamageScale[armorfSprint, $LandingDamageType] = 0.8;
$DamageScale[armorfSprint, $ImpactDamageType] = 0.8;
$DamageScale[armorfSprint, $CrushDamageType] = 1.0;
$DamageScale[armorfSprint, $BulletDamageType] = 1.2;
$DamageScale[armorfSprint, $PlasmaDamageType] = 1.0;
$DamageScale[armorfSprint, $EnergyDamageType] = 1.3;
$DamageScale[armorfSprint, $ExplosionDamageType] = 1.0;
$DamageScale[armorfSprint, $MissileDamageType] = 1.0;
$DamageScale[armorfSprint, $DebrisDamageType] = 1.2;
$DamageScale[armorfSprint, $ShrapnelDamageType] = 1.2;
$DamageScale[armorfSprint, $LaserDamageType] = 1.0;
$DamageScale[armorfSprint, $MortarDamageType] = 1.3;
$DamageScale[armorfSprint, $BlasterDamageType] = 1.3;
$DamageScale[armorfSprint, $ElectricityDamageType] = 1.0;
$DamageScale[armorfSprint, $MineDamageType] = 1.2;
$DamageScale[armorfSprint, $SniperDamageType] = 1.0;
$DamageScale[armorfSprint, $FlashDamageType] = 1.0;
 //
$VehicleUse[armorfSprint, Wraith] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Interceptor] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, Scout] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfSprint, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Commando Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormCommando] = 4;
$DamageScale[armormCommando, $LandingDamageType] = 1.0;
$DamageScale[armormCommando, $ImpactDamageType] = 1.0;
$DamageScale[armormCommando, $CrushDamageType] = 1.0;
$DamageScale[armormCommando, $BulletDamageType] = 0.8;
$DamageScale[armormCommando, $PlasmaDamageType] = 1.0;
$DamageScale[armormCommando, $EnergyDamageType] = 1.0;
$DamageScale[armormCommando, $ExplosionDamageType] = 0.8;
$DamageScale[armormCommando, $MissileDamageType] = 0.8;
$DamageScale[armormCommando, $DebrisDamageType] = 0.8;
$DamageScale[armormCommando, $ShrapnelDamageType] = 0.8;
$DamageScale[armormCommando, $LaserDamageType] = 1.0;
$DamageScale[armormCommando, $MortarDamageType] = 1.0;
$DamageScale[armormCommando, $BlasterDamageType] = 1.0;
$DamageScale[armormCommando, $ElectricityDamageType] = 1.0;
$DamageScale[armormCommando, $MineDamageType] = 0.8;
$DamageScale[armormCommando, $SniperDamageType] = 0.8;
$DamageScale[armormCommando, $FlashDamageType] = 1.0;
 //
$VehicleUse[armormCommando, Wraith] = $CanRide;
$VehicleUse[armormCommando, Interceptor] = $CanRide;
$VehicleUse[armormCommando, Scout] = $CanRide;
$VehicleUse[armormCommando, LAPC] = $CanRide;
$VehicleUse[armormCommando, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Commando Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfCommando] = 4;
$DamageScale[armorfCommando, $LandingDamageType] = 1.0;
$DamageScale[armorfCommando, $ImpactDamageType] = 1.0;
$DamageScale[armorfCommando, $CrushDamageType] = 1.0;
$DamageScale[armorfCommando, $BulletDamageType] = 0.8;
$DamageScale[armorfCommando, $PlasmaDamageType] = 1.0;
$DamageScale[armorfCommando, $EnergyDamageType] = 1.0;
$DamageScale[armorfCommando, $ExplosionDamageType] = 0.8;
$DamageScale[armorfCommando, $MissileDamageType] = 0.8;
$DamageScale[armorfCommando, $DebrisDamageType] = 0.8;
$DamageScale[armorfCommando, $ShrapnelDamageType] = 0.8;
$DamageScale[armorfCommando, $LaserDamageType] = 1.0;
$DamageScale[armorfCommando, $MortarDamageType] = 1.0;
$DamageScale[armorfCommando, $BlasterDamageType] = 1.0;
$DamageScale[armorfCommando, $ElectricityDamageType] = 1.0;
$DamageScale[armorfCommando, $MineDamageType] = 0.8;
$DamageScale[armorfCommando, $SniperDamageType] = 0.8;
$DamageScale[armorfCommando, $FlashDamageType] = 1.0;
 //
$VehicleUse[armorfCommando, Wraith] = $CanRide;
$VehicleUse[armorfCommando, Interceptor] = $CanRide;
$VehicleUse[armorfCommando, Scout] = $CanRide;
$VehicleUse[armorfCommando, LAPC] = $CanRide;
$VehicleUse[armorfCommando, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Male Loader Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormLoader] = 2;
$DamageScale[armormLoader, $LandingDamageType] = 1.0;
$DamageScale[armormLoader, $ImpactDamageType] = 1.0;
$DamageScale[armormLoader, $CrushDamageType] = 1.0;
$DamageScale[armormLoader, $BulletDamageType] = 1.0;
$DamageScale[armormLoader, $PlasmaDamageType] = 1.0;
$DamageScale[armormLoader, $EnergyDamageType] = 0.8;
$DamageScale[armormLoader, $ExplosionDamageType] = 1.0;
$DamageScale[armormLoader, $MissileDamageType] = 1.0;
$DamageScale[armormLoader, $DebrisDamageType] = 1.0;
$DamageScale[armormLoader, $ShrapnelDamageType] = 1.0;
$DamageScale[armormLoader, $LaserDamageType] = 0.8;
$DamageScale[armormLoader, $MortarDamageType] = 1.0;
$DamageScale[armormLoader, $BlasterDamageType] = 0.8;
$DamageScale[armormLoader, $ElectricityDamageType] = 0.8;
$DamageScale[armormLoader, $MineDamageType] = 1.0;
$DamageScale[armormLoader, $SniperDamageType] = 1.0;
$DamageScale[armormLoader, $FlashDamageType] = 0.8;
 //
$VehicleUse[armormLoader, Wraith] = $CanRide;
$VehicleUse[armormLoader, Interceptor] = $CanRide;
$VehicleUse[armormLoader, Scout] = $CanRide;
$VehicleUse[armormLoader, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armormLoader, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Female Loader Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorfLoader] = 2;
$DamageScale[armorfLoader, $LandingDamageType] = 1.0;
$DamageScale[armorfLoader, $ImpactDamageType] = 1.0;
$DamageScale[armorfLoader, $CrushDamageType] = 1.0;
$DamageScale[armorfLoader, $BulletDamageType] = 1.0;
$DamageScale[armorfLoader, $PlasmaDamageType] = 1.0;
$DamageScale[armorfLoader, $EnergyDamageType] = 0.8;
$DamageScale[armorfLoader, $ExplosionDamageType] = 1.0;
$DamageScale[armorfLoader, $MissileDamageType] = 1.0;
$DamageScale[armorfLoader, $DebrisDamageType] = 1.0;
$DamageScale[armorfLoader, $ShrapnelDamageType] = 1.0;
$DamageScale[armorfLoader, $LaserDamageType] = 0.8;
$DamageScale[armorfLoader, $MortarDamageType] = 1.0;
$DamageScale[armorfLoader, $BlasterDamageType] = 0.8;
$DamageScale[armorfLoader, $ElectricityDamageType] = 0.8;
$DamageScale[armorfLoader, $MineDamageType] = 1.0;
$DamageScale[armorfLoader, $SniperDamageType] = 1.0;
$DamageScale[armorfLoader, $FlashDamageType] = 0.8;
 //
$VehicleUse[armorfLoader, Wraith] = $CanRide;
$VehicleUse[armorfLoader, Interceptor] = $CanRide;
$VehicleUse[armorfLoader, Scout] = $CanRide;
$VehicleUse[armorfLoader, LAPC] = $CanPilot | $CanRide;
$VehicleUse[armorfLoader, HAPC] = $CanPilot | $CanRide;

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // Destroyer Armor
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armorDestroyer] = 5;
$DamageScale[armorDestroyer, $LandingDamageType] = 1.2;
$DamageScale[armorDestroyer, $ImpactDamageType] = 1.2;
$DamageScale[armorDestroyer, $CrushDamageType] = 1.2;
$DamageScale[armorDestroyer, $BulletDamageType] = 1.0;
$DamageScale[armorDestroyer, $PlasmaDamageType] = 0.8;
$DamageScale[armorDestroyer, $EnergyDamageType] = 1.0;
$DamageScale[armorDestroyer, $ExplosionDamageType] = 1.0;
$DamageScale[armorDestroyer, $MissileDamageType] = 1.0;
$DamageScale[armorDestroyer, $DebrisDamageType] = 0.8;
$DamageScale[armorDestroyer, $ShrapnelDamageType] = 0.8;
$DamageScale[armorDestroyer, $LaserDamageType] = 1.0;
$DamageScale[armorDestroyer, $MortarDamageType] = 1.0;
$DamageScale[armorDestroyer, $BlasterDamageType] = 1.0;
$DamageScale[armorDestroyer, $ElectricityDamageType] = 1.0;
$DamageScale[armorDestroyer, $MineDamageType] = 0.8;
$DamageScale[armorDestroyer, $SniperDamageType] = 1.0;
$DamageScale[armorDestroyer, $FlashDamageType] = 1.0;
 //
$VehicleUse[armorDestroyer, Wraith] = $CanRide;
$VehicleUse[armorDestroyer, Interceptor] = $CanRide;
$VehicleUse[armorDestroyer, Scout] = $CanRide;
$VehicleUse[armorDestroyer, LAPC] = $CanRide;
$VehicleUse[armorDestroyer, HAPC] = $CanRide;

function PopulateItemMax(%item, %mDM, %fDM, %mSP, %fSP, %mCM, %fCM, %mLD, %fLD, %DE)
{
  $ItemMax[armormDeathmatch, %item] = %mDM;
  $ItemMax[armorfDeathmatch, %item] = %fDM;
  $ItemMax[armormSprint, %item] = %mSP;
  $ItemMax[armorfSprint, %item] = %fSP;
  $ItemMax[armormCommando, %item] = %mCM;
  $ItemMax[armorfCommando, %item] = %fCM;
  $ItemMax[armormLoader, %item] = %mLD;
  $ItemMax[armorfLoader, %item] = %fLD;
  $ItemMax[armorDestroyer, %item] = %DE;  
}

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Blaster,           1,   1,   1,   1,   1,   1,   1,   1,   1); // Blaster
PopulateItemMax(Bolt,              1,   1,   1,   1,   1,   1,   1,   1,   1); // Thunderbolt (suped up ELF)
PopulateItemMax(ChainGun,          1,   1,   1,   1,   1,   1,   0,   0,   0); // Chaingun
PopulateItemMax(BulletAmmo,      150, 150, 100, 100, 150, 150, 100, 100, 200); 
PopulateItemMax(DeathLaser,        1,   1,   0,   0,   0,   0,   0,   0,   1); // Rapidfire Laser
PopulateItemMax(DiscLauncher,      1,   1,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(DiscAmmo,         15,  15,  15,  15,  20,  20,  15,  15,  25);
PopulateItemMax(Fixit,             0,   0,   0,   0,   0,   0,   1,   1,   0); // Repair Gun
PopulateItemMax(Flamer,            1,   1,   0,   0,   1,   1,   0,   0,   0); // Flame thrower
PopulateItemMax(GrenadeLauncher,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(GrenadeAmmo,      10,  10,  10,  10,  15,  15,  10,  10,  20);
PopulateItemMax(ImpGun,            1,   1,   1,   1,   1,   1,   1,   1,   1); 
PopulateItemMax(LaserRifle,        1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(MassDriver,        1,   1,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(MassAmmo,         20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(Mortar,            1,   1,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(MortarAmmo,        5,   5,   5,   5,   5,   5,   5,   5,  10);
PopulateItemMax(Omega,             1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(PlasmaGun,         1,   1,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(PlasmaAmmo,       40,  40,  30,  30,  40,  40,  30,  30,  50);
PopulateItemMax(RailGun,           1,   1,   0,   0,   1,   1,   1,   1,   0);
PopulateItemMax(RailAmmo,          5,   5,  10,  10,  10,  10,   5,   5,  10);
PopulateItemMax(RocketLauncher,    1,   1,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(RocketAmmo,        5,   5,  10,  10,  10,  10,  10,  10,  10);
PopulateItemMax(Silencer,          1,   1,   0,   0,   1,   1,   0,   0,   0); // Magnum
PopulateItemMax(SilencerAmmo,     25,  25,  25,  25,  25,  25,  25,  25,  25); 
PopulateItemMax(SniperRifle,       1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(SniperAmmo,       10,  10,  15,  15,  30,  30,  30,  30,  30);
PopulateItemMax(TargetingLaser,    0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(TargetMarkLaser,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(TractorDevice,     0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TranqGun,          1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(TranqAmmo,        20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(Vulcan,            1,   1,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(VulcanAmmo,      100, 100, 100, 100, 150, 150, 150, 150, 200);
PopulateItemMax(WaveGun,           1,   1,   0,   0,   0,   0,   1,   1,   0); // Shockwave

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // MISC 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Beacon,            3,   3,   3,   3,   3,   3,   1,   1,   3);
PopulateItemMax(Grenade,           4,   4,   3,   3,   4,   4,   5,   5,   5);
PopulateItemMax(MineAmmo,          3,   3,   3,   3,   4,   4,   5,   5,   5);
PopulateItemMax(RepairKit,         1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // PACKS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,          1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(CloakingDevice,    1,   1,   0,   0,   1,   1,   1,   1,   1);
PopulateItemMax(EnergyPack,        1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(Laptop,            0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(PhotonPack,        0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(RepairPack,        1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(SensorJammerPack,  1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,        1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(SuicidePack,       1,   1,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TrackerMissilePack,0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(TrackerMissileAmmo,0,   0,   5,   5,   7,   7,   7,   7,  10);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE SENSORS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                        mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                                        ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,                  1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack,  1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MotionSensorPack,            1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PulseSensorPack,             1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                              mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                              ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(IonTurretPack,     0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(LaserTurretPack,   0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(MortarTurretPack,  0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(PlasmaTurretPack,  0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(RailTurretPack,    1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemmax(RocketPack,        0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemmax(ShockTurretPack,   0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemmax(VulcanTurretPack,  1,   1,   0,   0,   0,   0,   1,   1,   0);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                    mDM  fDM  mSP  fSP  mCM  fCM  mLD  fLD   DE
 //                                    ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemmax(AcceleratorDevicePack,   1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemmax(BlastWallPack,           0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(DeployableAmmoPack,      0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(DeployableComPack,       0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(DeployableInvPack,       0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemmax(MechPack,                0,   0,   0,   0,   0,   0,   1,   1,   0); // HPC
PopulateItemmax(ForceFieldPack,          0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemmax(LargeForceFieldPack,     0,   0,   0,   0,   0,   0,   1,   1,   1);
PopulateItemmax(MannequinPack,           1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemmax(MechPack,                0,   0,   1,   1,   0,   0,   0,   0,   0); // Scout 
PopulateItemMax(PlatformPack,            1,   1,   0,   0,   0,   0,   1,   1,   1);
PopulateItemMax(SpringPack,              1,   1,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(TeleportPack,            0,   0,   0,   0,   0,   0,   1,   1,   0);
PopulateItemMax(TreePack,                1,   1,   1,   1,   1,   1,   1,   1,   1);

 //Admin
PopulateItemMax(PackOMen,                1,   1,   1,   1,   1,   1,   1,   1,   1);

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