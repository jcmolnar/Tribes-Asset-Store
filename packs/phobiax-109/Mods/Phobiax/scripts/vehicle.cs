FlierData Scout { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "flyer"; shieldShapeName = "shield_medium"; mass = 9.0; drag = 1.0; density = 1.2; maxBank = 0.5; maxPitch = 0.5; maxSpeed = 50; minSpeed = -2; lift = 0.75; maxAlt = 25; maxVertical = 10; maxDamage = 0.6; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 0.4; groundDamageScale = 1.0; projectileType = FlierRocket; reloadDelay = 2.0; repairRate = 0; fireSound = SoundFireFlierRocket; damageSound = SoundFlierCrash; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 22; description = "Scout"; };
FlierData LAPC { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "hover_apc_sml"; shieldShapeName = "shield_large"; mass = 18.0; drag = 1.0; density = 1.2; maxBank = 0.25; maxPitch = 0.175; maxSpeed = 25; minSpeed = -1; lift = 0.5; maxAlt = 15; maxVertical = 6; maxDamage = 1.5; damageLevel = {1.0, 1.0}; destroyDamage = 1.0; maxEnergy = 100; accel = 0.25; groundDamageScale = 0.50; repairRate = 0; ramDamage = 2; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; fireSound = SoundFireFlierRocket; reloadDelay = 3.0; damageSound = SoundTankCrash; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 23; description = "LPC"; };
FlierData HAPC { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "hover_apc"; shieldShapeName = "shield_large"; mass = 18.0; drag = 1.0; density = 1.2; maxBank = 0.25; maxPitch = 0.175; maxSpeed = 25; minSpeed = -1; lift = 0.35; maxAlt = 15; maxVertical = 6; maxDamage = 2.0; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 0.25; groundDamageScale = 0.125; repairRate = 0; ramDamage = 2; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; fireSound = SoundFireFlierRocket; reloadDelay = 3.0; damageSound = SoundTankCrash; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 23; description = "HPC"; };

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType] = 1.0;
$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType] = 1.0;
$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType] = 1.0;

