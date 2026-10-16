
DeployableTaserTrtC.maxDamage = 15;

lgaForceFieldShape.maxDamage = 250;
lgbForceFieldShape.maxDamage = 250;
medaForceFieldShape.maxDamage = 250;
medbForceFieldShape.maxDamage = 250;
medcForceFieldShape.maxDamage = 250;

Boost.explosionRadius = 20.0;
Boost.kickBackStrength = 500;

Fireball.damageValue        = 0.5;
SmScreen.damageValue = 0.2;
ExSmScreen.damageValue = 280;
FireScreen.damageValue      = 3;
SpellAbilityProj.damageValue        = 1;
ChaingunBullet.damageValue        = 1;
LiLPOOmkiBullet.damageValue        = 1;
LiLPOOmkiiBullet.damageValue        = 1;
FusionBolt.damageValue        = 0.5;
MiniFusionBolt.damageValue        = 0.5;
BlasterBolt.damageValue        = 1;
PlasmaBolt.damageValue        = 1;
DiscShell.damageValue      = 2;
GrenadeShell.damageValue        = 1;
MortarShell.damageValue        = 1.0;
LiLFFBShell.damageValue = 150;
MortarTurretShell.damageValue        = 1.32;
FlierRocket.damageValue      = 2;
LiLRocketEMP.damageValue = 0.3;
LiLRocket.damageValue = 1;
LiLRocketSubmission.damageValue = 1;
LiLRocketalt.damageValue      = 2;
LiLEMPRocketONE.damageValue = 0.5;
LiLEMPRocketTWO.damageValue = 0.5;
LiLEMPRocketalt.damageValue      = 0.5;
MiniFlakproj.damageValue      = 0.2;
MiniSAMproj.damageValue      = 0.5;
TurretMissile.damageValue      = 0.5;
sniperLaser.damageConversion  = 0.7;
TaserRfLaser.damageConversion  = 3;
TaserTrtBLaser.damageConversion = 0.09;
TaserTrtCLaser.damageConversion = 0.0001;
LaserTrtLaser.damageConversion = 0.09;
targetLaser.damageConversion  = 0.0;
lightningCharge.damagePerSec      = 2;
lightningCharge.energyDrainPerSec = 500.0;
BeamOfPainProj.damagePerSec      = 2;
BeamOfPainProj.energyDrainPerSec = 500;
MiniSmokeTurretproj.damagePerSec      = 0.5;
MiniSmokeTurretproj.energyDrainPerSec = 0;
MiniELFTurretproj.damagePerSec      = 0.01;
MiniELFTurretproj.energyDrainPerSec = 1000;
turretCharge.damagePerSec      = 0;
turretCharge.energyDrainPerSec = 500;

//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------

$DamageScale[larmor, $LandingDamageType] = 1.0;
$DamageScale[larmor, $ImpactDamageType] = 1.0;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $BulletDamageType] = 1.2;
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
$DamageScale[larmor, $LiLRocketDamageType] = 1.0;
$DamageScale[larmor, $EMPDamageType] = 1.0;
$DamageScale[larmor, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[larmor, $SmokeDamageType] = 1.0;
$DamageScale[larmor, $MiniELFDamageType] = 1.0;
$DamageScale[larmor, $beamofpainDamageType] = 1.0;
$DamageScale[larmor, $FlashDamageType] = 1.0;

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 1;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 0;
$ItemMax[larmor, MineAmmo] = 35;
$ItemMax[larmor, Grenade] = 35;
$ItemMax[larmor, Beacon]  = 35;

//--VX-
$ItemMax[larmor, TaserRifle] = 1;

$ItemMax[larmor, LiLFFB] = 1;
$ItemMax[larmor, LiLFFBAmmo] = 8;

$ItemMax[larmor, TaserTrtBPack] = 1;
$ItemMax[larmor, TaserTrtCPack] = 1;
$ItemMax[larmor, LaserTurretPack] = 1;

$ItemMax[larmor, lgaForceFieldPack] = 1;
$ItemMax[larmor, lgbForceFieldPack] = 1;
$ItemMax[larmor, medaForceFieldPack] = 1;
$ItemMax[larmor, medbForceFieldPack] = 1;
$ItemMax[larmor, medcForceFieldPack] = 1;
//--VX

$ItemMax[larmor, BulletAmmo] = 999;
$ItemMax[larmor, PlasmaAmmo] = 350;
$ItemMax[larmor, DiscAmmo] = 250;
$ItemMax[larmor, GrenadeAmmo] = 20;
$ItemMax[larmor, MortarAmmo] = 18;

$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, SensorJammerPack] = 1;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 1;
$ItemMax[larmor, CameraPack] = 1;
$ItemMax[larmor, TurretPack] = 1;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, RepairKit] = 1;
$ItemMax[larmor, DeployableInvPack] = 1;
$ItemMax[larmor, DeployableAmmoPack] = 1;

