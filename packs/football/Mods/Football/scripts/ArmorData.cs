$rechargeRate[larmor] = 8;
$rechargeRate[lfemale] = 8;
$larmor::maxEnergy = 60;
$larmor::maxJetSideForceFactor = 0.8;
$larmor::maxJetForwardVelocity = 250;
$larmor::minJetEnergy = 1;
$larmor::jetForce = 400;
$larmor::jetEnergyDrain = 4.0;
$larmor::maxDamage = 0.66;
$larmor::maxForwardSpeed = 11;
$larmor::maxBackwardSpeed = 10;
$larmor::maxSideSpeed = 10;
$larmor::groundForce = 40 * 9.0;
$larmor::mass = 9.0;
$larmor::groundTraction = 3.0;
$larmor::drag = 1.0;
$larmor::density = 1.2;
$larmor::minDamageSpeed = 25;
$larmor::damageScale = 0.005;
$larmor::jumpImpulse = 50;
$larmor::jumpSurfaceMinDot = 0.2;

$rechargeRate[clarmor] = 8;
$rechargeRate[clfemale] = 8;
$clarmor::maxEnergy = 60;
$clarmor::maxJetSideForceFactor = 0.8;
$clarmor::maxJetForwardVelocity = 250;
$clarmor::minJetEnergy = 1;
$clarmor::jetForce = 400;
$clarmor::jetEnergyDrain = 4.0;
$clarmor::maxDamage = 0.66;
$clarmor::maxForwardSpeed = 8;
$clarmor::maxBackwardSpeed = 7;
$clarmor::maxSideSpeed = 7;
$clarmor::groundForce = 40 * 9.0;
$clarmor::mass = 9.0;
$clarmor::groundTraction = 3.0;
$clarmor::drag = 1.0;
$clarmor::density = 1.2;
$clarmor::minDamageSpeed = 25;
$clarmor::damageScale = 0.005;
$clarmor::jumpImpulse = 50;
$clarmor::jumpSurfaceMinDot = 0.2;

$rechargeRate[marmor] = 8;
$marmor::maxEnergy = 60;
$marmor::maxJetSideForceFactor = 0.8;
$marmor::maxJetForwardVelocity = 275;
$marmor::minJetEnergy = 1;
$marmor::jetForce = 425;
$marmor::jetEnergyDrain = 4.0;
$marmor::maxDamage = 1.0;
$marmor::maxForwardSpeed = 10.0;
$marmor::maxBackwardSpeed = 9.0;
$marmor::maxSideSpeed = 9.0;
$marmor::groundForce = 35 * 13.0;
$marmor::mass = 15.0;
$marmor::groundTraction = 3.0;
$marmor::drag = 1.0;
$marmor::density = 1.5;
$marmor::minDamageSpeed = 25;
$marmor::damageScale = 0.005;
$marmor::jumpImpulse = 85;
$marmor::jumpSurfaceMinDot = 0.2;

$rechargeRate[harmor] = 8;
$harmor::maxEnergy = 60;
$harmor::maxJetSideForceFactor = 0.8;
$harmor::maxJetForwardVelocity = 300;
$harmor::minJetEnergy = 1;
$harmor::jetForce = 450;
$harmor::jetEnergyDrain = 4.0;
$harmor::maxDamage = 1.32;
$harmor::maxForwardSpeed = 9.0;
$harmor::maxBackwardSpeed = 8.0;
$harmor::maxSideSpeed = 8.0;
$harmor::groundForce = 35 * 18.0;
$harmor::groundTraction = 4.5;
$harmor::mass = 18.0;
$harmor::drag = 1.0;
$harmor::density = 2.5;
$harmor::minDamageSpeed = 25;
$harmor::damageScale = 0.006;
$harmor::jumpImpulse = 125;
$harmor::jumpSurfaceMinDot = 0.2;

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

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, MineAmmo] = 3;
$ItemMax[larmor, Grenade] = 5;
$ItemMax[larmor, Beacon]  = 3;

$ItemMax[larmor, BulletAmmo] = 100;
$ItemMax[larmor, PlasmaAmmo] = 30;
$ItemMax[larmor, DiscAmmo] = 15;
$ItemMax[larmor, GrenadeAmmo] = 10;
$ItemMax[larmor, MortarAmmo] = 10;

$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, SensorJammerPack] = 1;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 1;
$ItemMax[larmor, CameraPack] = 1;
$ItemMax[larmor, TurretPack] = 0;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, RepairKit] = 1;
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;

