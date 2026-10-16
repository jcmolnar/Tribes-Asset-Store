FlierData Scout 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "flyer";
 shieldShapeName = "shield_medium";
 mass = 9.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 75;
 minSpeed = -2;
 lift = 0.75;
 maxAlt = 25;
 maxVertical = 10;
 maxDamage = 0.70;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.6;
 groundDamageScale = 1.0;
 reloadDelay = 2;
 repairRate = 0;
 fireSound = SoundFireFlierRocket;
 damageSound = SoundFlierCrash;
 ramDamage = 1.5;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 visibleToSensor = true;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;
 driverPose = 22;
 };
//-------------------------------------
 function Scout::onFire(%vehicle, %slot) {
 if(!%vehicle.isFiring) {
 %count = 2;
 RenToggleFire(%vehicle);
 schedule("RenMissleFire(" @ %vehicle @ " , " @ %count @ ");",0.25,%vehicle);
 schedule("RenToggleFire(" @ %vehicle @ ");",1.87,%vehicle);
 }
 }
 function RenMissleFire(%vehicle, %count) {
 if(%count) {
 %trans = GameBase::getMuzzleTransform(%vehicle);
 %vel = Item::getVelocity(%vehicle);
 Projectile::spawnProjectile("Nuke",%trans,%vehicle,%vel);
 playSound(SoundFlierRocket,GameBase::getPosition(%vehicle));
 %count--;
 schedule("RenMissleFire(" @ %vehicle @ " , " @ %count @ ");",0.2,%vehicle);
 }
 }
 function RenToggleFire(%this) {
 if(%this.isFiring) %this.isFiring = false;
 else %this.isFiring = true;
 }
//------------------------------------- 
FlierData Jet 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "flyer";
 shieldShapeName = "shield_medium";
 mass = 9.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 75;
 minSpeed = -2;
 lift = 0.95;
 maxAlt = 25;
 maxVertical = 12;
 maxDamage = 0.70;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.8;
 groundDamageScale = 1.0;
 projectileType = VulcanBullet2;
 reloadDelay = 0.08;
 repairRate = 0;
 damageSound = SoundFlierCrash;
 ramDamage = 1.5;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 visibleToSensor = true;
 shadowDetailMask = 2;
 fireSound = SoundFireMortar;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;
 driverPose = 22;
 
};
 
FlierData Wraith 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "flyer";
 shieldShapeName = "shield_medium";
 mass = 9.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 65;
 minSpeed = -2;
 lift = 0.75;
 maxAlt = 25;
 maxVertical = 10;
 maxDamage = 0.5;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.4;
 groundDamageScale = 1.0;
 reloadDelay = 0.1;
 repairRate = 0;
 fireSound = SoundFireFlierRocket;
 damageSound = SoundFlierCrash;
 ramDamage = 1.5;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 visibleToSensor = false;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = false;
 driverPose = 22;
 
};
//----------------------------------------
FlierData CorAir 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "flyer";
 shieldShapeName = "shield_medium";
 mass = 9.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 70;
 minSpeed = -2;
 lift = 0.95;
 maxAlt = 25;
 maxVertical = 12;
 maxDamage = 0.6;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.4;
 groundDamageScale = 1.0;
 projectileType = FlierBolt;
 reloadDelay = 0.20;
 repairRate = 0;
 fireSound = SoundFireFlierRocket;
 damageSound = SoundFlierCrash;
 ramDamage = 1.5;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 visibleToSensor = true;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;
 driverPose = 22;
 
}
;
//----------------------------------------
 FlierData SLAPC 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "hover_apc_sml";
 shieldShapeName = "shield_large";
 mass = 18.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 55;
 minSpeed = -5;
 lift = 0.5;
 maxAlt = 15;
 maxVertical = 9;
 maxDamage = 2.3;
 damageLevel = {1.0, 1.0};
 destroyDamage = 1.0;
 maxEnergy = 100;
 accel = 0.25;
 groundDamageScale = 0.50;
 repairRate = 0;
 ramDamage = 2.3;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 fireSound = SoundFireMortar;
 reloadDelay = 4.0;
 damageSound = SoundTankCrash;
 visibleToSensor = True;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;
 driverPose = 23;
 
};
//-------------------------------------------
 function SLAPC::onFire(%vehicle, %slot) {
 if(!%vehicle.isFiring) {
 %count = 4;
 RenToggleFire(%vehicle);
 schedule("RenNukeFire(" @ %vehicle @ " , " @ %count @ ");",0.25,%vehicle);
 schedule("RentoggleFire(" @ %vehicle @ ");",6.0,%vehicle);
 } 
 }
 function RenNukeFire(%vehicle, %count) {
 if(%count) {
 %trans = GameBase::getMuzzleTransform(%vehicle);
 %vel = Item::getVelocity(%vehicle);
 Projectile::spawnProjectile("ShockShell2",%trans,%vehicle,%vel);
 playSound(SoundFireMortar,GameBase::getPosition(%vehicle));
 %count--;
 schedule("RenNukeFire(" @ %vehicle @ " , " @ %count @ ");",0.2,%vehicle);
 }
 }
 function RenToggleFire(%this) {
 if(%this.isFiring) %this.isFiring = false;
 else %this.isFiring = true;
 }

