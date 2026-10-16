 //========================================================== Wheeeeeeeeeeee
//                                        Vehicles
//========================================================== Mega Man 1024

FlierData EscapePod // Lightning
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
        maxAlt = 2500;
        maxVertical = 10;
        maxDamage = 0.1;
        damageLevel = {1.0, 1.0};
        accel = 0.75;

        groundDamageScale = 0.01;

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
        maxDamage = 1.32;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
        accel = 0.7;

        groundDamageScale = 0.01;

        projectileType = RPG;
        reloadDelay = 0.5;
        repairRate = 0;
        fireSound = SoundMissileTurretFire;
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
//dismount...

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
        #if(%pl.lastWeapon != "")
        #{
        #        Player::useItem(%pl,%pl.lastWeapon);
        #        %pl.lastWeapon = "";
        #}
        %pl.driver = "";
        %pl.vehicle = "";
        %damage = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%pl, %damage);
        $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
        GameBase::setPosition(%this, "-1000 -1000 -1000");
        GameBase::applyRadiusDamage($MortarDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
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

        projectileType = SniperXBullet;
        reloadDelay = 0.3;
        repairRate = 0;
        fireSound = SoundFireSniperX;
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

function SurveyDrone::onCollision(%this,%object)
{
        %repairRate = 0.1;
        %damage = GameBase::getDamageLevel(%object);
        %difference = %damage - %repairRate;
        if (%difference < 0.0)        //If repair by 10 percent would result in exceeding 100 percent, just repair the missing few percent
                {
                        %repairRate = %damage;
                }
        %newDamage = %damage - %repairRate;
        GameBase::setDamageLevel(%object, %newDamage);
}

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
    shapeFile = "camera";
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
        maxAlt = 30;
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

FlierData Scout
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris;
        className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 65;
   minSpeed = -2;
        maxSideSpeed = 45;
        lift = 0.75;
        maxAlt = 25;
        maxVertical = 10;
        maxDamage = 0.6;
        damageLevel = {1.0, 1.0};
        maxEnergy = 30;
        accel = 0.6;

        groundDamageScale = 1.0;

        #projectileType = StdRocket;
        reloadDelay = 0.75;
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

function Scout::onFire(%this) {
        if(%this.lastFire > getSimTime()) return;
        %this.lastFire = getSimTime() + 3.5;
        playsound(SoundFireFlierRocket, GameBase::getPosition(%this));
        %trans = GameBase::getMuzzleTransform(%this);
        %vel = Item::getVelocity(%this);
        if(GameBase::getLOSInfo(%this, 500)) {
                %object = $los::object;
                if(getObjectType(%object) == "Flier") {
                        %targetId = GameBase::getControlClient(%object);
                        %targetName = Client::getName(%targetId);
                        %client = GameBase::getControlClient(%this);
                        %name = Client::getName(%client);
                        if(%targetName == "") {
                                Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ "~wmine_act.wav");
                        } else {
                                Client::sendMessage(%client, 0, "Lock Aquired: " @ GameBase::getDataName(%object) @ " piloted by " @ %targetName @ "~wmine_act.wav");
                                Client::sendMessage(%targetId, 0, "WARNING - " @ %name @ " has an AA lock!~werror_message.wav");
                        }
                        Projectile::spawnProjectile("TurretMissile", %trans, %this, %vel, %object);
                } else {
                        Projectile::spawnProjectile("FlierRocket",%trans,%this,%vel);
                }
        } else {
                Projectile::spawnProjectile("FlierRocket",%trans,%this,%vel);
        }
}

#-----------------------------------------------------------------#
# Missile Launcher Script by Valya[AAOD], Z_Dog and Mega Man 1024 #
#-----------------------------------------------------------------#

