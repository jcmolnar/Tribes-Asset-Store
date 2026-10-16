//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------
//Air Brakes(Hard)
$BrakeSpeed[larmor] = -0.3;
$BrakeSpeed[marmor] = -0.2;
$BrakeSpeed[harmor] = -0.1;
$BrakeSpeed[lfemale] = -0.3;
$BrakeSpeed[mfemale] = -0.2;

$DamageScale[larmor, $LandingDamageType] = 0.6;
$DamageScale[larmor, $ImpactDamageType] = 1.0;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $FlakDamageType] = 0.098;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $EnergyDamageType] = 1.0;
$DamageScale[larmor, $ExplosionDamageType] = 0.6;
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $DebrisDamageType] = 0.7;
$DamageScale[larmor, $ShrapnelDamageType] = 0.75;
$DamageScale[larmor, $LaserDamageType] = 1;
$DamageScale[larmor, $RifleDamageType] = 1.0;  
$DamageScale[larmor, $MortarDamageType] = 1.2;
$DamageScale[larmor, $BlasterDamageType] = 0.8;
$DamageScale[larmor, $ElectricityDamageType] = 0.7;
$DamageScale[larmor, $MineDamageType] = 0.9;
$DamageScale[larmor, $RailDamageType] = 1.0; 
$DamageScale[larmor, $SalvoDamageType] = 0.2;
$DamageScale[larmor, $SentryDamageType] = 0.5;

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, AssaultRifle] = 1;
$ItemMax[larmor, Railgun] = 1;
$ItemMax[larmor, FFBLauncher] = 0;
$ItemMax[larmor, RocketLauncher] = 0;
$ItemMax[larmor, CloakGun] = 1;  
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, MineAmmo] = 5;
$ItemMax[larmor, Grenade] = 15;
$ItemMax[larmor, Beacon]  = 15;

$ItemMax[larmor, BulletAmmo] = 100;
$ItemMax[larmor, PlasmaAmmo] = 75;
$ItemMax[larmor, DiscAmmo] = 100;
$ItemMax[larmor, GrenadeAmmo] = 15;
$ItemMax[larmor, MortarAmmo] = 0;
$ItemMax[larmor, MayhemAmmo] = 500;
$ItemMax[larmor, RailAmmo] = 250;
$ItemMax[larmor, FFBAmmo] = 5;
$ItemMax[larmor, RocketAmmo] = 15;   

$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, SensorJammerPack] = 1;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 5;
$ItemMax[larmor, DeployableSensorJammerPack] = 1;
$ItemMax[larmor, CameraPack] = 1;
$ItemMax[larmor, SpySatellitePack] = 1;
$ItemMax[larmor, RocketPack] = 1;
$ItemMax[larmor, TurretPack] = 1;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, RepairKit] = 5;
$ItemMax[larmor, DeployableInvPack] = 1;
$ItemMax[larmor, DeployableAmmoPack] = 0;
$ItemMax[larmor, ForceFieldPack] = 1;
$ItemMax[larmor, LargeFieldPack] = 1;
$ItemMax[larmor, StealthShieldPack] = 1;
$ItemMax[larmor, FakeFlagPack] = 1;
$ItemMax[larmor, TeleportPack] = 0;
$ItemMax[larmor, HellPack] = 1;
$itemmax[larmor, ResupplyPack] = 1;
$ElfForce[larmor] = 30;
$BoostSpeed[larmor] = 2.75;
$SpeedMax[larmor] = 180;

$MaxWeapons[larmor] = 8;

