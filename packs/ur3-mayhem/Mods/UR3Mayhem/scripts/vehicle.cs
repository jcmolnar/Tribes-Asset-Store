//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
      shapeFile = "newflyer";
      shieldShapeName = "shield_medium";
      mass = 9.0;
      drag = 1.0;
      density = 1.2;
      maxBank = 0.9;
      maxPitch = 0.9;
      maxSpeed = 150;
      minSpeed = -20;
	lift = 0.75;
	maxAlt = 55;
	maxVertical = 50;
	maxDamage = 5.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.9;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 0.05;
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


FlierData Jet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
      shapeFile = "vyper";
      shieldShapeName = "shield_medium";
      mass = 9.0;
      drag = 1.0;
      density = 1.2;
      maxBank = 0.9;
      maxPitch = 0.9;
      maxSpeed = 190;
      minSpeed = -9;
	lift = 0.75;
	maxAlt = 55;
	maxVertical = 12;
	maxDamage = 5.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.99;

	groundDamageScale = 2.0;

	projectileType = DiscShell;
	reloadDelay = 0.2;
	repairRate = 1;
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

};

FlierData Jet2
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
      shapeFile = "newflyer";
      shieldShapeName = "shield_medium";
      mass = 9.0;
      drag = 1.0;
      density = 1.2;
      maxBank = 0.9;
      maxPitch = 0.9;
      maxSpeed = 190;
      minSpeed = -9;
	lift = 0.75;
	maxAlt = 55;
	maxVertical = 12;
	maxDamage = 5.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.99;

	groundDamageScale = 2.0;

	projectileType = BlasterBolt;
	reloadDelay = 0.02;
	repairRate = 1;
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

};



 FlierData Bomber
 {
 explosionId = flashExpLarge;
 debrisId = flashDebrisLarge;
 className = "Vehicle";
 shapeFile = "vyper";
 shieldShapeName = "shield_medium";
 mass = 9.0;
 drag = 1.0;
 density = 1.2;
 maxBank = 0.9;
 maxPitch = 0.9;
 maxSpeed = 190;
 minSpeed = -5;
 lift = 0.75;
 maxAlt = 35;
 maxVertical = 5;
 maxDamage = 0.6;
 damageLevel = {1.0, 1.0};
 maxEnergy = 100;
 accel = 0.99;
 groundDamageScale = 1.0;
 reloadDelay = 6.0;
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
 description = "EMP Bomber"; };
     function Bomber::onFire(%vehicle, %slot) { if(!%vehicle.isFiring) { %count = 7; ToggleFire(%vehicle); schedule("DeployEMP(" @ %vehicle @ " , " @ %count @ ");",0.25,%vehicle); schedule("ToggleFire(" @ %vehicle @ ");",6.0,%vehicle); } }
     function DeployEMP(%vehicle, %count) { if(%count) { %trans = GameBase::getMuzzleTransform(%vehicle); %vel = Item::getVelocity(%vehicle); Projectile::spawnProjectile("EMPBomb",%trans,%vehicle,%vel); playSound(SoundPlasmaTurretFire,GameBase::getPosition(%vehicle)); %count--; schedule("DeployEMP(" @ %vehicle @ " , " @ %count @ ");",0.2,%vehicle); } }
     function ToggleFire(%this) { if(%this.isFiring) %this.isFiring = false; else %this.isFiring = true; }


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
   maxBank = 0.9;
   maxPitch = 0.9;
   maxSpeed = 190;
   minSpeed = -9;
	lift = 0.95;
	maxAlt = 35;
	maxVertical = 12;
	maxDamage = 0.9;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.99;

	groundDamageScale = 2.0;

	projectileType = RifleBullet;
	reloadDelay = 0.03;
	repairRate = 1;
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

	visibleDriver = false;
	driverPose = 22;

};



FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_medium";
   mass = 8.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.95;
   maxPitch = 0.75;
   maxSpeed = 125;
   minSpeed = -1;
	lift = 0.9;
	maxAlt = 55;
	maxVertical = 9;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.95;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
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
};

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
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
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
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
};