//----------------------------------------
 FlierData LAPC 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "hover_apc_sml";
 shieldShapeName = "shield_large";
 mass = 18.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 55;
 minSpeed = -5;
 lift = 0.5;
 maxAlt = 15;
 maxVertical = 9;
 maxDamage = 2.3;
 damageLevel = {1.0, 1.0};
 destroyDamage = 1.0;
 maxEnergy = 100;
 accel = 0.25;
 groundDamageScale = 0.50;
 repairRate = 0;
 ramDamage = 2.3;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 fireSound = SoundFireMortar;
 reloadDelay = 4.0;
 damageSound = SoundTankCrash;
 visibleToSensor = true;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;

 driverPose = 23;
 
};
//-------------------------------------------
 function LAPC::onFire(%vehicle, %slot) {
 if(!%vehicle.isFiring) {
 %count = 2;
 RenToggleFire(%vehicle);
 schedule("RenMortarFire(" @ %vehicle @ " , " @ %count @ ");",0.25,%vehicle);
 schedule("RentoggleFire(" @ %vehicle @ ");",6.0,%vehicle);
 }
 }
 function RenMortarFire(%vehicle, %count) {
 if(%count) {
 %trans = GameBase::getMuzzleTransform(%vehicle);
 %vel = Item::getVelocity(%vehicle);
 Projectile::spawnProjectile("MortarShell2",%trans,%vehicle,%vel);
 playSound(SoundFireMortar,GameBase::getPosition(%vehicle));
 %count--;
 schedule("RenMortarFire(" @ %vehicle @ " , " @ %count @ ");",0.2,%vehicle);
 }
 }
 function RenToggleFire(%this) {
 if(%this.isFiring) %this.isFiring = false;
 else %this.isFiring = true;
 }
//-------------------------------------------
 FlierData HAPC 
{
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "hover_apc";
 shieldShapeName = "shield_large";
 mass = 18.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.8;
 maxPitch = 0.9;
 maxSpeed = 50;
 minSpeed = -5;
 lift = 0.35;
 maxAlt = 15;
 maxVertical = 6;
 maxDamage = 2.5;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.25;
 groundDamageScale = 0.125;
 repairRate = 0;
 ramDamage = 2.5;
 ramDamageType = -1;
 mapFilter = 2;
 mapIcon = "M_vehicle";
 fireSound = SoundFireFlierRocket;
 reloadDelay = 3.0;
 damageSound = SoundTankCrash;
 visibleToSensor = false;
 shadowDetailMask = 2;
 mountSound = SoundFlyerMount;
 dismountSound = SoundFlyerDismount;
 idleSound = SoundFlyerIdle;
 moveSound = SoundFlyerActive;
 visibleDriver = true;
 driverPose = 23;
 
}
;