$ItemMax[larmor, FootballThrower] = 1;
$ItemMax[larmor, Football] = 100;

$MaxWeapons[larmor] = 3;

//----------------------------------------------------------------------------
// Carrier Light Armor
//----------------------------------------------------------------------------

$DamageScale[clarmor, $LandingDamageType] = 1.0;
$DamageScale[clarmor, $ImpactDamageType] = 1.0;
$DamageScale[clarmor, $CrushDamageType] = 1.0;
$DamageScale[clarmor, $BulletDamageType] = 1.2;
$DamageScale[clarmor, $PlasmaDamageType] = 1.0;
$DamageScale[clarmor, $EnergyDamageType] = 1.3;
$DamageScale[clarmor, $ExplosionDamageType] = 1.0;
$DamageScale[clarmor, $MissileDamageType] = 1.0;
$DamageScale[clarmor, $DebrisDamageType] = 1.2;
$DamageScale[clarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[clarmor, $LaserDamageType] = 1.0;
$DamageScale[clarmor, $MortarDamageType] = 1.3;
$DamageScale[clarmor, $BlasterDamageType] = 1.3;
$DamageScale[clarmor, $ElectricityDamageType] = 1.0;
$DamageScale[clarmor, $MineDamageType] = 1.2;

$ItemMax[clarmor, Blaster] = 1;
$ItemMax[clarmor, Chaingun] = 1;
$ItemMax[clarmor, Disclauncher] = 1;
$ItemMax[clarmor, GrenadeLauncher] = 1;
$ItemMax[clarmor, Mortar] = 0;
$ItemMax[clarmor, PlasmaGun] = 1;
$ItemMax[clarmor, LaserRifle] = 1;
$ItemMax[clarmor, EnergyRifle] = 1;
$ItemMax[clarmor, TargetingLaser] = 1;
$ItemMax[clarmor, MineAmmo] = 3;
$ItemMax[clarmor, Grenade] = 5;
$ItemMax[clarmor, Beacon]  = 3;

$ItemMax[clarmor, BulletAmmo] = 100;
$ItemMax[clarmor, PlasmaAmmo] = 30;
$ItemMax[clarmor, DiscAmmo] = 15;
$ItemMax[clarmor, GrenadeAmmo] = 10;
$ItemMax[clarmor, MortarAmmo] = 10;

$ItemMax[clarmor, EnergyPack] = 1;
$ItemMax[clarmor, RepairPack] = 1;
$ItemMax[clarmor, ShieldPack] = 1;
$ItemMax[clarmor, SensorJammerPack] = 1;
$ItemMax[clarmor, MotionSensorPack] = 1;
$ItemMax[clarmor, PulseSensorPack] = 1;
$ItemMax[clarmor, DeployableSensorJammerPack] = 1;
$ItemMax[clarmor, CameraPack] = 1;
$ItemMax[clarmor, TurretPack] = 0;
$ItemMax[clarmor, AmmoPack] = 1;
$ItemMax[clarmor, RepairKit] = 1;
$ItemMax[clarmor, DeployableInvPack] = 0;
$ItemMax[clarmor, DeployableAmmoPack] = 0;

$ItemMax[clarmor, FootballThrower] = 1;
$ItemMax[clarmor, Football] = 100;

$MaxWeapons[clarmor] = 3;

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
$DamageScale[marmor, $LandingDamageType] = 1.0;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $BulletDamageType] = 1.0;
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

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, Disclauncher] = 1;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, Mortar] = 0;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, LaserRifle] = 0;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, MineAmmo] = 3;
$ItemMax[marmor, Grenade] = 6;
$ItemMax[marmor, Beacon] = 3;

$ItemMax[marmor, BulletAmmo] = 150;
$ItemMax[marmor, PlasmaAmmo] = 40;
$ItemMax[marmor, DiscAmmo] = 15;
$ItemMax[marmor, GrenadeAmmo] = 10;
$ItemMax[marmor, MortarAmmo] = 10;

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

$ItemMax[marmor, FootballThrower] = 1;
$ItemMax[marmor, Football] = 100;

$MaxWeapons[marmor] = 4;

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

$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, Chaingun] = 1;
$ItemMax[harmor, Disclauncher] = 1;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, LaserRifle] = 0;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[harmor, MineAmmo] = 3;
$ItemMax[harmor, Grenade] = 8;
$ItemMax[harmor, Beacon] = 3;

