# New vehicle and it's fixed :)

FlierData Arwing
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 40;
        maxSideSpeed = 10;
   minSpeed = -15;
        lift = 1;
        maxAlt = 1024;
        maxVertical = 10;
        maxDamage = 0.75;
        damageLevel = {1.0, 1.0};
        accel = 0.4;
        groundDamageScale = 1;
        reloadDelay = 0.15;
        maxEnergy = 40;
        repairRate = 0;
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
        description = "Arwing";
	damageSkinData = "objectDamageSkins";
};

function Arwing::onFire(%this) 
{
	if(%this.lastFire > getSimTime()) return;
	%this.lastFire = getSimTime() + 1.42;
	%vel = Item::getVelocity(%this); 
	playsound(SoundFireChain, GameBase::getPosition(%this));
	Arwing::FireMinigun(%this,%vel);
	schedule("Arwing::FireMinigun("@%this@",\""@%vel@"\");", 0.2, %this);
	schedule("Arwing::FireMinigun("@%this@",\""@%vel@"\");", 0.4, %this);
	schedule("Arwing::FireMinigun("@%this@",\""@%vel@"\");", 0.6, %this);
}

function Arwing::FireMinigun(%this,%vel) 
{
	%trans = GameBase::getMuzzleTransform(%this); 	
	Projectile::spawnProjectile("MinigunBullet",%trans,%this,%vel); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%this,%vel); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%this,%vel); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%this,%vel); 
}

FlierData EscapePod
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32.14;
   maxPitch = 32.14;
   maxSpeed = 45;
   minSpeed = -1.5;
        maxSideSpeed = 50;
        lift = 0;
        maxAlt = 1024;
        maxVertical = 0.0001;
        maxDamage = 1.07;
        damageLevel = {1.0, 1.0};
        accel = 0.75;
        groundDamageScale = 1;
        maxEnergy = 50;
        repairRate = 0;
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
        description = "Lightning";
	damageSkinData = "objectDamageSkins";
};

function EscapePod::onFire(%this) // the FIRST flier with an attached elf!
{
	if(%this.lastFire > getSimTime()) 
		return;

	%this.lastFire = getSimTime() + 0.05;

	if(GameBase::getLOSinfo(%this, 20))
	{
		%vel = Item::getVelocity(%this); 
		%trans = GameBase::getMuzzleTransform(%this); 	
		%elf = Projectile::spawnProjectile("FlierCharge",%trans,%this,%vel);
		schedule("DeleteObject("@ %elf @");",0.075,%this);	// just in case we blow up while using elf... hehe
	}
}

FlierData SkyCutter
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 128;
        maxSideSpeed = 32;
   minSpeed = -32;
        lift = 1;
        maxAlt = 1024;
        maxVertical = 10;
        maxDamage = 0.1;
        damageLevel = {1.0, 1.0};
        accel = 0.4;
        groundDamageScale = 0.5;
        projectileType = IonBolt;
        reloadDelay = 0.3;
        maxEnergy = 128;
        repairRate = 0;
        fireSound = SoundFireLaser;
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
        description = "Sky Cutter";
	damageSkinData = "objectDamageSkins";
};

FlierData Explorer
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        classname = "Vehicle";
        shapeFile = "flyer";
        shieldShapeName = "shield_medium";
        mass = 1.0;
        drag = 0.1;
        density = 1.0;
        maxBank = 12.5;
        maxPitch = 12.0;
        maxSpeed = 65;
        minSpeed = -15;
        maxSideSpeed = 10;

        lift = 1.0;
        maxAlt = 1024;
        maxVertical = 0.0000001;
        maxDamage = 0.55;

        damageLevel = {1.0, 1.0};
        maxEnergy = 65;
        accel = 1.5;
        groundDamageScale = 1;
        reloadDelay = 0.15;
        repairRate = 0;
        fireSound = ShockExplosion;
        damageSound = SoundFlierCrash;
        ramDamage = 0.65;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;
        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;
        visibleDriver = False;
        driverPose = 22;
        description = "3DFX Explorer";
	damageSkinData = "objectDamageSkins";
};

FlierData Skyranger
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 45;
        maxSideSpeed = 10;
   minSpeed = -10;
       lift = 1;
        maxAlt = 1024;
        maxVertical = 10;
        maxDamage = 0.25;
        damageLevel = {1.0, 1.0};
        maxEnergy = 45;
        accel = 0.4;

        groundDamageScale = 1;

        projectileType = DiscShell;
        reloadDelay = 0.45;
        repairRate = 0;
        fireSound = SoundFireDisc;
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
        description = "Skyranger";
	damageSkinData = "objectDamageSkins";
};

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
   maxBank = 1.5;
   maxPitch = 1.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 1024;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.4;
	groundDamageScale = 1.0;
	reloadDelay = 0;
	repairRate = 0;
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
	description = "Scout";
	damageSkinData = "objectDamageSkins";
};

function Scout::onFire(%this) 
{
        if(%this.lastFire > getSimTime()) return;
        %this.lastFire = getSimTime() + 0.75;
        playsound(SoundFireFlierRocket, GameBase::getPosition(%this));
        %trans = GameBase::getMuzzleTransform(%this);
        %vel = Item::getVelocity(%this);
        if(GameBase::getLOSInfo(%this, 500)) {
                %object = $los::object;
                if(getObjectType(%object) == "Flier" || (%object) == "Turret" || (%object) == "Sensor") {
                        %targetId = GameBase::getControlClient(%object);
                        %targetName = Client::getName(%targetId);
                        %client = GameBase::getControlClient(%this);
                        %name = Client::getName(%client);
                        if(%targetName == "") {
                                Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ "~wmine_act.wav");
                        } else {
                                Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ " piloted by " @ %targetName @ "~wmine_act.wav");
                        }
                        Projectile::spawnProjectile("TurretMissile", %trans, %this, %vel, %object);
                } else {
                        Projectile::spawnProjectile("FlierRocket",%trans,%this,%vel);
                }
        } else {
                Projectile::spawnProjectile("FlierRocket",%trans,%this,%vel);
        }
}

FlierData Avenger
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris2;
        className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 50;
        maxSideSpeed = 10;
   minSpeed = -10;
        lift = 1;
        maxAlt = 512;
        maxVertical = 10;
        maxDamage = 1.25;
        damageLevel = {1.0, 1.0};
        maxEnergy = 50;
        accel = 0.5;

        groundDamageScale = 1;

        projectileType = AntiMatter;
        reloadDelay = 0.5;
        repairRate = 0;
        fireSound = ShockExplosion;
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
        driverPose = 23;
        description = "ThunderTank";
	damageSkinData = "objectDamageSkins";
};

FlierData StarHammer
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 50;
        maxSideSpeed = 10;
   minSpeed = -5;
        lift = 1;
        maxAlt = 1024;
        maxVertical = 10;
        maxDamage = 1.75;
        damageLevel = {1.0, 1.0};
        accel = 0.6;

        groundDamageScale = 1;

        reloadDelay = 1.5;
        maxEnergy = 50;
        repairRate = 0;
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
        description = "Star Hammer";
	damageSkinData = "objectDamageSkins";
};