//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
$DamageScale[marmor, $LandingDamageType] = 0.45;
$DamageScale[marmor, $ImpactDamageType] = 1.0;
$DamageScale[marmor, $CrushDamageType] = 1.0;
$DamageScale[marmor, $FlakDamageType] = 0.225;
$DamageScale[marmor, $PlasmaDamageType] = 1.0;
$DamageScale[marmor, $EnergyDamageType] = 1.0;
$DamageScale[marmor, $ExplosionDamageType] = 0.5;
$DamageScale[marmor, $MissileDamageType] = 0.8;
$DamageScale[marmor, $ShrapnelDamageType] = 0.7;
$DamageScale[marmor, $DebrisDamageType] = 0.5;
$DamageScale[marmor, $LaserDamageType] = 1.0;
$DamageScale[marmor, $RifleDamageType] = 0.34;  
$DamageScale[marmor, $MortarDamageType] = 1.0;
$DamageScale[marmor, $BlasterDamageType] = 0.6;
$DamageScale[marmor, $ElectricityDamageType] = 0.8;
$DamageScale[marmor, $MineDamageType] = 0.75;
$DamageScale[marmor, $RailDamageType] = 0.34;
$DamageScale[marmor, $SalvoDamageType] = 0.15;
$DamageScale[marmor, $SentryDamageType] = 0.45;

$ItemMax[marmor, Blaster] = 1;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, Disclauncher] = 1;
$ItemMax[marmor, GrenadeLauncher] = 0;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, LaserRifle] = 0;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, AssaultRifle] = 1;
$ItemMax[marmor, Railgun] = 1;
$ItemMax[marmor, FFBLauncher] = 1;
$ItemMax[marmor, RocketLauncher] = 1;
$ItemMax[marmor, CloakGun] = 1;  
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, MineAmmo] = 5;
$ItemMax[marmor, Grenade] = 15;
$ItemMax[marmor, Beacon] = 15;

$ItemMax[marmor, BulletAmmo] = 150;
$ItemMax[marmor, PlasmaAmmo] = 100;
$ItemMax[marmor, DiscAmmo] = 125;
$ItemMax[marmor, GrenadeAmmo] = 20;
$ItemMax[marmor, MortarAmmo] = 20;
$ItemMax[marmor, MayhemAmmo] = 500;
$ItemMax[marmor, RailAmmo] = 250;
$ItemMax[marmor, FFBAmmo] = 10;
$ItemMax[marmor, RocketAmmo] = 15;   

$ItemMax[marmor, EnergyPack] = 1;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[marmor, SensorJammerPack] = 1;
$ItemMax[marmor, MotionSensorPack] = 1;
$ItemMax[marmor, PulseSensorPack] = 5;
$ItemMax[marmor, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, CameraPack] = 1;
$ItemMax[marmor, SpySatellitePack] = 1;
$ItemMax[marmor, TurretPack] = 1;
$ItemMax[marmor, RocketPack] = 1;
$ItemMax[marmor, AmmoPack] = 1;
$ItemMax[marmor, RepairKit] = 5;
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableAmmoPack] = 0;
$ItemMax[marmor, ForceFieldPack] = 1;
$ItemMax[marmor, LargeFieldPack] = 1;
$ItemMax[marmor, StealthShieldPack] = 1;
$ItemMax[marmor, FakeFlagPack] = 1;
$ItemMax[marmor, TeleportPack] = 0;
$ItemMax[marmor, HellPack] = 1;
$itemmax[marmor, ResupplyPack] = 1;
$ElfForce[marmor] = 50;
$BoostSpeed[marmor] = 2.2;
$SpeedMax[marmor] = 120;
$MaxWeapons[marmor] = 9;

//----------------------------------------------------------------------------
// Heavy Armor
//----------------------------------------------------------------------------
$DamageScale[harmor, $LandingDamageType] = 0.3;
$DamageScale[harmor, $ImpactDamageType] = 1.0;
$DamageScale[harmor, $CrushDamageType] = 1.0;
$DamageScale[harmor, $FlakDamageType] = 0.3;
$DamageScale[harmor, $PlasmaDamageType] = 0.8;
$DamageScale[harmor, $EnergyDamageType] = 0.7;
$DamageScale[harmor, $ExplosionDamageType] = 0.4;
$DamageScale[harmor, $MissileDamageType] = 0.6;
$DamageScale[harmor, $DebrisDamageType] = 0.8;
$DamageScale[harmor, $ShrapnelDamageType] = 0.8;
$DamageScale[harmor, $LaserDamageType] = 1.7;
$DamageScale[harmor, $RifleDamageType] = 0.17;  
$DamageScale[harmor, $MortarDamageType] = 0.7;
$DamageScale[harmor, $BlasterDamageType] = 0.7;
$DamageScale[harmor, $ElectricityDamageType] = 0.9;
$DamageScale[harmor, $MineDamageType] = 0.6;
$DamageScale[harmor, $RailDamageType] = 0.17; 
$DamageScale[harmor, $SalvoDamageType] = 0.1;
$DamageScale[harmor, $SentryDamageType] = 0.4;