//----------------------------------------------------------------------------

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
$DamageScale[Scout, $RifleDamageType] = 0.5;
$DamageScale[Scout, $RailDamageType] = 0.7;
$DamageScale[Scout, $EMPDamageType] = 1.0;
$DamageScale[Scout, $ShotgunDamageType] = 1.0; 
$DamageScale[Scout, $AssaultRifleDamageType] = 1.0;
$DamageScale[Scout, $FFBDamageType] = 1.0;
$DamageScale[Scout, $FlameDamageType] = 0.5;
$DamageScale[Scout, $TranqDamageType] = 0.7;
$DamageScale[Scout, $CrushDamageType] = 0.7;


$DamageScale[Jet, $ImpactDamageType] = 1.0;
$DamageScale[Jet, $BulletDamageType] = 1.0;
$DamageScale[Jet, $PlasmaDamageType] = 1.0;
$DamageScale[Jet, $EnergyDamageType] = 1.0;
$DamageScale[Jet, $ExplosionDamageType] = 1.0;
$DamageScale[Jet, $ShrapnelDamageType] = 1.0;
$DamageScale[Jet, $DebrisDamageType] = 1.0;
$DamageScale[Jet, $MissileDamageType] = 1.0;
$DamageScale[Jet, $LaserDamageType] = 1.0;
$DamageScale[Jet, $MortarDamageType] = 1.0;
$DamageScale[Jet, $BlasterDamageType] = 0.5;
$DamageScale[Jet, $ElectricityDamageType] = 1.0;
$DamageScale[Jet, $MineDamageType]        = 1.0;
$DamageScale[Jet, $RifleDamageType] = 0.5;
$DamageScale[Jet, $RailDamageType] = 0.7;
$DamageScale[Jet, $EMPDamageType] = 1.0;
$DamageScale[Jet, $ShotgunDamageType] = 1.0;
$DamageScale[Jet, $AssaultRifleDamageType] = 1.0;
$DamageScale[Jet, $FFBDamageType] = 1.0;
$DamageScale[Jet, $FlameDamageType] = 0.5;
$DamageScale[Jet, $TranqDamageType] = 0.7;
$DamageScale[Jet, $CrushDamageType] = 0.7;

$DamageScale[Jet2, $ImpactDamageType] = 1.0;
$DamageScale[Jet2, $BulletDamageType] = 1.0;
$DamageScale[Jet2, $PlasmaDamageType] = 1.0;
$DamageScale[Jet2, $EnergyDamageType] = 1.0;
$DamageScale[Jet2, $ExplosionDamageType] = 1.0;
$DamageScale[Jet2, $ShrapnelDamageType] = 1.0;
$DamageScale[Jet2, $DebrisDamageType] = 1.0;
$DamageScale[Jet2, $MissileDamageType] = 1.0;
$DamageScale[Jet2, $LaserDamageType] = 1.0;
$DamageScale[Jet2, $MortarDamageType] = 1.0;
$DamageScale[Jet2, $BlasterDamageType] = 0.5;
$DamageScale[Jet2, $ElectricityDamageType] = 1.0;
$DamageScale[Jet2, $MineDamageType]        = 1.0;
$DamageScale[Jet2, $RifleDamageType] = 0.5;
$DamageScale[Jet2, $RailDamageType] = 0.7;
$DamageScale[Jet2, $EMPDamageType] = 1.0;
$DamageScale[Jet2, $ShotgunDamageType] = 1.0;
$DamageScale[Jet2, $AssaultRifleDamageType] = 1.0;
$DamageScale[Jet2, $FFBDamageType] = 1.0;
$DamageScale[Jet2, $FlameDamageType] = 0.5;
$DamageScale[Jet2, $TranqDamageType] = 0.7;
$DamageScale[Jet2, $CrushDamageType] = 0.7;



