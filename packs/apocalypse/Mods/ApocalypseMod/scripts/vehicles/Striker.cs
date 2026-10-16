//--------------------------------------

$VehicleInvList[StrikerVehicle] = 1;

$DataBlockName[StrikerVehicle] = Striker;
$VehicleToItem[Striker] = StrikerVehicle;

$SingleRider[Striker] = false;
//--------------------------------------

$TeamItemMax[StrikerVehicle] = 1;

dataReinit(BombVehicle);

//--------------------------------------

RocketData StrikeRocket
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 200.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plastrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Striker
{
        explosionId = flashExpLarge;
        debrisId = flashDebrisLarge;
        className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 12.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = -2;
        lift = 0.5;
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 0.75;
        damageLevel = {1.0, 1.0};
        destroyDamage = 1.0;
        maxEnergy = 100;
        accel = 0.25;

        groundDamageScale = 0.50;

        projectileType = StrikeRocket;
        reloadDelay = 0.75;
        repairRate = 0;
        ramDamage = 2;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        fireSound = SoundFireFlierRocket;
        damageSound = SoundTankCrash;
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;

        visibleDriver = true;
        driverPose = 23;
        description = "Striker";
};

//--------------------------------------

ItemData StrikerVehicle
{
        description = "Striker";
        className = "Vehicle";
   heading = $InvCatVehicles;
        price = 1000;
};