function Experim::onFire(%this)
{
        if(%this.lastFire > getSimTime()) return;
        %this.lastFire = getSimTime() + 1.01;
        %trans = GameBase::getMuzzleTransform(%this);
        %vel = Item::getVelocity(%this);

        GameBase::getLOSInfo(%player,1024);
        %tpos=($los::position);
        %target=AquireTarget(%player,0,%tpos);
        if(%target)
        {
                                %targetcl=Player::GetClient(%target);
                                %jam=CheckTargetJamming(%target);
                                if(%jam==1)
                                {
                                        playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                        Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
                                }
                                else if(%jam==2)
                                {
                                        %tpos=GameBase::getPosition(%player);
                                        %target=AquireTarget(%player,2,%tpos);
                                        if(%target)
                                        {
                                                Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
                                                Client::sendMessage(%client,0,"~wmine_act.wav");
                                                playSound(SoundFireFlierRocket, GameBase::getPosition(%player));

                                        }
                                }
                                else
                                {
                                        Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
                                        Client::sendMessage(%client,0,"~wmine_act.wav");
                                        playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                }
                        }
                        else
                        {
                                %tpos=GameBase::getPosition(%player);
                                %target=AquireTarget(%player,1,%tpos);
                                if(%target)
                                {
                                        %TargetCl=Player::GetClient(%target);
                                        %jam=CheckTargetJamming(%target);
                                        if(%jam==1)
                                        {
                                                Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
                                                playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                                Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
                                        }
                                        else if(%jam==2)
                                        {
                                                %tpos=GameBase::getPosition(%player);
                                                %target=AquireTarget(%player,2,%tpos);
                                                if(%target)
                                                {
                                                        Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
                                                        Client::sendMessage(%client,0,"~wmine_act.wav");
                                                        playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                                }
                                        }
                                        else
                                        {
                                                Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
                                                Client::sendMessage(%client,0,"~wmine_act.wav");
                                                playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                        }
                                }
                                else
                                {
                                        playSound(SoundFireFlierRocket, GameBase::getPosition(%player));
                                        Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
                                }
                }
}