function StarHammer::onFire(%this)
{
        if(%this.lastFire > getSimTime()) return;
        %this.lastFire = getSimTime() + 3.25;
        playsound(SoundFireFlierRocket, GameBase::getPosition(%this));
        %trans = GameBase::getMuzzleTransform(%this);
        %vel = Item::getVelocity(%this);
	  playsound(SoundFireSeeking, GameBase::getPosition(%this));

        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
}

FlierData StarFighter
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 50;
        maxSideSpeed = 10;
   minSpeed = -7.5;
        lift = 1;
        maxAlt = 1024;
        maxVertical = 10;
        maxDamage = 1.5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 50;
        accel = 0.4;

        groundDamageScale = 1;

        projectileType = FastPimpinMissile;
        reloadDelay = 1.5;
        repairRate = 0;
        fireSound = SoundFirePlasma;
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
        description = "StarFighter";
	damageSkinData = "objectDamageSkins";
};

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
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 35;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 512;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 35;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
	damageSkinData = "objectDamageSkins";
};

function LAPC::onFire(%this) 
{
	if(%this.lastFire > getSimTime()) return;
	%this.lastFire = getSimTime() + 5.0;
	playsound(SoundFireFlierRocket, GameBase::getPosition(%this));
	%rot = GameBase::getRotation(%this);
	%t = GameBase::getMuzzleTransform(%this); 	
	%vel = Item::getVelocity(%this); 
	for(%i = 0; %i < 9 ; %i++)
		%trans = %trans @ getword(%t, %i) @ " ";
	%pos = getword(%t, 9) @ " " @ getword(%t, 10) @ " " @ getword(%t, 11);
	%vec = Vector::getFromRot(%rot, 20);
	%newpos = Vector::add(%vec, %pos);
	%newtrans = %trans @ %newpos;
	Projectile::spawnProjectile("FlierRocket",%newtrans,%this,%vel);
	%newrot = (getword(%rot, 0) + 1.57) @ " " @ getword(%rot, 1) @ " " @ getword(%rot, 2);
	%vec = Vector::getFromRot(%newrot, 5);
	%newpos = Vector::add(%vec, %pos);
	%newtrans = %trans @ %newpos;
	Projectile::spawnProjectile("FlierRocket",%newtrans,%this,%vel);
	%newrot = (getword(%rot, 0) - 1.57) @ " " @ getword(%rot, 1) @ " " @ getword(%rot, 2);
	%vec = Vector::getFromRot(%newrot, 5);
	%newpos = Vector::add(%vec, %pos);
	%newtrans = %trans @ %newpos;
	Projectile::spawnProjectile("FlierRocket",%newtrans,%this,%vel);
	%newrot = getword(%rot, 0) @ " " @ getword(%rot, 1) @ " " @ (getword(%rot, 2) + 1.57);
	%vec = Vector::getFromRot(%newrot, 5);
	%newpos = Vector::add(%vec, %pos);
	%newtrans = %trans @ %newpos;
	Projectile::spawnProjectile("FlierRocket",%newtrans,%this,%vel);
	%newrot = getword(%rot, 0) @ " " @ getword(%rot, 1) @ " " @ (getword(%rot, 2) - 1.57);
	%vec = Vector::getFromRot(%newrot, 5);
	%newpos = Vector::add(%vec, %pos);
	%newtrans = %trans @ %newpos;
	Projectile::spawnProjectile("FlierRocket",%newtrans,%this,%vel);
}

FlierData Interceptor
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris2;
        className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 3.25;
   maxPitch = 3.175;
   maxSpeed = 45;
   minSpeed = -12.5;
        lift = 0.5;
        maxAlt = 512;
        maxVertical = 900;
        maxDamage = 0.5;
        damageLevel = {1.0, 1.0};
        destroyDamage = 1.0;
        maxEnergy = 45;
        accel = 0.25;

        groundDamageScale = 0.50;

        repairRate = 0;
        ramDamage = 2;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";

        projectileType = sniperXBullet;
        fireSound = SoundFireSniperX;
        reloadDelay = 1.25;
        damageSound = SoundTankCrash;
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;

        visibleDriver = true;
        driverPose = 23;
	damageSkinData = "objectDamageSkins";
};

FlierData HAPC
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris3;
        className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;
   minSpeed = -1;
        lift = 0.35;
        maxAlt = 255;
        maxVertical = 6;
        maxDamage = 2.0;
        damageLevel = {1.0, 1.0};
        maxEnergy = 25;
        accel = 0.25;

        groundDamageScale = 0.125;

        repairRate = 0;
        ramDamage = 2;
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
	damageSkinData = "objectDamageSkins";
};

FlierData HoverTank
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris3;
        className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.9;
   maxPitch = 1;
   maxSpeed = 20;
   minSpeed = -1;
        lift = 2;
        maxAlt = 255;
        maxVertical = 0.001;
        maxDamage = 3.5;
        maxSideSpeed = 45;
        damageLevel = {1.0, 1.0};
        maxEnergy = 20;
        accel = 0.25;

        groundDamageScale = 0.125;

        repairRate = 0;
        ramDamage = 2;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        projectileType = ImplosionShell;
        fireSound = SoundFireMortar;
        reloadDelay = 2;
        damageSound = SoundTankCrash;
        visibleToSensor = false;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;

        visibleDriver = true;
        driverPose = 23;
	damageSkinData = "objectDamageSkins";
};

FlierData Icarus
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris3;
        className = "Vehicle";
   shapeFile = "Hover_apc";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 15;
        maxSideSpeed = 10;
   minSpeed = -15;
        lift = 2;
        maxAlt = 255;
        maxVertical = 0.0001;
        maxDamage = 7.5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 15;
        accel = 1;

        groundDamageScale = 0.125;

        projectileType = ClusterBomb;
        reloadDelay = 10;
        repairRate = 0;
        fireSound = SoundMortarTurretFire;
        damageSound = ShockExplosion;
        ramDamage = 5;
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
        description = "Annihilator";
	damageSkinData = "objectDamageSkins";
};

//============================================================================
//Drones, Missiles and crap as such
//============================================================================

#=============================================================================================#
# PyroXL Conversion flier											    #
#=============================================================================================#

RocketData StreakRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = mineExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 15;
   kickBackStrength = 255.0;

   muzzleVelocity   = 128.0;
   terminalVelocity = 255.0;
   acceleration     = 16.0;

   totalTime        = 9.99;
   liveTime         = 10;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // Streak specific
   trailType   = 1;
   trailLength = 75;
   trailWidth  = 0.55;

   soundId = SoundElfFire;	// hehehehe
};

FlierData PyroXL
{
        className = "Vehicle";
   shapeFile = "flyer";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1.0;
   maxPitch = 1.0;
   maxSpeed = 35;
   minSpeed = -5;
        maxSideSpeed = 7.5;
        lift = 0.75;
        maxAlt = 16384;		// up in the clouds :)
        maxVertical = 10;
        maxDamage = 2;
        damageLevel = {1.0, 1.0};
        maxEnergy = 35;
        accel = 0.3;		

        groundDamageScale = 2;

        projectileType = StreakRocket;
        reloadDelay = 1.0;
        repairRate = 0;
        fireSound = SoundFireFlierRocket;
        damageSound = SoundFlierCrash;
        ramDamage = 5;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;
        visibleDriver = false;
        driverPose = 22;
        description = "PyroXL";
        damageSkinData = "objectDamageSkins";
};