$MaxWeapons[larmor] = 10;

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
$DamageScale[marmor, $LandingDamageType] = 0.7;
$DamageScale[marmor, $ImpactDamageType] = 0.7;
$DamageScale[marmor, $CrushDamageType] = 0.7;
$DamageScale[marmor, $BulletDamageType] = 0.7;
$DamageScale[marmor, $PlasmaDamageType] = 0.6;
$DamageScale[marmor, $EnergyDamageType] = 0.7;
$DamageScale[marmor, $ExplosionDamageType] = 0.7;
$DamageScale[marmor, $MissileDamageType] = 0.7;
$DamageScale[marmor, $ShrapnelDamageType] = 0.7;
$DamageScale[marmor, $DebrisDamageType] = 0.7;
$DamageScale[marmor, $LaserDamageType] = 0.7;
$DamageScale[marmor, $MortarDamageType] = 0.7;
$DamageScale[marmor, $BlasterDamageType] = 0.7;
$DamageScale[marmor, $ElectricityDamageType] = 0.7;
$DamageScale[marmor, $MineDamageType] = 0.7;
$DamageScale[marmor, $LiLRocketDamageType] = 1.0;
$DamageScale[marmor, $EMPDamageType] = 1.0;
$DamageScale[marmor, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[marmor, $SmokeDamageType] = 1.0;
$DamageScale[marmor, $MiniELFDamageType] = 1.0;
$DamageScale[marmor, $beamofpainDamageType] = 1.0;
$DamageScale[marmor, $FlashDamageType] = 1.0;

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, Disclauncher] = 1;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, LaserRifle] = 1;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, TargetingLaser] = 0;
$ItemMax[marmor, MineAmmo] = 30;
$ItemMax[marmor, Grenade] = 60;
$ItemMax[marmor, Beacon] = 30;

//--VX-
$ItemMax[marmor, TaserRifle] = 1;

$ItemMax[marmor, LiLFFB] = 1;
$ItemMax[marmor, LiLFFBAmmo] = 8;

$ItemMax[marmor, TaserTrtBPack] = 1;
$ItemMax[marmor, TaserTrtCPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;

$ItemMax[marmor, lgaForceFieldPack] = 1;
$ItemMax[marmor, lgbForceFieldPack] = 1;
$ItemMax[marmor, medaForceFieldPack] = 1;
$ItemMax[marmor, medbForceFieldPack] = 1;
$ItemMax[marmor, medcForceFieldPack] = 1;
//--VX

$ItemMax[marmor, BulletAmmo] = 300;
$ItemMax[marmor, PlasmaAmmo] = 300;
$ItemMax[marmor, DiscAmmo] = 300;
$ItemMax[marmor, GrenadeAmmo] = 30;
$ItemMax[marmor, MortarAmmo] = 8;

$ItemMax[marmor, EnergyPack] = 1;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[marmor, SensorJammerPack] = 1;
$ItemMax[marmor, MotionSensorPack] = 1;
$ItemMax[marmor, PulseSensorPack] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, CameraPack] = 1;
$ItemMax[marmor, TurretPack] = 1;
$ItemMax[marmor, AmmoPack] = 1;
$ItemMax[marmor, RepairKit] = 1;
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableAmmoPack] = 1;

$MaxWeapons[marmor] = 8;

//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
$DamageScale[harmor, $LandingDamageType] = 1.0;
$DamageScale[harmor, $ImpactDamageType] = 1.0;
$DamageScale[harmor, $CrushDamageType] = 1.0;
$DamageScale[harmor, $BulletDamageType] = 0.6;
$DamageScale[harmor, $PlasmaDamageType] = 0.4;
$DamageScale[harmor, $EnergyDamageType] = 0.7;
$DamageScale[harmor, $ExplosionDamageType] = 0.6;
$DamageScale[harmor, $MissileDamageType] = 0.6;
$DamageScale[harmor, $DebrisDamageType] = 0.8;
$DamageScale[harmor, $ShrapnelDamageType] = 0.8;
$DamageScale[harmor, $LaserDamageType] = 0.6;
$DamageScale[harmor, $MortarDamageType] = 0.7;
$DamageScale[harmor, $BlasterDamageType] = 0.7;
$DamageScale[harmor, $ElectricityDamageType] = 1.0;
$DamageScale[harmor, $MineDamageType] = 0.8;
$DamageScale[harmor, $LiLRocketDamageType] = 1.0;
$DamageScale[harmor, $EMPDamageType] = 1.0;
$DamageScale[harmor, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[harmor, $SmokeDamageType] = 1.0;
$DamageScale[harmor, $MiniELFDamageType] = 1.0;
$DamageScale[harmor, $beamofpainDamageType] = 1.0;
$DamageScale[harmor, $FlashDamageType] = 1.0;

$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, Chaingun] = 1;
$ItemMax[harmor, Disclauncher] = 1;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, LaserRifle] = 1;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[harmor, TargetingLaser] = 0;
$ItemMax[harmor, MineAmmo] = 18;
$ItemMax[harmor, Grenade] = 8;
$ItemMax[harmor, Beacon] = 10;