$ItemMax[harmor, Blaster] = 1;
$ItemMax[harmor, Chaingun] = 0;
$ItemMax[harmor, Disclauncher] = 1;
$ItemMax[harmor, GrenadeLauncher] = 0;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, LaserRifle] = 0;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[harmor, AssaultRifle] = 1;
$ItemMax[harmor, Railgun] = 1;
$ItemMax[harmor, FFBLauncher] = 1;
$ItemMax[harmor, RocketLauncher] = 1;
$ItemMax[harmor, CloakGun] = 1; 
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[harmor, MineAmmo] = 10;
$ItemMax[harmor, Grenade] = 15;
$ItemMax[harmor, Beacon] = 15;

$ItemMax[harmor, BulletAmmo] = 0;
$ItemMax[harmor, PlasmaAmmo] = 100;
$ItemMax[harmor, DiscAmmo] = 150;
$ItemMax[harmor, GrenadeAmmo] = 25;
$ItemMax[harmor, MortarAmmo] = 25;
$ItemMax[harmor, MayhemAmmo] = 500;
$ItemMax[harmor, RailAmmo] = 250;
$ItemMax[harmor, FFBAmmo] = 10;
$ItemMax[harmor, RocketAmmo] = 30;

$ItemMax[harmor, EnergyPack] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[harmor, ShieldPack] = 1;
$ItemMax[harmor, SensorJammerPack] = 1;
$ItemMax[harmor, MotionSensorPack] = 1;
$ItemMax[harmor, PulseSensorPack] = 5;
$ItemMax[harmor, DeployableSensorJammerPack] = 1;
$ItemMax[harmor, CameraPack] = 1;
$ItemMax[harmor, SpySatellitePack] = 1;
$ItemMax[harmor, TurretPack] = 1;
$ItemMax[harmor, RocketPack] = 1; 
$ItemMax[harmor, AmmoPack] = 1;
$ItemMax[harmor, RepairKit] = 5;
$ItemMax[harmor, DeployableInvPack] = 1;
$ItemMax[harmor, DeployableAmmoPack] = 0;
$ItemMax[harmor, ForceFieldPack] = 1;
$ItemMax[harmor, LargeFieldPack] = 1;
$ItemMax[harmor, StealthShieldPack] = 1;
$ItemMax[harmor, FakeFlagPack] = 0;
$ItemMax[harmor, TeleportPack] = 0;
$ItemMax[harmor, HellPack] = 1;
$itemmax[harmor, ResupplyPack] = 1;
$ElfForce[harmor] = 75;
$BoostSpeed[harmor] = 1.7;
$SpeedMax[harmor] = 95;

$MaxWeapons[harmor] = 10;

//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
$DamageScale[lfemale, $LandingDamageType] = 0.6;
$DamageScale[lfemale, $ImpactDamageType] = 1.0;
$DamageScale[lfemale, $CrushDamageType] = 1.0;
$DamageScale[lfemale, $FlakDamageType] = 0.098;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $EnergyDamageType] = 1.0;
$DamageScale[lfemale, $ExplosionDamageType] = 0.6;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[lfemale, $DebrisDamageType] = 0.7;
$DamageScale[lfemale, $ShrapnelDamageType] = 0.75;
$DamageScale[lfemale, $LaserDamageType] = 1;
$DamageScale[lfemale, $RifleDamageType] = 1.0; 
$DamageScale[lfemale, $MortarDamageType] = 1.2;
$DamageScale[lfemale, $BlasterDamageType] = 0.8;
$DamageScale[lfemale, $ElectricityDamageType] = 0.7;
$DamageScale[lfemale, $MineDamageType] = 0.9;
$DamageScale[lfemale, $RailDamageType] = 1.0;
$DamageScale[lfemale, $SalvoDamageType] = 0.2;
$DamageScale[lfemale, $SentryDamageType] = 0.5;
 