function PyroXL::onDismount(%this, %cl)
{
	%pl = Client::getOwnedObject(%cl);		// Resetting constants back to 0
	%pl.lastMount = %this;
	%pl.newMountTime = getSimTime() + 3.0;
	%pl.driver = "";
	%pl.vehicle = "";
	%damage = GameBase::getDamageLevel(%this);

	Player::trigger(%pl,$BackpackSlot,false);		// Shutting off backpack
	Player::setMountObject(%pl, -1, 0);
	Client::setControlObject(%cl, %pl);
	GameBase::setPosition(%this, "-1000,-1000,-1000");
	GameBase::setDamageLevel(%pl, %damage);
	GameBase::setDamageLevel(%this, 10);	// Destroying the flier
}

FlierData EOMissile
{
        explosionId = MortarExp;
        className = "Vehicle";
    shapeFile = "rocket";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 10.5;
    maxPitch = 11.15;
    maxSpeed = 65;
    minSpeed = 40;
        maxSideSpeed = 10;
        lift = 0.85;
        maxAlt = 65536;
        maxVertical = 200;
        maxDamage = 0.001;
        damageLevel = {0.1, 0.1};
        maxEnergy = 30; // time in seconds until explodes
        accel = 2.0;

        groundDamageScale = 1.0;

        repairRate = 0;
        damageSound = ShockExplosion;
        ramDamage = 0.1;
        ramDamageType = $MissileDamageType;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundJetHeavy;
        moveSound = SoundJetHeavy;

        visibleDriver = false;
        driverPose = 22;
        description = "Electro-Optical Missile";
};

function EOMissile::onAdd(%this)
{
        GameBase::setRechargeRate (%this,0);
        schedule("EOMissile::exhaustFuel("@%this@");",1,%this);
}

function EOMissile::onCollision(%this,%object)
{
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
        calcRadiusDamage(%this,$MissileDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
}

function EOMissile::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function EOMissile::onDestroyed (%this,%mom)
{
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
        %pl.driver = "";
        %pl.vehicle= "";
   }
   calcRadiusDamage(%this,$MissileDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
}

function EOMissile::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1){
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
        calcRadiusDamage(%this,$MissileDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
  }
  else
  {
   GameBase::setEnergy(%this,%fuel - 1);
   schedule("EOMissile::exhaustFuel("@%this@");",1,%this);
  }
}

FlierData ProbeDroid
{
        explosionId = GrenadeExp;
        debrisId = FlierDebris;
        className = "Vehicle";
    shapeFile = "rocket";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 10.5;
    maxPitch = 11.15;
    maxSpeed = 70;
    minSpeed = 35;
        maxSideSpeed = 10;
        lift = 0.85;
        maxAlt = 65536;
        maxVertical = 200;
        maxDamage = 0.001;
        damageLevel = {1.0, 1.0};
        maxEnergy = 15; // time in seconds until explodes
        accel = 2.0;

        groundDamageScale = 20.0;

        repairRate = 0;
        damageSound = ShockExplosion;
        ramDamage = 1;
        ramDamageType = $MissileDamageType;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundJetHeavy;
        moveSound = SoundJetHeavy;

        visibleDriver = false;
        driverPose = 22;
        description = "Electro-Optical Missile";
	damageSkinData = "objectDamageSkins";
};

function ProbeDroid::onAdd(%this)
{
 GameBase::setRechargeRate (%this,0);
 schedule("ProbeDroid::exhaustFuel("@%this@");",1,%this);
}

function ProbeDroid::onCollision(%this,%object)
{
  GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function ProbeDroid::jump(%this,%mom)
{
 GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function ProbeDroid::onDestroyed (%this,%mom)
{
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
        %pl.driver = "";
        %pl.vehicle= "";
   }
   calcRadiusDamage(%this,$MissileDamageType, 30, 0.5, 20, 10, 8, 1.2, 0.7, 300, 200);
}

function ProbeDroid::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1) GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
  else
  {
   GameBase::setEnergy(%this,%fuel - 1);
   schedule("ProbeDroid::exhaustFuel("@%this@");",1,%this);
  }
}

FlierData ScouterMissile
{
        explosionId = rocketExp;
        className = "Vehicle";
    shapeFile = "rocket";
    shieldShapeName = "shield_medium";
    mass = 0.1;
    drag = 1.0;
    density = 1.2;
    maxBank = 10.5;
    maxPitch = 11.15;
    maxSpeed = 80;
    minSpeed = 40;
        lift = 2;
        maxAlt = 65536;
        maxVertical = 200;
        maxDamage = 0.001;
        damageLevel = {0.1, 0.1};
        maxEnergy = 60; // time in seconds until explodes
        accel = 1.0;

        groundDamageScale = 1.0;

        repairRate = 0;

        damageSound = shockExplosion;
        ramDamage = 0;
        ramDamageType = $NullDamageType;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundJetHeavy;
        moveSound = SoundJetHeavy;

        visibleDriver = false;
        driverPose = 22;
        description = "Electro-Optical Missile";
};

function ScouterMissile::onAdd(%this)
{
        GameBase::setRechargeRate (%this,0);
         schedule("ScouterMissile::exhaustFuel("@%this@");",1,%this);
}

function ScouterMissile::onCollision(%this,%object)
{
         GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function ScouterMissile::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function ScouterMissile::onDestroyed (%this,%mom)
{
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
        %pl.driver = "";
        %pl.vehicle= "";
   }
}

function ScouterMissile::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1){
        GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
  }
  else
  {
   GameBase::setEnergy(%this,%fuel - 1);
   schedule("ScouterMissile::exhaustFuel("@%this@");",1,%this);
  }
}

FlierData SurveyDrone
{
        explosionId = flashExpSmall;
        debrisId = flashDebrisSmall;
        className = "Vehicle";
    shapeFile = "mortargun";
    shieldShapeName = "shield_medium";
    mass = 0.001;
    drag = 1.0;
    density = 1.2;
    maxBank = 10;

   maxPitch = 10;
    maxSpeed = 12.5;
        maxSideSpeed = 10;
    minSpeed = -15;
        lift = 1.0;
        maxAlt = 128;
        maxVertical = 1;
        maxDamage = 0.5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 11;
        accel = 1.0;

        groundDamageScale = 0.001;

        projectileType = MiniFusionBolt;
        reloadDelay = 0.3;
        repairRate = 0;
        fireSound = SoundFireBlaster;
        damageSound = SoundFlierCrash;
        ramDamage = 0.0001;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundDiscSpin;
        moveSound = SoundDiscSpin;

        visibleDriver = false;
        driverPose = 22;
        description = "Survey Drone";
	damageSkinData = "objectDamageSkins";
};

function SurveyDrone::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
        calcRadiusDamage(%this,$DebrisDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
}