$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 1.0;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType]        = 1.0;
$DamageScale[Bomber, $RifleDamageType] = 0.5;
$DamageScale[Bomber, $RailDamageType] = 0.7;
$DamageScale[Bomber, $EMPDamageType] = 1.0;
$DamageScale[Bomber, $ShotgunDamageType] = 1.0;
$DamageScale[Bomber, $AssaultRifleDamageType] = 1.0;
$DamageScale[Bomber, $FFBDamageType] = 1.0;
$DamageScale[Bomber, $FlameDamageType] = 0.5;
$DamageScale[Bomber, $TranqDamageType] = 0.7;
$DamageScale[Bomber, $CrushDamageType] = 0.7;


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
$DamageScale[Wraith, $MineDamageType]        = 1.0;
$DamageScale[Wraith, $RifleDamageType] = 0.5;
$DamageScale[Wraith, $RailDamageType] = 0.7;
$DamageScale[Wraith, $EMPDamageType] = 1.0;
$DamageScale[Wraith, $ShotgunDamageType] = 1.0;
$DamageScale[Wraith, $AssaultRifleDamageType] = 1.0;
$DamageScale[Wraith, $FFBDamageType] = 1.0;
$DamageScale[Wraith, $FlameDamageType] = 0.5;
$DamageScale[Wraith, $TranqDamageType] = 0.7;
$DamageScale[Wraith, $CrushDamageType] = 0.7;


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
$DamageScale[LAPC, $RifleDamageType] = 0.5;
$DamageScale[LAPC, $RailDamageType] = 0.5;
$DamageScale[LAPC, $EMPDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;
$DamageScale[LAPC, $AssaultRifleDamageType] = 1.0;
$DamageScale[LAPC, $FFBDamageType] = 1.0;
$DamageScale[LAPC, $FlameDamageType] = 0.5;
$DamageScale[LAPC, $TranqDamageType] = 0.7;
$DamageScale[LAPC, $CrushDamageType] = 0.7;
 

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
$DamageScale[HAPC, $RifleDamageType] = 0.5;
$DamageScale[HAPC, $RailDamageType] = 0.5;
$DamageScale[HAPC, $EMPDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0; 
$DamageScale[HAPC, $AssaultRifleDamageType] = 1.0; 
$DamageScale[HAPC, $FFBDamageType] = 1.0;
$DamageScale[HAPC, $FlameDamageType] = 0.5;
$DamageScale[HAPC, $TranqDamageType] = 0.7;
$DamageScale[HAPC, $CrushDamageType] = 0.7;



//----------------------------------------------------------------------------

 function Vehicle::onAdd(%this)
 { 
 %this.shieldStrength = 0.0;
 GameBase::setRechargeRate (%this, 10);
    if(GameBase::getDataName(%this) == Scout)
       GameBase::setMapName (%this, "Scout");
    if(GameBase::getDataName(%this) == Jet)
       GameBase::setMapName (%this, "Avenger");
    if(GameBase::getDataName(%this) == LAPC)
       GameBase::setMapName (%this, "LPC");
    if(GameBase::getDataName(%this) == HAPC)
       GameBase::setMapName (%this, "HPC"); 
    if(GameBase::getDataName(%this) == Wraith)
       GameBase::setMapName (%this, "Wraith");
    if(GameBase::getDataName(%this) == Bomber)
       GameBase::setMapName (%this, "EMP Bomber"); }

 function Vehicle::onCollision (%this, %object)
 {
     if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
     if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
     if( Player::isAiControlled(%object) ) return; %armor = Player::getArmor(%object); %client = Player::getClient(%object);
     if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object)) { %weapon = Player::getMountedItem(%object,$WeaponSlot);
     if(%weapon != -1) { %object.lastWeapon = %weapon;
         Player::unMountItem(%object,$WeaponSlot); }
         Player::setMountObject(%object, %this, 1);
           Client::setControlObject(%client, %this);
           playSound (GameBase::getDataName(%this).mountSound,
              GameBase::getPosition(%this));
              GameBase::virtual(%this,"onMount",%this,%object);
                  %object.driver= 1;
                  %object.vehicle = %this;
                  %this.clLastMount = %client;
               }
                  else if((GameBase::getDataName(%this) != Scout)
                       && (GameBase::getDataName(%this) != Bomber))
              {
                  %mountSlot= Vehicle::findEmptySeat(%this,%client);
                     if(%mountSlot) { %object.vehicleSlot = %mountSlot;
                     %object.vehicle = %this;
                        Player::setMountObject(%object, %this, %mountSlot);
                        playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
                       }
                   }
                 else if (GameBase::getControlClient(%this) == -1) Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
                  }
                       }
                            }


 function Vehicle::findEmptySeat(%this,%client)
 {
      if(GameBase::getDataName(%this) == HAPC) %numSlots = 4;
                                          else %numSlots = 2;
                                             %count=0;
                                              for(%i=0;%i<%numSlots;%i++)
                                               if(%this.Seat[%i] == "") {
                           %slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
                           %slotVal[%count] = %i+2;
                           %lastEmpty = %i+2; %count++;
                     }
                            if(%count == 1) { %this.Seat[%lastEmpty-2] = %client; return %lastEmpty;
                     } else if (%count > 1) { %freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
                        %this.Seat[%freeSlot-2] = %client; return %freeSlot; } else return "False"; }

 function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3) { %playerX = getWord(%playerPos,0); %playerY = getWord(%playerPos,1); for(%i = 0 ;%i<%num;%i++) { %x = (getWord(%slotPos[%i],0)) - %playerX; %y = (getWord(%slotPos[%i],1)) - %playerY; if(%x < 0) %x *= -1; if(%y < 0) %y *= -1; %newDistance = sqrt((%x*%x)+(%y*%y)); if(%newDistance < %distance || %distance == "") { %distance = %newDistance; %closePos = %i; } } return %closePos; }

 function Vehicle::passengerJump(%this,%passenger,%mom) { %armor = Player::getArmor(%passenger); if(%armor == "larmor" || %armor == "lfemale") { %height = 2; %velocity = 70; %zVec = 70; } else if(%armor == "marmor" || %armor == "mfemale") { %height = 2; %velocity = 100; %zVec = 100; } else if(%armor == "harmor") { %height = 2; %velocity = 140; %zVec = 110; } %pos = GameBase::getPosition(%passenger); %posX = getWord(%pos,0); %posY = getWord(%pos,1); %posZ = getWord(%pos,2); if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) { %client = Player::getClient(%passenger); %this.Seat[%passenger.vehicleSlot-2] = ""; %passenger.vehicleSlot = ""; %passenger.vehicle= ""; Player::setMountObject(%passenger, -1, 0); %rotZ = getWord(GameBase::getRotation(%passenger),2); GameBase::setRotation(%passenger, "0 0 " @ %rotZ); GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)); %jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec); Player::applyImpulse(%passenger,%jumpDir); } else Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav"); }

 function Vehicle::jump(%this,%mom) { Vehicle::dismount(%this,%mom); }

 function Vehicle::dismount(%this,%mom) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %pl = Client::getOwnedObject(%cl); if(getObjectType(%pl) == "Player") { if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) { %pl.lastMount = %this; %pl.newMountTime = getSimTime() + 3.0; Player::setMountObject(%pl, %this, 0); Player::setMountObject(%pl, -1, 0); %rot = GameBase::getRotation(%this); %rotZ = getWord(%rot,2); GameBase::setRotation(%pl, "0 0 " @ %rotZ); Player::applyImpulse(%pl,%mom); Client::setControlObject(%cl, %pl); playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this)); if(%pl.lastWeapon != "") { Player::useItem(%pl,%pl.lastWeapon); %pl.lastWeapon = ""; } %pl.driver = ""; %pl.vehicle = ""; GameBase::virtual(%this,"onDismount",%this,%object); } else Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav"); } } }

 function Vehicle::onDestroyed (%this,%mom) { $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--; %cl = GameBase::getControlClient(%this); %pl = Client::getOwnedObject(%cl); if(%pl != -1) { Player::setMountObject(%pl, -1, 0); Client::setControlObject(%cl, %pl); if(%pl.lastWeapon != "") { Player::useItem(%pl,%pl.lastWeapon); %pl.lastWeapon = ""; } %pl.driver = ""; %pl.vehicle= ""; GameBase::virtual(%this,"onDismount",%this,%object); } for(%i = 0 ; %i < 4 ; %i++) if(%this.Seat[%i] != "") { %pl = Client::getOwnedObject(%this.Seat[%i]); Player::setMountObject(%pl, -1, 0); Client::setControlObject(%this.Seat[%i], %pl); %pl.vehicleSlot = ""; %pl.vehicle= ""; } calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); }

 function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { %value *= $damageScale[GameBase::getDataName(%this), %type]; StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); }

 function Vehicle::getHeatFactor(%this) { return 1.0; }