//--VX-
$ItemMax[harmor, TaserRifle] = 1;

$ItemMax[harmor, LiLFFB] = 1;
$ItemMax[harmor, LiLFFBAmmo] = 8;

$ItemMax[harmor, TaserTrtBPack] = 1;
$ItemMax[harmor, TaserTrtCPack] = 1;
$ItemMax[harmor, LaserTurretPack] = 1;

$ItemMax[harmor, lgaForceFieldPack] = 1;
$ItemMax[harmor, lgbForceFieldPack] = 1;
$ItemMax[harmor, medaForceFieldPack] = 1;
$ItemMax[harmor, medbForceFieldPack] = 1;
$ItemMax[harmor, medcForceFieldPack] = 1;
//--VX

$ItemMax[harmor, BulletAmmo] = 100;
$ItemMax[harmor, PlasmaAmmo] = 100;
$ItemMax[harmor, DiscAmmo] = 100;
$ItemMax[harmor, GrenadeAmmo] = 20;
$ItemMax[harmor, MortarAmmo] = 8;

$ItemMax[harmor, EnergyPack] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[harmor, ShieldPack] = 1;
$ItemMax[harmor, SensorJammerPack] = 1;
$ItemMax[harmor, MotionSensorPack] = 1;
$ItemMax[harmor, PulseSensorPack] = 1;
$ItemMax[harmor, DeployableSensorJammerPack] = 1;
$ItemMax[harmor, CameraPack] = 1;
$ItemMax[harmor, TurretPack] = 1;
$ItemMax[harmor, AmmoPack] = 1;
$ItemMax[harmor, RepairKit] = 1;
$ItemMax[harmor, DeployableInvPack] = 1;
$ItemMax[harmor, DeployableAmmoPack] = 1;

$MaxWeapons[harmor] = 8;

//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
$DamageScale[lfemale, $LandingDamageType] = 1.0;
$DamageScale[lfemale, $ImpactDamageType] = 1.0;	
$DamageScale[lfemale, $CrushDamageType] = 1.0;	
$DamageScale[lfemale, $BulletDamageType] = 1.2;
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
$DamageScale[lfemale, $LiLRocketDamageType] = 1.0;
$DamageScale[lfemale, $EMPDamageType] = 1.0;
$DamageScale[lfemale, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[lfemale, $SmokeDamageType] = 1.0;
$DamageScale[lfemale, $MiniELFDamageType] = 1.0;
$DamageScale[lfemale, $beamofpainDamageType] = 1.0;
$DamageScale[lfemale, $FlashDamageType] = 1.0;

$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, Mortar] = 1;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, TargetingLaser] = 0;
$ItemMax[lfemale, MineAmmo] = 35;
$ItemMax[lfemale, Grenade] = 35;
$ItemMax[lfemale, Beacon] = 35;

//--VX-
$ItemMax[lfemale, TaserRifle] = 1;

$ItemMax[lfemale, LiLFFB] = 1;
$ItemMax[lfemale, LiLFFBAmmo] = 8;

$ItemMax[lfemale, TaserTrtBPack] = 1;
$ItemMax[lfemale, TaserTrtCPack] = 1;
$ItemMax[lfemale, LaserTurretPack] = 1;

$ItemMax[lfemale, lgaForceFieldPack] = 1;
$ItemMax[lfemale, lgbForceFieldPack] = 1;
$ItemMax[lfemale, medaForceFieldPack] = 1;
$ItemMax[lfemale, medbForceFieldPack] = 1;
$ItemMax[lfemale, medcForceFieldPack] = 1;
//--VX