//-------------------------------------------
 $DamageScale[Scout, $TurretDamageType] = 1.0;
 $DamageScale[Scout, $ImpactDamageType] = 1.0;
 $DamageScale[Scout, $BulletDamageType] = 1.0;
 $DamageScale[Scout, $PlasmaDamageType] = 1.0;
 $DamageScale[Scout, $EnergyDamageType] = 1.0;
 $DamageScale[Scout, $ExplosionDamageType] = 1.0;
 $DamageScale[Scout, $ShrapnelDamageType] = 1.0;
 $DamageScale[Scout, $DebrisDamageType] = 1.0;
 $DamageScale[Scout, $MissileDamageType] = 1.2;
 $DamageScale[Scout, $LaserDamageType] = 1.0;
 $DamageScale[Scout, $MortarDamageType] = 1.0;
 $DamageScale[Scout, $BlasterDamageType] = 0.5;
 $DamageScale[Scout, $ElectricityDamageType] = 1.0;
 $DamageScale[Scout, $MineDamageType] = 1.0;
 $DamageScale[Scout, $SniperDamageType] = 1.0;
 $DamageScale[Scout, $LowWarheadDamageType] = 1.0;
 $DamageScale[Scout, $MedWarheadDamageType] = 1.0;
 $DamageScale[Scout, $HighWarheadDamageType] = 1.0;
 $DamageScale[Scout, $EMPWarheadDamageType] = 1.0;
 $DamageScale[Scout, $VulcanDamageType] = 1.0;
 $DamageScale[Scout, $TBulletDamageType] = 1.0;
 $DamageScale[Scout, $Vulcan2DamageType] = 1.0;
 $DamageScale[Scout, $MagnumDamageType] = 1.0;
 $DamageScale[Jet,  $TurretDamageType] = 1.0;
 $DamageScale[Jet, $ImpactDamageType] = 1.0;
 $DamageScale[Jet, $BulletDamageType] = 1.0;
 $DamageScale[Jet, $PlasmaDamageType] = 1.0;
 $DamageScale[Jet, $EnergyDamageType] = 1.0;
 $DamageScale[Jet, $ExplosionDamageType] = 1.0;
 $DamageScale[Jet, $ShrapnelDamageType] = 1.0;
 $DamageScale[Jet, $DebrisDamageType] = 1.0;
 $DamageScale[Jet, $MissileDamageType] = 1.2;
 $DamageScale[Jet, $LaserDamageType] = 1.0;
 $DamageScale[Jet, $MortarDamageType] = 1.0;
 $DamageScale[Jet, $BlasterDamageType] = 0.5;
 $DamageScale[Jet, $ElectricityDamageType] = 1.0;
 $DamageScale[Jet, $MineDamageType] = 1.0;
 $DamageScale[Jet, $SniperDamageType] = 1.0;
 $DamageScale[Jet, $LowWarheadDamageType] = 1.0;
 $DamageScale[Jet, $MedWarheadDamageType] = 1.0;
 $DamageScale[Jet, $HighWarheadDamageType] = 1.0;
 $DamageScale[Jet, $EMPWarheadDamageType] = 1.0;
 $DamageScale[Jet, $VulcanDamageType] = 1.0;
 $DamageScale[Jet, $TBulletDamageType] = 1.0;
 $DamageScale[Jet, $Vulcan2DamageType] = 1.0;
 $DamageScale[Jet, $MagnumDamageType] = 1.0;
 $DamageScale[CorAir, $TurretDamageType] = 1.0;
 $DamageScale[CorAir, $ImpactDamageType] = 1.0;
 $DamageScale[CorAir, $BulletDamageType] = 1.5;
 $DamageScale[CorAir, $PlasmaDamageType] = 1.0;
 $DamageScale[CorAir, $EnergyDamageType] = 1.0;
 $DamageScale[CorAir, $ExplosionDamageType] = 1.0;
 $DamageScale[CorAir, $ShrapnelDamageType] = 1.0;
 $DamageScale[CorAir, $DebrisDamageType] = 1.0;
 $DamageScale[CorAir, $MissileDamageType] = 1.2;
 $DamageScale[CorAir, $LaserDamageType] = 1.0;
 $DamageScale[CorAir, $MortarDamageType] = 1.0;
 $DamageScale[CorAir, $BlasterDamageType] = 0.5;
 $DamageScale[CorAir, $ElectricityDamageType] = 1.0;
 $DamageScale[CorAir, $MineDamageType] = 1.0;
 $DamageScale[CorAir, $SniperDamageType] = 1.0;
 $DamageScale[CorAir, $LowWarheadDamageType] = 1.0;
 $DamageScale[CorAir, $MedWarheadDamageType] = 1.0;
 $DamageScale[CorAir, $HighWarheadDamageType] = 1.0;
 $DamageScale[CorAir, $EMPWarheadDamageType] = 1.0;
 $DamageScale[CorAir, $VulcanDamageType] = 1.0;
 $DamageScale[CorAir, $TBulletDamageType] = 1.0;
 $DamageScale[CorAir, $Vulcan2DamageType] = 1.0;
 $DamageScale[CorAir, $MagnumDamageType] = 1.0;
 $DamageScale[SLAPC, $TurretDamageType] = 1.0;
 $DamageScale[SLAPC, $ImpactDamageType] = 2.0;
 $DamageScale[SLAPC, $BulletDamageType] = 0.6;
 $DamageScale[SLAPC, $PlasmaDamageType] = 1.0;
 $DamageScale[SLAPC, $EnergyDamageType] = 1.0;
 $DamageScale[SLAPC, $ExplosionDamageType] = 1.0;
 $DamageScale[SLAPC, $ShrapnelDamageType] = 1.0;
 $DamageScale[SLAPC, $DebrisDamageType] = 1.0;
 $DamageScale[SLAPC, $MissileDamageType] = 1.2;
 $DamageScale[SLAPC, $LaserDamageType] = 0.8;
 $DamageScale[SLAPC, $MortarDamageType] = 1.2;
 $DamageScale[SLAPC, $BlasterDamageType] = 0.5;
 $DamageScale[SLAPC, $ElectricityDamageType] = 1.0;
 $DamageScale[SLAPC, $MineDamageType] = 1.0;
 $DamageScale[SLAPC, $SniperDamageType] = 1.0;
 $DamageScale[SLAPC, $LowWarheadDamageType] = 1.1;
 $DamageScale[SLAPC, $MedWarheadDamageType] = 1.1;
 $DamageScale[SLAPC, $HighWarheadDamageType] = 1.2;
 $DamageScale[SLAPC, $EMPWarheadDamageType] = 1.1;
 $DamageScale[SLAPC, $VulcanDamageType] = 0.4;
 $DamageScale[SLAPC, $TBulletDamageType] = 0.6;
 $DamageScale[SLAPC, $Vulcan2DamageType] = 0.5;
 $DamageScale[SLAPC, $MagnumDamageType] = 0.7;
 $DamageScale[Wraith, $TurretDamageType] = 1.0;
 $DamageScale[Wraith, $ImpactDamageType] = 1.0;
 $DamageScale[Wraith, $BulletDamageType] = 1.0;
 $DamageScale[Wraith, $PlasmaDamageType] = 1.0;
 $DamageScale[Wraith, $EnergyDamageType] = 1.0;
 $DamageScale[Wraith, $ExplosionDamageType] = 1.0;
 $DamageScale[Wraith, $ShrapnelDamageType] = 1.0;
 $DamageScale[Wraith, $DebrisDamageType] = 1.0;
 $DamageScale[Wraith, $MissileDamageType] = 1.0;
 $DamageScale[Wraith, $LaserDamageType] = 1.0;
 $DamageScale[Wraith, $MortarDamageType] = 1.0;
 $DamageScale[Wraith, $BlasterDamageType] = 0.5;
 $DamageScale[Wraith, $ElectricityDamageType] = 1.0;
 $DamageScale[Wraith, $MineDamageType] = 1.0;
 $DamageScale[Wraith, $SniperDamageType] = 1.0;
 $DamageScale[Wraith, $LowWarheadDamageType] = 1.0;
 $DamageScale[Wraith, $MedWarheadDamageType] = 1.0;
 $DamageScale[Wraith, $HighWarheadDamageType] = 1.0;
 $DamageScale[Wraith, $EMPWarheadDamageType] = 1.0;
 $DamageScale[Wraith, $VulcanDamageType] = 1.0;
 $DamageScale[Wraith, $TBulletDamageType] = 1.0;
 $DamageScale[Wraith, $Vulcan2DamageType] = 1.0;
 $DamageScale[Wraith, $MagnumDamageType] = 1.0;
 $DamageScale[LAPC, $TurretDamageType] = 1.0;
 $DamageScale[LAPC, $ImpactDamageType] = 2.0;
 $DamageScale[LAPC, $BulletDamageType] = 0.6;
 $DamageScale[LAPC, $PlasmaDamageType] = 1.0;
 $DamageScale[LAPC, $EnergyDamageType] = 1.0;
 $DamageScale[LAPC, $ExplosionDamageType] = 1.0;
 $DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
 $DamageScale[LAPC, $DebrisDamageType] = 1.0;
 $DamageScale[LAPC, $MissileDamageType] = 1.2;
 $DamageScale[LAPC, $LaserDamageType] = 0.5;
 $DamageScale[LAPC, $MortarDamageType] = 1.2;
 $DamageScale[LAPC, $BlasterDamageType] = 0.5;
 $DamageScale[LAPC, $ElectricityDamageType] = 1.0;
 $DamageScale[LAPC, $MineDamageType] = 1.0;
 $DamageScale[LAPC, $SniperDamageType] = 1.0;
 $DamageScale[LAPC, $LowWarheadDamageType] = 1.1;
 $DamageScale[LAPC, $MedWarheadDamageType] = 1.1;
 $DamageScale[LAPC, $HighWarheadDamageType] = 1.2;
 $DamageScale[LAPC, $EMPWarheadDamageType] = 1.0;
 $DamageScale[LAPC, $VulcanDamageType] = 0.6;
 $DamageScale[LAPC, $TBulletDamageType] = 0.6;
 $DamageScale[LAPC, $Vulcan2DamageType] = 1.0;
 $DamageScale[LAPC, $MagnumDamageType] = 1.0;
 $DamageScale[HAPC, $TurretDamageType] = 1.0;
 $DamageScale[HAPC, $ImpactDamageType] = 2.0;
 $DamageScale[HAPC, $BulletDamageType] = 0.7;
 $DamageScale[HAPC, $PlasmaDamageType] = 1.0;
 $DamageScale[HAPC, $EnergyDamageType] = 1.0;
 $DamageScale[HAPC, $ExplosionDamageType] = 1.0;
 $DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
 $DamageScale[HAPC, $DebrisDamageType] = 1.0;
 $DamageScale[HAPC, $MissileDamageType] = 1.3;
 $DamageScale[HAPC, $LaserDamageType] = 0.5;
 $DamageScale[HAPC, $MortarDamageType] = 1.0;
 $DamageScale[HAPC, $BlasterDamageType] = 0.5;
 $DamageScale[HAPC, $ElectricityDamageType] = 1.0;
 $DamageScale[HAPC, $MineDamageType] = 1.0;
 $DamageScale[HAPC, $SniperDamageType] = 1.0;
 $DamageScale[HAPC, $LowWarheadDamageType] = 1.1;
 $DamageScale[HAPC, $MedWarheadDamageType] = 1.2;
 $DamageScale[HAPC, $HighWarheadDamageType] = 1.3;
 $DamageScale[HAPC, $EMPWarheadDamageType] = 1.1;
 $DamageScale[HAPC, $VulcanDamageType] = 0.5;
 $DamageScale[HAPC, $TBulletDamageType] = 0.5;
 $DamageScale[HAPC, $Vulcan2DamageType] = 0.6;
 $DamageScale[HAPC, $MagnumDamageType] = 0.6;
 
