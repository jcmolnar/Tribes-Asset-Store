$VehicleInvList[SupplyVehicle] = 1;
$DataBlockName[SupplyVehicle] = Supply;
$VehicleToItem[Supply] = SupplyVehicle;

$TeamItemMax[SupplyVehicle] = 2;

// don't forget to initialize team data to zero in item.cs

ItemData SupplyVehicle
{
	description = "Supply Vehicle";
	className = "Vehicle";
	heading = "aVehicle";
	price = 850;
};

FlierData Supply
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	 shapeFile = "hover_apc_sml";
	 shieldShapeName = "shield_large";
	 mass = 24.0;
	 drag = 1.0;
	 density = 1.2;
	 maxBank = 0.25;
   maxPitch = 0.2;
   maxSpeed = 40;
   minSpeed = -10;
	lift = 0.4;
	maxAlt = 13;
	maxVertical = 4;
	maxDamage = 2.0;
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
	description = "Supply Vehicle";
};

// ==================Supply Cannons=====================
$DamageScale[Supply, $ImpactDamageType] = 1.0;
$DamageScale[Supply, $BulletDamageType] = 1.0;
$DamageScale[Supply, $PlasmaDamageType] = 1.0;
$DamageScale[Supply, $EnergyDamageType] = 1.0;
$DamageScale[Supply, $ExplosionDamageType] = 1.0;
$DamageScale[Supply, $ShrapnelDamageType] = 1.0;
$DamageScale[Supply, $DebrisDamageType] = 1.0;
$DamageScale[Supply, $MissileDamageType] = 1.0;
$DamageScale[Supply, $LaserDamageType] = 1.0;
$DamageScale[Supply, $MortarDamageType] = 1.0;
$DamageScale[Supply, $BlasterDamageType] = 0.5;
$DamageScale[Supply, $ElectricityDamageType] = 1.0;
$DamageScale[Supply, $MineDamageType]        = 1.0;

$DamageScale[Supply, $PoisonGasDamageType]        = 0.0;
$DamageScale[Supply, $RadiationDamageType]        = 0.0;
$DamageScale[Supply, $EMPDamageType]        = 1.0;
$DamageScale[Supply, $NullDamageType]        = 0.0;
$DamageScale[Supply, $FireDamageType]        = 0.8;
$DamageScale[Supply, $AcidDamageType]        = 1.0;
$DamageScale[Supply, $BlindDamageType]        = 1.0;
$DamageScale[Supply, $SniperRifleDamageType]        = 1.0;
$DamageScale[Supply, $ShotgunDamageType]        = 1.0;
$DamageScale[Supply, $FlakDamageType]        = 1.3;
$DamageScale[Supply, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Supply, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Supply, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Supply, $RemoteBombDamageType]        = 1.0;

function Supply::onAdd(%this)
{
	Vehicle::onAdd(%this);
	%this.shieldStrength = 0;
}

function Supply::onCollision(%this, %object) {
	Vehicle::onCollision(%this, %object);

	// if this is the driver, we exit
	// if (%object.driver == 1) return;

	// if sitting in either forward seat or driver
	if (%object.driver == 1 || %object.vehicleSlot == 2 || %object.vehicleSlot == 3) {

		// resupply the player
		if (%object != -1) {
			$SupplyEnterTime[%this] = getSimTime();
			Supply::resupply(%this, %object);
		}

	}
}

function Supply::resupply(%this, %player) {
	// if still in the vehicle
	if (%player.Vehicle == %this) {

			// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - $SupplyEnterTime[%this] > 11)
				%cnt = 0;
			if (%cnt != 0) {
				%player.waitThrowTime = getSimTime();
				schedule("Supply::resupply(" @ %this @ ", "@%player@");",0.5,%this);
				return;
			}
			%player.Station = "";
			%client = Player::getClient(%player);
			%this.target = "";
			Client::sendMessage(%client,0,"Resupply Complete");


	}	
}

function Supply::dismount(%this, %mom) {
	Vehicle::dismount(%this, %mom);
}

function Supply::passengerJump(%this,%passenger,%mom) {
	Vehicle::passengerJump(%this,%passenger,%mom);
}

function Supply::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	// proceed as normal
	Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Supply::onDestroyed (%this,%mom) {
	Vehicle::onDestroyed (%this,%mom);
}

function Supply::onRemove (%this) {
}

