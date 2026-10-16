$VehicleInvList[MiniVehicle] = 1;
$DataBlockName[MiniVehicle] = Mini;
$VehicleToItem[Mini] = MiniVehicle;
$VehicleSlots[Mini] = 0;

$TeamItemMax[MiniVehicle] = 3;

$DamageScale[Mini, $ImpactDamageType] = 1.0;
$DamageScale[Mini, $BulletDamageType] = 1.0;
$DamageScale[Mini, $PlasmaDamageType] = 1.0;
$DamageScale[Mini, $EnergyDamageType] = 1.0;
$DamageScale[Mini, $ExplosionDamageType] = 1.0;
$DamageScale[Mini, $ShrapnelDamageType] = 1.0;
$DamageScale[Mini, $DebrisDamageType] = 1.0;
$DamageScale[Mini, $MissileDamageType] = 1.0;
$DamageScale[Mini, $LaserDamageType] = 0.5;
$DamageScale[Mini, $MortarDamageType] = 0.7;
$DamageScale[Mini, $BlasterDamageType] = 0.5;
$DamageScale[Mini, $ElectricityDamageType] = 1.0;
$DamageScale[Mini, $MineDamageType] = 1.0;
$DamageScale[Mini, $SniperDamageType] = 1.0;

function vehicleMini::Initialize()
{
  $TeamItemCount[0 @ MiniVehicle] = 0;
  $TeamItemCount[1 @ MiniVehicle] = 0;
  $TeamItemCount[2 @ MiniVehicle] = 0;
  $TeamItemCount[3 @ MiniVehicle] = 0;
  $TeamItemCount[4 @ MiniVehicle] = 0;
  $TeamItemCount[5 @ MiniVehicle] = 0;
  $TeamItemCount[6 @ MiniVehicle] = 0;
  $TeamItemCount[7 @ MiniVehicle] = 0;
}

GrenadeData MiniShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 1.0;
  damageType = $MortarDamageType;
  explosionRadius = 30.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 375;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "PlasmaTrail.dts";
};

ItemData MiniVehicle 
{
  description = "Mini B-2 Bomber";
  className = "Vehicle";
  heading = $InvHead[ihVeh];
  price = 675;
};

FlierData Mini 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "flyer";
  shieldShapeName = "shield_large";
  mass = 9.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.5;
  maxPitch = 0.5;
  maxSpeed = 50;
  minSpeed = -2;
  lift = 0.5;
  maxAlt = 10;
  maxVertical = 9;
  maxDamage = 1.5;
  damageLevel = {1.0, 1.0};
  destroyDamage = 1.0;
  maxEnergy = 100;
  accel = 1.5;
  groundDamageScale = 0.50;
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  projectileType = MiniShell;
  fireSound = SoundFireMortar;
  reloadDelay = 3.0;
  damageSound = SoundFlyerCrash;
  visibleToSensor = true;
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundFlyerActive;
  visibleDriver = true;
  driverPose = 22;
};

function Mini::onPilot(%this, %player)
{
  %client = Player::getClient(%player);
}

function Mini::onUnPilot(%this, %player)
{
  //
}

function Mini::onCollision (%this, %object) 
{
  %vehname = GameBase::getDataName(%this);
  if(GameBase::getDamageLevel(%this) < %vehname.maxDamage) 
  {
    if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") 
    {
      %armor = Player::getArmor(%object);
      %client = Player::getClient(%object);

       // Try to pilot the vehicle
      if (($VehicleUse[%armor, %vehname] & $CanPilot) && Vehicle::canMount(%this, %object))
      {
        %this.Pilot = %object;

         // Unmount the player's weapon as the pilot
        %weapon = Player::getMountedItem(%object,$WeaponSlot);
        if(%weapon != -1) 
        {
          %object.lastWeapon = %weapon;
          Player::unMountItem(%object,$WeaponSlot);
        }

        Player::setMountObject(%object, %this, 1);
        Client::setControlObject(%client, %this);
        playSound(%vehname.mountSound, GameBase::getPosition(%this));
        %object.driver= 1;
        %object.vehicle = %this;
        %this.clLastMount = %client;

//        eval(%vehname @ "::onPilot(" @ %this @ ", " @ %object @ ");");
        GameBase::virtual(%this, onPilot, %this, %object);
      }

       // Check if it is too small to ride
      else if ($VehicleSlots[%vehname] == 0)
        Client::sendMessage(Player::getClient(%object),0,"Cannot pilot this vehicle in your current armor class.~wError_Message.wav");

       // Try to ride the vehicle
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
        else
          Client::sendMessage(Player::getClient(%object),0,"No slot.  Dismount the vehicle to free it for takeoff.~wError_Message.wav");
      }
      else if (GameBase::getControlClient(%this) == -1) 
        Client::sendMessage(Player::getClient(%object),0,"Cannot pilot or ride this vehicle in your current armor class.~wError_Message.wav");
    }
  }
}