function Vehicle::onAdd(%this) 
{
 %this.shieldStrength = 0.0;
 GameBase::setRechargeRate (%this, 10);
 if(GameBase::getDataName(%this) == Scout) GameBase::setMapName (%this, "Scout");
 if(GameBase::getDataName(%this) == Jet) GameBase::setMapName (%this, "Interceptor");
 if(GameBase::getDataName(%this) == CorAir) GameBase::setMapName (%this, "Corsair");
 if(GameBase::getDataName(%this) == SLAPC) GameBase::setMapName (%this, "EMP Bomber LPC");
 if(GameBase::getDataName(%this) == HAPC) GameBase::setMapName (%this, "Stealth HPC");
 if(GameBase::getDataName(%this) == LAPC) GameBase::setMapName (%this, "Bomber LPC");
 
}
 function Vehicle::onCollision (%this, %object) 
{
 if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) 
{
 if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") 
{
 %armor = Player::getArmor(%object);
 %client = Player::getClient(%object);
 if(%object.station != "") 
{
 if (%armor != "sarmor" && %armor != "sfemale") 
{
 
 playNextAnim(%client);
 Player::kill(%client);
 
}
 else Client::sendMessage(%client,0,"You can not mount a vehicle while in a station.~wError_Message.wav");
 return;
 
}
//if (((%armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object)) || ((%armor == "earmor" || %armor == "efemale") && Vehicle::canMount (%this, %object) && Player::getMountedItem(%object,$Backpackslot) == "Laptop"))
if (((%armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object)) || ((%armor == "earmor" || %armor == "efemale") && Vehicle::canMount (%this, %object) && Player::getMountedItem(%object,$Backpackslot) == "Laptop" && (GameBase::getDataName(%this) == LAPC || GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == SLAPC)))
{
 %weapon = Player::getMountedItem(%object,$WeaponSlot);
 if(%weapon != -1) 
{
 %object.lastWeapon = %weapon;
 Player::unMountItem(%object,$WeaponSlot);
 
}
 if(GameBase::getDataName(%this) == Wraith) 
{
 if(Player::getMountedItem(%object,$FlagSlot) != "flag") GameBase::startFadeout(%this);
}

 %client.isFlying = "true";
 Player::setMountObject(%object, %this, 1);
 Client::setControlObject(%client, %this);
 playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
 %object.driver= 1;
 %object.vehicle = %this;
 %this.clLastMount = %client;

}
 else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Wraith) && (GameBase::getDataName(%this) != Jet) && (GameBase::getDataName(%this) != CorAir)) 
{
 %mountSlot= Vehicle::findEmptySeat(%this,%client);
 if(%mountSlot) 
{
 %object.vehicleSlot = %mountSlot;
 %object.vehicle = %this;
 Player::setMountObject(%object, %this, %mountSlot);
 playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
 
}
 
}
else if (GameBase::getControlClient(%this) == -1) Client::sendMessage(Player::getClient(%object),0,"You can't control this vehicle in this class. Please choose a different vehicle or Armor Class~wError_Message.wav");
 
}
 
}
 
}

 function Vehicle::findEmptySeat(%this,%client,%object) 
{

 if(GameBase::getDataName(%this) == HAPC) %numSlots = 4;
 else %numSlots = 2;
 %count=0;
 for(%i=0;%i<%numSlots;%i++) if(%this.Seat[%i] == "") 
{
 %slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
 %slotVal[%count] = %i+2;
 %lastEmpty = %i+2;
 %count++;
 
}
 if(%count == 1) 
{
 %this.Seat[%lastEmpty-2] = %client;
 return %lastEmpty;
 
}
 else if (%count > 1) 
{
 %freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
 %this.Seat[%freeSlot-2] = %client;
 return %freeSlot;
 
}
 else return "False";
 
}
 function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3) 
{
 %playerX = getWord(%playerPos,0);
 %playerY = getWord(%playerPos,1);
 for(%i = 0 ;
%i<%num;
%i++) 
{
 %x = (getWord(%slotPos[%i],0)) - %playerX;
 %y = (getWord(%slotPos[%i],1)) - %playerY;
 if(%x < 0) %x *= -1;
 if(%y < 0) %y *= -1;
 %newDistance = sqrt((%x*%x)+(%y*%y));
 if(%newDistance < %distance || %distance == "") 
{
 %distance = %newDistance;
 %closePos = %i;
 
}
 
}
 return %closePos;
 
}
 function Vehicle::passengerJump(%this,%passenger,%mom) 
{
 %armor = Player::getArmor(%passenger);
 if(%armor == "larmor" || %armor == "lfemale") 
{
 %height = 2;
 %velocity = 70;
 %zVec = 70;
 
}
 else if(%armor == "marmor" || %armor == "mfemale") 
{
 %height = 2;
 %velocity = 100;
 %zVec = 100;
 
}
 else if(%armor == "harmor" || %armor == "darmor")
{
 %height = 2;
 %velocity = 140;
 %zVec = 110;
 
}
 else 
{
 %height = 2;
 %velocity = 70;
 %zVec = 70;
 
}
 %pos = GameBase::getPosition(%passenger);
 %posX = getWord(%pos,0);
 %posY = getWord(%pos,1);
 %posZ = getWord(%pos,2);
 if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) 
{
 %client = Player::getClient(%passenger);
 %this.Seat[%passenger.vehicleSlot-2] = "";
 %passenger.vehicleSlot = "";
 %passenger.vehicle= "";
 Player::setMountObject(%passenger, -1, 0);
 %rotZ = getWord(GameBase::getRotation(%passenger),2);
 GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
 GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
 %jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
 Player::applyImpulse(%passenger,%jumpDir);
 Player::getClient(%passenger).isFlying = "false";
 
}
 else Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
 
}
 function Vehicle::jump(%this,%mom) 
{
 Vehicle::dismount(%this,%mom);
 
}
 function Vehicle::dismount(%this,%mom) 
{
 %cl = GameBase::getControlClient(%this);
 if(%cl != -1) 
{
 %pl = Client::getOwnedObject(%cl);
 if(getObjectType(%pl) == "Player") 
{
 if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) 
{
 %pl.lastMount = %this;
 %pl.newMountTime = getSimTime() + 3.0;
 Player::setMountObject(%pl, %this, 0);
 Player::setMountObject(%pl, -1, 0);
 %rot = GameBase::getRotation(%this);
 %rotZ = getWord(%rot,2);
 GameBase::setRotation(%pl, "0 0 " @ %rotZ);
 Player::applyImpulse(%pl,%mom);
 Client::setControlObject(%cl, %pl);
 playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
 %cl.isFlying = "false";
 if(%pl.lastWeapon != "") 
{
 Player::useItem(%pl,%pl.lastWeapon);
 %pl.lastWeapon = "";
 if(GameBase::getDataName(%this) == Wraith) 
{
 GameBase::startFadein(%this);
 
}
}
 %pl.driver = "";
 %pl.vehicle = "";
 
}
 else Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
 
}
 
}
 
}
 function Vehicle::onDestroyed (%this,%mom) 
{
 $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
 %cl = GameBase::getControlClient(%this);
 %pl = Client::getOwnedObject(%cl);
 if(%pl != -1) 
{
 Player::setMountObject(%pl, -1, 0);
 Client::setControlObject(%cl, %pl);
 %cl.isFlying = "false";
 if(%pl.lastWeapon != "") 
{
 Player::useItem(%pl,%pl.lastWeapon);
 %pl.lastWeapon = "";
 
}
 %pl.driver = "";
 
}
 for(%i = 0 ;
 %i < 4 ;
 %i++) if(%this.Seat[%i] != "") 
{
 %pl = Client::getOwnedObject(%this.Seat[%i]);
 Player::setMountObject(%pl, -1, 0);
 Client::setControlObject(%this.Seat[%i], %pl);
 
}
 calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
 
}
 function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
 %value *= $damageScale[GameBase::getDataName(%this), %type];
 StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
 
}
 function Vehicle::getHeatFactor(%this) 
{
 return 1.0;
}