$ItemMax[harmor, BulletAmmo] = 200;
$ItemMax[harmor, PlasmaAmmo] = 50;
$ItemMax[harmor, DiscAmmo] = 15;
$ItemMax[harmor, GrenadeAmmo] = 15;
$ItemMax[harmor, MortarAmmo] = 10;

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

$ItemMax[harmor, FootballThrower] = 1;
$ItemMax[harmor, Football] = 100;

$MaxWeapons[harmor] = 5;

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

$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, Mortar] = 0;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, MineAmmo] = 3;
$ItemMax[lfemale, Grenade] = 5;
$ItemMax[lfemale, Beacon] = 3;

$ItemMax[lfemale, BulletAmmo] = 100;
$ItemMax[lfemale, PlasmaAmmo] = 30;
$ItemMax[lfemale, DiscAmmo] = 15;
$ItemMax[lfemale, GrenadeAmmo] = 10;
$ItemMax[lfemale, MortarAmmo] = 10;

$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[lfemale, DeployableSensorJammerPack] = 1;
$ItemMax[lfemale, CameraPack] = 1;
$ItemMax[lfemale, TurretPack] = 0;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, RepairKit] = 1;
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;

$ItemMax[lfemale, FootballThrower] = 1;
$ItemMax[lfemale, Football] = 100;

$MaxWeapons[lfemale] = 3;

//----------------------------------------------------------------------------
// carrier light Female Armor
//----------------------------------------------------------------------------
$DamageScale[clfemale, $LandingDamageType] = 1.0;
$DamageScale[clfemale, $ImpactDamageType] = 1.0;	
$DamageScale[clfemale, $CrushDamageType] = 1.0;	
$DamageScale[clfemale, $BulletDamageType] = 1.2;
$DamageScale[clfemale, $PlasmaDamageType] = 1.0;
$DamageScale[clfemale, $EnergyDamageType] = 1.3;
$DamageScale[clfemale, $ExplosionDamageType] = 1.0;
$DamageScale[clfemale, $MissileDamageType] = 1.0;
$DamageScale[clfemale, $ShrapnelDamageType] = 1.2;
$DamageScale[clfemale, $DebrisDamageType] = 1.2;
$DamageScale[clfemale, $LaserDamageType] = 1.0;
$DamageScale[clfemale, $MortarDamageType] = 1.3;
$DamageScale[clfemale, $BlasterDamageType] = 1.3;
$DamageScale[clfemale, $ElectricityDamageType] = 1.0;
$DamageScale[clfemale, $MineDamageType] = 1.2;

$ItemMax[clfemale, Blaster] = 1;
$ItemMax[clfemale, Chaingun] = 1;
$ItemMax[clfemale, Disclauncher] = 1;
$ItemMax[clfemale, GrenadeLauncher] = 1;
$ItemMax[clfemale, Mortar] = 0;
$ItemMax[clfemale, PlasmaGun] = 1;
$ItemMax[clfemale, LaserRifle] = 1;
$ItemMax[clfemale, EnergyRifle] = 1;
$ItemMax[clfemale, TargetingLaser] = 1;
$ItemMax[clfemale, MineAmmo] = 3;
$ItemMax[clfemale, Grenade] = 5;
$ItemMax[clfemale, Beacon] = 3;

$ItemMax[clfemale, BulletAmmo] = 100;
$ItemMax[clfemale, PlasmaAmmo] = 30;
$ItemMax[clfemale, DiscAmmo] = 15;
$ItemMax[clfemale, GrenadeAmmo] = 10;
$ItemMax[clfemale, MortarAmmo] = 10;

$ItemMax[clfemale, EnergyPack] = 1;
$ItemMax[clfemale, RepairPack] = 1;
$ItemMax[clfemale, ShieldPack] = 1;
$ItemMax[clfemale, SensorJammerPack] = 1;
$ItemMax[clfemale, MotionSensorPack] = 1;
$ItemMax[clfemale, PulseSensorPack] = 1;
$ItemMax[clfemale, DeployableSensorJammerPack] = 1;
$ItemMax[clfemale, CameraPack] = 1;
$ItemMax[clfemale, TurretPack] = 0;
$ItemMax[clfemale, AmmoPack] = 1;
$ItemMax[clfemale, RepairKit] = 1;
$ItemMax[clfemale, DeployableInvPack] = 0;
$ItemMax[clfemale, DeployableAmmoPack] = 0;

$ItemMax[clfemale, FootballThrower] = 1;
$ItemMax[clfemale, Football] = 100;

