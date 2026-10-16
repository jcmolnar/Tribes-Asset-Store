FlierData Jetfire
{
        explosionId = flashExpLarge;
        debrisId = flashDebrisLarge;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 40;
   minSpeed = -10;
        maxSideSpeed = 40;
        lift = 1;
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 1.75;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
        accel = 0.7;

        groundDamageScale = 1;

        projectileType = IonBolt;
        reloadDelay = 0.75;
        repairRate = 0;
        fireSound = SoundFireLaser;
        damageSound = SoundFlierCrash;
        ramDamage = 1.5;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;

        visibleDriver = false;
        driverPose = 22;
        description = "JetFire";
};

function Jetfire::Dismount(%this, %cl)
{
        Player::useItem(%cl, "JetfirePack");
      %pl = Client::getOwnedObject(%cl);
        %pl.lastMount = %this;
        %pl.newMountTime = getSimTime() + 3.0;
        Player::setMountObject(%pl, -1, 0);
        %rot = GameBase::getRotation(%this);
        %rotZ = getWord(%rot,2);
        GameBase::setRotation(%pl, "0 0 " @ %rotZ);
      Client::setControlObject(%cl, %pl);

        %newPos = Vector::add(GameBase::getPosition(%cl), "0 0 -2");
        GameBase::setPosition(%pl, %newPos);

        playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
        bottomprint(Player::getClient(%player), "<jc><f2>Bipedal <f0>mode", 5);
        %pl.driver = "";
        %pl.vehicle = "";
        %damage = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%pl, %damage);
        GameBase::setPosition(%this, "-1000 -1000 -1000");
        GameBase::applyRadiusDamage($DebrisDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
}

FlierData Retaliator
{
        explosionId = flashExpLarge;
        debrisId = flashDebrisLarge;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 32;
   maxPitch = 32;
   maxSpeed = 40;
   minSpeed = -10;
        maxSideSpeed = 40;
        lift = 1;
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 1.33;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
        accel = 0.7;

        groundDamageScale = 1;

        projectileType = IonBolt;
        reloadDelay = 0.75;
        repairRate = 0;
        fireSound = SoundFireLaser;
        damageSound = SoundFlierCrash;
        ramDamage = 1.5;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        visibleToSensor = true;
        shadowDetailMask = 2;

        idleSound = SoundFlyerIdle;
        moveSound = SoundFlyerActive;

        visibleDriver = false;
        driverPose = 22;
        description = "Retaliator";
};

