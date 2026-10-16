//--------------------------------------

$VehicleInvList[HellfireVehicle] = 1;

$DataBlockName[HellfireVehicle] = Hellfire;
$VehicleToItem[Hellfire] = HellfireVehicle;

$SingleRider[Hellfire] = true;
//--------------------------------------

$TeamItemMax[HellfireVehicle] = 3;

//--------------------------------------

RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
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
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

FlierData Hellfire
{
        explosionId = flashExpLarge;
        debrisId = flashDebrisLarge;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
        lift = 0.75;
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 0.6;
        damageLevel = {1.0, 1.0};
        maxEnergy = 100;
        accel = 0.4;

        groundDamageScale = 1.0;

        projectileType = FlierRocket;
        reloadDelay = 1.0;
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
        description = "Hellfire";
};

//--------------------------------------

ItemData HellfireVehicle
{
        description = "Hellfire";
        className = "Vehicle";
   heading = $InvCatVehicles;
        price = 1000;
};