$MaxWeapons[clfemale] = 3;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$DamageScale[mfemale, $LandingDamageType] = 1.0;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $BulletDamageType] = 1.0;
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

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, Mortar] = 0;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, LaserRifle] = 0;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, MineAmmo] = 3;
$ItemMax[mfemale, Grenade] = 6;
$ItemMax[mfemale, Beacon] = 3;

$ItemMax[mfemale, BulletAmmo] = 150;
$ItemMax[mfemale, PlasmaAmmo] = 40;
$ItemMax[mfemale, DiscAmmo] = 15;
$ItemMax[mfemale, GrenadeAmmo] = 10;
$ItemMax[mfemale, MortarAmmo] = 10;

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

$ItemMax[mfemale, FootballThrower] = 1;
$ItemMax[mfemale, Football] = 100;

$MaxWeapons[mfemale] = 4;

//------------------------------------------------------------------
// light armor data:
//------------------------------------------------------------------

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

PlayerData larmor
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

	maxJetSideForceFactor = $larmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $larmor::maxJetForwardVelocity;
	minJetEnergy = $larmor::minJetEnergy;
	jetForce = $larmor::jetForce;
	jetEnergyDrain = $larmor::jetEnergyDrain;

	maxDamage = $larmor::maxDamage;
	maxForwardSpeed = $larmor::maxForwardSpeed;
	maxBackwardSpeed = $larmor::maxBackwardSpeed;
	maxSideSpeed = $larmor::maxSideSpeed;
	groundForce = $larmor::groundForce;
	mass = $larmor::mass;
	groundTraction = $larmor::groundTraction;
	maxEnergy = $larmor::maxEnergy;
	drag = $larmor::drag;
	density = $larmor::density;

	minDamageSpeed = $larmor::minDamageSpeed;
	damageScale = $larmor::damageScale;

	jumpImpulse = $larmor::jumpImpulse;
	jumpSurfaceMinDot = $larmor::jumpSurfaceMinDot;

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
// carrier light armor data:
//------------------------------------------------------------------

PlayerData clarmor
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

	maxJetSideForceFactor = $clarmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $clarmor::maxJetForwardVelocity;
	minJetEnergy = $clarmor::minJetEnergy;
	jetForce = $clarmor::jetForce;
	jetEnergyDrain = $clarmor::jetEnergyDrain;

	maxDamage = $clarmor::maxDamage;
	maxForwardSpeed = $clarmor::maxForwardSpeed;
	maxBackwardSpeed = $clarmor::maxBackwardSpeed;
	maxSideSpeed = $clarmor::maxSideSpeed;
	groundForce = $clarmor::groundForce;
	mass = $clarmor::mass;
	groundTraction = $clarmor::groundTraction;
	maxEnergy = $clarmor::maxEnergy;
	drag = $clarmor::drag;
	density = $clarmor::density;

	minDamageSpeed = $clarmor::minDamageSpeed;
	damageScale = $clarmor::damageScale;

	jumpImpulse = $clarmor::jumpImpulse;
	jumpSurfaceMinDot = $clarmor::jumpSurfaceMinDot;

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
// Medium Armor data:
//------------------------------------------------------------------

