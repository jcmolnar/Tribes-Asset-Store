
DeployableTaserTrtC.maxDamage = 5;

larmor.maxDamage = 1.2;
marmor.maxDamage = 2.2;
harmor.maxDamage = 3.2;
lfemale.maxDamage = 1.2;
mfemale.maxDamage = 2.2;

lgaForceFieldShape.maxDamage = 5;
lgbForceFieldShape.maxDamage = 5;
medaForceFieldShape.maxDamage = 5;
medbForceFieldShape.maxDamage = 5;
medcForceFieldShape.maxDamage = 5;

Boost.explosionRadius = 20.0;
Boost.kickBackStrength = 500;

Fireball.damageValue        = 0.2;
SmScreen.damageValue = 0.2;
ExSmScreen.damageValue = 0.2;
FireScreen.damageValue      = 0.2;
SpellAbilityProj.damageValue        = 0.2;
ChaingunBullet.damageValue        = 0.1;
LiLPOOmkiBullet.damageValue        = 0.1;
LiLPOOmkiiBullet.damageValue        = 0.1;
FusionBolt.damageValue        = 0.5;
MiniFusionBolt.damageValue        = 0.5;
BlasterBolt.damageValue        = 0.2;
PlasmaBolt.damageValue        = 0.1;
DiscShell.damageValue      = 0.3;
GrenadeShell.damageValue        = 0.2;
MortarShell.damageValue        = 0.2;
LiLFFBShell.damageValue = 0.2;
MortarTurretShell.damageValue        = 1.32;
FlierRocket.damageValue      = 2;
LiLRocketEMP.damageValue = 0.2;
LiLRocket.damageValue = 0.2;
LiLRocketSubmission.damageValue = 0.2;
LiLRocketalt.damageValue      = 0.2;
LiLEMPRocketONE.damageValue = 0.2;
LiLEMPRocketTWO.damageValue = 0.2;
LiLEMPRocketalt.damageValue      = 0.2;
MiniFlakproj.damageValue      = 0.2;
MiniSAMproj.damageValue      = 0.5;
TurretMissile.damageValue      = 0.5;
sniperLaser.damageConversion  = 0.1;
TaserRfLaser.damageConversion  = 0.1;
TaserTrtBLaser.damageConversion = 0.09;
TaserTrtCLaser.damageConversion = 0.0001;
LaserTrtLaser.damageConversion = 0.09;
targetLaser.damageConversion  = 0.0;
lightningCharge.damagePerSec      = 0.2;
lightningCharge.energyDrainPerSec = 500.0;
BeamOfPainProj.damagePerSec      = 0.2;
BeamOfPainProj.energyDrainPerSec = 500;
MiniSmokeTurretproj.damagePerSec      = 0.5;
MiniSmokeTurretproj.energyDrainPerSec = 0;
MiniELFTurretproj.damagePerSec      = 0.1;
MiniELFTurretproj.energyDrainPerSec = 1000;
turretCharge.damagePerSec      = 0.5;
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

$ItemMax[larmor, TaserTrtBPack] = 1;
$ItemMax[larmor, TaserTrtCPack] = 1;
$ItemMax[larmor, LaserTurretPack] = 1;

$ItemMax[larmor, lgaForceFieldPack] = 1;
$ItemMax[larmor, lgbForceFieldPack] = 1;
$ItemMax[larmor, medaForceFieldPack] = 1;
$ItemMax[larmor, medbForceFieldPack] = 1;
$ItemMax[larmor, medcForceFieldPack] = 1;
//--VX

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
$ItemMax[marmor, Grenade] = 35;
$ItemMax[marmor, Beacon] = 35;

//--VX-
$ItemMax[marmor, TaserRifle] = 1;

$ItemMax[marmor, LiLFFB] = 1;