$ItemMax[lfemale, BulletAmmo] = 999;
$ItemMax[lfemale, PlasmaAmmo] = 350;
$ItemMax[lfemale, DiscAmmo] = 250;
$ItemMax[lfemale, GrenadeAmmo] = 20;
$ItemMax[lfemale, MortarAmmo] = 18;

$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[lfemale, DeployableSensorJammerPack] = 1;
$ItemMax[lfemale, CameraPack] = 1;
$ItemMax[lfemale, TurretPack] = 1;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, RepairKit] = 1;
$ItemMax[lfemale, DeployableInvPack] = 1;
$ItemMax[lfemale, DeployableAmmoPack] = 1;

$MaxWeapons[lfemale] = 10;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$DamageScale[mfemale, $LandingDamageType] = 0.7;
$DamageScale[mfemale, $ImpactDamageType] = 0.7;
$DamageScale[mfemale, $CrushDamageType] = 0.7;
$DamageScale[mfemale, $BulletDamageType] = 0.7;
$DamageScale[mfemale, $EnergyDamageType] = 0.7;
$DamageScale[mfemale, $PlasmaDamageType] = 0.6;
$DamageScale[mfemale, $ExplosionDamageType] = 0.7;
$DamageScale[mfemale, $MissileDamageType] = 0.7;
$DamageScale[mfemale, $ShrapnelDamageType] = 0.7;
$DamageScale[mfemale, $DebrisDamageType] = 0.7;
$DamageScale[mfemale, $LaserDamageType] = 0.7;
$DamageScale[mfemale, $MortarDamageType] = 0.7;
$DamageScale[mfemale, $BlasterDamageType] = 0.7;
$DamageScale[mfemale, $ElectricityDamageType] = 0.7;
$DamageScale[mfemale, $MineDamageType] = 0.7;
$DamageScale[mfemale, $LiLRocketDamageType] = 1.0;
$DamageScale[mfemale, $EMPDamageType] = 1.0;
$DamageScale[mfemale, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[mfemale, $SmokeDamageType] = 1.0;
$DamageScale[mfemale, $MiniELFDamageType] = 1.0;
$DamageScale[mfemale, $beamofpainDamageType] = 1.0;
$DamageScale[mfemale, $FlashDamageType] = 1.0;

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, LaserRifle] = 1;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, TargetingLaser] = 0;
$ItemMax[mfemale, MineAmmo] = 8;
$ItemMax[mfemale, Grenade] = 8;
$ItemMax[mfemale, Beacon] = 30;

//--VX-
$ItemMax[mfemale, TaserRifle] = 1;

$ItemMax[mfemale, LiLFFB] = 1;
$ItemMax[mfemale, LiLFFBAmmo] = 8;

