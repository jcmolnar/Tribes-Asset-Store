//*************************************************************************************************************
// SF Addition - Begin - 7/19/99 - 9:40PM
//*************************************************************************************************************
// Current Armor Classes:
//
//    Type     |     Gender        |     Armor file
//
// Special Ops - Male and Female       somale/sofemale
// Infantry - Male and Female          imale/ifemale
// Heavy Infantry - Male and Female    himale/hifemale
// Console Man - Male and Female       cmmale/cmfemale
// All original armors for bot use ONLY

//----------------------------------------------------------------------------
// DEATHMATCH ARMOR MALE - Male
//----------------------------------------------------------------------------
echo("Loading Screaming Fist Version");
$DamageScale[dmale, $LandingDamageType] = 1.0;
$DamageScale[dmale, $ImpactDamageType] = 1.0;
$DamageScale[dmale, $CrushDamageType] = 1.0;
$DamageScale[dmale, $ExplosionDamageType] = 1.0;
$DamageScale[dmale, $DebrisDamageType] = 1.0;
$DamageScale[dmale, $ElectricityDamageType] = 1.0;
$DamageScale[dmale, $MineDamageType] = 1.0;
$DamageScale[dmale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[dmale, $ShrapnelDamageType] = 1.0;
$DamageScale[dmale, $SniperRifleDamageType] = 1.2;
$DamageScale[dmale, $MinigunDamageType] = 1.2;
$DamageScale[dmale, $AssRifleDamageType] = 1.2;
$DamageScale[dmale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[dmale, $FlamerDamageType] = 1.2;
$DamageScale[dmale, $GlockDamageType] = 1.2;
$DamageScale[dmale, $SilencedGlockDamageType] = 1.2;
$DamageScale[dmale, $MissileDamageType] = 1.7;
$DamageScale[dmale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[dmale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[dmale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[dmale, $ShotgunDamageType] = 1.2;
$DamageScale[dmale, $ComancheBulletDamageType] = 1.2;
$DamageScale[dmale, $ComancheImpactDamageType] = 1.2;
$DamageScale[dmale, $OspreyImpactDamageType] = 1.2;
$DamageScale[dmale, $BigCannonDamageType] = 1.2;
$DamageScale[dmale, $HowitzerDamageType] = 1.2;
$DamageScale[dmale, $HomingFlareDamageType] = 0.0;
$DamageScale[dmale, $OspreyTurretDamageType] = 1.2;

$ItemMax[dmale, MinigunAmmo] = 0;
$ItemMax[dmale, AssRifleAmmo] = 180;
$ItemMax[dmale, ShotgunAmmo] = 12;
$ItemMax[dmale, GlockAmmo] = 150;
$ItemMax[dmale, SniperRifleAmmo] = 10;
$ItemMax[dmale, FlamerAmmo] = 300;
$ItemMax[dmale, HomingFlareAmmo] = 0;
$ItemMax[dmale, LaserRifle] = 0;
$ItemMax[dmale, MAWAssRifleAmmo] = 0;
$ItemMax[dmale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[dmale, MAWGrenadeAmmo] = 10;
$ItemMax[dmale, RocketLauncherAmmo] = 2;
$ItemMax[dmale, FBWRocketAmmo] = 1;

$ItemMax[dmale, MAWAssRifle] = 0;
$ItemMax[dmale, MAWIncendiaryRifle] = 0;
$ItemMax[dmale, MAWGrenadeLauncher] = 0;
$ItemMax[dmale, HomingFlaregun] = 0;
$ItemMax[dmale, Shotgun] = 1;
$ItemMax[dmale, RocketLauncher] = 1;
$ItemMax[dmale, FBWRocketLauncher] = 1;
$ItemMax[dmale, Glock] = 1;
$ItemMax[dmale, AssRifle] = 1;
$ItemMax[dmale, Shotgun] = 1;
$ItemMax[dmale, SilencedGlock] = 1;
$ItemMax[dmale, SilencedAssRifle] = 1;
$ItemMax[dmale, FlamerGun] = 1;
$ItemMax[dmale, Minigun] = 0;
$ItemMax[dmale, SniperRifle] = 1;
$ItemMax[dmale, Detpack]  = 1;
$ItemMax[dmale, GrenadeLauncher] = 1;
//------------------------------------
//     END
//-------------------------------------
$ItemMax[dmale, MineAmmo] = 3;
$ItemMax[dmale, Grenade] = 6;
$ItemMax[dmale, Beacon]  = 0;
$ItemMax[dmale, Detonator] = 1;
$ItemMax[dmale, RemMineAmmo] = 6;
$ItemMax[dmale, FlashGrenade] = 6;
$ItemMax[dmale, ConsoleJack] = 0;

$ItemMax[dmale, EnergyPack] = 0;
$ItemMax[dmale, RepairPack] = 1;
//$ItemMax[dmale, DisguisePack] = 0;
$ItemMax[dmale, DeckPack] = 0;
$ItemMax[dmale, SensorJammerPack] = 0;
$ItemMax[dmale, MotionSensorPack] = 0;
$ItemMax[dmale, PulseSensorPack] = 0;
$ItemMax[dmale, CameraPack] = 0;
//--------------------------------------
//     SF Backpacks
//--------------------------------------
$ItemMax[dmale, FuelPack] = 1;
$ItemMax[dmale, MinigunAmmoPack] = 0;
$ItemMax[dmale, DeployableMedicPack] = 0;
$ItemMax[dmale, ReloaderPack] = 0;

$ItemMax[dmale, TurretPack] = 0;
$ItemMax[dmale, AmmoPack] = 1;
$ItemMax[dmale, RepairKit] = 2;
$ItemMax[dmale, DeployableInvPack] = 0;
$ItemMax[dmale, DeployableAmmoPack] = 0;

$MaxWeapons[dmale] = 16;





//----------------------------------------------------------------------------
// DEATHMATCH ARMOR FEMALE - FEMale
//----------------------------------------------------------------------------

$DamageScale[dfmale, $LandingDamageType] = 1.0;
$DamageScale[dfmale, $ImpactDamageType] = 1.0;
$DamageScale[dfmale, $CrushDamageType] = 1.0;
$DamageScale[dfmale, $ExplosionDamageType] = 1.0;
$DamageScale[dfmale, $DebrisDamageType] = 1.0;
$DamageScale[dfmale, $ElectricityDamageType] = 1.0;
$DamageScale[dfmale, $MineDamageType] = 1.0;
$DamageScale[dfmale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[dfmale, $ShrapnelDamageType] = 1.0;
$DamageScale[dfmale, $SniperRifleDamageType] = 1.2;
$DamageScale[dfmale, $MinigunDamageType] = 1.2;
$DamageScale[dfmale, $AssRifleDamageType] = 1.2;
$DamageScale[dfmale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[dfmale, $FlamerDamageType] = 1.2;
$DamageScale[dfmale, $GlockDamageType] = 1.2;
$DamageScale[dfmale, $SilencedGlockDamageType] = 1.2;
$DamageScale[dfmale, $MissileDamageType] = 1.7;
$DamageScale[dfmale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[dfmale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[dfmale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[dfmale, $ShotgunDamageType] = 1.2;
$DamageScale[dfmale, $ComancheBulletDamageType] = 1.2;
$DamageScale[dfmale, $ComancheImpactDamageType] = 1.2;
$DamageScale[dfmale, $OspreyImpactDamageType] = 1.2;
$DamageScale[dfmale, $BigCannonDamageType] = 1.2;
$DamageScale[dfmale, $HowitzerDamageType] = 1.2;
$DamageScale[dfmale, $OspreyTurretDamageType] = 1.2;
$DamageScale[dfmale, $HomingFlareDamageType] = 0.0;

$ItemMax[dfmale, MinigunAmmo] = 0;
$ItemMax[dfmale, AssRifleAmmo] = 180;
$ItemMax[dfmale, ShotgunAmmo] = 12;
$ItemMax[dfmale, GlockAmmo] = 150;
$ItemMax[dfmale, SniperRifleAmmo] = 12;
$ItemMax[dfmale, FlamerAmmo] = 300;
$ItemMax[dfmale, HomingFlareAmmo] = 0;
$ItemMax[dfmale, LaserRifle] = 0;
$ItemMax[dfmale, MAWAssRifleAmmo] = 0;
$ItemMax[dfmale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[dfmale, MAWGrenadeAmmo] = 10;
$ItemMax[dfmale, RocketLauncherAmmo] = 2;
$ItemMax[dfmale, FBWRocketAmmo] = 1;

$ItemMax[dfmale, MAWAssRifle] = 0;
$ItemMax[dfmale, MAWIncendiaryRifle] = 0;
$ItemMax[dfmale, MAWGrenadeLauncher] = 0;
$ItemMax[dfmale, HomingFlaregun] = 0;
$ItemMax[dfmale, Shotgun] = 1;
$ItemMax[dfmale, RocketLauncher] = 1;
$ItemMax[dfmale, FBWRocketLauncher] = 1;
$ItemMax[dfmale, Glock] = 1;
$ItemMax[dfmale, AssRifle] = 1;
$ItemMax[dfmale, Shotgun] = 1;
$ItemMax[dfmale, SilencedGlock] = 1;
$ItemMax[dfmale, SilencedAssRifle] = 1;
$ItemMax[dfmale, FlamerGun] = 1;
$ItemMax[dfmale, Minigun] = 0;
$ItemMax[dfmale, SniperRifle] = 1;
$ItemMax[dfmale, Detpack]  = 1;
$ItemMax[dfmale, GrenadeLauncher] = 1;
//------------------------------------
//     END
//-------------------------------------
$ItemMax[dfmale, MineAmmo] = 3;
$ItemMax[dfmale, Grenade] = 6;
$ItemMax[dfmale, Beacon]  = 0;
$ItemMax[dfmale, Detonator] = 1;
$ItemMax[dfmale, RemMineAmmo] = 6;
$ItemMax[dfmale, FlashGrenade] = 6;
$ItemMax[dfmale, ConsoleJack] = 0;

$ItemMax[dfmale, EnergyPack] = 0;
$ItemMax[dfmale, RepairPack] = 1;
//$ItemMax[dfmale, DisguisePack] = 0;
$ItemMax[dfmale, DeckPack] = 0;
$ItemMax[dfmale, SensorJammerPack] = 0;
$ItemMax[dfmale, MotionSensorPack] = 0;
$ItemMax[dfmale, PulseSensorPack] = 0;
$ItemMax[dfmale, CameraPack] = 0;
//--------------------------------------
//     SF Backpacks
//--------------------------------------
$ItemMax[dfmale, FuelPack] = 1;
$ItemMax[dfmale, MinigunAmmoPack] = 0;
$ItemMax[dfmale, DeployableMedicPack] = 0;
$ItemMax[dfmale, ReloaderPack] = 0;

$ItemMax[dfmale, TurretPack] = 0;
$ItemMax[dfmale, AmmoPack] = 1;
$ItemMax[dfmale, RepairKit] = 2;
$ItemMax[dfmale, DeployableInvPack] = 0;
$ItemMax[dfmale, DeployableAmmoPack] = 0;

$MaxWeapons[dfmale] = 16;




//----------------------------------------------------------------------------
// Turret Mount
//----------------------------------------------------------------------------

$DamageScale[tmount, $LandingDamageType] = 0;
$DamageScale[tmount, $ImpactDamageType] = 0;
$DamageScale[tmount, $CrushDamageType] = 0;
$DamageScale[tmount, $ExplosionDamageType] = 0;
$DamageScale[tmount, $DebrisDamageType] = 0;
$DamageScale[tmount, $ElectricityDamageType] = 0;
$DamageScale[tmount, $FlashDamageType] = 0;
$DamageScale[tmount, $MineDamageType] = 0;
//-------------------------------------
//     WEAPONS
//-------------------------------------
$DamageScale[tmount, $SniperRifleDamageType] = 0;
$DamageScale[tmount, $MinigunDamageType] = 0;
$DamageScale[tmount, $AssRifleDamageType] = 0;
$DamageScale[tmount, $SilencedAssRifleDamageType] = 0;
$DamageScale[tmount, $FlamerDamageType] = 0;
$DamageScale[tmount, $GlockDamageType] = 0;
$DamageScale[tmount, $SilencedGlockDamageType] = 0;
$DamageScale[tmount, $ShrapnelDamageType] = 0;
$DamageScale[tmount, $MissileDamageType] = 0;
$DamageScale[tmount, $MAWAssRifleDamageType] = 0;
$DamageScale[tmount, $MAWIncendiaryRifleDamageType] = 0;
$DamageScale[tmount, $MAWGrenadeLauncherDamageType] = 0;
$DamageScale[tmount, $ShotgunDamageType] = 0;
$DamageScale[tmount, $ComancheBulletDamageType] = 0;
$DamageScale[tmount, $ComancheImpactDamageType] = 0;
$DamageScale[tmount, $OspreyImpactDamageType] = 0;
$DamageScale[tmount, $BigCannonDamageType] = 0;
$DamageScale[tmount, $HowitzerDamageType] = 0;
$DamageScale[tmount, $OspreyTurretDamageType] = 0;
$DamageScale[tmount, $HomingFlareDamageType] = 0;

$ItemMax[tmount, MinigunAmmo] = 0;
$ItemMax[tmount, ShotgunAmmo] = 0;
$ItemMax[tmount, AssRifleAmmo] = 0;
$ItemMax[tmount, SniperRifleAmmo] = 0;
$ItemMax[tmount, HomingFlareAmmo] = 0;
$ItemMax[tmount, FlamerAmmo] = 0;
$ItemMax[tmount, GlockAmmo] = 0;
$ItemMax[tmount, MAWAssRifleAmmo] = 0;
$ItemMax[tmount, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[tmount, MAWGrenadeAmmo] = 0;
$ItemMac[tmount, RocketLauncherAmmo] = 0;
$ItemMac[tmount, FBWRocketAmmo] = 0;
$ItemMax[tmount, OspreyTurretAmmo] = 500;

$ItemMax[tmount, AssRifle] = 0;
$ItemMax[tmount, OspreyTurret] = 1;
$ItemMax[tmount, Shotgun] = 0;
$ItemMax[tmount, Glock] = 0;
$ItemMax[tmount, HomingFlaregun] = 0;
$ItemMax[tmount, RocketLauncher] = 0;
$ItemMax[tmount, FBWRocketLauncher] = 0;
$ItemMax[tmount, MAWAssRifle] = 0;
$ItemMax[tmount, MAWIncendiaryRifle] = 0;
$ItemMax[tmount, MAWGrenadeLauncher] = 0;
$ItemMax[tmount, Minigun] = 0;
$ItemMax[tmount, SniperRifle] = 0;
$ItemMax[tmount, SilencedAssRifle] = 0;
$ItemMax[tmount, SilencedGlock] = 0;
$ItemMax[tmount, FlamerGun] = 0;
$ItemMax[tmount, Detpack]  = 0;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[tmount, MineAmmo] = 0;
$ItemMax[tmount, Grenade] = 0;
$ItemMax[tmount, Beacon]  = 0;
$ItemMax[tmount, Detonator] = 0;
$ItemMax[tmount, RemMineAmmo] = 0;
$ItemMax[tmount, FlashGrenade] = 0;
$ItemMax[tmount, ConsoleJack] = 0;

$ItemMax[tmount, EnergyPack] = 0;
$ItemMax[tmount, RepairPack] = 0;
//$ItemMax[tmount, DisguisePack] = 0;
$ItemMax[tmount, DeckPack] = 0;
$ItemMax[tmount, SensorJammerPack] = 0;
$ItemMax[tmount, MotionSensorPack] = 0;
$ItemMax[tmount, PulseSensorPack] = 0;
$ItemMax[tmount, CameraPack] = 0;
//--------------------------------------
//     SF Backpacks
//--------------------------------------
$ItemMax[tmount, FuelPack] = 0;
$ItemMax[tmount, MinigunAmmoPack] = 0;
$ItemMax[tmount, DeployableMedicPack] = 0;
$ItemMax[tmount, ReloaderPack] = 0;

$ItemMax[tmount, TurretPack] = 0;
$ItemMax[tmount, AmmoPack] = 0;
$ItemMax[tmount, RepairKit] = 0;
$ItemMax[tmount, DeployableInvPack] = 0;
$ItemMax[tmount, DeployableAmmoPack] = 0;

$MaxWeapons[tmount] = 1;


//----------------------------------------------------------------------------
// Console Man - Male
//----------------------------------------------------------------------------

$DamageScale[cmmale, $LandingDamageType] = 1.0;
$DamageScale[cmmale, $ImpactDamageType] = 1.0;
$DamageScale[cmmale, $CrushDamageType] = 1.0;
$DamageScale[cmmale, $ExplosionDamageType] = 1.0;
$DamageScale[cmmale, $DebrisDamageType] = 1.2;
$DamageScale[cmmale, $ElectricityDamageType] = 1.0;
$DamageScale[cmmale, $FlashDamageType] = 1.0;
$DamageScale[cmmale, $MineDamageType] = 1.2;
//-------------------------------------
//     WEAPONS
//-------------------------------------
$DamageScale[cmmale, $SniperRifleDamageType] = 1.2;
$DamageScale[cmmale, $MinigunDamageType] = 1.2;
$DamageScale[cmmale, $AssRifleDamageType] = 1.2;
$DamageScale[cmmale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[cmmale, $FlamerDamageType] = 1.2;
$DamageScale[cmmale, $GlockDamageType] = 1.2;
$DamageScale[cmmale, $SilencedGlockDamageType] = 1.2;
$DamageScale[cmmale, $ShrapnelDamageType] = 1.2;
$DamageScale[cmmale, $MissileDamageType] = 2.0;
$DamageScale[cmmale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[cmmale, $MAWIncendiaryRifleDamageType] = 1.5;
$DamageScale[cmmale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[cmmale, $ShotgunDamageType] = 1.2;
$DamageScale[cmmale, $ComancheBulletDamageType] = 1.2;
$DamageScale[cmmale, $ComancheImpactDamageType] = 1.2;
$DamageScale[cmmale, $OspreyImpactDamageType] = 1.2;
$DamageScale[cmmale, $BigCannonDamageType] = 1.2;
$DamageScale[cmmale, $HowitzerDamageType] = 1.2;
$DamageScale[cmmale, $OspreyTurretDamageType] = 1.2;
$DamageScale[cmmale, $HomingFlareDamageType] = 0;

$ItemMax[cmmale, MinigunAmmo] = 0;
$ItemMax[cmmale, ShotgunAmmo] = 12;
$ItemMax[cmmale, AssRifleAmmo] = 90;
$ItemMax[cmmale, HomingFlareAmmo] = 20;
$ItemMax[cmmale, SniperRifleAmmo] = 0;
$ItemMax[cmmale, FlamerAmmo] = 0;
$ItemMax[cmmale, GlockAmmo] = 150;
$ItemMax[cmmale, MAWAssRifleAmmo] = 0;
$ItemMax[cmmale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[cmmale, MAWGrenadeAmmo] = 0;
$ItemMac[cmmale, RocketLauncherAmmo] = 0;
$ItemMac[cmmale, FBWRocketAmmo] = 0;

$ItemMax[cmmale, AssRifle] = 1;
$ItemMax[cmmale, Shotgun] = 1;
$ItemMax[cmmale, Glock] = 1;
$ItemMax[cmmale, HomingFlaregun] = 1;
$ItemMax[cmmale, RocketLauncher] = 0;
$ItemMax[cmmale, FBWRocketLauncher] = 0;
$ItemMax[cmmale, MAWAssRifle] = 0;
$ItemMax[cmmale, MAWIncendiaryRifle] = 0;
$ItemMax[cmmale, MAWGrenadeLauncher] = 0;
$ItemMax[cmmale, Minigun] = 0;
$ItemMax[cmmale, SniperRifle] = 0;
$ItemMax[cmmale, SilencedAssRifle] = 0;
$ItemMax[cmmale, SilencedGlock] = 0;
$ItemMax[cmmale, FlamerGun] = 0;
$ItemMax[cmmale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[cmmale, MineAmmo] = 3;
$ItemMax[cmmale, Grenade] = 5;
$ItemMax[cmmale, Beacon]  = 0;
$ItemMax[cmmale, Detonator] = 1;
$ItemMax[cmmale, ConsoleJack] = 1;

$ItemMax[cmmale, TargetingLaser] = 0;
$ItemMax[cmmale, RemMineAmmo] = 3;
$ItemMax[cmmale, FlashGrenade] = 3;

$ItemMax[cmmale, EnergyPack] = 0;
$ItemMax[cmmale, RepairPack] = 1;
$ItemMax[cmmale, SensorJammerPack] = 0;
$ItemMax[cmmale, MotionSensorPack] = 1;
$ItemMax[cmmale, PulseSensorPack] = 1;
$ItemMax[cmmale, CameraPack] = 1;
//--------------------------------------
//     SF Backpacks
//--------------------------------------
$ItemMax[cmmale, DeckPack] = 1;
//$ItemMax[cmmale, DisguisePack] = 0;
$ItemMax[cmmale, BugPack] = 0;
$ItemMax[cmmale, FuelPack] = 0;
$ItemMax[cmmale, MinigunAmmoPack] = 0;
$ItemMax[cmmale, DeployableMedicPack] = 0;
$ItemMax[cmmale, ReloaderPack] = 1;

$ItemMax[cmmale, GRoCCannonPack] = 1;
$ItemMax[cmmale, TurretPack] = 1;
$ItemMax[cmmale, AmmoPack] = 1;
$ItemMax[cmmale, RepairKit] = 1;
$ItemMax[cmmale, DeployableInvPack] = 0;
$ItemMax[cmmale, DeployableAmmoPack] = 0;

$MaxWeapons[cmmale] = 2;

//----------------------------------------------------------------------------
// SpecialOps - Male
//----------------------------------------------------------------------------

$DamageScale[somale, $LandingDamageType] = 1.0;
$DamageScale[somale, $ImpactDamageType] = 1.0;
$DamageScale[somale, $CrushDamageType] = 1.0;
$DamageScale[somale, $ExplosionDamageType] = 1.0;
$DamageScale[somale, $DebrisDamageType] = 1.2;
$DamageScale[somale, $ElectricityDamageType] = 1.0;
$DamageScale[somale, $MineDamageType] = 1.2;
$DamageScale[somale, $FlashDamageType] = 1.0;
//-------------------------------------
//     WEAPONS
//-------------------------------------
$DamageScale[somale, $ShrapnelDamageType] = 1.2;
$DamageScale[somale, $SniperRifleDamageType] = 1.2;
$DamageScale[somale, $MinigunDamageType] = 1.2;
$DamageScale[somale, $AssRifleDamageType] = 1.2;
$DamageScale[somale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[somale, $FlamerDamageType] = 1.2;
$DamageScale[somale, $GlockDamageType] = 1.2;
$DamageScale[somale, $SilencedGlockDamageType] = 1.2;
$DamageScale[somale, $MissileDamageType] = 2.0;
$DamageScale[somale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[somale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[somale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[somale, $ShotgunDamageType] = 1.2;
$DamageScale[somale, $ComancheBulletDamageType] = 1.2;
$DamageScale[somale, $ComancheImpactDamageType] = 1.2;
$DamageScale[somale, $OspreyImpactDamageType] = 1.2;
$DamageScale[somale, $BigCannonDamageType] = 1.2;
$DamageScale[somale, $HowitzerDamageType] = 1.2;
$DamageScale[somale, $OspreyTurretDamageType] = 1.2;
$DamageScale[somale, $HomingFlareDamageType] = 0;

$ItemMax[somale, MinigunAmmo] = 0;
$ItemMax[somale, ShotgunAmmo] = 12;
$ItemMax[somale, RocketLauncherAmmo] = 0;
$ItemMax[somale, FBWRocketAmmo] = 0;
$ItemMax[somale, AssRifleAmmo] = 120;
$ItemMax[somale, SniperRifleAmmo] = 10;
$ItemMax[somale, FlamerAmmo] = 0;
$ItemMax[somale, GlockAmmo] = 150;
$ItemMax[somale, HomingFlareAmmo] = 0;
$ItemMax[somale, LaserRifle] = 0;
$ItemMax[somale, MAWAssRifleAmmo] = 0;
$ItemMax[somale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[somale, MAWGrenadeAmmo] = 0;

$ItemMax[somale, SniperRifle] = 1;
$ItemMax[somale, Shotgun] = 1;
$ItemMax[somale, Glock] = 1;
$ItemMax[somale, SilencedGlock] = 1;
$ItemMax[somale, AssRifle] = 1;
$ItemMax[somale, SilencedAssRifle] = 1;
$ItemMax[somale, RocketLauncher] = 0;
$ItemMax[somale, FBWRocketLauncher] = 0;
$ItemMax[somale, MAWAssRifle] = 0;
$ItemMax[somale, MAWIncendiaryRifle] = 0;
$ItemMax[somale, MAWGrenadeLauncher] = 0;
$ItemMax[somale, Minigun] = 0;
$ItemMax[somale, FlamerGun] = 0;
$ItemMax[somale, HomingFlaregun] = 0;
$ItemMax[somale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[somale, MineAmmo] = 3;
$ItemMax[somale, Grenade] = 4;
$ItemMax[somale, Beacon] = 0;
$ItemMax[somale, Detonator] = 1;
$ItemMax[somale, TargetingLaser] = 0;
$ItemMax[somale, RemMineAmmo] = 3;
$ItemMax[somale, FlashGrenade] = 6;
$ItemMax[somale, ConsoleJack] = 0;

$ItemMax[somale, EnergyPack] = 0;
$ItemMax[somale, RepairPack] = 1;

$ItemMax[somale, MotionSensorPack] = 1;
$ItemMax[somale, PulseSensorPack] = 1;
$ItemMax[somale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
//$ItemMax[somale, DisguisePack] = 1;
$ItemMax[somale, DeckPack] = 0;
$ItemMax[somale, MinigunAmmoPack] = 0;
$ItemMax[somale, FuelPack] = 0;
$ItemMax[somale, DeployableMedicPack] = 0;
$ItemMax[somale, ReloaderPack] = 1;
$ItemMax[somale, BugPack] = 1;
$ItemMax[somale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[somale, TurretPack] = 0;
$ItemMax[somale, AmmoPack] = 1;
$ItemMax[somale, RepairKit] = 1;
$ItemMax[somale, DeployableInvPack] = 0;
$ItemMax[somale, DeployableAmmoPack] = 0;

$MaxWeapons[somale] = 2;

//----------------------------------------------------------------------------
// Infantry - Male
//----------------------------------------------------------------------------

$DamageScale[imale, $LandingDamageType] = 1.0;
$DamageScale[imale, $ImpactDamageType] = 1.0;
$DamageScale[imale, $CrushDamageType] = 1.0;
$DamageScale[imale, $ExplosionDamageType] = 1.0;
$DamageScale[imale, $DebrisDamageType] = 1.0;
$DamageScale[imale, $ElectricityDamageType] = 1.0;
$DamageScale[imale, $MineDamageType] = 1.0;
$DamageScale[imale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[imale, $ShrapnelDamageType] = 1.0;
$DamageScale[imale, $SniperRifleDamageType] = 1.2;
$DamageScale[imale, $MinigunDamageType] = 1.2;
$DamageScale[imale, $AssRifleDamageType] = 1.2;
$DamageScale[imale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[imale, $FlamerDamageType] = 1.2;
$DamageScale[imale, $GlockDamageType] = 1.2;
$DamageScale[imale, $SilencedGlockDamageType] = 1.2;
$DamageScale[imale, $MissileDamageType] = 1.7;
$DamageScale[imale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[imale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[imale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[imale, $ShotgunDamageType] = 1.2;
$DamageScale[imale, $ComancheBulletDamageType] = 1.2;
$DamageScale[imale, $ComancheImpactDamageType] = 1.2;
$DamageScale[imale, $OspreyImpactDamageType] = 1.2;
$DamageScale[imale, $BigCannonDamageType] = 1.2;
$DamageScale[imale, $HowitzerDamageType] = 1.2;
$DamageScale[imale, $OspreyTurretDamageType] = 1.2;
$DamageScale[imale, $HomingFlareDamageType] = 0;

$ItemMax[imale, MinigunAmmo] = 0;
$ItemMax[imale, AssRifleAmmo] = 120;
$ItemMax[imale, ShotgunAmmo] = 12;
$ItemMax[imale, GlockAmmo] = 150;
$ItemMax[imale, SniperRifleAmmo] = 0;
$ItemMax[imale, FlamerAmmo] = 0;
$ItemMax[imale, LaserRifle] = 0;
$ItemMax[imale, MAWAssRifleAmmo] = 0;
$ItemMax[imale, HomingFlareAmmo] = 0;
$ItemMax[imale, MAWIncendiaryRifleAmmo] = 10;
$ItemMax[imale, MAWGrenadeAmmo] = 12;
$ItemMax[imale, RocketLauncherAmmo] = 1;
$ItemMax[imale, FBWRocketAmmo] = 1;

$ItemMax[imale, MAWAssRifle] = 1;
$ItemMax[imale, MAWIncendiaryRifle] = 1;
$ItemMax[imale, MAWGrenadeLauncher] = 1;
$ItemMax[imale, Shotgun] = 1;
$ItemMax[imale, RocketLauncher] = 1;
$ItemMax[imale, FBWRocketLauncher] = 1;
$ItemMax[imale, Glock] = 1;
$ItemMax[imale, AssRifle] = 1;
$ItemMax[imale, Shotgun] = 1;
$ItemMax[imale, SilencedGlock] = 0;
$ItemMax[imale, SilencedAssRifle] = 0;
$ItemMax[imale, FlamerGun] = 1;
$ItemMax[imale, Minigun] = 0;
$ItemMax[imale, SniperRifle] = 0;
$ItemMax[imale, HomingFlaregun] = 0;
$ItemMax[imale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[imale, Detonator] = 1;
$ItemMax[imale, TargetingLaser] = 0;
$ItemMax[imale, RemMineAmmo] = 3;
$ItemMax[imale, MineAmmo] = 3;
$ItemMax[imale, Grenade] = 6;
$ItemMax[imale, Beacon] = 0;
$ItemMax[imale, FlashGrenade] = 3;
$ItemMax[imale, ConsoleJack] = 0;

$ItemMax[imale, EnergyPack] = 0;
$ItemMax[imale, RepairPack] = 1;
//$ItemMax[imale, DisguisePack] = 0;
$ItemMax[imale, DeckPack] = 0;
$ItemMax[imale, MotionSensorPack] = 1;
$ItemMax[imale, PulseSensorPack] = 1;
$ItemMax[imale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[imale, MinigunAmmoPack] = 0;
$ItemMax[imale, FuelPack] = 0;
$ItemMax[imale, DeployableMedicPack] = 1;
$ItemMax[imale, ReloaderPack] = 1;
$ItemMax[imale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[imale, TurretPack] = 1;
$ItemMax[imale, AmmoPack] = 1;
$ItemMax[imale, RepairKit] = 1;
$ItemMax[imale, DeployableInvPack] = 0;
$ItemMax[imale, DeployableAmmoPack] = 0;

$MaxWeapons[imale] = 3;

//----------------------------------------------------------------------------
// Heavy Infantry - Male
//----------------------------------------------------------------------------

$DamageScale[himale, $LandingDamageType] = 1.0;
$DamageScale[himale, $ImpactDamageType] = 1.0;
$DamageScale[himale, $CrushDamageType] = 1.0;
$DamageScale[himale, $ExplosionDamageType] = 0.6;
$DamageScale[himale, $DebrisDamageType] = 0.8;
$DamageScale[himale, $ElectricityDamageType] = 1.0;
$DamageScale[himale, $MineDamageType] = 0.8;
$DamageScale[himale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[himale, $ShrapnelDamageType] = 0.8;
$DamageScale[himale, $SniperRifleDamageType] = 1.0;
$DamageScale[himale, $MinigunDamageType] = 1.0;
$DamageScale[himale, $AssRifleDamageType] = 0.8;
$DamageScale[himale, $SilencedAssRifleDamageType] = 0.8;
$DamageScale[himale, $FlamerDamageType] = 1.0;
$DamageScale[himale, $GlockDamageType] = 0.8;
$DamageScale[himale, $SilencedGlockDamageType] = 0.8;
$DamageScale[himale, $MissileDamageType] = 1.2;
$DamageScale[himale, $MAWAssRifleDamageType] = 0.8;
$DamageScale[himale, $MAWIncendiaryRifleDamageType] = 0.8;
$DamageScale[himale, $MAWGrenadeLauncherDamageType] = 0.8;
$DamageScale[himale, $ShotgunDamageType] = 1.2;
$DamageScale[himale, $ComancheBulletDamageType] = 0.8;
$DamageScale[himale, $ComancheImpactDamageType] = 1.0;
$DamageScale[himale, $OspreyImpactDamageType] = 1.0;
$DamageScale[himale, $BigCannonDamageType] = 1.0;
$DamageScale[himale, $HowitzerDamageType] = 1.0;
$DamageScale[himale, $OspreyTurretDamageType] = 1.0;
$DamageScale[himale, $HomingFlareDamageType] = 0;

$ItemMax[himale, MinigunAmmo] = 0;
$ItemMax[himale, GlockAmmo] = 300;
$ItemMax[himale, AssRifleAmmo] = 240;
$ItemMax[himale, ShotgunAmmo] = 24;
$ItemMax[himale, SniperRifleAmmo] = 0;
$ItemMax[himale, HomingFlareAmmo] = 0;
$ItemMax[himale, MAWGrenadeAmmo] = 0;
$ItemMax[himale, MAWAssRifleAmmo] = 0;
$ItemMax[himale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[himale, RocketLauncherAmmo] = 0;
$ItemMax[himale, FBWRocketAmmo] = 0;
$ItemMax[himale, FlamerAmmo] = 0;

$ItemMax[himale, MAWAssRifle] = 0;
$ItemMax[himale, MAWIncendiaryRifle] = 0;
$ItemMax[himale, MAWGrenadeLauncher] = 0;
$ItemMax[himale, HomingFlaregun] = 0;
$ItemMax[himale, RocketLauncher] = 0;
$ItemMax[himale, FBWRocketLauncher] = 0;
$ItemMax[himale, Shotgun] = 1;
$ItemMax[himale, Minigun] = 1;
$ItemMax[himale, Glock] = 1;
$ItemMax[himale, AssRifle] = 1;
$ItemMax[himale, SilencedGlock] = 0;
$ItemMax[himale, SilencedAssRifle] = 0;
$ItemMax[himale, SniperRifle] = 0;
$ItemMax[himale, FlamerGun] = 0;
$ItemMax[himale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[himale, MineAmmo] = 6;
$ItemMax[himale, Grenade] = 9;
$ItemMax[himale, Beacon] = 0;
$ItemMax[himale, Detonator] = 1;
$ItemMax[himale, RemMineAmmo] = 6;
$ItemMax[himale, FlashGrenade] = 3;
$ItemMax[himale, TargetingLaser] = 0;
$ItemMax[himale, ConsoleJack] = 0;

$ItemMax[himale, RepairPack] = 1;
//$ItemMax[himale, DisguisePack] = 0;
$ItemMax[himale, DeckPack] = 0;
$ItemMax[himale, MotionSensorPack] = 1;
$ItemMax[himale, PulseSensorPack] = 1;
$ItemMax[himale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[himale, MinigunAmmoPack] = 1;
$ItemMax[himale, FuelPack] = 0;
$ItemMax[himale, DeployableMedicPack] = 1;
$ItemMax[himale, ReloaderPack] = 1;
$ItemMax[himale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[himale, TurretPack] = 1;
$ItemMax[himale, AmmoPack] = 1;
$ItemMax[himale, RepairKit] = 1;
$ItemMax[himale, DeployableInvPack] = 1;
$ItemMax[himale, DeployableAmmoPack] = 1;

$MaxWeapons[himale] = 2;

//----------------------------------------------------------------------------
// Console Man - Female
//----------------------------------------------------------------------------

$DamageScale[cmfemale, $LandingDamageType] = 1.0;
$DamageScale[cmfemale, $ImpactDamageType] = 1.0;
$DamageScale[cmfemale, $CrushDamageType] = 1.0;
$DamageScale[cmfemale, $ExplosionDamageType] = 1.0;
$DamageScale[cmfemale, $DebrisDamageType] = 1.2;
$DamageScale[cmfemale, $ElectricityDamageType] = 1.0;
$DamageScale[cmfemale, $MineDamageType] = 1.2;
$DamageScale[cmfemale, $FlashDamageType] = 1.0;
//-------------------------------------
//     WEAPONS
//-------------------------------------
$DamageScale[cmfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[cmfemale, $SniperRifleDamageType] = 1.2;
$DamageScale[cmfemale, $MinigunDamageType] = 1.2;
$DamageScale[cmfemale, $AssRifleDamageType] = 1.2;
$DamageScale[cmfemale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[cmfemale, $GlockDamageType] = 1.2;
$DamageScale[cmfemale, $SilencedGlockDamageType] = 1.2;
$DamageScale[cmfemale, $FlamerDamageType] = 1.2;
$DamageScale[cmfemale, $MissileDamageType] = 2.0;
$DamageScale[cmfemale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[cmfemale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[cmfemale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[cmfemale, $ShotgunDamageType] = 1.2;
$DamageScale[cmfemale, $ComancheBulletDamageType] = 1.2;
$DamageScale[cmfemale, $ComancheImpactDamageType] = 1.2;
$DamageScale[cmfemale, $OspreyImpactDamageType] = 1.2;
$DamageScale[cmfemale, $BigCannonDamageType] = 1.2;
$DamageScale[cmfemale, $HowitzerDamageType] = 1.2;
$DamageScale[cmfemale, $OspreyTurretDamageType] = 1.2;
$DamageScale[cmfemale, $HomingFlareDamageType] = 0;

$ItemMax[cmfemale, MinigunAmmo] = 0;
$ItemMax[cmfemale, AssRifleAmmo] = 120;
$ItemMax[cmfemale, GlockAmmo] = 150;
$ItemMax[cmfemale, ShotgunAmmo] = 12;
$ItemMax[cmfemale, SniperRifleAmmo] = 0;
$ItemMax[cmfemale, MAWGrenadeAmmo] = 0;
$ItemMax[cmfemale, MAWAssRifleAmmo] = 0;
$ItemMax[cmfemale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[cmfemale, FlamerAmmo] = 0;
$ItemMax[cmfemale, RocketLauncherAmmo] = 0;
$ItemMax[cmfemale, FBWRocketAmmo] = 0;
$ItemMax[cmfemale, HomingFlareAmmo] = 20;

$ItemMax[cmfemale, AssRifle] = 1;
$ItemMax[cmfemale, SilencedAssRifle] = 0;
$ItemMax[cmfemale, Glock] = 1;
$ItemMax[cmfemale, Shotgun] = 1;
$ItemMax[cmfemale, HomingFlaregun] = 1;
$ItemMax[cmfemale, SilencedGlock] = 0;
$ItemMax[cmfemale, MAWAssRifle] = 0;
$ItemMax[cmfemale, MAWIncendiaryRifle] = 0;
$ItemMax[cmfemale, MAWGrenadeLauncher] = 0;
$ItemMax[cmfemale, RocketLauncher] = 0;
$ItemMax[cmfemale, FBWRocketLauncher] = 0;
$ItemMax[cmfemale, Minigun] = 0;
$ItemMax[cmfemale, SniperRifle] = 0;
$ItemMax[cmfemale, FlamerGun] = 0;
$ItemMax[cmfemale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[cmfemale, MineAmmo] = 3;
$ItemMax[cmfemale, Grenade] = 5;
$ItemMax[cmfemale, Beacon]  = 0;
$ItemMax[cmfemale, Detonator] = 1;
$ItemMax[cmfemale, RemMineAmmo] = 3;
$ItemMax[cmfemale, FlashGrenade] = 3;
$ItemMax[cmfemale, TargetingLaser] = 0;
$ItemMax[cmfemale, ConsoleJack] = 1;

$ItemMax[cmfemale, EnergyPack] = 0;
$ItemMax[cmfemale, RepairPack] = 1;
//$ItemMax[cmfemale, DisguisePack] = 0;
$ItemMax[cmfemale, DeckPack] = 1;
$ItemMax[cmfemale, SensorJammerPack] = 0;
$ItemMax[cmfemale, MotionSensorPack] = 1;
$ItemMax[cmfemale, PulseSensorPack] = 1;
$ItemMax[cmfemale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[cmfemale, MinigunAmmoPack] = 0;
$ItemMax[cmfemale, FuelPack] = 0;
$ItemMax[cmfemale, DeployableMedicPack] = 0;
$ItemMax[cmfemale, ReloaderPack] = 1;
$ItemMax[cmfemale, GRoCCannonPack] = 1;
//*****************************************************************************
$ItemMax[cmfemale, TurretPack] = 1;
$ItemMax[cmfemale, AmmoPack] = 1;
$ItemMax[cmfemale, RepairKit] = 1;
$ItemMax[cmfemale, DeployableInvPack] = 0;
$ItemMax[cmfemale, DeployableAmmoPack] = 0;

$MaxWeapons[cmfemale] = 2;

//----------------------------------------------------------------------------
// Special Ops - Female
//----------------------------------------------------------------------------

$DamageScale[sofemale, $LandingDamageType] = 1.0;
$DamageScale[sofemale, $ImpactDamageType] = 1.0;	
$DamageScale[sofemale, $CrushDamageType] = 1.0;	
$DamageScale[sofemale, $ExplosionDamageType] = 1.0;
$DamageScale[sofemale, $DebrisDamageType] = 1.2;
$DamageScale[sofemale, $ElectricityDamageType] = 1.0;
$DamageScale[sofemale, $MineDamageType] = 1.2;
$DamageScale[sofemale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[sofemale, $ShrapnelDamageType] = 1.2;
$DamageScale[sofemale, $SniperRifleDamageType] = 1.2;
$DamageScale[sofemale, $MinigunDamageType] = 1.2;
$DamageScale[sofemale, $GlockDamageType] = 1.2;
$DamageScale[sofemale, $AssRifleDamageType] = 1.2;
$DamageScale[sofemale, $SilencedGlockDamageType] = 1.2;
$DamageScale[sofemale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[sofemale, $FlamerDamageType] = 1.2;
$DamageScale[sofemale, $MissileDamageType] = 2.0;
$DamageScale[sofemale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[sofemale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[sofemale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[sofemale, $ShotgunDamageType] = 1.2;
$DamageScale[sofemale, $ComancheBulletDamageType] = 1.2;
$DamageScale[sofemale, $ComancheImpactDamageType] = 1.2;
$DamageScale[sofemale, $OspreyImpactDamageType] = 1.2;
$DamageScale[sofemale, $BigCannonDamageType] = 1.2;
$DamageScale[sofemale, $HowitzerDamageType] = 1.2;
$DamageScale[sofemale, $OspreyTurretDamageType] = 1.2;
$DamageScale[sofemale, $HomingFlareDamageType] = 0;

$ItemMax[sofemale, MinigunAmmo] = 0;
$ItemMax[sofemale, ShotgunAmmo] = 12;
$ItemMax[sofemale, AssRifleAmmo] = 120;
$ItemMax[sofemale, GlockAmmo] = 150;
$ItemMax[sofemale, SniperRifleAmmo] = 10;
$ItemMax[sofemale, MAWAssRifleAmmo] = 0;
$ItemMax[sofemale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[sofemale, MAWGrenadeAmmo] = 0;
$ItemMax[sofemale, FlamerAmmo] = 0;
$ItemMax[sofemale, RocketLauncherAmmo] = 0;
$ItemMax[sofemale, FBWRocketAmmo] = 0;
$ItemMax[sofemale, HomingFlareAmmo] = 0;

$ItemMax[sofemale, Glock] = 1;
$ItemMax[sofemale, SilencedGlock] = 1;
$ItemMax[sofemale, Shotgun] = 1;
$ItemMax[sofemale, SniperRifle] = 1;
$ItemMax[sofemale, HomingFlaregun] = 0;
$ItemMax[sofemale, MAWAssRifle] = 0;
$ItemMax[sofemale, MAWIncendiaryRifle] = 0;
$ItemMax[sofemale, MAWGrenadeLauncher] = 0;
$ItemMax[sofemale, RocketLauncher] = 0;
$ItemMax[sofemale, Minigun] = 0;
$ItemMax[sofemale, AssRifle] = 1;
$ItemMax[sofemale, SilencedAssRifle] = 1;
$ItemMax[sofemale, FlamerGun] = 0;
$ItemMax[sofemale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------
$ItemMax[sofemale, MineAmmo] = 3;
$ItemMax[sofemale, Grenade] = 4;
$ItemMax[sofemale, Beacon] = 0;
$ItemMax[sofemale, Detonator] = 1;
$ItemMax[sofemale, RemMineAmmo] = 3;
$ItemMax[sofemale, FlashGrenade] = 6;
$ItemMax[sofemale, TargetingLaser] = 0;
$ItemMax[sofemale, ConsoleJack] = 0;

$ItemMax[sofemale, EnergyPack] = 0;
$ItemMax[sofemale, RepairPack] = 1;
//$ItemMax[sofemale, DisguisePack] = 1;
$ItemMax[sofemale, DeckPack] = 0;
$ItemMax[sofemale, BugPack] = 1;
$ItemMax[sofemale, MotionSensorPack] = 1;
$ItemMax[sofemale, PulseSensorPack] = 1;
$ItemMax[sofemale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[sofemale, MinigunAmmoPack] = 0;
$ItemMax[sofemale, FuelPack] = 0;
$ItemMax[sofemale, DeployableMedicPack] = 0;
$ItemMax[sofemale, ReloaderPack] = 1;
$ItemMax[sofemale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[sofemale, TurretPack] = 0;
$ItemMax[sofemale, AmmoPack] = 1;
$ItemMax[sofemale, RepairKit] = 1;
$ItemMax[sofemale, DeployableInvPack] = 0;
$ItemMax[sofemale, DeployableAmmoPack] = 0;

$MaxWeapons[sofemale] = 2;

//----------------------------------------------------------------------------
// Infantry - Female
//----------------------------------------------------------------------------

$DamageScale[ifemale, $LandingDamageType] = 1.0;
$DamageScale[ifemale, $ImpactDamageType] = 1.0;
$DamageScale[ifemale, $CrushDamageType] = 1.0;
$DamageScale[ifemale, $ExplosionDamageType] = 1.0;
$DamageScale[ifemale, $DebrisDamageType] = 1.0;
$DamageScale[ifemale, $ElectricityDamageType] = 1.0;
$DamageScale[ifemale, $MineDamageType] = 1.0;
$DamageScale[ifemale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[ifemale, $SniperRifleDamageType] = 1.2;
$DamageScale[ifemale, $MinigunDamageType] = 1.2;
$DamageScale[ifemale, $AssRifleDamageType] = 1.2;
$DamageScale[ifemale, $SilencedAssRifleDamageType] = 1.2;
$DamageScale[ifemale, $FlamerDamageType] = 1.2;
$DamageScale[ifemale, $GlockDamageType] = 1.2;
$DamageScale[ifemale, $SilencedGlockDamageType] = 1.2;
$DamageScale[ifemale, $ShrapnelDamageType] = 1.0;
$DamageScale[ifemale, $MissileDamageType] = 1.7;
$DamageScale[ifemale, $MAWAssRifleDamageType] = 1.2;
$DamageScale[ifemale, $MAWIncendiaryRifleDamageType] = 1.2;
$DamageScale[ifemale, $MAWGrenadeLauncherDamageType] = 1.2;
$DamageScale[ifemale, $ShotgunDamageType] = 1.2;
$DamageScale[ifemale, $ComancheBulletDamageType] = 1.2;
$DamageScale[ifemale, $ComancheImpactDamageType] = 1.2;
$DamageScale[ifemale, $OspreyImpactDamageType] = 1.2;
$DamageScale[ifemale, $BigCannonDamageType] = 1.2;
$DamageScale[ifemale, $HowitzerDamageType] = 1.2;
$DamageScale[ifemale, $OspreyTurretDamageType] = 1.2;
$DamageScale[ifemale, $HomingFlareDamageType] = 0;

$ItemMax[ifemale, MinigunAmmo] = 0;
$ItemMax[ifemale, AssRifleAmmo] = 120;
$ItemMax[ifemale, GlockAmmo] = 150;
$ItemMax[ifemale, ShotgunAmmo] = 12;
$ItemMax[ifemale, SniperRifleAmmo] = 0;
$ItemMax[ifemale, HomingFlareAmmo] = 0;
$ItemMax[ifemale, FlamerAmmo] = 0;
$ItemMax[ifemale, MAWAssRifleAmmo] = 0;
$ItemMax[ifemale, MAWIncendiaryRifleAmmo] = 10;
$ItemMax[ifemale, MAWGrenadeAmmo] = 12;
$ItemMax[ifemale, RocketLauncherAmmo] = 1;
$ItemMax[ifemale, FBWRocketAmmo] = 1;

$ItemMax[ifemale, MAWAssRifle] = 1;
$ItemMax[ifemale, MAWIncendiaryRifle] = 1;
$ItemMax[ifemale, MAWGrenadeLauncher] = 1;
$ItemMax[ifemale, RocketLauncher] = 1;
$ItemMax[ifemale, FBWRocketLauncher] = 1;
$ItemMax[ifemale, Glock] = 1;
$ItemMax[ifemale, AssRifle] = 1;
$ItemMax[ifemale, Shotgun] = 1;
$ItemMax[ifemale, HomingFlaregun] = 0;
$ItemMax[ifemale, SilencedGlock] = 0;
$ItemMax[ifemale, SilencedAssRifle] = 0;
$ItemMax[ifemale, FlamerGun] = 0;
$ItemMax[ifemale, SniperRifle] = 0;
$ItemMax[ifemale, Minigun] = 0;
$ItemMax[ifemale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[ifemale, MineAmmo] = 3;
$ItemMax[ifemale, Grenade] = 6;
$ItemMax[ifemale, Beacon] = 0;
$ItemMax[ifemale, Detonator] = 1;
$ItemMax[ifemale, RemMineAmmo] = 3;
$ItemMax[ifemale, FlashGrenade] = 3;
$ItemMax[ifemale, TargetingLaser] = 0;
$ItemMax[ifemale, ConsoleJack] = 0;

$ItemMax[ifemale, EnergyPack] = 0;
$ItemMax[ifemale, RepairPack] = 1;
//$ItemMax[ifemale, DisguisePack] = 0;
$ItemMax[ifemale, DeckPack] = 0;
$ItemMax[ifemale, MotionSensorPack] = 1;
$ItemMax[ifemale, PulseSensorPack] = 1;
$ItemMax[ifemale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[ifemale, MinigunAmmoPack] = 0;
$ItemMax[ifemale, FuelPack] = 1;
$ItemMax[ifemale, DeployableMedicPack] = 1;
$ItemMax[ifemale, ReloaderPack] = 1;
$ItemMax[ifemale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[ifemale, TurretPack] = 1;
$ItemMax[ifemale, AmmoPack] = 1;
$ItemMax[ifemale, RepairKit] = 1;
$ItemMax[ifemale, DeployableInvPack] = 0;
$ItemMax[ifemale, DeployableAmmoPack] = 0;

$MaxWeapons[ifemale] = 3;

//----------------------------------------------------------------------------
// Heavy Infantry - Female
//----------------------------------------------------------------------------

$DamageScale[hifemale, $LandingDamageType] = 1.0;
$DamageScale[hifemale, $ImpactDamageType] = 1.0;
$DamageScale[hifemale, $CrushDamageType] = 1.0;
$DamageScale[hifemale, $ExplosionDamageType] = 0.6;
$DamageScale[hifemale, $DebrisDamageType] = 0.8;
$DamageScale[hifemale, $ElectricityDamageType] = 1.0;
$DamageScale[hifemale, $MineDamageType] = 0.8;
$DamageScale[hifemale, $FlashDamageType] = 1.0;
//------------------------------------
//Addition - weapons
//------------------------------------
$DamageScale[hifemale, $ShrapnelDamageType] = 0.8;
$DamageScale[hifemale, $SniperRifleDamageType] = 1.0;
$DamageScale[hifemale, $MinigunDamageType] = 1.0;
$DamageScale[hifemale, $AssRifleDamageType] = 0.8;
$DamageScale[hifemale, $SilencedAssRifleDamageType] = 0.8;
$DamageScale[hifemale, $FlamerDamageType] = 1.0;
$DamageScale[hifemale, $GlockDamageType] = 0.8;
$DamageScale[hifemale, $SilencedGlockDamageType] = 0.8;
$DamageScale[hifemale, $MissileDamageType] = 1.2;
$DamageScale[hifemale, $MAWAssRifleDamageType] = 0.8;
$DamageScale[hifemale, $MAWIncendiaryRifleDamageType] = 0.8;
$DamageScale[hifemale, $MAWGrenadeLauncherDamageType] = 0.8;
$DamageScale[hifemale, $ShotgunDamageType] = 1.2;
$DamageScale[hifemale, $ComancheBulletDamageType] = 0.8;
$DamageScale[hifemale, $ComancheImpactDamageType] = 1.0;
$DamageScale[hifemale, $OspreyImpactDamageType] = 1.0;
$DamageScale[hifemale, $BigCannonDamageType] = 1.0;
$DamageScale[hifemale, $HowitzerDamageType] = 1.0;
$DamageScale[hifemale, $OspreyTurretDamageType] = 1.0;
$DamageScale[hifemale, $HomingFlareDamageType] = 0;

$ItemMax[hifemale, MinigunAmmo] = 0;
$ItemMax[hifemale, AssRifleAmmo] = 240;
$ItemMax[hifemale, GlockAmmo] = 300;
$ItemMax[hifemale, ShotgunAmmo] = 12;
$ItemMax[hifemale, SniperRifleAmmo] = 0;
$ItemMax[hifemale, FlamerAmmo] = 0;
$ItemMax[hifemale, HomingFlareAmmo] = 0;
$ItemMax[hifemale, MAWAssRifleAmmo] = 0;
$ItemMax[hifemale, MAWIncendiaryRifleAmmo] = 0;
$ItemMax[hifemale, MAWGrenadeAmmo] = 0;
$ItemMax[hifemale, RocketLauncherAmmo] = 0;
$ItemMax[hifemale, FBWRocketAmmo] = 0;

$ItemMax[hifemale, Minigun] = 1;
$ItemMax[hifemale, Glock] = 1;
$ItemMax[hifemale, Shotgun] = 1;
$ItemMax[hifemale, SilencedGlock] = 0;
$ItemMax[hifemale, MAWAssRifle] = 0;
$ItemMax[hifemale, MAWIncendiaryRifle] = 0;
$ItemMax[hifemale, MAWGrenadeLauncher] = 0;
$ItemMax[hifemale, RocketLauncher] = 0;
$ItemMax[hifemale, FBWRocketLauncher] = 0;
$ItemMax[hifemale, AssRifle] = 1;
$ItemMax[hifemale, SilencedAssRifle] = 0;
$ItemMax[hifemale, SniperRifle] = 0;
$ItemMax[hifemale, FlamerGun] = 0;
$ItemMax[hifemale, HomingFlaregun] = 0;
$ItemMax[hifemale, Detpack]  = 1;
//-------------------------------------
//     END
//-------------------------------------

$ItemMax[hifemale, MineAmmo] = 3;
$ItemMax[hifemale, Grenade] = 9;
$ItemMax[hifemale, Beacon] = 0;
$ItemMax[hifemale, Detonator] = 1;
$ItemMax[hifemale, RemMineAmmo] = 3;
$ItemMax[hifemale, FlashGrenade] = 3;
$ItemMax[hifemale, TargetingLaser] = 0;
$ItemMax[hifemale, ConsoleJack] = 0;

$ItemMax[hifemale, RepairPack] = 1;
//$ItemMax[hifemale, DisguisePack] = 0;
$ItemMax[hifemale, DeckPack] = 0;
$ItemMax[hifemale, MotionSensorPack] = 1;
$ItemMax[hifemale, PulseSensorPack] = 1;
$ItemMax[hifemale, CameraPack] = 1;
//*****************************************************************************
//     SF Backpacks
//*****************************************************************************
$ItemMax[hifemale, MinigunAmmoPack] = 1;
$ItemMax[hifemale, FuelPack] = 0;
$ItemMax[hifemale, DeployableMedicPack] = 1;
$ItemMax[hifemale, ReloaderPack] = 1;
$ItemMax[hifemale, GRoCCannonPack] = 0;
//*****************************************************************************
$ItemMax[hifemale, TurretPack] = 1;
$ItemMax[hifemale, AmmoPack] = 1;
$ItemMax[hifemale, RepairKit] = 1;
$ItemMax[hifemale, DeployableInvPack] = 1;
$ItemMax[hifemale, DeployableAmmoPack] = 1;

$MaxWeapons[hifemale] = 2;
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************




//------------------------------------------------------------------
// Console Man - Male data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/7/99 - 11:30PM
//*************************************************************************************************************

DamageSkinData armorDamageSkins
{
	bmpName[0] = "dskin1_armor";
	bmpName[1] = "dskin2_armor";
	bmpName[2] = "dskin3_armor";
	bmpName[3] = "dskin4_armor";
	bmpName[4] = "dskin5_armor";
	bmpName[5] = "dskin6_armor";
	bmpName[6] = "dskin7_armor";
	bmpName[7] = "dskin8_armor";
	bmpName[8] = "dskin9_armor";
	bmpName[9] = "dskin10_armor";
};

PlayerData cmmale
{
	className = "Armor";
	shapeFile = "cmmale";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
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
	
	jetSound = NoSound;
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
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Special Ops - Male data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************
PlayerData somale
{
	className = "Armor";
	shapeFile = "somale";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	visibleToSensor = true;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
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
	//   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	//   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	//   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[7] = { "crouch root", none, 1, false, false, false, false, 3 };
	animData[8] = { "crouch root", none, 1, false, false, false, false, 3 };
	animData[9] = { "crouch root", none, 1, false, false, false, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
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
	
	jetSound = NoSound;
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
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Infantry - Male data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************

PlayerData imale
{
	className = "Armor";
	shapeFile = "larmor";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	flameShapeName = "";
	shieldShapeName = "shield";
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = true;
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 11.0;
	maxBackwardSpeed = 10.0;
	maxSideSpeed = 10.0;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
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
	
	jetSound = NoSound;
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
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Heavy Infantry - Male data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 8/13/99 - 12:30PM
//*************************************************************************************************************

PlayerData himale
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 0;
	jetEnergyDrain = 0.0;
	
	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.84;
	boxNormalTorsoPercentage = 0.55;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************


//------------------------------------------------------------------
// Turret Mount data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 8/14/99 - 10:30PM
//*************************************************************************************************************

PlayerData tmount
{
	className = "Turret Mount";
	shapeFile = "Osprey-tmount";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = false;
	mapFilter = 0;
	mapIcon = "M_player";
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 0;
	jetForce = 0;
	jetEnergyDrain = 0.0;
	
	canCrouch = false;
	maxDamage = 2.0;
	maxForwardSpeed = 0.0;
	maxBackwardSpeed = 0.0;
	maxSideSpeed = 0.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 15.0;
	maxEnergy = 60;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 0;
	jumpSurfaceMinDot = 0.0;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "root", none, 1, true, false, true, false, 3 };
	animData[2]  = { "root", none, 1, true, false, true, false, 3 };
	animData[3]  = { "root", none, 1, true, false, true, false, 3 };
	animData[4]  = { "root", none, -1, true, false, true, false, 3 };
	animData[5] = { "root", none, 1, true, false, true, false, 3 };
	animData[6] = { "root", none, 1, true, false, true, false, 3 };
	animData[7] = { "root", none, 1, true, false, true, false, 3 };
	animData[8] = { "root", none, 1, true, false, true, false, 3 };
	animData[9] = { "root", none, -1, true, false, true, false, 3 };
	animData[10] = { "root", none, 1, true, false, true, false, 3 };
	animData[11] = { "root", none, -1, true, false, true, false, 3 };
	animData[12] = { "root", none, 1, true, false, true, false, 3 };
	animData[13] = { "root", none, -1, true, false, true, false, 3 };
	animData[14]  = { "root", none, 1, true, true, true, false, 3 };
	animData[15]  = { "root", none, 1, true, false, false, false, 3 };
	animData[16]  = { "root", none, 1, true, false, false, false, 3 };
	animData[17]  = { "root", none, 1, true, false, false, false, 3 };
	animData[18]  = { "root", none, 1, true, false, false, false, 3 };
	animData[19] = { "root", none, 1, true, true, true, false, 0 };
	
	// misc. animations:
	animData[20] = { "root", none, 1, true, false, false, false, 3 };
	animData[21] = { "root", none, 1, true, false, false, false, 3 };
	animData[22] = { "root", none, 1, false, false, false, false, 3 };
	animData[23] = { "root", none, 1, true, true, true, false, 3 };
	animData[24] = { "root", none, 1, false, false, false, false, 3 };
	
	// death animations:
	animData[25] = { "root", none, 1, false, false, false, false, 4 };
	animData[26] = { "root", none, 1, false, false, false, false, 4 };
	animData[27] = { "root", none, 1, false, false, false, false, 4 };
	animData[28] = { "root", none, 1, false, false, false, false, 4 };
	animData[29] = { "root", none, 1, false, false, false, false, 4 };
	animData[30] = { "root", none, 1, false, false, false, false, 4 };
	animData[31] = { "root", none, 1, false, false, false, false, 4 };
	animData[32] = { "root", none, 1, false, false, false, false, 4 };
	animData[33] = { "root", none, 1, false, false, false, false, 4 };
	animData[34] = { "root", none, 1, false, false, false, false, 4 };
	animData[35] = { "root", none, 1, false, false, false, false, 4 };
	animData[36] = { "root", none, 1, false, false, false, false, 4 };
	animData[37] = { "root", none, 1, false, false, false, false, 4 };
	
	// signal moves:
	animData[38] = { "root",  none, 1, true, false, false, false, 2 };
	animData[39] = { "root", none, 1, true, false, false, true, 1 };
	animData[40] = { "root",none, 1, true, false, false, false, 2 };
	animData[41] = { "root", none, 1, true, false, false, true, 1 };
	animData[42] = { "root", none, 1, true, false, false, true, 1 }; 
	
    // celebraton animations:
	animData[43] = { "root", none, 1, true, false, false, false, 2 };
	animData[44] = { "root", none, 1, true, false, false, false, 2 };
	animData[45] = { "root", none, 1, true, false, false, false, 2 };
	
    // taunt anmations:
	animData[46] = { "root", none, 1, true, false, false, false, 2 };
	animData[47] = { "root", none, 1, true, false, false, false, 2 };
	
    // poses:
	animData[48] = { "root", none, 1, true, false, false, true, 1 };
	animData[49] = { "root", none, 1, true, false, false, true, 1 };
	
	// Bonus wave
	animData[50] = { "root", none, 1, true, false, false, true, 1 };
	
	jetSound = NoSound;
	
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
	boxNormalHeight = 1.8;
	
	boxNormalHeadPercentage  = 0.0;
	boxNormalTorsoPercentage = 0.0;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Console Man - Female data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/7/99 - 11:30PM
//*************************************************************************************************************

PlayerData cmfemale
{
	className = "Armor";
	shapeFile = "cfemale";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	canCrouch = true;
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.75;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.78;
	boxCrouchTorsoPercentage = 0.35;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Special Ops - Female data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************

PlayerData sofemale
{
	className = "Armor";
	shapeFile = "sfemale";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	canCrouch = true;
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.75;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.78;
	boxCrouchTorsoPercentage = 0.35;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Infantry - Female data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************

PlayerData ifemale
{
	className = "Armor";
	shapeFile = "lfemale";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	canCrouch = true;
	maxJetSideForceFactor = 1;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
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
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.75;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.78;
	boxCrouchTorsoPercentage = 0.35;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// Heavy Infantry - Female data:
//------------------------------------------------------------------

//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************

PlayerData hifemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	canCrouch = false;
	maxDamage = 1.0;
	maxForwardSpeed = 8.0;
	maxBackwardSpeed = 7.0;
	maxSideSpeed = 7.0;
	groundForce = 35 * 13.0;
	mass = 13.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	mass = 13.0;
	drag = 1.0;
	density = 1.5;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
	animData[0]  = { "root", none, 1, true, true, true, false, 0 };
	animData[1]  = { "run", none, 1, true, false, true, false, 3 };
	animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
	animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
	animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
	animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.85;
	boxNormalTorsoPercentage = 0.55;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------
// DEATHMATCH ARMOR MALE - Male data:
//------------------------------------------------------------------
//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************

PlayerData dmale
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
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 90;
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
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
	
	jetSound = NoSound;
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
// DEATHMATCH ARMOR FEMALE
//------------------------------------------------------------------

PlayerData dfmale
{
	className = "Armor";
	shapeFile = "lfemale";
	flameShapeName = "lflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	
	canCrouch = true;
	maxJetSideForceFactor = 1.0;
	maxJetForwardVelocity = 1;
	minJetEnergy = 61;
	jetForce = 1;
	jetEnergyDrain = 0.0;
	
	
	maxDamage = 0.66;
	maxForwardSpeed = 12;
	maxBackwardSpeed = 11;
	maxSideSpeed = 11;
	groundForce = 40 * 9.0;
	mass = 9.0;
	groundTraction = 3.0;
	maxEnergy = 60;
	drag = 1.0;
	density = 1.2;
	
	minDamageSpeed = 30;
	damageScale = 0.02;
	
	jumpImpulse = 75;
	jumpSurfaceMinDot = 0.2;
	
	// animation data:
	// animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread
	
	// movement animations:
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
	animData[19] = { "run", none, 1, true, true, true, false, 3 };
	
	// misc. animations:
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
	
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
	
	
	jetSound = NoSound;
	
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
	
	boxNormalHeadPercentage  = 0.85;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage  = 0.88;
	boxCrouchTorsoPercentage = 0.35;
	
	boxHeadLeftPercentage  = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage  = 0;
	boxHeadFrontPercentage = 1;
};