function CameraDrone::onFire(%this,%slot)
{
 %client = GameBase::getControlClient(%this);
 if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
  {
        if(GameBase::getLOSInfo(%this,3))

        {
                %obj = getObjectType($los::object);
                if(%obj == "SimTerrain" || %obj == "InteriorShape")
                 {
                    %this.deployed = true;
                        %prot = GameBase::getRotation(%this);
                        %zRot = getWord(%prot,2);
                        if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
                        else
                        {
                                if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
                                else %rot = Vector::getRotation($los::normal);
                        }
                        %beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
            addToSet("MissionCleanup", %beacon);
                        GameBase::setTeam(%beacon,GameBase::getTeam(%this));
                        GameBase::setRotation(%beacon,%rot);
                        GameBase::setPosition(%beacon,$los::position);
                        Gamebase::setMapName(%beacon,"Target Beacon");
                    Beacon::onEnabled(%beacon);
                        playSound(SoundPickupBackpack,$los::position);
                        $TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
                        echo("MSG: Survey Drone deployed a Beacon");
                        SurveyDrone::removeDrone(%this);
                }
         }
  }
}

function SurveyDrone::removeDrone(%this)
{
 %client = GameBase::getControlClient(%this);
 %player = Client::getOwnedObject(%client);

  Player::setMountObject(%player, -1, 0);
  Client::setControlObject(%client,%player);
  %player.vehicle = "";

  Client::sendMessage(%client,0,"Drone beacon deployed successfully");

  $TeamItemCount[GameBase::getTeam(%this) @ "SurveyDronePack"]--;
  GameBase::startFadeOut(%this);
  GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

FlierData Drone
{
        explosionId = boltexp1;
        debrisId = flashDebrisSmall;
        className = "Vehicle";
    shapeFile = "mortargun";
    shieldShapeName = "shield_medium";
    mass = 0.01;
    drag = 0.6;
    density = 0.3;
    maxBank = 1.5;
    maxPitch = 1.0;
    maxSpeed = 12;
        maxSideSpeed = 10;
    minSpeed = -10;
        lift = 0.75;
        maxAlt = 128;
        maxVertical = 10;
        maxDamage = 0.5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 15;
        accel = 0.6;

        groundDamageScale = 0.001;

        repairRate = 0;
        damageSound = SoundFlierCrash;
        ramDamage = 0.0001;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        mountSound = SoundFlyerMount;
        dismountSound = SoundFlyerDismount;
        idleSound = SoundDiscSpin;
        moveSound = SoundDiscSpin;

        visibleDriver = false;
        driverPose = 22;
        description = "Drone";
	damageSkinData = "objectDamageSkins";
        deployed = false;
};

function Drone::onCollision (%this, %object)
{
}

function Drone::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function Drone::onFire(%this,%slot)
{
 %client = GameBase::getControlClient(%this);
 if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
  {
        if(GameBase::getLOSInfo(%this,3))
         {
                %obj = getObjectType($los::object);
                if(%obj == "SimTerrain" || %obj == "InteriorShape")
                 {
                    %this.deployed = true;
                        %prot = GameBase::getRotation(%this);
                        %zRot = getWord(%prot,2);
                        if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
                        else
                        {
                                if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
                                else %rot = Vector::getRotation($los::normal);
                        }
                        %camera = newObject("Camera","Turret",CameraTurret,true);
            addToSet("MissionCleanup", %camera);
                        GameBase::setTeam(%camera,GameBase::getTeam(%this));
                        GameBase::setRotation(%camera,%rot);
                        GameBase::setPosition(%camera,$los::position);
                        Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                        Client::sendMessage(%client,0,"Camera deployed");
                        playSound(SoundPickupBackpack,$los::position);
                        $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
                        echo("MSG: Drone deployed a Camera");
                        Drone::removeDrone(%this);
                }
         }
  }
}

function Drone::removeDrone(%this)
{
 %client = GameBase::getControlClient(%this);
 %player = Client::getOwnedObject(%client);

  Player::setMountObject(%player, -1, 0);
  Client::setControlObject(%client,%player);
  %player.vehicle = "";

  Client::sendMessage(%client,0,"Drone camera deployed successfully");

  $TeamItemCount[GameBase::getTeam(%this) @ "DronePack"]--;
  GameBase::startFadeOut(%this);
  GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

//===========================================================================
//Now here is the codez!
//===========================================================================

$DamageScale[EOMissile, $ImpactDamageType] = 1.0;
$DamageScale[EOMissile, $BulletDamageType] = 1.0;
$DamageScale[EOMissile, $PlasmaDamageType] = 1.0;
$DamageScale[EOMissile, $EnergyDamageType] = 1.0;
$DamageScale[EOMissile, $ExplosionDamageType] = 1.0;
$DamageScale[EOMissile, $ShrapnelDamageType] = 1.0;
$DamageScale[EOMissile, $DebrisDamageType] = 1.0;
$DamageScale[EOMissile, $MissileDamageType] = 1.0;
$DamageScale[EOMissile, $LaserDamageType] = 0.5;
$DamageScale[EOMissile, $MortarDamageType] = 1.0;
$DamageScale[EOMissile, $BlasterDamageType] = 0.5;
$DamageScale[EOMissile, $ElectricityDamageType] = 1.0;
$DamageScale[EOMissile, $MineDamageType]        = 1.0;

$DamageScale[EODisc, $ImpactDamageType] = 1.0;
$DamageScale[EODisc, $BulletDamageType] = 1.0;
$DamageScale[EODisc, $PlasmaDamageType] = 1.0;
$DamageScale[EODisc, $EnergyDamageType] = 1.0;
$DamageScale[EODisc, $ExplosionDamageType] = 1.0;
$DamageScale[EODisc, $ShrapnelDamageType] = 1.0;
$DamageScale[EODisc, $DebrisDamageType] = 1.0;
$DamageScale[EODisc, $MissileDamageType] = 1.0;
$DamageScale[EODisc, $LaserDamageType] = 0.5;
$DamageScale[EODisc, $MortarDamageType] = 1.0;
$DamageScale[EODisc, $BlasterDamageType] = 0.5;
$DamageScale[EODisc, $ElectricityDamageType] = 1.0;
$DamageScale[EODisc, $MineDamageType]        = 1.0;

$DamageScale[ScouterMissile, $ImpactDamageType] = 1.0;
$DamageScale[ScouterMissile, $BulletDamageType] = 1.0;
$DamageScale[ScouterMissile, $PlasmaDamageType] = 1.0;
$DamageScale[ScouterMissile, $EnergyDamageType] = 1.0;
$DamageScale[ScouterMissile, $ExplosionDamageType] = 1.0;
$DamageScale[ScouterMissile, $ShrapnelDamageType] = 1.0;
$DamageScale[ScouterMissile, $DebrisDamageType] = 1.0;
$DamageScale[ScouterMissile, $MissileDamageType] = 1.0;
$DamageScale[ScouterMissile, $LaserDamageType] = 0.5;
$DamageScale[ScouterMissile, $MortarDamageType] = 1.0;
$DamageScale[ScouterMissile, $BlasterDamageType] = 0.5;
$DamageScale[ScouterMissile, $ElectricityDamageType] = 1.0;
$DamageScale[ScouterMissile, $MineDamageType]        = 1.0;

function ShortCoolProj::onFire(%this) { GameBase::setDamageLevel(%this, 10); }
function ShortCoolProj::jump(%this) { GameBase::setDamageLevel(%this, 10); }

$DamageScale[SurveyDrone, $ImpactDamageType] = 1.0;
$DamageScale[SurveyDrone, $BulletDamageType] = 1.0;
$DamageScale[SurveyDrone, $PlasmaDamageType] = 1.0;
$DamageScale[SurveyDrone, $EnergyDamageType] = 1.0;
$DamageScale[SurveyDrone, $ExplosionDamageType] = 1.0;
$DamageScale[SurveyDrone, $ShrapnelDamageType] = 1.0;
$DamageScale[SurveyDrone, $DebrisDamageType] = 1.0;
$DamageScale[SurveyDrone, $MissileDamageType] = 1.0;
$DamageScale[SurveyDrone, $LaserDamageType] = 1.0;
$DamageScale[SurveyDrone, $MortarDamageType] = 1.0;
$DamageScale[SurveyDrone, $BlasterDamageType] = 0.5;
$DamageScale[SurveyDrone, $ElectricityDamageType] = 1.0;
$DamageScale[SurveyDrone, $MineDamageType]        = 1.0;
$DamageScale[SurveyDrone, $FusionDamageType] = 1.5;
$DamageScale[SurveyDrone, $DisruptorDamageType] = 1.0;
$DamageScale[SurveyDrone, $IonDamageType] = 2.2;
$DamageScale[SurveyDrone, $VulcanDamageType] = 1.0;
$DamageScale[SurveyDrone, $ShotgunDamageType] = 1.0;
$DamageScale[SurveyDrone, $NukeDamageType] = 10.0;
$DamageScale[SurveyDrone, $ZapDamageType] = 2.0;
$DamageScale[SurveyDrone, $HeatDamageType] = 1.0;
$DamageScale[SurveyDrone, $ATCDamageType] = 1.0;
$DamageScale[SurveyDrone, $StarDamageType] = 1.0;
$DamageScale[SurveyDrone, $ShockwaveDamageType] = 1.0;

$DamageScale[SurveyDrone, $PBWDamageType] = 1.0;
$DamageScale[SurveyDrone, $FlameDamageType] = 1.0;
$DamageScale[SurveyDrone, $IceDamageType] = 1.0;
$DamageScale[SurveyDrone, $BurstDamageType] = 1.0;
$DamageScale[SurveyDrone, $ReaverDamageType] = 1.0;
$DamageScale[SurveyDrone, $RifleDamageType] = 1.0;
$DamageScale[SurveyDrone, $MassShotgunDamageType] = 1.0;
$DamageScale[SurveyDrone, $GaussDamageType] = 1.0;
$DamageScale[SurveyDrone, $MBDamageType] = 1.0;
$DamageScale[SurveyDrone, $NullDamageType] = 1.0;

$DamageScale[ProbeDroid, $ImpactDamageType] = 1.0;
$DamageScale[ProbeDroid, $BulletDamageType] = 1.0;
$DamageScale[ProbeDroid, $PlasmaDamageType] = 1.0;
$DamageScale[ProbeDroid, $EnergyDamageType] = 1.0;
$DamageScale[ProbeDroid, $ExplosionDamageType] = 1.0;
$DamageScale[ProbeDroid, $ShrapnelDamageType] = 1.0;
$DamageScale[ProbeDroid, $DebrisDamageType] = 1.0;
$DamageScale[ProbeDroid, $MissileDamageType] = 1.0;
$DamageScale[ProbeDroid, $LaserDamageType] = 1.0;
$DamageScale[ProbeDroid, $MortarDamageType] = 1.0;
$DamageScale[ProbeDroid, $BlasterDamageType] = 0.5;
$DamageScale[ProbeDroid, $ElectricityDamageType] = 1.0;
$DamageScale[ProbeDroid, $MineDamageType]        = 1.0;
$DamageScale[ProbeDroid, $FusionDamageType] = 1.5;
$DamageScale[ProbeDroid, $DisruptorDamageType] = 1.0;
$DamageScale[ProbeDroid, $IonDamageType] = 2.2;
$DamageScale[ProbeDroid, $VulcanDamageType] = 1.0;
$DamageScale[ProbeDroid, $ShotgunDamageType] = 1.0;
$DamageScale[ProbeDroid, $NukeDamageType] = 10.0;
$DamageScale[ProbeDroid, $ZapDamageType] = 2.0;
$DamageScale[ProbeDroid, $HeatDamageType] = 1.0;
$DamageScale[ProbeDroid, $ATCDamageType] = 1.0;
$DamageScale[ProbeDroid, $StarDamageType] = 1.0;
$DamageScale[ProbeDroid, $ShockwaveDamageType] = 1.0;
$DamageScale[ProbeDroid, $PBWDamageType] = 1.0;
$DamageScale[ProbeDroid, $FlameDamageType] = 1.0;
$DamageScale[ProbeDroid, $IceDamageType] = 1.0;
$DamageScale[ProbeDroid, $BurstDamageType] = 1.0;
$DamageScale[ProbeDroid, $ReaverDamageType] = 1.0;
$DamageScale[ProbeDroid, $RifleDamageType] = 1.0;
$DamageScale[ProbeDroid, $MassShotgunDamageType] = 1.0;
$DamageScale[ProbeDroid, $GaussDamageType] = 1.0;
$DamageScale[ProbeDroid, $MBDamageType] = 1.0;
$DamageScale[ProbeDroid, $NullDamageType] = 1.0;

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
$DamageScale[Scout, $MineDamageType]        = 1.0;

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
$DamageScale[LAPC, $MineDamageType]        = 1.0;

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
$DamageScale[HAPC, $MineDamageType]        = 1.0;

$DamageScale[Arwing, $ImpactDamageType] = 1.0;
$DamageScale[Arwing, $BulletDamageType] = 1.0;
$DamageScale[Arwing, $PlasmaDamageType] = 1.0;
$DamageScale[Arwing, $EnergyDamageType] = 1.0;
$DamageScale[Arwing, $ExplosionDamageType] = 1.0;
$DamageScale[Arwing, $ShrapnelDamageType] = 1.0;
$DamageScale[Arwing, $DebrisDamageType] = 1.0;
$DamageScale[Arwing, $MissileDamageType] = 1.0;
$DamageScale[Arwing, $LaserDamageType] = 0.5;
$DamageScale[Arwing, $MortarDamageType] = 1.0;
$DamageScale[Arwing, $BlasterDamageType] = 0.5;
$DamageScale[Arwing, $ElectricityDamageType] = 1.0;
$DamageScale[Arwing, $MineDamageType]        = 1.0;

$DamageScale[SkyCutter, $ImpactDamageType] = 1.0;
$DamageScale[SkyCutter, $BulletDamageType] = 1.0;
$DamageScale[SkyCutter, $PlasmaDamageType] = 1.0;
$DamageScale[SkyCutter, $EnergyDamageType] = 1.0;
$DamageScale[SkyCutter, $ExplosionDamageType] = 1.0;
$DamageScale[SkyCutter, $ShrapnelDamageType] = 1.0;
$DamageScale[SkyCutter, $DebrisDamageType] = 1.0;
$DamageScale[SkyCutter, $MissileDamageType] = 1.0;
$DamageScale[SkyCutter, $LaserDamageType] = 0.5;
$DamageScale[SkyCutter, $MortarDamageType] = 1.0;
$DamageScale[SkyCutter, $BlasterDamageType] = 0.5;
$DamageScale[SkyCutter, $ElectricityDamageType] = 1.0;
$DamageScale[SkyCutter, $MineDamageType]        = 1.0;

$DamageScale[Explorer, $ImpactDamageType] = 1.0;
$DamageScale[Explorer, $BulletDamageType] = 1.0;
$DamageScale[Explorer, $PlasmaDamageType] = 1.0;
$DamageScale[Explorer, $EnergyDamageType] = 1.0;
$DamageScale[Explorer, $ExplosionDamageType] = 1.0;
$DamageScale[Explorer, $ShrapnelDamageType] = 1.0;
$DamageScale[Explorer, $DebrisDamageType] = 1.0;
$DamageScale[Explorer, $MissileDamageType] = 1.0;
$DamageScale[Explorer, $LaserDamageType] = 0.5;
$DamageScale[Explorer, $MortarDamageType] = 1.0;
$DamageScale[Explorer, $BlasterDamageType] = 0.5;
$DamageScale[Explorer, $ElectricityDamageType] = 1.0;
$DamageScale[Explorer, $MineDamageType]        = 1.0;

$DamageScale[Skyranger, $ImpactDamageType] = 1.0;
$DamageScale[Skyranger, $BulletDamageType] = 1.0;
$DamageScale[Skyranger, $PlasmaDamageType] = 1.0;
$DamageScale[Skyranger, $EnergyDamageType] = 1.0;
$DamageScale[Skyranger, $ExplosionDamageType] = 1.0;
$DamageScale[Skyranger, $ShrapnelDamageType] = 1.0;
$DamageScale[Skyranger, $DebrisDamageType] = 1.0;
$DamageScale[Skyranger, $MissileDamageType] = 1.0;
$DamageScale[Skyranger, $LaserDamageType] = 0.5;
$DamageScale[Skyranger, $MortarDamageType] = 1.0;
$DamageScale[Skyranger, $BlasterDamageType] = 0.5;
$DamageScale[Skyranger, $ElectricityDamageType] = 1.0;
$DamageScale[Skyranger, $MineDamageType]        = 1.0;

$DamageScale[Icarus, $ImpactDamageType] = 1.0;
$DamageScale[Icarus, $BulletDamageType] = 1.0;
$DamageScale[Icarus, $PlasmaDamageType] = 1.0;
$DamageScale[Icarus, $EnergyDamageType] = 1.0;
$DamageScale[Icarus, $ExplosionDamageType] = 1.0;
$DamageScale[Icarus, $ShrapnelDamageType] = 1.0;
$DamageScale[Icarus, $DebrisDamageType] = 1.0;
$DamageScale[Icarus, $MissileDamageType] = 1.0;
$DamageScale[Icarus, $LaserDamageType] = 0.5;
$DamageScale[Icarus, $MortarDamageType] = 1.0;
$DamageScale[Icarus, $BlasterDamageType] = 0.5;
$DamageScale[Icarus, $ElectricityDamageType] = 1.0;
$DamageScale[Icarus, $MineDamageType]        = 1.0;

$DamageScale[Avenger, $ImpactDamageType] = 1.0;
$DamageScale[Avenger, $BulletDamageType] = 1.0;
$DamageScale[Avenger, $PlasmaDamageType] = 1.0;
$DamageScale[Avenger, $EnergyDamageType] = 1.0;
$DamageScale[Avenger, $ExplosionDamageType] = 1.0;
$DamageScale[Avenger, $ShrapnelDamageType] = 1.0;
$DamageScale[Avenger, $DebrisDamageType] = 1.0;
$DamageScale[Avenger, $MissileDamageType] = 1.0;
$DamageScale[Avenger, $LaserDamageType] = 0.5;
$DamageScale[Avenger, $MortarDamageType] = 1.0;
$DamageScale[Avenger, $BlasterDamageType] = 0.5;
$DamageScale[Avenger, $ElectricityDamageType] = 1.0;
$DamageScale[Avenger, $MineDamageType]        = 1.0;

$DamageScale[StarFighter, $ImpactDamageType] = 1.0;
$DamageScale[StarFighter, $BulletDamageType] = 1.0;
$DamageScale[StarFighter, $PlasmaDamageType] = 1.0;
$DamageScale[StarFighter, $EnergyDamageType] = 1.0;
$DamageScale[StarFighter, $ExplosionDamageType] = 1.0;
$DamageScale[StarFighter, $ShrapnelDamageType] = 1.0;
$DamageScale[StarFighter, $DebrisDamageType] = 1.0;
$DamageScale[StarFighter, $MissileDamageType] = 1.0;
$DamageScale[StarFighter, $LaserDamageType] = 0.5;
$DamageScale[StarFighter, $MortarDamageType] = 1.0;
$DamageScale[StarFighter, $BlasterDamageType] = 0.5;
$DamageScale[StarFighter, $ElectricityDamageType] = 1.0;
$DamageScale[StarFighter, $MineDamageType]        = 1.0;

$DamageScale[HoverTank, $ImpactDamageType] = 1.0;
$DamageScale[HoverTank, $BulletDamageType] = 1.0;
$DamageScale[HoverTank, $PlasmaDamageType] = 1.0;
$DamageScale[HoverTank, $EnergyDamageType] = 1.0;
$DamageScale[HoverTank, $ExplosionDamageType] = 1.0;
$DamageScale[HoverTank, $ShrapnelDamageType] = 1.0;
$DamageScale[HoverTank, $DebrisDamageType] = 1.0;
$DamageScale[HoverTank, $MissileDamageType] = 1.0;
$DamageScale[HoverTank, $LaserDamageType] = 0.5;
$DamageScale[HoverTank, $MortarDamageType] = 1.0;
$DamageScale[HoverTank, $BlasterDamageType] = 0.5;
$DamageScale[HoverTank, $ElectricityDamageType] = 1.0;
$DamageScale[HoverTank, $MineDamageType]        = 1.0;

$DamageScale[Interceptor, $ImpactDamageType] = 1.0;
$DamageScale[Interceptor, $BulletDamageType] = 1.0;
$DamageScale[Interceptor, $PlasmaDamageType] = 1.0;
$DamageScale[Interceptor, $EnergyDamageType] = 1.0;
$DamageScale[Interceptor, $ExplosionDamageType] = 1.0;
$DamageScale[Interceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[Interceptor, $DebrisDamageType] = 1.0;
$DamageScale[Interceptor, $MissileDamageType] = 1.0;
$DamageScale[Interceptor, $LaserDamageType] = 0.5;
$DamageScale[Interceptor, $MortarDamageType] = 1.0;
$DamageScale[Interceptor, $BlasterDamageType] = 0.5;
$DamageScale[Interceptor, $ElectricityDamageType] = 1.0;
$DamageScale[Interceptor, $MineDamageType]        = 1.0;

$DamageScale[eSCAPEpOD, $ImpactDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $BulletDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $PlasmaDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $EnergyDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $ExplosionDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $ShrapnelDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $DebrisDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $MissileDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $LaserDamageType] = 0.5;
$DamageScale[eSCAPEpOD, $MortarDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $BlasterDamageType] = 0.5;
$DamageScale[eSCAPEpOD, $ElectricityDamageType] = 1.0;
$DamageScale[eSCAPEpOD, $MineDamageType]        = 1.0;

$DamageScale[StarHammer, $ImpactDamageType] = 1.0;
$DamageScale[StarHammer, $BulletDamageType] = 1.0;
$DamageScale[StarHammer, $PlasmaDamageType] = 1.0;
$DamageScale[StarHammer, $EnergyDamageType] = 1.0;
$DamageScale[StarHammer, $ExplosionDamageType] = 1.0;
$DamageScale[StarHammer, $ShrapnelDamageType] = 1.0;
$DamageScale[StarHammer, $DebrisDamageType] = 1.0;
$DamageScale[StarHammer, $MissileDamageType] = 1.0;
$DamageScale[StarHammer, $LaserDamageType] = 0.5;
$DamageScale[StarHammer, $MortarDamageType] = 1.0;
$DamageScale[StarHammer, $BlasterDamageType] = 0.5;
$DamageScale[StarHammer, $ElectricityDamageType] = 1.0;
$DamageScale[StarHammer, $MineDamageType]        = 1.0;

$DamageScale[PyroXL, $ImpactDamageType] = 1.0;
$DamageScale[PyroXL, $BulletDamageType] = 1.0;
$DamageScale[PyroXL, $PlasmaDamageType] = 1.0;
$DamageScale[PyroXL, $EnergyDamageType] = 1.0;
$DamageScale[PyroXL, $ExplosionDamageType] = 1.0;
$DamageScale[PyroXL, $ShrapnelDamageType] = 1.0;
$DamageScale[PyroXL, $DebrisDamageType] = 1.0;
$DamageScale[PyroXL, $MissileDamageType] = 1.0;
$DamageScale[PyroXL, $LaserDamageType] = 1.0;
$DamageScale[PyroXL, $MortarDamageType] = 1.0;
$DamageScale[PyroXL, $BlasterDamageType] = 0.5;
$DamageScale[PyroXL, $ElectricityDamageType] = 1.0;
$DamageScale[PyroXL, $MineDamageType]        = 1.0;

GrenadeData VehicleSmoke
{
   explosionId 	    = noExp;
   bulletShapeName    = "rsmoke.dts";
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;    
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function Vehicle::BlowUp(%vehicle)	
{
	%mom = "8 16 32";
	%vec = "3 2 1";
	%pos = getBoxCenter(%vehicle);
	GameBase::applyDamage(%vehicle,$DebrisDamageType,10,%pos,%mom,%vec,%vehicle);
}

function speedometer(%vehicle)
{
	%speed = Vehicle::getVelocity(%vehicle);

	GameBase::setEnergy(%vehicle,%speed);
	schedule("speedometer("@%vehicle@");",0.01,%vehicle);
}

function Vehicle::getVelocity(%vehicle)
{
	%vel = Item::getVelocity(%vehicle);
	%x = getWord(%vel, 0);  
	%y = getWord(%vel, 1);
	%z = getWord(%vel, 2);
	%speed = sqrt((%x*%x)+(%y*%y)+(%z*%z));	

	if(%speed < 0)
		%speed -= %speed*2;

	return %speed;
}

function keepers(%this) {
        %cl = GameBase::getControlClient(%this);
        %pl = Client::getOwnedObject(%cl);
        %cl.safet = false;
        remoteEval(%cl, SetControls);
        if(%pl != -1) {
                doneposs(%cl);
                Client::setControlObject(%cl, %pl);
        }
}

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
        %this.isMarked=false;
        GameBase::setRechargeRate (%this, 0);
        GameBase::setMapName (%this, "Vehicle");
        %data = GameBase::getDataName(%this);

	if(%data != ShortCoolProj || %data != SurveyDrone || %data != ProbeDroid || %data != Drone || %data != EOMissile || %data != ScouterMissile)
		speedometer(%this);

        if(%data.shapefile == "rocket") {
                if (%data == ShortCoolProj){
                        schedule("keepers("@%this@");",10,%this);
                        schedule("GameBase::setDamageLevel("@%this@", "@%data.maxDamage@");",10.5,%this);
                        }
        }

        if(GameBase::getDataName(%this) == Scout)
        {   
		GameBase::setMapName (%this, "Scout");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
        }
        else if(GameBase::getDataName(%this) == LAPC)
        {   
		GameBase::setMapName (%this, "LPC");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == HAPC)
        {
		GameBase::setMapName (%this, "HPC");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == HoverTank)
        {
		GameBase::setMapName (%this, "Hover Tank");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == StarHammer)
        {   
		GameBase::setMapName (%this, "Star Hammer");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
        }
        else if(GameBase::getDataName(%this) == Arwing)
        {   
		GameBase::setMapName (%this, "Arwing");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
        }
        else if(GameBase::getDataName(%this) == SkyCutter)
        {   
		GameBase::setMapName (%this, "Sky Cutter");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
        }
        if(GameBase::getDataName(%this) == EscapePod)
        {   
		GameBase::setMapName (%this, "Lightning");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.1, %this);
        }
        else if(GameBase::getDataName(%this) == Icarus)
        {       
		GameBase::setMapName (%this, "Annihilator");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == Skyranger)
        {       
		GameBase::setMapName (%this, "Skyranger");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke("@%this@");",0.1,%this);
        }
        else if(GameBase::getDataName(%this) == StarFighter)
        {   
		GameBase::setMapName (%this, "StarFighter");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
		schedule("Vehicle::SetSmoke("@%this@");",0.1,%this);
        }
        else if(GameBase::getDataName(%this) == Avenger)
        {  
		GameBase::setMapName (%this, "ThunderTank");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == Explorer)
        {   
		GameBase::setMapName (%this, "3DFX Explorer");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == PyroXL)
        {   
		GameBase::setMapName (%this, "PyroXL Convert");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 8);
        }
        else if(GameBase::getDataName(%this) == Interceptor)
        {        
		GameBase::setMapName (%this, "Valkyrie Interceptor");
            %this.shieldStrength = 0;
            GameBase::setRechargeRate (%this, 0);
        }
}

function Vehicle::onCollision(%this, %object)
{
	%data = GameBase::getDataName(%this);

        if(%data.shapefile == "remoteturret") return;
        if(%data.shapefile == "rocket" || (%data.shapefile == "discb" && getObjectType(%object) == "Player")) {
                GameBase::setDamageLevel(%this, 99);
                return;
        }

	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "BlastechM" || %armor == "BlastechF") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}

					      if(%data == Explorer) 
						{
							if(Player::getMountedItem(%object,$FlagSlot) != "flag")
							{
                                          	GameBase::startFadeout(%this);
								%rate = Player::getSensorSupression(%player) + 1;
								Player::setSensorSupression(%player,%rate);
							}
                                    }

						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (%vehicle.mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(%data != Scout && %data != EscapePod && %data != PyroXL && %data != Arwing && %data != SkyCutter && %data != StarHammer && %data != Explorer && %data != Skyranger && %data != StarFighter)
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (%vehicle.mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Peltast or Blastech armor to pilot a vehicle.~wError_Message.wav");
				else return;
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	%name = GameBase::getDataName(%this);
	if(%name == HAPC || %name == HoverTank || %name == Icarus){
                %numSlots = 4;} 
	else if(%name == LAPC || %name == Avenger || %name == Interceptor){
                %numSlots = 2;}
	else if(%name == EscapePod || %name == PyroXL || %name == Arwing || %name == SkyCutter || %name == StarHammer || %name == Explorer || %name == Skyranger || %name == StarFighter){
                %numSlots = 1;}
	else if(%name == ShortCoolProj || %name == SurveyDrone || %name == ProbeDroid || %name == Drone || %name == EOMissile || %name == ScouterMissile){
                %numSlots = 0;}
        %count=0;
        for(%i=0;%i<%numSlots;%i++)
                if(%this.Seat[%i] == "") {
                        %slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
                        %slotVal[%count] = %i+2;
                        %lastEmpty = %i+2;
                        %count++;
                }
        if(%count == 1) {
                %this.Seat[%lastEmpty-2] = %client;
                return %lastEmpty;
        }
        else if (%count > 1)        {
                %freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
                %this.Seat[%freeSlot-2] = %client;
                return %freeSlot;
        }
        else
                return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
        %playerX = getWord(%playerPos,0);
        %playerY = getWord(%playerPos,1);
        for(%i = 0 ;%i<%num;%i++) {
                %x = (getWord(%slotPos[%i],0)) - %playerX;
                %y = (getWord(%slotPos[%i],1)) - %playerY;
                if(%x < 0)
                        %x *= -1;
                if(%y < 0)
                        %y *= -1;
                %newDistance = sqrt((%x*%x)+(%y*%y));
                if(%newDistance < %distance || %distance == "") {
                          %distance = %newDistance;
                        %closePos = %i;
                }
        }
        return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
        %armor = Player::getArmor(%passenger);
        if(%armor == "larmor" || %armor == "lfemale" || %armor == "BlastechM" || %armor == "BlastechF") {
                %height = 2;
                %velocity = 70;
                %zVec = 70;
        }
        else if(%armor == "marmor" || %armor == "mfemale" || %armor == "MagIonM" || %armor == "MagIonF") {
                %height = 2;
                %velocity = 100;
                %zVec = 100;
        }
        else if(%armor == "harmor"|| %armor == "MECH") {
                %height = 2;
                %velocity = 140;
                %zVec = 110;
        }

        %pos = GameBase::getPosition(%passenger);

       %posX = getWord(%pos,0);
        %posY        = getWord(%pos,1);
        %posZ        = getWord(%pos,2);

        if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {
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
        }
        else
                Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
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
        if(GameBase::getDataName(%this) == "PyroXL")
        {
                PyroXL::onDismount(%this, %cl);
                return;
        }
        else if(GameBase::getDataName(%this) == Explorer) 
	  {
		GameBase::startFadein(%this);
		%rate = Player::getSensorSupression(%this) - 1;
		Player::setSensorSupression(%this,0);
        }

      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
                   // dismount the player
                        if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
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
                                if(%pl.lastWeapon != "") {
                                        Player::useItem(%pl,%pl.lastWeapon);
                                        %pl.lastWeapon = "";

                      }
                                %pl.driver = "";
                                %pl.vehicle = "";
                        }
                        else
                                Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
                }
   }
}


