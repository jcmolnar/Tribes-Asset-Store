ItemData MedicArmor
{
   heading = "aArmor";
	description = "Medic Armor";
	className = "Armor";
	price = 175;
};

ItemData SensorArmor
{
   heading = "aArmor";
	description = "Sensor Network Armor";
	className = "Armor";
	price = 300;
};

ItemData FlagArmor
{
   heading = "aSpecialist Armor";
	description = "Flag Mover Armor";
	className = "Armor";
	price = 200;
};

$ArmorType[Male, FlagArmor] = flarmor;
$ArmorType[Male, MedicArmor] = medarmor;
$ArmorType[Male, SensorArmor] = senarmor;
$ArmorType[Female, FlagArmor] = feflarmor;
$ArmorType[Female, MedicArmor] = medfemale;
$ArmorType[Female, SensorArmor] = senfemale;

$ArmorName[flarmor] = FlagArmor;
$ArmorName[medarmor] = MedicArmor;
$ArmorName[senarmor] = SensorArmor;
$ArmorName[feflarmor] = FlagArmor;
$ArmorName[medfemale] = MedicArmor;
$ArmorName[senfemale] = SensorArmor;

//----------------------------------------------------------------------------
// Medic Armor
//----------------------------------------------------------------------------
$DamageScale[medarmor, $LandingDamageType] = 1.0;
$DamageScale[medarmor, $ImpactDamageType] = 1.0;
$DamageScale[medarmor, $CrushDamageType] = 1.0;
$DamageScale[medarmor, $BulletDamageType] = 1.0;
$DamageScale[medarmor, $PlasmaDamageType] = 0.6;
$DamageScale[medarmor, $EnergyDamageType] = 1.0;
$DamageScale[medarmor, $ExplosionDamageType] = 1.0;
$DamageScale[medarmor, $MissileDamageType] = 1.0;
$DamageScale[medarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[medarmor, $DebrisDamageType] = 1.0;
$DamageScale[medarmor, $LaserDamageType] = 1.0;
$DamageScale[medarmor, $MortarDamageType] = 1.0;
$DamageScale[medarmor, $BlasterDamageType] = 1.0;
$DamageScale[medarmor, $ElectricityDamageType] = 1.0;
$DamageScale[medarmor, $MineDamageType] = 1.0;

$ItemMax[medarmor, Blaster] = 1;
$ItemMax[medarmor, Chaingun] = 1;
$ItemMax[medarmor, Disclauncher] = 1;
$ItemMax[medarmor, GrenadeLauncher] = 0;
$ItemMax[medarmor, Mortar] = 0;
$ItemMax[medarmor, PlasmaGun] = 1;
$ItemMax[medarmor, LaserRifle] = 0;
$ItemMax[medarmor, EnergyRifle] = 1;
$ItemMax[medarmor, TargetingLaser] = 1;
$ItemMax[medarmor, MineAmmo] = 4;
$ItemMax[medarmor, Grenade] = 3;
$ItemMax[medarmor, Beacon] = 0;

$ItemMax[medarmor, BulletAmmo] = 150;
$ItemMax[medarmor, PlasmaAmmo] = 40;
$ItemMax[medarmor, DiscAmmo] = 15;
$ItemMax[medarmor, GrenadeAmmo] = 0;
$ItemMax[medarmor, MortarAmmo] = 10;

$ItemMax[medarmor, EnergyPack] = 1;
$ItemMax[medarmor, RepairPack] = 1;
$ItemMax[medarmor, ShieldPack] = 0;
$ItemMax[medarmor, SensorJammerPack] =0;
$ItemMax[medarmor, MotionSensorPack] =  0;
$ItemMax[medarmor, PulseSensorPack] = 0;
$ItemMax[medarmor, DeployableSensorJammerPack] = 0;
$ItemMax[medarmor, CameraPack] = 1;
$ItemMax[medarmor, TurretPack] = 0;
$ItemMax[medarmor, AmmoPack] = 0;
$ItemMax[medarmor, RepairKit] = 5;
$ItemMax[medarmor, DeployableInvPack] = 0;
$ItemMax[medarmor, DeployableAmmoPack] = 0;

// ****
$ItemMax[medarmor, AirMineAmmo] = 0;
$ItemMax[medarmor, FlagMineAmmo] = 0;

$ItemMax[medarmor, RocketTurretPack] = 0;
$ItemMax[medarmor, LaserTurretPack] = 0;
//$ItemMax[medarmor, DepMortarPack] = 0;
$ItemMax[medarmor, SmallElfPack] = 0;
$ItemMax[medarmor, SatCameraPack] = 1;
$ItemMax[medarmor, FlagstandPack] = 1;
$ItemMax[medarmor, DeployableWallPack] =0;
$ItemMax[medarmor, RepairMakerPack] = 1;
$ItemMax[medarmor, RPGAmmoPack] = 0;
$ItemMax[medarmor, MineLayerPack] = 0;
$ItemMax[medarmor, CloakPack] = 0;
$ItemMax[medarmor, HeatSinkPack] = 1;
$ItemMax[medarmor, ForceFieldPack] = 0;
$ItemMax[medarmor, LargeFieldPack] = 0;
$ItemMax[medarmor, AirPlatformPack] = 1;
$ItemMax[medarmor, LargeAirPlatPack] = 0;
$ItemMax[medarmor, GenWarnPack] = 0;
//$ItemMax[medarmor, VehPadPack] = 0;
//$ItemMax[medarmor, VehStationPack] = 0;

$MaxWeapons[medarmor] = 2;

//----------------------------------------------------------------------------
// Sensor Network Armor
//----------------------------------------------------------------------------
$DamageScale[senarmor, $LandingDamageType] = 0.6;
$DamageScale[senarmor, $ImpactDamageType] = 1.0;
$DamageScale[senarmor, $CrushDamageType] = 1.0;
$DamageScale[senarmor, $BulletDamageType] = 1.0;
$DamageScale[senarmor, $PlasmaDamageType] = 0.6;
$DamageScale[senarmor, $EnergyDamageType] = 1.0;
$DamageScale[senarmor, $ExplosionDamageType] = 1.0;
$DamageScale[senarmor, $MissileDamageType] = 1.0;
$DamageScale[senarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[senarmor, $DebrisDamageType] = 1.0;
$DamageScale[senarmor, $LaserDamageType] = 1.5;
$DamageScale[senarmor, $MortarDamageType] = 1.0;
$DamageScale[senarmor, $BlasterDamageType] = 1.0;
$DamageScale[senarmor, $ElectricityDamageType] = 1.0;
$DamageScale[senarmor, $MineDamageType] = 1.0;

$ItemMax[senarmor, Blaster] = 1;
$ItemMax[senarmor, Chaingun] = 1;
$ItemMax[senarmor, Disclauncher] = 1;
$ItemMax[senarmor, GrenadeLauncher] = 1;
$ItemMax[senarmor, Mortar] = 0;
$ItemMax[senarmor, PlasmaGun] = 0;
$ItemMax[senarmor, LaserRifle] = 0;
$ItemMax[senarmor, EnergyRifle] = 0;
$ItemMax[senarmor, TargetingLaser] = 0;
$ItemMax[senarmor, MineAmmo] = 4;
$ItemMax[senarmor, Grenade] = 3;
$ItemMax[senarmor, Beacon] = 0;

$ItemMax[senarmor, BulletAmmo] = 150;
$ItemMax[senarmor, PlasmaAmmo] = 0;
$ItemMax[senarmor, DiscAmmo] = 15;
$ItemMax[senarmor, GrenadeAmmo] = 10;
$ItemMax[senarmor, MortarAmmo] = 0;

$ItemMax[senarmor, EnergyPack] = 0;
$ItemMax[senarmor, RepairPack] = 0;
$ItemMax[senarmor, ShieldPack] = 0;
$ItemMax[senarmor, SensorJammerPack] = 0;
$ItemMax[senarmor, MotionSensorPack] = 5;
$ItemMax[senarmor, PulseSensorPack] = 5;
$ItemMax[senarmor, DeployableSensorJammerPack] = 5;
$ItemMax[senarmor, CameraPack] = 5;
$ItemMax[senarmor, TurretPack] =0;
$ItemMax[senarmor, AmmoPack] = 0;
$ItemMax[senarmor, RepairKit] = 1;
$ItemMax[senarmor, DeployableInvPack] = 0;
$ItemMax[senarmor, DeployableAmmoPack] = 0;

// ****
$ItemMax[senarmor, AirMineAmmo] = 0;
$ItemMax[senarmor, FlagMineAmmo] = 0;

$ItemMax[senarmor, RocketTurretPack] = 0;
$ItemMax[senarmor, LaserTurretPack] = 0;
//$ItemMax[senarmor, DepMortarPack] = 0;
$ItemMax[senarmor, SmallElfPack] = 0;
$ItemMax[senarmor, SatCameraPack] = 5;
$ItemMax[senarmor, FlagstandPack] = 0;
$ItemMax[senarmor, DeployableWallPack] =0;
$ItemMax[senarmor, RepairMakerPack] = 0;
$ItemMax[senarmor, RPGAmmoPack] = 0;
$ItemMax[senarmor, MineLayerPack] = 0;
$ItemMax[senarmor, CloakPack] = 0;
$ItemMax[senarmor, HeatSinkPack] = 0;
$ItemMax[senarmor, ForceFieldPack] = 0;
$ItemMax[senarmor, LargeFieldPack] = 0;
$ItemMax[senarmor, AirPlatformPack] = 0;
$ItemMax[senarmor, LargeAirPlatPack] = 0;
$ItemMax[senarmor, GenWarnPack] = 1;
//$ItemMax[senarmor, VehPadPack] = 0;
//$ItemMax[senarmor, VehStationPack] = 0;

$MaxWeapons[senarmor] = 3;

//----------------------------------------------------------------------------
// Flag Mover  Armor
//----------------------------------------------------------------------------

$DamageScale[flarmor, $LandingDamageType] = 1.0;
$DamageScale[flarmor, $ImpactDamageType] = 1.0;
$DamageScale[flarmor, $CrushDamageType] = 1.0;
$DamageScale[flarmor, $BulletDamageType] = 1.2;
$DamageScale[flarmor, $PlasmaDamageType] = 1.0;
$DamageScale[flarmor, $EnergyDamageType] = 1.3;
$DamageScale[flarmor, $ExplosionDamageType] = 1.0;
$DamageScale[flarmor, $MissileDamageType] = 1.0;
$DamageScale[flarmor, $DebrisDamageType] = 1.2;
$DamageScale[flarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[flarmor, $LaserDamageType] = 1.0;
$DamageScale[flarmor, $MortarDamageType] = 1.3;
$DamageScale[flarmor, $BlasterDamageType] = 1.3;
$DamageScale[flarmor, $ElectricityDamageType] = 1.0;
$DamageScale[flarmor, $MineDamageType] = 1.2;

$ItemMax[flarmor, Blaster] = 1;
$ItemMax[flarmor, Chaingun] = 1;
$ItemMax[flarmor, Disclauncher] = 1;
$ItemMax[flarmor, GrenadeLauncher] = 1;
$ItemMax[flarmor, Mortar] = 0;
$ItemMax[flarmor, PlasmaGun] = 1;
$ItemMax[flarmor, LaserRifle] = 1;
$ItemMax[flarmor, EnergyRifle] = 1;
$ItemMax[flarmor, TargetingLaser] = 1;
$ItemMax[flarmor, MineAmmo] = 4;
$ItemMax[flarmor, Grenade] = 5;
$ItemMax[flarmor, Beacon]  = 3;

$ItemMax[flarmor, BulletAmmo] = 100;
$ItemMax[flarmor, PlasmaAmmo] = 30;
$ItemMax[flarmor, DiscAmmo] = 15;
$ItemMax[flarmor, GrenadeAmmo] = 10;
$ItemMax[flarmor, MortarAmmo] = 10;

$ItemMax[flarmor, EnergyPack] = 1;
$ItemMax[flarmor, RepairPack] = 1;
$ItemMax[flarmor, ShieldPack] = 1;
$ItemMax[flarmor, CameraPack] = 0;
$ItemMax[flarmor, SensorJammerPack] = 1;
$ItemMax[flarmor, MotionSensorPack] = 1;
$ItemMax[flarmor, PulseSensorPack] = 1;
$ItemMax[flarmor, DeployableSensorJammerPack] = 1;
$ItemMax[flarmor, TurretPack] = 0;
$ItemMax[flarmor, AmmoPack] = 1;
$ItemMax[flarmor, RepairKit] = 1;
$ItemMax[flarmor, DeployableInvPack] = 0;
$ItemMax[flarmor, DeployableAmmoPack] = 0;

// ****
$ItemMax[flarmor, AirMineAmmo] = 0;
$ItemMax[flarmor, FlagMineAmmo] = 0;

$ItemMax[flarmor, RocketTurretPack] = 0;
$ItemMax[flarmor, LaserTurretPack] = 0;
//$ItemMax[flarmor, DepMortarPack] = 1;
$ItemMax[flarmor, SmallElfPack] = 0;
$ItemMax[flarmor, SatCameraPack] = 1;
$ItemMax[flarmor, FlagstandPack] = 1;
$ItemMax[flarmor, DeployableWallPack] =0;
$ItemMax[flarmor, RepairMakerPack] = 1;
$ItemMax[flarmor, RPGAmmoPack] = 0;
$ItemMax[flarmor, MineLayerPack] = 1;
$ItemMax[flarmor, CloakPack] = 0;
$ItemMax[flarmor, HeatSinkPack] = 0;
$ItemMax[flarmor, ForceFieldPack] = 0;
$ItemMax[flarmor, LargeFieldPack] = 0;
$ItemMax[flarmor, AirPlatformPack] = 1;
$ItemMax[flarmor, LargeAirPlatPack] = 0;
$ItemMax[flarmor, GenWarnPack] = 0;
//$ItemMax[flarmor, VehPadPack] = 0;
//$ItemMax[flarmor, VehStationPack] = 0;

$MaxWeapons[flarmor] = 3;

//----------------------------------------------------------------------------
// Female  Medic Armor
//----------------------------------------------------------------------------
$DamageScale[medfemale, $LandingDamageType] = 1.0;
$DamageScale[medfemale, $ImpactDamageType] = 1.0;
$DamageScale[medfemale, $CrushDamageType] = 1.0;
$DamageScale[medfemale, $BulletDamageType] = 1.0;
$DamageScale[medfemale, $PlasmaDamageType] = 0.6;
$DamageScale[medfemale, $EnergyDamageType] = 1.0;
$DamageScale[medfemale, $ExplosionDamageType] = 1.0;
$DamageScale[medfemale, $MissileDamageType] = 1.0;
$DamageScale[medfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[medfemale, $DebrisDamageType] = 1.0;
$DamageScale[medfemale, $LaserDamageType] = 1.0;
$DamageScale[medfemale, $MortarDamageType] = 1.0;
$DamageScale[medfemale, $BlasterDamageType] = 1.0;
$DamageScale[medfemale, $ElectricityDamageType] = 1.0;
$DamageScale[medfemale, $MineDamageType] = 1.0;


$ItemMax[medfemale, Blaster] = 1;
$ItemMax[medfemale, Chaingun] = 1;
$ItemMax[medfemale, Disclauncher] = 1;
$ItemMax[medfemale, GrenadeLauncher] = 0;
$ItemMax[medfemale, Mortar] = 0;
$ItemMax[medfemale, PlasmaGun] = 1;
$ItemMax[medfemale, LaserRifle] = 0;
$ItemMax[medfemale, EnergyRifle] = 1;
$ItemMax[medfemale, TargetingLaser] = 1;
$ItemMax[medfemale, MineAmmo] = 4;
$ItemMax[medfemale, Grenade] = 3;
$ItemMax[medfemale, Beacon] = 0;

$ItemMax[medfemale, BulletAmmo] = 150;
$ItemMax[medfemale, PlasmaAmmo] = 40;
$ItemMax[medfemale, DiscAmmo] = 15;
$ItemMax[medfemale, GrenadeAmmo] = 0;
$ItemMax[medfemale, MortarAmmo] = 10;

$ItemMax[medfemale, EnergyPack] = 1;
$ItemMax[medfemale, RepairPack] = 1;
$ItemMax[medfemale, ShieldPack] = 0;
$ItemMax[medfemale, SensorJammerPack] =0;
$ItemMax[medfemale, MotionSensorPack] =  0;
$ItemMax[medfemale, PulseSensorPack] = 0;
$ItemMax[medfemale, DeployableSensorJammerPack] = 0;
$ItemMax[medfemale, CameraPack] = 1;
$ItemMax[medfemale, TurretPack] = 0;
$ItemMax[medfemale, AmmoPack] = 0;
$ItemMax[medfemale, RepairKit] = 5;
$ItemMax[medfemale, DeployableInvPack] = 0;
$ItemMax[medfemale, DeployableAmmoPack] = 0;

// ****
$ItemMax[medfemale, AirMineAmmo] = 0;
$ItemMax[medfemale, flagmineammo] = 0;

$ItemMax[medfemale, RocketTurretPack] = 0;
$ItemMax[medfemale, LaserTurretPack] = 0;
//$ItemMax[medfemale, DepMortarPack] = 0;
$ItemMax[medfemale, SmallElfPack] = 0;
$ItemMax[medfemale, SatCameraPack] = 1;
$ItemMax[medfemale, FlagstandPack] = 1;
$ItemMax[medfemale, DeployableWallPack] =0;
$ItemMax[medfemale, RepairMakerPack] = 1;
$ItemMax[medfemale, RPGAmmoPack] = 0;
$ItemMax[medfemale, MineLayerPack] = 0;
$ItemMax[medfemale, CloakPack] = 0;
$ItemMax[medfemale, HeatSinkPack] = 1;
$ItemMax[medfemale, ForceFieldPack] = 0;
$ItemMax[medfemale, LargeFieldPack] = 0;
$ItemMax[medfemale, AirPlatformPack] = 1;
$ItemMax[medfemale, LargeAirPlatPack] = 0;
$ItemMax[medfemale, GenWarnPack] = 0;
//$ItemMax[medfemale, VehPadPack] = 0;
//$ItemMax[medfemale, VehStationPack] = 0;

$MaxWeapons[medfemale] = 2;

//----------------------------------------------------------------------------
// Sensor Network Female Armor
//----------------------------------------------------------------------------
$DamageScale[senfemale, $LandingDamageType] = 0.6;
$DamageScale[senfemale, $ImpactDamageType] = 1.0;
$DamageScale[senfemale, $CrushDamageType] = 1.0;
$DamageScale[senfemale, $BulletDamageType] = 1.0;
$DamageScale[senfemale, $PlasmaDamageType] = 0.6;
$DamageScale[senfemale, $EnergyDamageType] = 1.0;
$DamageScale[senfemale, $ExplosionDamageType] = 1.0;
$DamageScale[senfemale, $MissileDamageType] = 1.0;
$DamageScale[senfemale, $ShrapnelDamageType] = 1.0;
$DamageScale[senfemale, $DebrisDamageType] = 1.0;
$DamageScale[senfemale, $LaserDamageType] = 1.5;
$DamageScale[senfemale, $MortarDamageType] = 1.0;
$DamageScale[senfemale, $BlasterDamageType] = 1.0;
$DamageScale[senfemale, $ElectricityDamageType] = 1.0;
$DamageScale[senfemale, $MineDamageType] = 1.0;

$ItemMax[senfemale, Blaster] = 1;
$ItemMax[senfemale, Chaingun] = 1;
$ItemMax[senfemale, Disclauncher] = 1;
$ItemMax[senfemale, GrenadeLauncher] = 1;
$ItemMax[senfemale, Mortar] = 0;
$ItemMax[senfemale, PlasmaGun] = 0;
$ItemMax[senfemale, LaserRifle] = 0;
$ItemMax[senfemale, EnergyRifle] = 0;
$ItemMax[senfemale, TargetingLaser] = 0;
$ItemMax[senfemale, MineAmmo] = 4;
$ItemMax[senfemale, Grenade] = 3;
$ItemMax[senfemale, Beacon] = 0;

$ItemMax[senfemale, BulletAmmo] = 150;
$ItemMax[senfemale, PlasmaAmmo] = 0;
$ItemMax[senfemale, DiscAmmo] = 15;
$ItemMax[senfemale, GrenadeAmmo] = 10;
$ItemMax[senfemale, MortarAmmo] = 0;

$ItemMax[senfemale, EnergyPack] = 0;
$ItemMax[senfemale, RepairPack] = 0;
$ItemMax[senfemale, ShieldPack] = 0;
$ItemMax[senfemale, SensorJammerPack] = 0;
$ItemMax[senfemale, MotionSensorPack] = 5;
$ItemMax[senfemale, PulseSensorPack] = 5;
$ItemMax[senfemale, DeployableSensorJammerPack] = 5;
$ItemMax[senfemale, CameraPack] = 5;
$ItemMax[senfemale, TurretPack] = 0;
$ItemMax[senfemale, AmmoPack] = 0;
$ItemMax[senfemale, RepairKit] = 1;
$ItemMax[senfemale, DeployableInvPack] = 0;
$ItemMax[senfemale, DeployableAmmoPack] = 0;

// ****
$ItemMax[senfemale, AirMineAmmo] = 0;
$ItemMax[senfemale, FlagMineAmmo] = 0;

$ItemMax[senfemale, RocketTurretPack] = 0;
$ItemMax[senfemale, LaserTurretPack] = 0;
//$ItemMax[senfemale, DepMortarPack] = 0;
$ItemMax[senfemale, SmallElfPack] = 0;
$ItemMax[senfemale, SatCameraPack] = 5;
$ItemMax[senfemale, FlagstandPack] = 0;
$ItemMax[senfemale, DeployableWallPack] =0;
$ItemMax[senfemale, RepairMakerPack] = 0;
$ItemMax[senfemale, RPGAmmoPack] = 0;
$ItemMax[senfemale, MineLayerPack] = 0;
$ItemMax[senfemale, CloakPack] = 0;
$ItemMax[senfemale, HeatSinkPack] = 0;
$ItemMax[senfemale, ForceFieldPack] = 0;
$ItemMax[senfemale, LargeFieldPack] = 0;
$ItemMax[senfemale, AirPlatformPack] = 0;
$ItemMax[senfemale, LargeAirPlatPack] = 0;
$ItemMax[senfemale, GenWarnPack] = 0;
//$ItemMax[senfemale, VehPadPack] = 1;
//$ItemMax[senfemale, VehStationPack] = 0;

$MaxWeapons[senfemale] = 3;

//----------------------------------------------------------------------------
// Female Flag Mover  Armor
//----------------------------------------------------------------------------

$DamageScale[feflarmor, $LandingDamageType] = 1.0;
$DamageScale[feflarmor, $ImpactDamageType] = 1.0;
$DamageScale[feflarmor, $CrushDamageType] = 1.0;
$DamageScale[feflarmor, $BulletDamageType] = 1.2;
$DamageScale[feflarmor, $PlasmaDamageType] = 1.0;
$DamageScale[feflarmor, $EnergyDamageType] = 1.3;
$DamageScale[feflarmor, $ExplosionDamageType] = 1.0;
$DamageScale[feflarmor, $MissileDamageType] = 1.0;
$DamageScale[feflarmor, $DebrisDamageType] = 1.2;
$DamageScale[feflarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[feflarmor, $LaserDamageType] = 1.0;
$DamageScale[feflarmor, $MortarDamageType] = 1.3;
$DamageScale[feflarmor, $BlasterDamageType] = 1.3;
$DamageScale[feflarmor, $ElectricityDamageType] = 1.0;
$DamageScale[feflarmor, $MineDamageType] = 1.2;

$ItemMax[feflarmor, Blaster] = 1;
$ItemMax[feflarmor, Chaingun] = 1;
$ItemMax[feflarmor, Disclauncher] = 1;
$ItemMax[feflarmor, GrenadeLauncher] = 1;
$ItemMax[feflarmor, Mortar] = 0;
$ItemMax[feflarmor, PlasmaGun] = 1;
$ItemMax[feflarmor, LaserRifle] = 1;
$ItemMax[feflarmor, EnergyRifle] = 1;
$ItemMax[feflarmor, TargetingLaser] = 1;
$ItemMax[feflarmor, MineAmmo] = 4;
$ItemMax[feflarmor, Grenade] = 5;
$ItemMax[feflarmor, Beacon]  = 3;

$ItemMax[feflarmor, BulletAmmo] = 100;
$ItemMax[feflarmor, PlasmaAmmo] = 30;
$ItemMax[feflarmor, DiscAmmo] = 15;
$ItemMax[feflarmor, GrenadeAmmo] = 10;
$ItemMax[feflarmor, MortarAmmo] = 10;

$ItemMax[feflarmor, EnergyPack] = 1;
$ItemMax[feflarmor, RepairPack] = 1;
$ItemMax[feflarmor, ShieldPack] = 1;
$ItemMax[feflarmor, SensorJammerPack] = 1;
$ItemMax[feflarmor, MotionSensorPack] = 1;
$ItemMax[feflarmor, PulseSensorPack] = 1;
$ItemMax[feflarmor, DeployableSensorJammerPack] = 1;
$ItemMax[feflarmor, TurretPack] = 0;
$ItemMax[feflarmor, AmmoPack] = 1;
$ItemMax[feflarmor, RepairKit] = 1;
$ItemMax[feflarmor, DeployableInvPack] = 0;
$ItemMax[feflarmor, DeployableAmmoPack] = 0;

// ****
$ItemMax[feflarmor, AirMineAmmo] = 0;
$ItemMax[feflarmor, FlagMineAmmo] = 0;

$ItemMax[feflarmor, RocketTurretPack] = 0;
$ItemMax[feflarmor, LaserTurretPack] = 0;
//$ItemMax[feflarmor, DepMortarPack] = 1;
$ItemMax[feflarmor, SmallElfPack] = 0;
$ItemMax[feflarmor, SatCameraPack] = 1;
$ItemMax[feflarmor, FlagstandPack] = 1;
$ItemMax[feflarmor, DeployableWallPack] =0;
$ItemMax[feflarmor, RepairMakerPack] = 1;
$ItemMax[feflarmor, RPGAmmoPack] = 0;
$ItemMax[feflarmor, MineLayerPack] = 1;
$ItemMax[feflarmor, CloakPack] = 0;
$ItemMax[feflarmor, HeatSinkPack] = 0;
$ItemMax[feflarmor, ForceFieldPack] = 0;
$ItemMax[feflarmor, LargeFieldPack] = 0;
$ItemMax[feflarmor, AirPlatformPack] = 1;
$ItemMax[feflarmor, LargeAirPlatPack] = 0;
$ItemMax[feflarmor, GenWarnPack] = 0;
//$ItemMax[feflarmor, VehPadPack] = 0;
//$ItemMax[feflarmor, VehStationPack] = 0;

$MaxWeapons[feflarmor] = 3;

// -----------------------------------------------------

// ****
$ItemMax[larmor, AirMineAmmo] = 3;
$ItemMax[larmor, FlagMineAmmo] = 3;

$ItemMax[larmor, RocketTurretPack] = 0;
$ItemMax[larmor, LaserTurretPack] = 0;
//$ItemMax[larmor, DepMortarPack] = 1;
$ItemMax[larmor, SmallElfPack] = 0;
$ItemMax[larmor, SatCameraPack] = 1;
$ItemMax[larmor, FlagstandPack] = 1;
$ItemMax[larmor, DeployableWallPack] = 0;
$ItemMax[larmor, RepairMakerPack] = 1;
$ItemMax[larmor, RPGAmmoPack] = 0;
$ItemMax[larmor, MineLayerPack] = 1;
$ItemMax[larmor, CloakPack] = 1;
$ItemMax[larmor, HeatSinkPack] = 1;
$ItemMax[larmor, ForceFieldPack] = 0;
$ItemMax[larmor, LargeFieldPack] = 0;
$ItemMax[larmor, AirPlatformPack] = 1;
$ItemMax[larmor, LargeAirPlatPack] = 0;
$ItemMax[larmor, GenWarnPack] = 1;
//$ItemMax[larmor, VehPadPack] = 0;
//$ItemMax[larmor, VehStationPack] = 0;

// ****
$ItemMax[marmor, AirMineAmmo] = 3;
$ItemMax[marmor, FlagMineAmmo] = 3;

$ItemMax[marmor, RocketTurretPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;
//$ItemMax[marmor, DepMortarPack] = 1;
$ItemMax[marmor, SmallElfPack] = 1;
$ItemMax[marmor, SatCameraPack] = 1;
$ItemMax[marmor, FlagstandPack] = 1;
$ItemMax[marmor, DeployableWallPack] =1;
$ItemMax[marmor, RepairMakerPack] = 1;
$ItemMax[marmor, RPGAmmoPack] = 1;
$ItemMax[marmor, MineLayerPack] = 1;
$ItemMax[marmor, CloakPack] = 1;
$ItemMax[marmor, HeatSinkPack] = 1;
$ItemMax[marmor, ForceFieldPack] = 1;
$ItemMax[marmor, LargeFieldPack] = 1;
$ItemMax[marmor, AirPlatformPack] = 1;
$ItemMax[marmor, LargeAirPlatPack] = 1;
$ItemMax[marmor, GenWarnPack] = 1;
//$ItemMax[marmor, VehPadPack] = 0;
//$ItemMax[marmor, VehStationPack] = 0;

// ****
$ItemMax[harmor, AirMineAmmo] = 3;
$ItemMax[harmor, FlagMineAmmo] = 3;

$ItemMax[harmor, RocketTurretPack] = 1;
$ItemMax[harmor, LaserTurretPack] = 1;
//$ItemMax[harmor, DepMortarPack] = 1;
$ItemMax[harmor, SmallElfPack] = 1;
$ItemMax[harmor, SatCameraPack] = 1;
$ItemMax[harmor, FlagstandPack] = 1;
$ItemMax[harmor, DeployableWallPack] =1;
$ItemMax[harmor, RepairMakerPack] = 1;
$ItemMax[harmor, RPGAmmoPack] = 1;
$ItemMax[harmor, MineLayerPack] = 1;
$ItemMax[harmor, CloakPack] = 0;
$ItemMax[harmor, HeatSinkPack] = 1;
$ItemMax[harmor, ForceFieldPack] = 1;
$ItemMax[harmor, LargeFieldPack] = 1;
$ItemMax[harmor, AirPlatformPack] = 1;
$ItemMax[harmor, LargeAirPlatPack] = 1;
$ItemMax[harmor, GenWarnPack] = 1;
//$ItemMax[harmor, VehPadPack] = 1;
//$ItemMax[harmor, VehStationPack] = 1;

// ****
$ItemMax[lfemale, AirMineAmmo] = 3;
$ItemMax[lfemale, FlagMineAmmo] = 3;

$ItemMax[lfemale, RocketTurretPack] = 0;
$ItemMax[lfemale, LaserTurretPack] = 0;
//$ItemMax[lfemale, DepMortarPack] = 1;
$ItemMax[lfemale, SmallElfPack] = 0;
$ItemMax[lfemale, SatCameraPack] = 1;
$ItemMax[lfemale, FlagstandPack] = 1;
$ItemMax[lfemale, DeployableWallPack] =0;
$ItemMax[lfemale, RepairMakerPack] = 1;
$ItemMax[lfemale, RPGAmmoPack] = 0;
$ItemMax[lfemale, MineLayerPack] = 1;
$ItemMax[lfemale, CloakPack] = 1;
$ItemMax[lfemale, HeatSinkPack] = 1;
$ItemMax[lfemale, ForceFieldPack] = 0;
$ItemMax[lfemale, LargeFieldPack] = 0;
$ItemMax[lfemale, AirPlatformPack] = 1;
$ItemMax[lfemale, LargeAirPlatPack] = 0;
$ItemMax[lfemale, GenWarnPack] = 1;
//$ItemMax[lfemale, VehPadPack] = 0;
//$ItemMax[lfemale, VehStationPack] = 0;

// ****
$ItemMax[mfemale, AirMineAmmo] = 3;
$ItemMax[mfemale, FlagMineAmmo] = 3;

$ItemMax[mfemale, RocketTurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
//$ItemMax[mfemale, DepMortarPack] = 1;
$ItemMax[mfemale, SmallElfPack] = 1;
$ItemMax[mfemale, SatCameraPack] = 1;
$ItemMax[mfemale, FlagstandPack] = 1;
$ItemMax[mfemale, DeployableWallPack] =1;
$ItemMax[mfemale, RepairMakerPack] = 1;
$ItemMax[mfemale, RPGAmmoPack] = 1;
$ItemMax[mfemale, MineLayerPack] = 1;
$ItemMax[mfemale, CloakPack] = 0;
$ItemMax[mfemale, HeatSinkPack] = 1;
$ItemMax[mfemale, ForceFieldPack] = 1;
$ItemMax[mfemale, LargeFieldPack] = 1;
$ItemMax[mfemale, AirPlatformPack] = 1;
$ItemMax[mfemale, LargeAirPlatPack] = 1;
$ItemMax[mfemale, GenWarnPack] = 1;
//$ItemMax[mfemale, VehPadPack] = 0;
//$ItemMax[mfemale, VehStationPack] = 0;

//------------------------------------------------------------------
// Medic Armor data:
//------------------------------------------------------------------

PlayerData medarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 300;
   jetEnergyDrain = 1.0;

	maxDamage = 0.9;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed =8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 16.0;
   mass = 16.0;
   groundTraction = 3.0;
	
   maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

   minDamageSpeed = 25;
   damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Sensor Network Armor data:
//------------------------------------------------------------------

PlayerData senarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed =8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 14.0;
   mass = 14.0;
   groundTraction = 3.0;
	
   maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

   minDamageSpeed = 20;
   damageScale = 0.006;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Flag Mover armor data:
//------------------------------------------------------------------

PlayerData flarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Female Medic Armor data:
//------------------------------------------------------------------

PlayerData medfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 300;
   jetEnergyDrain = 1.0;

	maxDamage = 0.9;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed =8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 16.0;
   mass = 16.0;
   groundTraction = 3.0;
	
   maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

   minDamageSpeed = 25;
   damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Female Sensor Network Armor data:
//------------------------------------------------------------------

PlayerData senfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 9.0;
   maxBackwardSpeed =8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 14.0;
   mass = 14.0;
   groundTraction = 3.0;
	
   maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

   minDamageSpeed = 20;
   damageScale = 0.006;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Female Flag Mover armor data:
//------------------------------------------------------------------

PlayerData feflarmor
{
   className = "Armor";
   shapeFile = "lfemale";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 22;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