$DamageScale[Scout, $MagneticDamageType] = 0.5;
$DamageScale[Scout, $EMPDamageType] = 1.0;
$DamageScale[Scout, $BomberDamageType] = 1.0;
$DamageScale[Scout, $RifleDamageType] = 0.5;
$DamageScale[Scout, $FlakDamageType] = 1.0;
$DamageScale[Scout, $RocketDamageType] = 1.0;
$DamageScale[Scout, $ShotgunDamageType] = 1.0;
$DamageScale[Scout, $LowWarheadDamageType] = 1.0;
$DamageScale[Scout, $MedWarheadDamageType] = 1.0;
$DamageScale[Scout, $HighWarheadDamageType] = 1.0;
$DamageScale[Scout, $EMPWarheadDamageType] = 1.0;
$DamageScale[Scout, $PhalanxxDamageType] = 1.0;
$DamageScale[Scout, $ELFTurretDamageType] = 1.0;
$DamageScale[LAPC, $MagneticDamageType] = 0.5;
$DamageScale[LAPC, $EMPDamageType] = 1.0;
$DamageScale[LAPC, $BomberDamageType] = 1.0;
$DamageScale[LAPC, $RifleDamageType] = 0.5;
$DamageScale[LAPC, $FlakDamageType] = 1.0;
$DamageScale[LAPC, $RocketDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;
$DamageScale[LAPC, $LowWarheadDamageType] = 1.0;
$DamageScale[LAPC, $MedWarheadDamageType] = 1.0;
$DamageScale[LAPC, $HighWarheadDamageType] = 1.0;
$DamageScale[LAPC, $EMPWarheadDamageType] = 1.0;
$DamageScale[LAPC, $PhalanxxDamageType] = 1.0;
$DamageScale[LAPC, $ELFTurretDamageType] = 1.0;
$DamageScale[HAPC, $MagneticDamageType] = 0.5;
$DamageScale[HAPC, $EMPDamageType] = 1.0;
$DamageScale[HAPC, $BomberDamageType] = 1.0;
$DamageScale[HAPC, $RifleDamageType] = 0.5;
$DamageScale[HAPC, $FlakDamageType] = 1.0;
$DamageScale[HAPC, $RocketDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;
$DamageScale[HAPC, $LowWarheadDamageType] = 1.0;
$DamageScale[HAPC, $MedWarheadDamageType] = 1.0;
$DamageScale[HAPC, $HighWarheadDamageType] = 1.0;
$DamageScale[HAPC, $EMPWarheadDamageType] = 1.0;
$DamageScale[HAPC, $PhalanxxDamageType] = 1.0;
$DamageScale[HAPC, $ELFTurretDamageType] = 1.0;

$DamageScale[Scout, $FighterDamageType] = 2.5;
$DamageScale[Scout, $DecimatorDamageType] = 1.25;
$DamageScale[Scout, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[Scout, $SentinelDamageType] = 1.0;
$DamageScale[Scout, $DoomsdayDamageType] = 2.0;
$DamageScale[Scout, $TazerBeamDamageType] = 0.5;
$DamageScale[Scout, $TazerBoltDamageType] = 1.0;
$DamageScale[Scout, $RetributionDamageType] = 1.0;
$DamageScale[Scout, $FlareDamageType] = 1.0;
$DamageScale[Scout, $InjectorDamageType] = 1.0;
$DamageScale[Scout, $NaniteDamageType] = 1.0;
$DamageScale[Scout, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[Scout, $BoomBoxNukeDamageType] = 1.0;
$DamageScale[LAPC, $FighterDamageType] = 2.5;
$DamageScale[LAPC, $DecimatorDamageType] = 1.25;
$DamageScale[LAPC, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[LAPC, $SentinelDamageType] = 1.0;
$DamageScale[LAPC, $DoomsdayDamageType] = 2.0;
$DamageScale[LAPC, $TazerBeamDamageType] = 0.5;
$DamageScale[LAPC, $TazerBoltDamageType] = 1.0;
$DamageScale[LAPC, $RetributionDamageType] = 1.0;
$DamageScale[LAPC, $FlareDamageType] = 1.0;
$DamageScale[LAPC, $InjectorDamageType] = 1.0;
$DamageScale[LAPC, $NaniteDamageType] = 1.0;
$DamageScale[LAPC, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[LAPC, $BoomBoxNukeDamageType] = 1.0;
$DamageScale[HAPC, $FighterDamageType] = 2.5;
$DamageScale[HAPC, $DecimatorDamageType] = 1.25;
$DamageScale[HAPC, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[HAPC, $SentinelDamageType] = 1.0;
$DamageScale[HAPC, $DoomsdayDamageType] = 2.0;
$DamageScale[HAPC, $TazerBeamDamageType] = 0.5;
$DamageScale[HAPC, $TazerBoltDamageType] = 1.0;
$DamageScale[HAPC, $RetributionDamageType] = 1.0;
$DamageScale[HAPC, $FlareDamageType] = 1.0;
$DamageScale[HAPC, $InjectorDamageType] = 1.0;
$DamageScale[HAPC, $NaniteDamageType] = 1.0;
$DamageScale[HAPC, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[HAPC, $BoomBoxNukeDamageType] = 1.0;

FlierData Bomber { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "flyer"; shieldShapeName = "shield_medium"; mass = 9.0; drag = 1.0; density = 1.2; maxBank = 0.5; maxPitch = 0.6; maxSpeed = 50; minSpeed = -5; lift = 0.25; maxAlt = 35; maxVertical = 5; maxDamage = 0.3; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 0.25; groundDamageScale = 1.0; reloadDelay = 6.0; repairRate = 0; fireSound = SoundPlasmaTurretFire; damageSound = SoundFlierCrash; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 22; description = "Firestorm Bomber"; };
function Bomber::onFire(%vehicle, %slot) { if(!%vehicle.isFiring) { %count = 7; ixToggleFire(%vehicle); schedule("ixDeployBomblets(" @ %vehicle @ " , " @ %count @ ");",0.25,%vehicle); schedule("ixToggleFire(" @ %vehicle @ ");",6.0,%vehicle); } }
function ixDeployBomblets(%vehicle, %count) { if(%count) { %trans = GameBase::getMuzzleTransform(%vehicle); %vel = Item::getVelocity(%vehicle); Projectile::spawnProjectile("BomberWarhead",%trans,%vehicle,%vel); playSound(SoundPlasmaTurretFire,GameBase::getPosition(%vehicle)); %count--; schedule("ixDeployBomblets(" @ %vehicle @ " , " @ %count @ ");",0.2,%vehicle); } }
function ixToggleFire(%this) { if(%this.isFiring) %this.isFiring = false; else %this.isFiring = true; }

FlierData SLAPC { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "hover_apc_sml"; shieldShapeName = "shield_large"; mass = 18.0; drag = 1.0; density = 1.2; maxBank = 0.25; maxPitch = 0.175; maxSpeed = 25; minSpeed = -1; lift = 0.5; maxAlt = 15; maxVertical = 6; maxDamage = 1.5; damageLevel = {1.0, 1.0}; destroyDamage = 1.0; maxEnergy = 100; accel = 0.25; groundDamageScale = 0.50; repairRate = 0; ramDamage = 2; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; fireSound = SoundFireFlierRocket; reloadDelay = 3.0; damageSound = SoundTankCrash; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 23; description = "Stealth LPC"; };
function SLAPC::onMount(%this, %player) { %rate = Player::getSensorSupression(%player) + 10; Player::setSensorSupression(%player,%rate); }
function SLAPC::onDismount(%this, %player) { %rate = Player::getSensorSupression(%player) - 10; Player::setSensorSupression(%player,%rate); }

FlierData Fighter { explosionId = flashExpLarge; debrisId = flashDebrisLarge; className = "Vehicle"; shapeFile = "flyer"; shieldShapeName = "shield_medium"; mass = 9.0; drag = 1.0; density = 1.2; maxBank = 0.75; maxPitch = 0.5; maxSpeed = 55; minSpeed = -5; lift = 0.5; maxAlt = 25; maxVertical = 10; maxDamage = 0.3; damageLevel = {1.0, 1.0}; maxEnergy = 100; accel = 0.65; groundDamageScale = 1.0; projectileType = FighterBolt; reloadDelay = 0.125; repairRate = 0; fireSound = SoundRemoteTurretFire; damageSound = SoundFlierCrash; ramDamage = 1.5; ramDamageType = -1; mapFilter = 2; mapIcon = "M_vehicle"; visibleToSensor = true; shadowDetailMask = 2; mountSound = SoundFlyerMount; dismountSound = SoundFlyerDismount; idleSound = SoundFlyerIdle; moveSound = SoundFlyerActive; visibleDriver = true; driverPose = 22; description = "Lightningstrike Fighter"; };

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType] = 1.0;
$DamageScale[Bomber, $MagneticDamageType] = 0.5;
$DamageScale[Bomber, $EMPDamageType] = 1.0;
$DamageScale[Bomber, $BomberDamageType] = 1.0;
$DamageScale[Bomber, $RifleDamageType] = 0.5;
$DamageScale[Bomber, $FlakDamageType] = 1.0;
$DamageScale[Bomber, $RocketDamageType] = 1.0;
$DamageScale[Bomber, $ShotgunDamageType] = 1.0;
$DamageScale[Bomber, $LowWarheadDamageType] = 1.0;
$DamageScale[Bomber, $MedWarheadDamageType] = 1.0;
$DamageScale[Bomber, $HighWarheadDamageType] = 1.0;
$DamageScale[Bomber, $EMPWarheadDamageType] = 1.0;
$DamageScale[Bomber, $PhalanxxDamageType] = 1.0;
$DamageScale[Bomber, $ELFTurretDamageType] = 1.0;
$DamageScale[SLAPC, $ImpactDamageType] = 1.0;
$DamageScale[SLAPC, $BulletDamageType] = 1.0;
$DamageScale[SLAPC, $PlasmaDamageType] = 1.0;
$DamageScale[SLAPC, $EnergyDamageType] = 1.0;
$DamageScale[SLAPC, $ExplosionDamageType] = 1.0;
$DamageScale[SLAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[SLAPC, $DebrisDamageType] = 1.0;
$DamageScale[SLAPC, $MissileDamageType] = 1.0;
$DamageScale[SLAPC, $LaserDamageType] = 1.0;
$DamageScale[SLAPC, $MortarDamageType] = 1.0;
$DamageScale[SLAPC, $BlasterDamageType] = 0.5;
$DamageScale[SLAPC, $ElectricityDamageType] = 1.0;
$DamageScale[SLAPC, $MineDamageType] = 1.0;
$DamageScale[SLAPC, $MagneticDamageType] = 0.5;
$DamageScale[SLAPC, $EMPDamageType] = 1.0;
$DamageScale[SLAPC, $BomberDamageType] = 1.0;
$DamageScale[SLAPC, $RifleDamageType] = 0.5;
$DamageScale[SLAPC, $FlakDamageType] = 1.0;
$DamageScale[SLAPC, $RocketDamageType] = 1.0;
$DamageScale[SLAPC, $ShotgunDamageType] = 1.0;
$DamageScale[SLAPC, $LowWarheadDamageType] = 1.0;
$DamageScale[SLAPC, $MedWarheadDamageType] = 1.0;
$DamageScale[SLAPC, $HighWarheadDamageType] = 1.0;
$DamageScale[SLAPC, $EMPWarheadDamageType] = 1.0;
$DamageScale[SLAPC, $PhalanxxDamageType] = 1.0;
$DamageScale[SLAPC, $ELFTurretDamageType] = 1.0;

$DamageScale[Bomber, $FighterDamageType] = 2.5;
$DamageScale[Bomber, $DecimatorDamageType] = 1.25;
$DamageScale[Bomber, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[Bomber, $SentinelDamageType] = 1.0;
$DamageScale[Bomber, $DoomsdayDamageType] = 2.0;
$DamageScale[Bomber, $TazerBeamDamageType] = 0.5;
$DamageScale[Bomber, $TazerBoltDamageType] = 1.0;
$DamageScale[Bomber, $RetributionDamageType] = 1.0;
$DamageScale[Bomber, $FlareDamageType] = 1.0;
$DamageScale[Bomber, $InjectorDamageType] = 1.0;
$DamageScale[Bomber, $NaniteDamageType] = 1.0;
$DamageScale[Bomber, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[Bomber, $BoomBoxNukeDamageType] = 1.0;
$DamageScale[SLAPC, $FighterDamageType] = 2.5;
$DamageScale[SLAPC, $DecimatorDamageType] = 1.25;
$DamageScale[SLAPC, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[SLAPC, $SentinelDamageType] = 1.0;
$DamageScale[SLAPC, $DoomsdayDamageType] = 2.0;
$DamageScale[SLAPC, $TazerBeamDamageType] = 0.5;
$DamageScale[SLAPC, $TazerBoltDamageType] = 1.0;
$DamageScale[SLAPC, $RetributionDamageType] = 1.0;
$DamageScale[SLAPC, $FlareDamageType] = 1.0;
$DamageScale[SLAPC, $InjectorDamageType] = 1.0;
$DamageScale[SLAPC, $NaniteDamageType] = 1.0;
$DamageScale[SLAPC, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[SLAPC, $BoomBoxNukeDamageType] = 1.0;

$DamageScale[Fighter, $ImpactDamageType] = 1.0;
$DamageScale[Fighter, $BulletDamageType] = 1.0;
$DamageScale[Fighter, $PlasmaDamageType] = 1.0;
$DamageScale[Fighter, $EnergyDamageType] = 1.0;
$DamageScale[Fighter, $ExplosionDamageType] = 1.0;
$DamageScale[Fighter, $ShrapnelDamageType] = 1.0;
$DamageScale[Fighter, $DebrisDamageType] = 1.0;
$DamageScale[Fighter, $MissileDamageType] = 1.0;
$DamageScale[Fighter, $LaserDamageType] = 0.5;
$DamageScale[Fighter, $MortarDamageType] = 1.0;
$DamageScale[Fighter, $BlasterDamageType] = 0.5;
$DamageScale[Fighter, $ElectricityDamageType] = 1.0;
$DamageScale[Fighter, $MineDamageType] = 1.0;
$DamageScale[Fighter, $MagneticDamageType] = 0.5;
$DamageScale[Fighter, $EMPDamageType] = 1.0;
$DamageScale[Fighter, $BomberDamageType] = 1.0;
$DamageScale[Fighter, $RifleDamageType] = 0.5;
$DamageScale[Fighter, $FlakDamageType] = 1.0;
$DamageScale[Fighter, $RocketDamageType] = 1.0;
$DamageScale[Fighter, $ShotgunDamageType] = 1.0;
$DamageScale[Fighter, $LowWarheadDamageType] = 1.0;
$DamageScale[Fighter, $MedWarheadDamageType] = 1.0;
$DamageScale[Fighter, $HighWarheadDamageType] = 1.0;
$DamageScale[Fighter, $EMPWarheadDamageType] = 1.0;
$DamageScale[Fighter, $PhalanxxDamageType] = 1.0;
$DamageScale[Fighter, $ELFTurretDamageType] = 1.0;
$DamageScale[Fighter, $FighterDamageType] = 1.75;
$DamageScale[Fighter, $DecimatorDamageType] = 1.25;
$DamageScale[Fighter, $EnergyRepeaterDamageType] = 1.0;
$DamageScale[Fighter, $SentinelDamageType] = 1.0;
$DamageScale[Fighter, $DoomsdayDamageType] = 2.0;
$DamageScale[Fighter, $TazerBeamDamageType] = 0.5;
$DamageScale[Fighter, $TazerBoltDamageType] = 1.0;
$DamageScale[Fighter, $RetributionDamageType] = 1.0;
$DamageScale[Fighter, $FlareDamageType] = 1.0;
$DamageScale[Fighter, $InjectorDamageType] = 1.0;
$DamageScale[Fighter, $NaniteDamageType] = 1.0;
$DamageScale[Fighter, $BoomBoxFizzleDamageType] = 1.0;
$DamageScale[Fighter, $BoomBoxNukeDamageType] = 1.0;

function Vehicle::onAdd(%this)
{
  %this.shieldStrength = 0.0;
  GameBase::setRechargeRate (%this, 10);
  if(GameBase::getDataName(%this) == Scout) GameBase::setMapName (%this, "Scout");
  if(GameBase::getDataName(%this) == LAPC) GameBase::setMapName (%this, "LPC");
  if(GameBase::getDataName(%this) == HAPC) GameBase::setMapName (%this, "HPC");
  if(GameBase::getDataName(%this) == SLAPC) GameBase::setMapName (%this, "Stealth LPC");
  if(GameBase::getDataName(%this) == Bomber) GameBase::setMapName (%this, "Bomber");
  if(GameBase::getDataName(%this) == Fighter) GameBase::setMapName (%this, "Fighter");
}



function Vehicle::onCollision (%this, %object)
{
  if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
  {
    if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
    {
      if( Player::isAiControlled(%object) ) return;
      %armor = Player::getArmor(%object);
      %client = Player::getClient(%object);
      %weapon = Player::getMountedItem(%object,$WeaponSlot);
      if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
      {
        %weapon = Player::getMountedItem(%object,$WeaponSlot);
        if(%weapon != -1)
        {
          %object.lastWeapon = %weapon;
          Player::unMountItem(%object,$WeaponSlot);
        }
        Player::setMountObject(%object, %this, 1);
        Client::setControlObject(%client, %this);
        playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
        GameBase::virtual(%this,"onMount",%this,%object);
        %object.driver = 1;
        %object.vehicle = %this;
        %this.clLastMount = %client;
      }
      else
      if ((%armor == "marmor" || %armor == "mfemale") && Vehicle::canMount (%this, %object))
      {
        if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Bomber) && (GameBase::getDataName(%this) != Fighter))
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
        else
        {
          if(Player::getMountedItem(%object,$BackpackSlot) == "PilotPack")
          {
            if((Player::getMountedItem(%object,$WeaponSlot) == "PilotKey") && (Player::isTriggered(%object, $WeaponSlot)))
            {
              pxMediumPilotArmor(%client,%armor,"On");
              %object.lastWeapon = %weapon;
              $pxPilotKeyOn[%client] = true;
              Player::unMountItem(%object,$WeaponSlot);
              $pxPilotKeyOn[%client] = false;
              Player::setMountObject(%object, %this, 1);
              Client::setControlObject(%client, %this);
              playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
              GameBase::virtual(%this,"onMount",%this,%object);
              %object.driver = 1;
              %object.vehicle = %this;
              %this.clLastMount = %client;
            }
            else Client::sendMessage(Player::getClient(%object),0,"You must activate your Pilot's Key to pilot vehicles.~wError_Message.wav");
          }
          else Client::sendMessage(Player::getClient(%object),0,"You must have a Pilot Pack to pilot vehicles in Medium Armor.~wError_Message.wav");
        }
      }
      else
      if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Bomber) && (GameBase::getDataName(%this) != Fighter))
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
      else
      if (GameBase::getControlClient(%this) == -1) Client::sendMessage(Player::getClient(%object),0,"You may not pilot vehicles in Heavy Armor.~wError_Message.wav");
    }
  }
}



function pxMediumPilotArmor(%client,%armor,%state)
{
   if(%state == "On")
   {
      $pxOriginalArmor[%client] = %armor;
      Player::setArmor(%client, "p" @ %armor);
   }
   if(%state == "Off")
   {
      Player::setArmor(%client, $pxOriginalArmor[%client]);
      $pxOriginalArmor[%client] = "";
   }
}



function Vehicle::findEmptySeat(%this,%client)
{
  if(GameBase::getDataName(%this) == HAPC) %numSlots = 4;
  else %numSlots = 2;
  %count=0;
  for(%i=0; %i<%numSlots; %i++) if(%this.Seat[%i] == "")
  {
    %slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
    %slotVal[%count] = %i+2;
    %lastEmpty = %i+2;
    %count++;
  }
  if(%count == 1)
  {
    %this.Seat[%lastEmpty-2] = %client; return %lastEmpty;
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
{ %playerX = getWord(%playerPos,0); %playerY = getWord(%playerPos,1); for(%i = 0 ;%i<%num;%i++)
{ %x = (getWord(%slotPos[%i],0)) - %playerX; %y = (getWord(%slotPos[%i],1)) - %playerY;

if(%x < 0) %x *= -1;

if(%y < 0) %y *= -1; %newDistance = sqrt((%x*%x)+(%y*%y));

if(%newDistance < %distance || %distance == "")
{ %distance = %newDistance; %closePos = %i;
}
} return %closePos;
}



function Vehicle::passengerJump(%this,%passenger,%mom)
{ %armor = Player::getArmor(%passenger);

if(%armor == "larmor" || %armor == "lfemale")
{ %height = 2; %velocity = 70; %zVec = 70;
}

else

if(%armor == "marmor" || %armor == "mfemale")
{ %height = 2; %velocity = 100; %zVec = 100;
}

else

if(%armor == "harmor")
{ %height = 2; %velocity = 140; %zVec = 110;
} %pos = GameBase::getPosition(%passenger); %posX = getWord(%pos,0); %posY = getWord(%pos,1); %posZ = getWord(%pos,2);

if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
{ %client = Player::getClient(%passenger); %this.Seat[%passenger.vehicleSlot-2] = ""; %passenger.vehicleSlot = ""; %passenger.vehicle= ""; Player::setMountObject(%passenger, -1, 0); %rotZ = getWord(GameBase::getRotation(%passenger),2); GameBase::setRotation(%passenger, "0 0 " @ %rotZ); GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)); %jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec); Player::applyImpulse(%passenger,%jumpDir);
}

else Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}



function Vehicle::jump(%this,%mom)
{
  Vehicle::dismount(%this,%mom);
}



function Vehicle::dismount(%this,%mom)
{ %cl = GameBase::getControlClient(%this);

if(%cl != -1)
{ %pl = Client::getOwnedObject(%cl);

if(getObjectType(%pl) == "Player")
{

if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
{ %armor = Player::getArmor(%pl); %client = Player::getClient(%pl); pxMediumPilotArmor(%client,%armor,"Off"); %pl.lastMount = %this; %pl.newMountTime = getSimTime() + 3.0; Player::setMountObject(%pl, %this, 0); Player::setMountObject(%pl, -1, 0); %rot = GameBase::getRotation(%this); %rotZ = getWord(%rot,2); GameBase::setRotation(%pl, "0 0 " @ %rotZ); Player::applyImpulse(%pl,%mom); Client::setControlObject(%cl, %pl); playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));

if(%pl.lastWeapon != "")
{ Player::useItem(%pl,%pl.lastWeapon); %pl.lastWeapon = "";
} %pl.driver = ""; %pl.vehicle = ""; GameBase::virtual(%this,"onDismount",%this,%object);
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
    if(%pl.lastWeapon != "")
    {
      Player::useItem(%pl,%pl.lastWeapon);
      %pl.lastWeapon = "";
    }
    %armor = Player::getArmor(%pl);
    pxMediumPilotArmor(%cl,%armor,"Off");
    %pl.driver = "";
    %pl.vehicle= "";
    GameBase::virtual(%this,"onDismount",%this,%object);
  }
  for(%i = 0 ; %i < 4 ; %i++) if(%this.Seat[%i] != "")
  {
    %pl = Client::getOwnedObject(%this.Seat[%i]);
    Player::setMountObject(%pl, -1, 0);
    Client::setControlObject(%this.Seat[%i], %pl);
    %pl.vehicleSlot = "";
    %pl.vehicle= "";
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
  if(GameBase::getDataName(%this) == SLAPC) return 0.0;
  else return 1.0;
}