PlayerData marmor
{
	className = "Armor";
	shapeFile = "marmor";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = false;

	maxJetSideForceFactor = $marmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $marmor::maxJetForwardVelocity;
	minJetEnergy = $marmor::minJetEnergy;
	jetForce = $marmor::jetForce;
	jetEnergyDrain = $marmor::jetEnergyDrain;

	maxDamage = $marmor::maxDamage;
	maxForwardSpeed = $marmor::maxForwardSpeed;
	maxBackwardSpeed = $marmor::maxBackwardSpeed;
	maxSideSpeed = $marmor::maxSideSpeed;
	groundForce = $marmor::groundForce;
	mass = $marmor::mass;
	groundTraction = $marmor::groundTraction;

	maxEnergy = $marmor::maxEnergy;
	drag = $marmor::drag;
	density = $marmor::density;

	minDamageSpeed = $marmor::minDamageSpeed;
	damageScale = $marmor::damageScale;

	jumpImpulse = $marmor::jumpImpulse;
	jumpSurfaceMinDot = $marmor::jumpSurfaceMinDot;

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

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------

PlayerData harmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = false;

	maxJetSideForceFactor = $harmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $harmor::maxJetForwardVelocity;
	minJetEnergy = $harmor::minJetEnergy;
	jetForce = $harmor::jetForce;
	jetEnergyDrain = $harmor::jetEnergyDrain;

	maxDamage = $harmor::maxDamage;
	maxForwardSpeed = $harmor::maxForwardSpeed;
	maxBackwardSpeed = $harmor::maxBackwardSpeed;
	maxSideSpeed = $harmor::maxSideSpeed;
	groundForce = $harmor::groundForce;
	groundTraction = $harmor::groundTraction;
	mass = $harmor::mass;
	maxEnergy = $harmor::maxEnergy;
	drag = $harmor::drag;
	density = $harmor::density;

	minDamageSpeed = $harmor::minDamageSpeed;
	damageScale = $harmor::damageScale;

	jumpImpulse = $harmor::jumpImpulse;
	jumpSurfaceMinDot = $harmor::jumpSurfaceMinDot;

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
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//------------------------------------------------------------------
// Light female data:
//------------------------------------------------------------------

PlayerData lfemale
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

	maxJetSideForceFactor = $larmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $larmor::maxJetForwardVelocity;
	minJetEnergy = $larmor::minJetEnergy;
	jetForce = $larmor::jetForce;
	jetEnergyDrain = $larmor::jetEnergyDrain;

	maxDamage = $larmor::maxDamage;
	maxForwardSpeed = $larmor::maxForwardSpeed;
	maxBackwardSpeed = $larmor::maxBackwardSpeed;
	maxSideSpeed = $larmor::maxSideSpeed;
	groundForce = $larmor::groundForce;
	mass = $larmor::mass;
	groundTraction = $larmor::groundTraction;
	maxEnergy = $larmor::maxEnergy;
	drag = $larmor::drag;
	density = $larmor::density;

	minDamageSpeed = $larmor::minDamageSpeed;
	damageScale = $larmor::damageScale;

	jumpImpulse = $larmor::jumpImpulse;
	jumpSurfaceMinDot = $larmor::jumpSurfaceMinDot;

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

//------------------------------------------------------------------
// carrier light female data:
//------------------------------------------------------------------

PlayerData clfemale
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

	maxJetSideForceFactor = $clarmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $clarmor::maxJetForwardVelocity;
	minJetEnergy = $clarmor::minJetEnergy;
	jetForce = $clarmor::jetForce;
	jetEnergyDrain = $clarmor::jetEnergyDrain;

	maxDamage = $clarmor::maxDamage;
	maxForwardSpeed = $clarmor::maxForwardSpeed;
	maxBackwardSpeed = $clarmor::maxBackwardSpeed;
	maxSideSpeed = $clarmor::maxSideSpeed;
	groundForce = $clarmor::groundForce;
	mass = $clarmor::mass;
	groundTraction = $clarmor::groundTraction;
	maxEnergy = $clarmor::maxEnergy;
	drag = $clarmor::drag;
	density = $clarmor::density;

	minDamageSpeed = $clarmor::minDamageSpeed;
	damageScale = $clarmor::damageScale;

	jumpImpulse = $clarmor::jumpImpulse;
	jumpSurfaceMinDot = $clarmor::jumpSurfaceMinDot;

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

//------------------------------------------------------------------
// Medium female data:
//------------------------------------------------------------------

PlayerData mfemale
{
	className = "Armor";
	shapeFile = "mfemale";
	flameShapeName = "mflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;

	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	canCrouch = false;

	maxJetSideForceFactor = $marmor::maxJetSideForceFactor;
	maxJetForwardVelocity = $marmor::maxJetForwardVelocity;
	minJetEnergy = $marmor::minJetEnergy;
	jetForce = $marmor::jetForce;
	jetEnergyDrain = $marmor::jetEnergyDrain;

	maxDamage = $marmor::maxDamage;
	maxForwardSpeed = $marmor::maxForwardSpeed;
	maxBackwardSpeed = $marmor::maxBackwardSpeed;
	maxSideSpeed = $marmor::maxSideSpeed;
	groundForce = $marmor::groundForce;
	mass = $marmor::mass;
	groundTraction = $marmor::groundTraction;

	maxEnergy = $marmor::maxEnergy;
	drag = $marmor::drag;
	density = $marmor::density;

	minDamageSpeed = $marmor::minDamageSpeed;
	damageScale = $marmor::damageScale;

	jumpImpulse = $marmor::jumpImpulse;
	jumpSurfaceMinDot = $marmor::jumpSurfaceMinDot;

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

//------------------------------------------------------------------
//
//------------------------------------------------------------------