$ItemMax[mfemale, TaserTrtBPack] = 1;
$ItemMax[mfemale, TaserTrtCPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
//--VX

$ItemMax[mfemale, BulletAmmo] = 500;
$ItemMax[mfemale, PlasmaAmmo] = 500;
$ItemMax[mfemale, DiscAmmo] = 500;
$ItemMax[mfemale, GrenadeAmmo] = 20;
$ItemMax[mfemale, MortarAmmo] = 8;

$ItemMax[mfemale, EnergyPack] = 1;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[mfemale, SensorJammerPack] = 1;
$ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[mfemale, PulseSensorPack] = 1;
$ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[mfemale, CameraPack] = 1;
$ItemMax[mfemale, TurretPack] = 1;
$ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[mfemale, RepairKit] = 1;
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 1;

$ItemMax[mfemale, lgaForceFieldPack] = 1;
$ItemMax[mfemale, lgbForceFieldPack] = 1;
$ItemMax[mfemale, medaForceFieldPack] = 1;
$ItemMax[mfemale, medbForceFieldPack] = 1;
$ItemMax[mfemale, medcForceFieldPack] = 1;

$MaxWeapons[mfemale] = 10;

//------------------------------------------------------------------

//-------------------------------VX-------------------------------------------

$ItemMax[larmor, ExSmScreenAbility] = 1;
$ItemMax[larmor, ExSmScreenAbilityAmmo] = 60;
$ItemMax[larmor, SmScreenAbility] = 1;
$ItemMax[larmor, SmScreenAbilityAmmo] = 125;
$ItemMax[larmor, FireballAbility] = 1;
$ItemMax[larmor, FireballAbilityAmmo] = 275;
$ItemMax[larmor, FireScreenAbility] = 1;
$ItemMax[larmor, FireScreenAbilityAmmo] = 160;

$ItemMax[marmor, ExSmScreenAbility] = 1;
$ItemMax[marmor, ExSmScreenAbilityAmmo] = 60;
$ItemMax[marmor, SmScreenAbility] = 1;
$ItemMax[marmor, SmScreenAbilityAmmo] = 125;
$ItemMax[marmor, FireballAbility] = 1;
$ItemMax[marmor, FireballAbilityAmmo] = 275;
$ItemMax[marmor, FireScreenAbility] = 1;
$ItemMax[marmor, FireScreenAbilityAmmo] = 160;

$ItemMax[harmor, ExSmScreenAbility] = 1;
$ItemMax[harmor, ExSmScreenAbilityAmmo] = 60;
$ItemMax[harmor, SmScreenAbility] = 1;
$ItemMax[harmor, SmScreenAbilityAmmo] = 125;
$ItemMax[harmor, FireballAbility] = 1;
$ItemMax[harmor, FireballAbilityAmmo] = 275;
$ItemMax[harmor, FireScreenAbility] = 1;
$ItemMax[harmor, FireScreenAbilityAmmo] = 160;

$ItemMax[lfemale, ExSmScreenAbility] = 1;
$ItemMax[lfemale, ExSmScreenAbilityAmmo] = 60;
$ItemMax[lfemale, SmScreenAbility] = 1;
$ItemMax[lfemale, SmScreenAbilityAmmo] = 125;
$ItemMax[lfemale, FireballAbility] = 1;
$ItemMax[lfemale, FireballAbilityAmmo] = 275;
$ItemMax[lfemale, FireScreenAbility] = 1;
$ItemMax[lfemale, FireScreenAbilityAmmo] = 160;

$ItemMax[mfemale, ExSmScreenAbility] = 1;
$ItemMax[mfemale, ExSmScreenAbilityAmmo] = 60;
$ItemMax[mfemale, SmScreenAbility] = 1;
$ItemMax[mfemale, SmScreenAbilityAmmo] = 125;
$ItemMax[mfemale, FireballAbility] = 1;
$ItemMax[mfemale, FireballAbilityAmmo] = 275;
$ItemMax[mfemale, FireScreenAbility] = 1;
$ItemMax[mfemale, FireScreenAbilityAmmo] = 160;

//CloakingDevice
$ItemMax[larmor, CloakingDevice] = 1;
$ItemMax[marmor, CloakingDevice] = 1;
$ItemMax[harmor, CloakingDevice] = 1;
$ItemMax[lfemale, CloakingDevice] = 1;
$ItemMax[mfemale, CloakingDevice] = 1;

$ItemMax[larmor, LaserTurretBPack] = 1;
$ItemMax[marmor, LaserTurretBPack] = 1;
$ItemMax[harmor, LaserTurretBPack] = 1;
$ItemMax[lfemale, LaserTurretBPack] = 1;
$ItemMax[mfemale, LaserTurretBPack] = 1;

$ItemMax[larmor, MiniFlakTurretPack] = 1;
$ItemMax[marmor, MiniFlakTurretPack] = 1;
$ItemMax[harmor, MiniFlakTurretPack] = 1;
$ItemMax[lfemale, MiniFlakTurretPack] = 1;
$ItemMax[mfemale, MiniFlakTurretPack] = 1;

$ItemMax[larmor, MiniSAMTurretPack] = 1;
$ItemMax[marmor, MiniSAMTurretPack] = 1;
$ItemMax[harmor, MiniSAMTurretPack] = 1;
$ItemMax[lfemale, MiniSAMTurretPack] = 1;
$ItemMax[mfemale, MiniSAMTurretPack] = 1;

$ItemMax[larmor, MiniELFTurretPack] = 1;
$ItemMax[marmor, MiniELFTurretPack] = 1;
$ItemMax[harmor, MiniELFTurretPack] = 1;
$ItemMax[lfemale, MiniELFTurretPack] = 1;
$ItemMax[mfemale, MiniELFTurretPack] = 1;

$ItemMax[larmor, MiniSmokeTurretPack] = 1;
$ItemMax[marmor, MiniSmokeTurretPack] = 1;
$ItemMax[harmor, MiniSmokeTurretPack] = 1;
$ItemMax[lfemale, MiniSmokeTurretPack] = 1;
$ItemMax[mfemale, MiniSmokeTurretPack] = 1;

$ItemMax[larmor, TeleportPack] = 1;
$ItemMax[marmor, TeleportPack] = 1;
$ItemMax[harmor, TeleportPack] = 1;
$ItemMax[lfemale, TeleportPack] = 1;
$ItemMax[mfemale, TeleportPack] = 1;

$ItemMax[larmor, LiLPOOmkii] = 1;
$ItemMax[marmor, LiLPOOmkii] = 1;
$ItemMax[harmor, LiLPOOmkii] = 1;
$ItemMax[lfemale, LiLPOOmkii] = 1;
$ItemMax[mfemale, LiLPOOmkii] = 1;

$ItemMax[larmor, LiLPOOmkiiAmmo] = 999;
$ItemMax[marmor, LiLPOOmkiiAmmo] = 999;
$ItemMax[harmor, LiLPOOmkiiAmmo] = 999;
$ItemMax[lfemale, LiLPOOmkiiAmmo] = 999;
$ItemMax[mfemale, LiLPOOmkiiAmmo] = 999;

$ItemMax[larmor, LiLPOOmki] = 1;
$ItemMax[marmor, LiLPOOmki] = 1;
$ItemMax[harmor, LiLPOOmki] = 1;
$ItemMax[lfemale, LiLPOOmki] = 1;
$ItemMax[mfemale, LiLPOOmki] = 1;

$ItemMax[larmor, LiLPOOmkiAmmo] = 999;
$ItemMax[marmor, LiLPOOmkiAmmo] = 999;
$ItemMax[harmor, LiLPOOmkiAmmo] = 999;
$ItemMax[lfemale, LiLPOOmkiAmmo] = 999;
$ItemMax[mfemale, LiLPOOmkiAmmo] = 999;

$ItemMax[larmor, LiLRocketLauncher] = 1;
$ItemMax[marmor, LiLRocketLauncher] = 1;
$ItemMax[harmor, LiLRocketLauncher] = 1;
$ItemMax[lfemale, LiLRocketLauncher] = 1;
$ItemMax[mfemale, LiLRocketLauncher] = 1;

$ItemMax[larmor, LiLRocketLauncherAmmo] = 80;
$ItemMax[marmor, LiLRocketLauncherAmmo] = 80;
$ItemMax[harmor, LiLRocketLauncherAmmo] = 100;
$ItemMax[lfemale, LiLRocketLauncherAmmo] = 80;
$ItemMax[mfemale, LiLRocketLauncherAmmo] = 100;

$ItemMax[larmor, LiLEMPRocketLauncher] = 1;
$ItemMax[marmor, LiLEMPRocketLauncher] = 1;
$ItemMax[harmor, LiLEMPRocketLauncher] = 1;
$ItemMax[lfemale, LiLEMPRocketLauncher] = 1;
$ItemMax[mfemale, LiLEMPRocketLauncher] = 1;

$ItemMax[larmor, LiLEMPRocketLauncherAmmo] = 80;
$ItemMax[marmor, LiLEMPRocketLauncherAmmo] = 80;
$ItemMax[harmor, LiLEMPRocketLauncherAmmo] = 100;
$ItemMax[lfemale, LiLEMPRocketLauncherAmmo] = 80;
$ItemMax[mfemale, LiLEMPRocketLauncherAmmo] = 100;

$ItemMax[larmor, BeamOfPain] = 1;
$ItemMax[marmor, BeamOfPain] = 1;
$ItemMax[harmor, BeamOfPain] = 1;
$ItemMax[lfemale, BeamOfPain] = 1;
$ItemMax[mfemale, BeamOfPain] = 1;

$ItemMax[larmor, SpellAbility] = 1;
$ItemMax[marmor, SpellAbility] = 1;
$ItemMax[harmor, SpellAbility] = 1;
$ItemMax[lfemale, SpellAbility] = 1;
$ItemMax[mfemale, SpellAbility] = 1;

$ItemMax[larmor, SpellAbilityAmmo] = 500;
$ItemMax[marmor, SpellAbilityAmmo] = 500;
$ItemMax[harmor, SpellAbilityAmmo] = 500;
$ItemMax[lfemale, SpellAbilityAmmo] = 500;
$ItemMax[mfemale, SpellAbilityAmmo] = 500;

$ItemMax[larmor, cactuspack] = 1;
$ItemMax[marmor, cactuspack] = 1;
$ItemMax[harmor, cactuspack] = 1;
$ItemMax[lfemale, cactuspack] = 1;
$ItemMax[mfemale, cactuspack] = 1;

$ItemMax[larmor, FlashGrenade] = 35;
$ItemMax[marmor, FlashGrenade] = 35;
$ItemMax[harmor, FlashGrenade] = 35;
$ItemMax[lfemale, FlashGrenade] = 35;
$ItemMax[mfemale, FlashGrenade] = 35;

$ItemMax[larmor, LiLBoostammo] = 35;
$ItemMax[marmor, LiLBoostammo] = 35;
$ItemMax[harmor, LiLBoostammo] = 35;
$ItemMax[lfemale, LiLBoostammo] = 35;
$ItemMax[mfemale, LiLBoostammo] = 35;

$ItemMax[larmor, RadiusMineAmmo] = 1;
$ItemMax[marmor, RadiusMineAmmo] = 1;
$ItemMax[harmor, RadiusMineAmmo] = 1;
$ItemMax[lfemale, RadiusMineAmmo] = 1;
$ItemMax[mfemale, RadiusMineAmmo] = 1;

$ItemMax[larmor, VXGasAttackAmmo] = 35;
$ItemMax[marmor, VXGasAttackAmmo] = 35;
$ItemMax[harmor, VXGasAttackAmmo] = 35;
$ItemMax[lfemale, VXGasAttackAmmo] = 35;
$ItemMax[mfemale, VXGasAttackAmmo] = 35;
//-----------------------------VX----------------------------------------


// light armor data:
//------------------------------------------------------------------
//
////PlayerData larmor
//
//   larmor.className = "Armor";
//   larmor.shapeFile = "larmor";
//   larmor.damageSkinData = "armorDamageSkins";
//	larmor.debrisId = playerDebris;
//   larmor.flameShapeName = "lflame";
//   larmor.shieldShapeName = "shield";
//   larmor.shadowDetailMask = 1;
//   larmor.validateShape = true;
//
//   larmor.visibleToSensor = True;
//	larmor.mapFilter = 1;
//	larmor.mapIcon = "M_player";
//   larmor.canCrouch = true;
//
//   larmor.maxJetSideForceFactor = 0.8;
//   larmor.maxJetForwardVelocity = 32;
//   larmor.minJetEnergy = 1;
//   larmor.jetForce = 436;
//   larmor.jetEnergyDrain = 0.1;
//
//	larmor.maxDamage = 0.66;
//   larmor.maxForwardSpeed = 13;
//   larmor.maxBackwardSpeed = 13;
//   larmor.maxSideSpeed = 10;
//   larmor.groundForce = 40 * 9.0;
//   larmor.mass = 9.0;
//   larmor.groundTraction = 3.0;
//	larmor.maxEnergy = 500;
//   larmor.drag = 1.0;
//   larmor.density = 1.2;
//
//	larmor.minDamageSpeed = 25;
//	larmor.damageScale = 0.005;
//
//   larmor.jumpImpulse = 75;
//   larmor.jumpSurfaceMinDot = 0.2;
//
//
////------------------------------------------------------------------
//// Medium Armor data:
////------------------------------------------------------------------
////
////PlayerData marmor
//
//   marmor.className = "Armor";
//   marmor.shapeFile = "marmor";
//   marmor.flameShapeName = "mflame";
//   marmor.shieldShapeName = "shield";
//   marmor.damageSkinData = "armorDamageSkins";
//	marmor.debrisId = playerDebris;
//   marmor.shadowDetailMask = 1;
//   marmor.validateShape = true;
//
//   marmor.canCrouch = false;
//   marmor.visibleToSensor = True;
//	marmor.mapFilter = 1;
//	marmor.mapIcon = "M_player";
//
//   marmor.maxJetSideForceFactor = 0.8;
//   marmor.maxJetForwardVelocity = 32;
//   marmor.minJetEnergy = 1;
//   marmor.jetForce = 436;
//   marmor.jetEnergyDrain = 0.1;
//
//	marmor.maxDamage = 1.0;
//   marmor.maxForwardSpeed = 11;
//   marmor.maxBackwardSpeed = 11;
//   marmor.maxSideSpeed = 11;
//   marmor.groundForce = 40 * 9;
//   marmor.mass = 11;
//   marmor.groundTraction = 3.0;
//	
//	marmor.maxEnergy = 500;
//   marmor.drag = 1.0;
//   marmor.density = 1.2;
//
//	marmor.minDamageSpeed = 25;
//	marmor.damageScale = 0.005;
//
//   marmor.jumpImpulse = 110;
//   marmor.jumpSurfaceMinDot = 0.2;
//
//
//
////------------------------------------------------------------------
//// Heavy Armor data:
////------------------------------------------------------------------
////
////PlayerData harmor
//
//   harmor.className = "Armor";
//   harmor.shapeFile = "harmor";
//   harmor.flameShapeName = "hflame";
//   harmor.shieldShapeName = "shield";
//   harmor.damageSkinData = "armorDamageSkins";
//	harmor.debrisId = playerDebris;
//   harmor.shadowDetailMask = 1;
//   harmor.validateShape = true;
//
//   harmor.visibleToSensor = True;
//	harmor.mapFilter = 1;
//	harmor.mapIcon = "M_player";
//
///   harmor.maxJetSideForceFactor = 0.8;
//   harmor.maxJetForwardVelocity = 13;
//   harmor.minJetEnergy = 1;
//   harmor.jetForce = 436;
//   harmor.jetEnergyDrain = 0.1;
//
//	harmor.maxDamage = 2.0;
//   harmor.maxForwardSpeed = 11;
//   harmor.maxBackwardSpeed = 11;
//   harmor.maxSideSpeed = 11;
//   harmor.groundForce = 40 * 9;
//   harmor.groundTraction = 3;
//   harmor.mass = 11;
//	harmor.maxEnergy = 100;
//   harmor.drag = 1.0;
//   harmor.density = 2.5;
//   harmor.canCrouch = false;
//
//	harmor.minDamageSpeed = 25;
//	harmor.damageScale = 0.006;
//
//   harmor.jumpImpulse = 150;
//   harmor.jumpSurfaceMinDot = 0.2;
//
//
////------------------------------------------------------------------
//// Light female data:
////------------------------------------------------------------------
////
////PlayerData lfemale
//
//   lfemale.className = "Armor";
//   lfemale.shapeFile = "lfemale";
//   lfemale.flameShapeName = "lflame";
//   lfemale.shieldShapeName = "shield";
//   lfemale.damageSkinData = "armorDamageSkins";
//	lfemale.debrisId = playerDebris;
//   lfemale.shadowDetailMask = 1;
//   lfemale.validateShape = true;
//
//   lfemale.visibleToSensor = True;
//	lfemale.mapFilter = 1;
//	lfemale.mapIcon = "M_player";
//
//   lfemale.canCrouch = true;
//   lfemale.maxJetSideForceFactor = 0.8;
//   lfemale.maxJetForwardVelocity = 32;
//   lfemale.minJetEnergy = 1;
//   lfemale.jetForce = 436;
//   lfemale.jetEnergyDrain = 0.1;
//
//	lfemale.maxDamage = 0.66;
//   lfemale.maxForwardSpeed = 13;
//   lfemale.maxBackwardSpeed = 13;
//   lfemale.maxSideSpeed = 13;
///   lfemale.groundForce = 40 * 9.0;
//   lfemale.mass = 9.0;
//   lfemale.groundTraction = 3.0;
//	lfemale.maxEnergy = 500;
//   lfemale.drag = 1.0;
//   lfemale.density = 1.2;
//
//	lfemale.minDamageSpeed = 25;
//	lfemale.damageScale = 0.005;
//
//   lfemale.jumpImpulse = 75;
//   lfemale.jumpSurfaceMinDot = 0.2;
//
//
//------------------------------------------------------------------
// Medium female data:
//------------------------------------------------------------------
//
///mfemale
//
//   mfemale.className = "Armor";
//   mfemale.shapeFile = "mfemale";
//   mfemale.flameShapeName = "mflame";
//   mfemale.shieldShapeName = "shield";
//   mfemale.damageSkinData = "armorDamageSkins";
//	mfemale.debrisId = playerDebris;
//   mfemale.shadowDetailMask = 1;
//   mfemale.validateShape = true;
//
//   mfemale.visibleToSensor = True;
//	mfemale.mapFilter = 1;
//	mfemale.mapIcon = "M_player";
//
//   mfemale.maxJetSideForceFactor = 0.8;
//   mfemale.maxJetForwardVelocity = 32;
//   mfemale.minJetEnergy = 1;
//   mfemale.jetForce = 436;
//   mfemale.jetEnergyDrain = 0.1;
//
//   mfemale.canCrouch = false;
//	mfemale.maxDamage = 1.0;
//   mfemale.maxForwardSpeed = 11;
//   mfemale.maxBackwardSpeed = 11;
//   mfemale.maxSideSpeed = 11;
//   mfemale.groundForce = 40 * 9;
//   mfemale.mass = 13;
//   mfemale.groundTraction = 3.0;
//	mfemale.maxEnergy = 500;
//   mfemale.mass = 11;
//   mfemale.drag = 1.0;
//   mfemale.density = 1.5;
//
//	mfemale.minDamageSpeed = 25;
//	mfemale.damageScale = 0.005;
//
//   mfemale.jumpImpulse = 110;
//   mfemale.jumpSurfaceMinDot = 0.2;
//
//
//------------------------------------------------------------------
//
//------------------------------------------------------------------


