//--------------------------------------

$VehicleInvList[BombVehicle] = 1;

$DataBlockName[BombVehicle] = Bomber;
$VehicleToItem[Bomber] = BombVehicle;

$SingleRider[Bomber] = true;
//--------------------------------------

$TeamItemMax[BombVehicle] = 2;

dataReinit(BombVehicle);

//--------------------------------------

GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 15.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

//--------------------------------------

FlierData Bomber
{
        explosionId = flashExpLarge;
        debrisId = flashDebrisLarge;
        className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_medium";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 20;
   minSpeed = -10;
        lift = 0.75;
        maxAlt = 15;
        maxVertical = 6;
        maxDamage = 1.0;
        damageLevel = {1.0, 1.0};
        maxEnergy = 100;
        accel = 0.3;

        groundDamageScale = 0.5;

        projectileType = BomberShell;
        reloadDelay = 1.5;
        repairRate = 0;
        fireSound = SoundFireMortar;
        damageSound = SoundFlierCrash;
        ramDamage = 2;
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
        driverPose = 23;
        description = "Bomber";
};

//--------------------------------------

ItemData BombVehicle
{
        description = "Bomber";
        className = "Vehicle";
   heading = $InvCatVehicles;
        price = 750;
};