$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, Mortar] = 0;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, AssaultRifle] = 1;
$ItemMax[lfemale, Railgun] = 1;
$ItemMax[lfemale, FFBLauncher] = 0;
$ItemMax[lfemale, RocketLauncher] = 0;
$ItemMax[lfemale, CloakGun] = 1; 
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, MineAmmo] = 5;
$ItemMax[lfemale, Grenade] = 15;
$ItemMax[lfemale, Beacon] = 15;

$ItemMax[lfemale, BulletAmmo] = 100;
$ItemMax[lfemale, PlasmaAmmo] = 75;
$ItemMax[lfemale, DiscAmmo] = 100;
$ItemMax[lfemale, GrenadeAmmo] = 15;
$ItemMax[lfemale, MortarAmmo] = 0;
$ItemMax[lfemale, MayhemAmmo] = 500;
$ItemMax[lfemale, RailAmmo] = 250;
$ItemMax[lfemale, FFBAmmo] = 5;
$ItemMax[lfemale, RocketAmmo] = 15;   

$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 5;
$ItemMax[lfemale, DeployableSensorJammerPack] = 1;
$ItemMax[lfemale, CameraPack] = 1;
$ItemMax[lfemale, SpySatellitePack] = 1;
$ItemMax[lfemale, TurretPack] = 1;
$ItemMax[lfemale, RocketPack] = 1;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, RepairKit] = 5;
$ItemMax[lfemale, DeployableInvPack] = 1;
$ItemMax[lfemale, DeployableAmmoPack] = 0;
$ItemMax[lfemale, ForceFieldPack] = 1;
$ItemMax[lfemale, LargeFieldPack] = 1;
$ItemMax[lfemale, StealthShieldPack] = 1;
$ItemMax[lfemale, FakeFlagPack] = 1;
$ItemMax[lfemale, TeleportPack] = 0;
$ItemMax[lfemale, HellPack] = 1;
$itemmax[lfemale, ResupplyPack] = 1;
$ElfForce[lfemale] = 30;
$BoostSpeed[lfemale] = 2.75;
$SpeedMax[lfemale] = 180;

$MaxWeapons[lfemale] = 8;

//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$DamageScale[mfemale, $LandingDamageType] = 0.45;
$DamageScale[mfemale, $ImpactDamageType] = 1.0;
$DamageScale[mfemale, $CrushDamageType] = 1.0;
$DamageScale[mfemale, $FlakDamageType] = 0.225;
$DamageScale[mfemale, $EnergyDamageType] = 1.0;
$DamageScale[mfemale, $PlasmaDamageType] = 1.0;
$DamageScale[mfemale, $ExplosionDamageType] = 0.5;
$DamageScale[mfemale, $MissileDamageType] = 0.8;
$DamageScale[mfemale, $ShrapnelDamageType] = 0.75;
$DamageScale[mfemale, $DebrisDamageType] = 0.7;
$DamageScale[mfemale, $LaserDamageType] = 1.7;
$DamageScale[mfemale, $RifleDamageType] = 0.34; 
$DamageScale[mfemale, $MortarDamageType] = 1.0;
$DamageScale[mfemale, $BlasterDamageType] = 1.0;
$DamageScale[mfemale, $ElectricityDamageType] = 0.8;
$DamageScale[mfemale, $MineDamageType] = 0.75;
$DamageScale[mfemale, $RailDamageType] = 0.34;
$DamageScale[mfemale, $SalvoDamageType] = 0.15;
$DamageScale[mfemale, $SentryDamageType] = 0.45;

$ItemMax[mfemale, Blaster] = 1;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, Disclauncher] = 1;
$ItemMax[mfemale, GrenadeLauncher] = 0;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, LaserRifle] = 0;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, AssaultRifle] = 1;
$ItemMax[mfemale, Railgun] = 1;
$ItemMax[mfemale, FFBLauncher] = 1;
$ItemMax[mfemale, RocketLauncher] = 1;
$ItemMax[mfemale, CloakGun] = 1; 
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, MineAmmo] = 5;
$ItemMax[mfemale, Grenade] = 15;
$ItemMax[mfemale, Beacon] = 15;