function Vehicle::onDestroyed (%this,%mom)
{
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
        %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	%name = GameBase::getDataName(%this);
        %data = GameBase::getDataName(%this);
        %cl.safet = false;
	%meo = (%data.shapefile == "camera" || %data.shapefile == "remoteturret");

	if(%data.shapefile == "rocket" || %meo) 
	{
      	  doneposs(%cl);
	        Client::setControlObject(%cl, %pl);
	        if (%data == EOMissile) 
		  {
              	  GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 80, 1.0, 175, %cl);
        	  } 
		  else if (%data == ShortCoolProj) 
		  {
	                GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 23, 0.4, 305, %cl);
      	          GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 35.0, 0.65, 0, %cl);
        	  }
	}

	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        %value *= $damageScale[GameBase::getDataName(%this), %type];
        StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);

        if(%type == $EMPDamageType) 
		schedule("Vehicle::BlowUp("@%this@");",5,%this); 
}

function Vehicle::getHeatFactor(%this)
{
        // Not getting called right now because turrets don't track
        // vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}



//================================================================================
//====================Vehicle Smoke Trails Data===================================
//================================================================================
//
ExplosionData vehiclesmokeExp
{
	shapeName = "smoke.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;
	timeScale = 15;
	timeZero = 0.2;
	timeOne = 0.9;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

MineData VehicleDummy
{
	className = "smokepuff";
    shapeFile = "smoke";
    shadowDetailMask = 1;
    explosionId = fakeExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = -1;
	drag = 0;
};

GrenadeData VehicleSmokeGren
{
	explosionTag       = vehiclesmokeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = -1;
	elasticity         = 0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $NullDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 0;
	totalTime          = 0.3;
	liveTime           = 0.3;
	projSpecialTime    = 0.01;
};

function VehicleDummy::Detonate(%this,%ismoving)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 2.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

	if(!%ismoving)
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);
	else
	{
		%velX = getWord(%ismoving, 0);
		%velY = getWord(%ismoving, 1);
		if(%velX >= %velY)
			%topvel = %velX;
		else
			%topvel = %velY;

		%timeperiod = ((%topvel/(%this.maxSpeed))*-0.20);
		if(%timeperiod > 0)
			%timeperiod = %timeperiod * -1;
		%timeperiod = %timeperiod + 1;
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",%timeperiod);
	}
}