function Retaliator::Dismount(%this, %cl)
{
        Player::useItem(%cl, "RetaliatorPack");
      %pl = Client::getOwnedObject(%cl);
        %pl.lastMount = %this;
        %pl.newMountTime = getSimTime() + 3.0;
        Player::setMountObject(%pl, -1, 0);
        %rot = GameBase::getRotation(%this);
        %rotZ = getWord(%rot,2);
        GameBase::setRotation(%pl, "0 0 " @ %rotZ);
      Client::setControlObject(%cl, %pl);

        %newPos = Vector::add(GameBase::getPosition(%cl), "0 0 -2");
        GameBase::setPosition(%pl, %newPos);

        playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
        bottomprint(Player::getClient(%player), "<jc><f2>Bipedal <f0>mode", 5);
        %pl.driver = "";
        %pl.vehicle = "";
        %damage = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%pl, %damage);
        GameBase::setPosition(%this, "-1000 -1000 -1000");
        GameBase::applyRadiusDamage($DebrisDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
}

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
        maxAlt = 250;
        maxVertical = 10;
        maxDamage = 0.75;
        damageLevel = {1.0, 1.0};
        accel = 0.4;
        groundDamageScale = 1;
        reloadDelay = 0.15;
        maxEnergy = 30;
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
   maxSpeed = 50;
   minSpeed = -1.5;
        maxSideSpeed = 50;
        lift = 1;
        maxAlt = 250;
        maxVertical = 10;
        maxDamage = 0.7;
        damageLevel = {1.0, 1.0};
        accel = 0.75;
        groundDamageScale = 1;
        reloadDelay = 0.2;
        projectileType = SuperBlaster;
        maxEnergy = 30;
        repairRate = 0;
        fireSound = SoundPlasmaTurretFire;
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
};

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
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 0.1;
        damageLevel = {1.0, 1.0};
        accel = 0.4;
        groundDamageScale = 0.5;
        projectileType = RifleBullet;
        reloadDelay = 0.3;
        maxEnergy = 30;
        repairRate = 0;
        fireSound = SoundFirePistol;
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
        maxAlt = 100000;
        maxVertical = 0.0000001;
        maxDamage = 0.55;

        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
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
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 0.25;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
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
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
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
        maxAlt = 255;
        maxVertical = 10;
        maxDamage = 1.25;
        damageLevel = {1.0, 1.0};
        maxEnergy = 40;
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
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 1.75;
        damageLevel = {1.0, 1.0};
        accel = 0.6;

        groundDamageScale = 1;

        reloadDelay = 1.5;
        maxEnergy = 30;
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
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 1.5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
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
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
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
        maxAlt = 900;
        maxVertical = 900;
        maxDamage = 0.5;
        damageLevel = {1.0, 1.0};
        destroyDamage = 1.0;
        maxEnergy = 40;
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
        maxAlt = 15;
        maxVertical = 6;
        maxDamage = 2.0;
        damageLevel = {1.0, 1.0};
        maxEnergy = 50;
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
   maxSpeed = 25;
   minSpeed = -1;
        lift = 2;
        maxAlt = 15;
        maxVertical = 0.001;
        maxDamage = 3.5;
        maxSideSpeed = 45;
        damageLevel = {1.0, 1.0};
        maxEnergy = 50;
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
        maxAlt = 2500;
        maxVertical = 0.0001;
        maxDamage = 5;
        damageLevel = {1.0, 1.0};
        maxEnergy = 50;
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
};

//============================================================================
//Drones, Missiles and crap as such
//============================================================================

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
        maxAlt = 200;
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
        maxAlt = 200;
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
    shapeFile = "camera";
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
        maxAlt = 50;
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
};