$ItemMax[mfemale, BulletAmmo] = 350;
$ItemMax[mfemale, PlasmaAmmo] = 150;
$ItemMax[mfemale, DiscAmmo] = 125;
$ItemMax[mfemale, GrenadeAmmo] = 20;
$ItemMax[mfemale, MortarAmmo] = 20;
$ItemMax[mfemale, MayhemAmmo] = 500;
$ItemMax[mfemale, RailAmmo] = 250;
$ItemMax[mfemale, FFBAmmo] = 10;
$ItemMax[mfemale, RocketAmmo] = 15;  
  

$ItemMax[mfemale, EnergyPack] = 1;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[mfemale, SensorJammerPack] = 1;
$ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[mfemale, PulseSensorPack] = 5;
$ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[mfemale, CameraPack] = 1;
$ItemMax[mfemale, SpySatellitePack] = 1;
$ItemMax[mfemale, RocketPack] = 1;
$ItemMax[mfemale, TurretPack] = 1;
$ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[mfemale, RepairKit] = 5;
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 0;
$ItemMax[mfemale, ForceFieldPack] = 1;
$ItemMax[mfemale, LargeFieldPack] = 1;
$ItemMax[mfemale, StealthShieldPack] = 1;
$ItemMax[mfemale, FakeFlagPack] = 1;
$ItemMax[mfemale, TeleportPack] = 0;
$ItemMax[mfemale, HellPack] = 1;
$itemmax[mfemale, ResupplyPack] = 1;
$ElfForce[mfemale] = 50;
$BoostSpeed[mfemale] = 2.2;
$SpeedMax[mfemale] = 120;

$MaxWeapons[mfemale] = 9;

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
   visibleToSensor = False;
    mapFilter = 1;
    mapIcon = "M_player";
   canCrouch = True;
    validateShape = true;

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = 436;
   jetEnergyDrain = 0.1;
 
    maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 13;
   maxSideSpeed = 13;
   groundForce = 34 * 10.0;
   mass = 8.0;
   groundTraction = 3.0;
    maxEnergy = 100;
   drag = 1.0;
   density = 1.2;
 
    minDamageSpeed = 35;
    damageScale = 0.005;

   horzVelClamp = 200; 
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
    validateShape = true;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 35;
   minJetEnergy = 1;
   jetForce = 430;
   jetEnergyDrain = 0.1;

	maxDamage = 1.0;
   maxForwardSpeed = 13.0;
   maxBackwardSpeed = 13.0;
   maxSideSpeed = 13.0;
   groundForce = 35 * 13.0;
   mass = 10.0;
   groundTraction = 3.0;
	
	maxEnergy = 100;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   horzVelClamp = 120; 
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
    validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 25;
   minJetEnergy = 1;
   jetForce = 635;
   jetEnergyDrain = 0.1;

	maxDamage = 1.32;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 17.0;
	maxEnergy = 110;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;
   horzVelClamp = 60;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 150;
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

   jetSound = SoundJetHeavy;

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
    validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = 436;
   jetEnergyDrain = 0.1;

	maxDamage = 0.66;
   maxForwardSpeed = 13;
   maxBackwardSpeed = 13;
   maxSideSpeed = 13;
   groundForce = 40 * 9.0;
   mass = 8.0;
   groundTraction = 3.0;
	maxEnergy = 100;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   horzVelClamp = 200; 
   jumpImpulse = 75;
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
   boxNormalHeight = 2.2;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

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
    validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.95;
   maxJetForwardVelocity = 34;
   minJetEnergy = 1;
   jetForce = 620;
   jetEnergyDrain = 0.1;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 10.0;
   maxSideSpeed = 10.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 100;
   mass = 10.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   horzVelClamp = 120; 
   jumpImpulse = 110;
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
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

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

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};