$ItemMax[marmor, TaserTrtBPack] = 1;
$ItemMax[marmor, TaserTrtCPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;

$ItemMax[marmor, lgaForceFieldPack] = 1;
$ItemMax[marmor, lgbForceFieldPack] = 1;
$ItemMax[marmor, medaForceFieldPack] = 1;
$ItemMax[marmor, medbForceFieldPack] = 1;
$ItemMax[marmor, medcForceFieldPack] = 1;
//--VX

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
$ItemMax[harmor, Grenade] = 35;
$ItemMax[harmor, Beacon] = 35;

//--VX-
$ItemMax[harmor, TaserRifle] = 1;

$ItemMax[harmor, LiLFFB] = 1;

$ItemMax[harmor, TaserTrtBPack] = 1;
$ItemMax[harmor, TaserTrtCPack] = 1;
$ItemMax[harmor, LaserTurretPack] = 1;

$ItemMax[harmor, lgaForceFieldPack] = 1;
$ItemMax[harmor, lgbForceFieldPack] = 1;
$ItemMax[harmor, medaForceFieldPack] = 1;
$ItemMax[harmor, medbForceFieldPack] = 1;
$ItemMax[harmor, medcForceFieldPack] = 1;
//--VX

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

$ItemMax[lfemale, TaserTrtBPack] = 1;
$ItemMax[lfemale, TaserTrtCPack] = 1;
$ItemMax[lfemale, LaserTurretPack] = 1;

$ItemMax[lfemale, lgaForceFieldPack] = 1;
$ItemMax[lfemale, lgbForceFieldPack] = 1;
$ItemMax[lfemale, medaForceFieldPack] = 1;
$ItemMax[lfemale, medbForceFieldPack] = 1;
$ItemMax[lfemale, medcForceFieldPack] = 1;
//--VX

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
$ItemMax[mfemale, Grenade] = 35;
$ItemMax[mfemale, Beacon] = 35;

//--VX-
$ItemMax[mfemale, TaserRifle] = 1;

$ItemMax[mfemale, LiLFFB] = 1;

$ItemMax[mfemale, TaserTrtBPack] = 1;
$ItemMax[mfemale, TaserTrtCPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
//--VX

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
$ItemMax[larmor, SmScreenAbility] = 1;
$ItemMax[larmor, FireballAbility] = 1;
$ItemMax[larmor, FireScreenAbility] = 1;

$ItemMax[marmor, ExSmScreenAbility] = 1;
$ItemMax[marmor, SmScreenAbility] = 1;
$ItemMax[marmor, FireballAbility] = 1;
$ItemMax[marmor, FireScreenAbility] = 1;

$ItemMax[harmor, ExSmScreenAbility] = 1;
$ItemMax[harmor, SmScreenAbility] = 1;
$ItemMax[harmor, FireballAbility] = 1;
$ItemMax[harmor, FireScreenAbility] = 1;

$ItemMax[lfemale, ExSmScreenAbility] = 1;
$ItemMax[lfemale, SmScreenAbility] = 1;
$ItemMax[lfemale, FireballAbility] = 1;
$ItemMax[lfemale, FireScreenAbility] = 1;

$ItemMax[mfemale, ExSmScreenAbility] = 1;
$ItemMax[mfemale, SmScreenAbility] = 1;
$ItemMax[mfemale, FireballAbility] = 1;
$ItemMax[mfemale, FireScreenAbility] = 1;

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

$ItemMax[larmor, LiLPOOmki] = 1;
$ItemMax[marmor, LiLPOOmki] = 1;
$ItemMax[harmor, LiLPOOmki] = 1;
$ItemMax[lfemale, LiLPOOmki] = 1;
$ItemMax[mfemale, LiLPOOmki] = 1;

$ItemMax[larmor, LiLRocketLauncher] = 1;
$ItemMax[marmor, LiLRocketLauncher] = 1;
$ItemMax[harmor, LiLRocketLauncher] = 1;
$ItemMax[lfemale, LiLRocketLauncher] = 1;
$ItemMax[mfemale, LiLRocketLauncher] = 1;

$ItemMax[larmor, LiLEMPRocketLauncher] = 1;
$ItemMax[marmor, LiLEMPRocketLauncher] = 1;
$ItemMax[harmor, LiLEMPRocketLauncher] = 1;
$ItemMax[lfemale, LiLEMPRocketLauncher] = 1;
$ItemMax[mfemale, LiLEMPRocketLauncher] = 1;

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