function Vehicle::SetSmoke(%this)
{
	if(%this.fading != "")
	{
		Schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.3, %this);
		return;
	}
	Vehicle::CheckSmoke(%this);
}


function Vehicle::CheckSmoke(%this)
{
	%vel = Item::getVelocity(%this);
	%velX = getWord(%vel, 0);
	%velY = getWord(%vel, 1);
	if(%velX > 4 || %velX < -4 || %velY > 4 || %velY < -4)
	{
      	%cl = GameBase::getControlClient(%this);
		%player = client::getOwnedobject(%cl);
		%thisPos = GameBase::getPosition(%this);
		%xcoord = getWord(%thisPos,0);
		%ycoord = getWord(%thisPos,1);
		%zcoord = getWord(%thisPos,2) - 2;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],%vel);
		deleteObject(%obj[%this]);
		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.05, %this);
	}
	else if(%this)
	{
	      %cl = GameBase::getControlClient(%this);
		%player = client::getOwnedobject(%cl);
		%thisPos = GameBase::getPosition(%this);

		%xcoord = getWord(%thisPos,0);
		%ycoord = getWord(%thisPos,1);
		%zcoord = getWord(%thisPos,2) - 2;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],%vel);
		deleteObject(%obj[%this]);

		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.4, %this);
	}
	else return;
}