function SurveyDrone::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
        calcRadiusDamage(%this,$DebrisDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
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

$DamageScale[Jetfire, $ImpactDamageType] = 1.0;
$DamageScale[Jetfire, $BulletDamageType] = 1.0;
$DamageScale[Jetfire, $PlasmaDamageType] = 1.0;
$DamageScale[Jetfire, $EnergyDamageType] = 1.0;
$DamageScale[Jetfire, $ExplosionDamageType] = 1.0;
$DamageScale[Jetfire, $ShrapnelDamageType] = 1.0;
$DamageScale[Jetfire, $DebrisDamageType] = 1.0;
$DamageScale[Jetfire, $MissileDamageType] = 1.0;
$DamageScale[Jetfire, $LaserDamageType] = 0.5;
$DamageScale[Jetfire, $MortarDamageType] = 1.0;
$DamageScale[Jetfire, $BlasterDamageType] = 0.5;
$DamageScale[Jetfire, $ElectricityDamageType] = 1.0;
$DamageScale[Jetfire, $MineDamageType]        = 1.0;

$DamageScale[Retaliator, $ImpactDamageType] = 1.0;
$DamageScale[Retaliator, $BulletDamageType] = 1.0;
$DamageScale[Retaliator, $PlasmaDamageType] = 1.0;
$DamageScale[Retaliator, $EnergyDamageType] = 1.0;
$DamageScale[Retaliator, $ExplosionDamageType] = 1.0;
$DamageScale[Retaliator, $ShrapnelDamageType] = 1.0;
$DamageScale[Retaliator, $DebrisDamageType] = 1.0;
$DamageScale[Retaliator, $MissileDamageType] = 1.0;
$DamageScale[Retaliator, $LaserDamageType] = 0.5;
$DamageScale[Retaliator, $MortarDamageType] = 1.0;
$DamageScale[Retaliator, $BlasterDamageType] = 0.5;
$DamageScale[Retaliator, $ElectricityDamageType] = 1.0;
$DamageScale[Retaliator, $MineDamageType]        = 1.0;

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
        if(%data.shapefile == "rocket") {
                if (%data == ShortCoolProj) {
                        schedule("keepers("@%this@");",10,%this);
                        schedule("GameBase::setDamageLevel("@%this@", "@%data.maxDamage@");",10.5,%this);
                        }
        }
         if(GameBase::getDataName(%this) == Scout)
        {        GameBase::setMapName (%this, "Scout");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == LAPC)
        {        GameBase::setMapName (%this, "LPC");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == HAPC)
        {        GameBase::setMapName (%this, "HPC");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == HoverTank)
        {        GameBase::setMapName (%this, "Hover Tank");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == StarHammer)
        {        GameBase::setMapName (%this, "Star Hammer");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == Arwing)
        {        GameBase::setMapName (%this, "Arwing");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == SkyCutter)
        {        GameBase::setMapName (%this, "Sky Cutter");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
         if(GameBase::getDataName(%this) == EscapePod)
        {        GameBase::setMapName (%this, "Lightning");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == Icarus)
        {        GameBase::setMapName (%this, "Annihilator");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == Skyranger)
        {        GameBase::setMapName (%this, "Skyranger");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == StarFighter)
        {        GameBase::setMapName (%this, "StarFighter");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
			
        }
        else if(GameBase::getDataName(%this) == Avenger)
        {        GameBase::setMapName (%this, "ThunderTank");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == Explorer)
        {        GameBase::setMapName (%this, "3DFX Explorer");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
        else if(GameBase::getDataName(%this) == Jetfire)
        {        GameBase::setMapName (%this, "Human Flier Jetfire");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 8);
        }
        else if(GameBase::getDataName(%this) == Retaliator)
        {        GameBase::setMapName (%this, "Human Flier Retaliator");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 8);
        }

        else if(GameBase::getDataName(%this) == Interceptor)
        {        GameBase::setMapName (%this, "Valkyrie Interceptor");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }
}

//THIS SECTION ADDED BY SCAV - MODIFY IT FOR YOUR MOD
function PopulateCanPilot(%APC, %peltastm, %peltastf, %blastechm, %blastechf, %magionm, %magionf, %hoplitem, %hoplitef, %mech, %harmor, %mearmor, %ebarmor, %ebfemale, %sarmor, %sfemale)
{
  $VehicleUse[larmor, %APC] = %peltastm;
  $VehicleUse[lfemale, %APC] = %peltastf;
  $VehicleUse[blastechm, %APC] = %blastechm;
  $VehicleUse[blastechf, %APC] = %blastechf;
  $VehicleUse[magionm, %APC] = %magionm;
  $VehicleUse[magionf, %APC] = %magionf;
  $VehicleUse[marmor, %APC] = %hoplitem;
  $VehicleUse[mfemale, %APC] = %hoplitef;
  $VehicleUse[mech, %APC] = %mech;
  $VehicleUse[harmor, %APC] = %harmor;  
  $VehicleUse[mearmor, %APC] = %mearmor;
  $VehicleUse[ebarmor, %APC] = %ebarmor;
  $VehicleUse[sarmor, %APC] = %sarmor;
  $VehicleUse[sfemale, %APC] = %sfemale;
  $VehicleUse[ebfemale, %APC] = %ebfemale;
}

$CanPuke = 0;
$CanPilot = 1;
$CanRide = 2;