FlierData LAPC
{
        explosionId = FlierExplosion;
        debrisId = FlierDebris2;
        className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.3;
   maxPitch = 0.1;
   maxSpeed = 40;
   minSpeed = -10;
        lift = 0.5;
        maxAlt = 9;
        maxVertical = 5;
        maxDamage = 1.5;
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

        projectileType = mortarshell;
        fireSound = SoundFireMortar;
        reloadDelay = 2.0;
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

        projectileType = RPEMP;
        fireSound = SoundPlasmaTurretFire;
        reloadDelay = 2.0;
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

FlierData EOMissile
{
        explosionId = MortarExp;
        debrisId = EODebris;
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
        ramDamageType = $MortarDamageType;
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
        calcRadiusDamage(%this,$MortarDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
}

function EOMissile::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
        calcRadiusDamage(%this,$MortarDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
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
   calcRadiusDamage(%this,$MortarDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
}

function EOMissile::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1){
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
        calcRadiusDamage(%this,$MortarDamageType, 20, 1.0, 250, 20, 20, 1.0, 1.0, 250, 250);
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
        maxAlt = 200;
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
        debrisId = flashDebrisLarge;
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
        ramDamage = 0.25;
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

function ScouterMissile::onAdd(%this)
{
        GameBase::setRechargeRate (%this,0);
         schedule("ScouterMissile::exhaustFuel("@%this@");",1,%this);
}

function ScouterMissile::onCollision(%this,%object)
{
         GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
        calcRadiusDamage(%this,$MissileDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
}

function ScouterMissile::jump(%this,%mom)
{
        GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
        calcRadiusDamage(%this,$MissileDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
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
        calcRadiusDamage(%this,$MissileDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
}

function ScouterMissile::exhaustFuel(%this)
{
  %fuel = GameBase::getEnergy(%this);
  if(%fuel < 1){
        GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
        calcRadiusDamage(%this,$MissileDamageType, 9.5, 0.5, 250, 9.5, 9.5, 0.5, 0.5, 250, 250);
  }
  else
  {
   GameBase::setEnergy(%this,%fuel - 1);
   schedule("ScouterMissile::exhaustFuel("@%this@");",1,%this);
  }
}

#now we reach "The breaking Point"
#woofowowoowwowowofofowofowf

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
        maxAlt = 2500;
        maxVertical = 1000;
        maxDamage = 0.75;
        damageLevel = {1.0, 1.0};
        accel = 0.4;

        groundDamageScale = 1.7;

        projectileType = BlasterBolt;
        reloadDelay = 0.15;
        maxEnergy = 30;
        repairRate = 0;
        fireSound = SoundFireBlaster;
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

        groundDamageScale = 0.01;

        projectileType = DisruptorBeam;
        reloadDelay = 0.3;
        maxEnergy = 30;
        repairRate = 0;
        fireSound = SoundLaserHit;
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

        #projectileType = IonShock3;
        reloadDelay = 1.5;
        maxEnergy = 30;
        repairRate = 0;
        #fireSound = capturedtower;
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

        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
        Projectile::spawnProjectile("EcstacyShot",%trans,%this,%vel);
}

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
        groundDamageScale = 0.5;
        #projectileType = rifleBullet2;
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

        groundDamageScale = 0.1;

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

        groundDamageScale = 0.01;

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
        maxAlt = 250;
        maxVertical = 100;
        maxDamage = 1.25;
        damageLevel = {1.0, 1.0};
        maxEnergy = 40;
        accel = 0.8;

        groundDamageScale = 0.1;

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

        groundDamageScale = 0.01;

        projectileType = Plasmabolt2;
        reloadDelay = 0.45;
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

        groundDamageScale = 0.001;

        repairRate = 0;
        ramDamage = 2;
        ramDamageType = -1;
        mapFilter = 2;
        mapIcon = "M_vehicle";
        projectileType = RPM;
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
        {        GameBase::setMapName (%this, "Human Flier");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 8);
        }
        else if(GameBase::getDataName(%this) == Interceptor)
        {        GameBase::setMapName (%this, "Valkyrie Interceptor");
                %this.shieldStrength = 0;
                GameBase::setRechargeRate (%this, 0);
        }

}

function Vehicle::onCollision (%this, %object)
{
        %data = GameBase::getDataName(%this);
        if(%data.shapefile == "remoteturret") return;
        if(%data.shapefile == "rocket" || (%data.shapefile == "discb" && getObjectType(%object) == "Player")) {
                GameBase::setDamageLevel(%this, 99);
                return;
        }

        if(%object.driver != "") return;

        if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
                if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
                        {
                        %armor = Player::getArmor(%object);
                      %client = Player::getClient(%object);
//                                if ((%armor == "larmor" || %armor == "lfemale" || %armor == "BlastechM" || %armor == "BlastechF") && Vehicle::canMount (%this, %object))
                                if ((%armor == "larmor" || %armor == "lfemale" || %armor == "marmor" || %armor == "mfemale" || %armor == "harmor" || %armor == "BlastechM" || %armor == "BlastechF" || %armor == "MagIonM" || %armor == "MagIonF" || %armor == "MECH") && Vehicle::canMount (%this, %object))
                                        {
                                        if (!Player::isAiControlled(%object))  //No bots allowed as drivers!! Only as passengers!
                                                {
                                                %weapon = Player::getMountedItem(%object,$WeaponSlot);
                                                if(%weapon != -1) {
                                                        %object.lastWeapon = %weapon;
                                                        Player::unMountItem(%object,$WeaponSlot);
                                                        }
                                                        if(%data == Explorer) {
                                                        if(Player::getMountedItem(%object,$FlagSlot) != "flag")
                                                                GameBase::startFadeout(%this);
                                                }
                                                Player::setMountObject(%object, %this, 1);
                                                doneposs(%client);
                                                %client.safet = false;
                                                remoteEval(%client, SetControls, true);
                                                Client::setControlObject(%client, %this);
                                                playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
                                                %object.driver= 1;
                                                %object.vehicle = %this;
                                                %this.clLastMount = %client;
                                                $Spoonbot::IsPilot[%client] = True;
                                                BotFuncs::BotsHopOn(%client);
                                                }
                                        }
//                                else if(GameBase::getDataName(%this) != Scout || (%this) != EscapePod || (%this) != Jetfire || (%this) != SurveyDrone || (%this) !=  ProbeDroid || (%this) != Drone || (%this) != EOMissile || (%this) != ScouterMissile || (%this) != Arwing || (%this) != SkyCutter || (%this) != StarHammer || (%this) != Explorer || (%this) != Skyranger || (%this) != Icarus || (%this) != Avenger || (%this) != StarFighter)
					    else if(GameBase::getDataName(%this) != SuperX) 
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
                                else if (GameBase::getControlClient(%this) == -1){
                                        Client::sendMessage(Player::getClient(%object),0,"You must be in Light or Blastech armor to pilot the vehicles.~wError_Message.wav");
                                        return;
                                }
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
	else if(%name == EscapePod || %name == Jetfire || %name == Arwing || %name == SkyCutter || %name == StarHammer || %name == Explorer || %name == Skyranger || %name == StarFighter){
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

                if ($Spoonbot::IsPilot[%client]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
                {
                        BotsHopOff(%client);


              }

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
                                                if(GameBase::getDataName(%this) == Explorer)
                                                {
                                                        GameBase::startFadein(%this);
                                                }
                        if ($Spoonbot::IsPilot[%cl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
                        {
                                BotsHopOff(%cl);
                        }
                        if ($Spoonbot::IsPilot[%pl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
                        {
                                BotsHopOff(%pl);
                        }


                      }
                                %pl.driver = "";
                                %pl.vehicle = "";
                        }
                        else
                                Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
                }
   }
}

function Vehicle::onDestroyed (%this,%mom) {

$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
%cl = GameBase::getControlClient(%this);
%pl = Client::getOwnedObject(%cl);

remoteEval(%cl, SetControls);

Client::setOwnedObject(%cl, %this);
Client::setOwnedObject(%cl, %pl);

%data = GameBase::getDataName(%this);
%cl.safet = false;

%meo = (%data.shapefile == "camera" || %data.shapefile == "discb");

if(%data.shapefile == "rocket" || %meo) {
        doneposs(%cl);
        Client::setControlObject(%cl, %pl);
        if (%data == EOMissile) {
                GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 80, 1.0, 175, %cl);
        } else if (%data == ShortCoolProj) {
                GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 23, 0.4, 305, %cl);
                GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 35.0, 0.65, 0, %cl);
        } else if (%data == ScouterMissile) {
                GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 30, 0.57, 365, %cl);
                GameBase::applyRadiusDamage($MissileDamageType, getBoxCenter(%this), 35.0, 0.5, 0, %cl);
        }
        if(%pl != -1) {
                Player::setMountObject(%pl, -1, 0);
                doneposs(%cl);
                Client::setControlObject(%cl, %pl);
                if(%pl.lastWeapon != "") {
                        Player::useItem(%pl,%pl.lastWeapon);
                        %pl.lastWeapon = "";
                }
                %pl.driver = "";
        }
        if ($Spoonbot::IsPilot[%cl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
        {
                BotsHopOff(%cl);
        }
        if ($Spoonbot::IsPilot[%pl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
        {
                BotsHopOff(%pl);
        }
        for(%i = 0 ; %i < 4 ; %i++)
                if(%this.Seat[%i] != "") {
                        %pl = Client::getOwnedObject(%this.Seat[%i]);
                        Player::setMountObject(%pl, -1, 0);
                        doneposs(%this.Seat[%i]);
                        Client::setControlObject(%this.Seat[%i], %pl);
                }
        calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        %value *= $damageScale[GameBase::getDataName(%this), %type];
        StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
        if(%type == $EMPDamageType) {
                Vehicle::BlowUp(%this); 
        }
}

function Vehicle::getHeatFactor(%this)
{
        // Not getting called right now because turrets don't track
        // vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}

function Vehicle::getHeat(%this) { return 1.0; }

function checkEm(%cl, %pl, %obj) {
        if(Client::getControlObject(%cl) == %obj && Client::getOwnedObject(%cl) != -1) {
                Client::setControlObject(%cl, Client::getOwnedObject(%cl));
                doneposs(%cl);
        }
        %cl.booyah = false;
}






#End