PopulateCanPilot(Scout,        $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(Arwing,       $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(Skycutter,    $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(EscapePod,    $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(Skyranger,    $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(starfighter,  $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(starhammer,   $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(explorer,     $CanPilot, $CanPilot, $CanPilot, $CanPilot, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPuke, $CanPilot, $CanPilot, $CanPuke);
PopulateCanPilot(LAPC,         $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);
PopulateCanPilot(Avenger,      $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);
PopulateCanPilot(Interceptor,  $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);
PopulateCanPilot(HAPC,         $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);
PopulateCanPilot(HoverTank,    $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);
PopulateCanPilot(Icarus,       $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanPilot, $CanPilot, $CanPilot, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide, $CanRide);

//END OF SECTION ADDED BY SCAV

function Vehicle::onCollision (%this, %object)
{
        %vehname = GameBase::getDataName(%this);
        %data = GameBase::getDataName(%this);
        if(%data.shapefile == "remoteturret") return;
        if(%data.shapefile == "rocket" || (%data.shapefile == "discb" && getObjectType(%object) == "Player")) {
                GameBase::setDamageLevel(%this, 99);
                return;
        }

        if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
                if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
                        {
                        %armor = Player::getArmor(%object);
                      %client = Player::getClient(%object);
//THIS NEXT LINE ADDED BY SCAV                                
				 if (($VehicleUse[%armor, %vehname] & $CanPilot) && Vehicle::canMount(%this, %object))
                                        {
                                        if (!Player::isAiControlled(%object)) 
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
											Player::setDetectParameters(%client, 50, 150);
											%rate = Player::getSensorSupression(%player) + 1;
											Player::setSensorSupression(%player,%rate);
										}
                                                }
                                                Player::setMountObject(%object, %this, 1);
                                                doneposs(%client);
                                                Client::setControlObject(%client, %this);
                                                playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
                                                %object.driver= 1;
                                                %object.vehicle = %this;
                                                %this.clLastMount = %client;
                                                }
                                        }
				      	  //ADDED BY SCAV
					        else if ($VehicleUse[%armor, %vehname] & $CanRide) 
                                      {
                                                 %mountSlot= Vehicle::findEmptySeat(%this,%client);
                                                if(%mountSlot)
                                                        {
                                                                %object.vehicleSlot = %mountSlot;
                                                                %object.vehicle = %this;
                                                                Player::setMountObject(%object, %this, %mountSlot);
                                                                playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
                                                        }
//ADDED BY SCAV
else
          Client::sendMessage(Player::getClient(%object),0,"No slot.  Dismount the vehicle to free it for takeoff.~wError_Message.wav");
      }
	// Check if it is too small to ride
	      else if ($VehicleSlots[%vehname] == 0)
              {
		     	Client::sendMessage(Player::getClient(%object),0,"Cannot pilot this vehicle in your current armor class.~werror_message.wav");
              }

      else if (GameBase::getControlClient(%this) == -1)
      {
        Client::sendMessage(Player::getClient(%object),0,"Cannot ride this vehicle in your current armor class.~wError_Message.wav");
      }
//END ADD BY SCAV                                        
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
	else if(%name == EscapePod || %name == Jetfire || %name == Retaliator || %name == Arwing || %name == SkyCutter || %name == StarHammer || %name == Explorer || %name == Skyranger || %name == StarFighter){
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

function Vehicle::BlowUp(%this)
{
	
	%time = GameBase::getEnergy(%this);
	if(%time < 8) GameBase::applyDamage(%this,$EnergyDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	else 
	{
		GameBase::setEnergy(%this,%time - 1);
   		schedule("Vehicle::BlowUp("@%this@");",0.1,%this);
  	}
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
        if(GameBase::getDataName(%this) == "Jetfire")
        {
                Jetfire::Dismount(%this, %cl);
                return;
        }
        else if(GameBase::getDataName(%this) == "Retaliator")
        {
                Retaliator::Dismount(%this, %cl);
                return;
        }
        else if(GameBase::getDataName(%this) == Explorer) 
	  {
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 1;
		Player::setSensorSupression(%player,0);
		Player::setDetectParameters(%clientid, 0.027, 0);
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
	  {
		%cl = Player::getClient(%player);
		%arm = Player::getArmor(%cl);
		if(%arm == "harmor" || %arm == "MECH") // To prevent the Jetfire bug of arising
		{
			GameBase::applyDamage(%this,$EnergyDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
		}
		else
		{
                Vehicle::BlowUp(%this); 
		}
        }
}

function Vehicle::getHeatFactor(%this)
{
        // Not getting called right now because turrets don't track
        // vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}


