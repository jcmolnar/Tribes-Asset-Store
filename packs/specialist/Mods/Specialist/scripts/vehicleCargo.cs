$VehicleInvList[CargoVehicle] = 1;
$DataBlockName[CargoVehicle] = Cargo;
$VehicleToItem[Cargo] = CargoVehicle;

$TeamItemMax[CargoVehicle] = 2;

$CargoCapacity = 10; // number of items the cargo vehicle can carry

// don't forget to initialize team data to zero in item.cs

ItemData CargoVehicle
{
	description = "Cargo Vehicle";
	className = "Vehicle";
	heading = "aVehicle";
	price = 850;
};

FlierData Cargo
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 24.0;
	drag = 1.0;
   density = 1.2;
   maxBank = 0.15;
   maxPitch = 0.1;
   maxSpeed = 30;
   minSpeed = -10;
	lift = 0.45;
	maxAlt = 10;
	maxVertical = 4;
	maxDamage = 2.5;
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
	description = "Cargo Vehicle";
};

// ==================Cargo Cannons=====================
$DamageScale[Cargo, $ImpactDamageType] = 1.0;
$DamageScale[Cargo, $BulletDamageType] = 1.0;
$DamageScale[Cargo, $PlasmaDamageType] = 1.0;
$DamageScale[Cargo, $EnergyDamageType] = 1.0;
$DamageScale[Cargo, $ExplosionDamageType] = 1.0;
$DamageScale[Cargo, $ShrapnelDamageType] = 1.0;
$DamageScale[Cargo, $DebrisDamageType] = 1.0;
$DamageScale[Cargo, $MissileDamageType] = 1.0;
$DamageScale[Cargo, $LaserDamageType] = 1.0;
$DamageScale[Cargo, $MortarDamageType] = 1.0;
$DamageScale[Cargo, $BlasterDamageType] = 0.5;
$DamageScale[Cargo, $ElectricityDamageType] = 1.0;
$DamageScale[Cargo, $MineDamageType]        = 1.0;

$DamageScale[Cargo, $PoisonGasDamageType]        = 0.0;
$DamageScale[Cargo, $RadiationDamageType]        = 0.0;
$DamageScale[Cargo, $EMPDamageType]        = 1.0;
$DamageScale[Cargo, $NullDamageType]        = 0.0;
$DamageScale[Cargo, $FireDamageType]        = 0.8;
$DamageScale[Cargo, $AcidDamageType]        = 1.0;
$DamageScale[Cargo, $BlindDamageType]        = 1.0;
$DamageScale[Cargo, $SniperRifleDamageType]        = 1.0;
$DamageScale[Cargo, $ShotgunDamageType]        = 1.0;
$DamageScale[Cargo, $FlakDamageType]        = 1.3;
$DamageScale[Cargo, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Cargo, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Cargo, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Cargo, $RemoteBombDamageType]        = 1.0;

function Cargo::onAdd(%this)
{
	Vehicle::onAdd(%this);
	%this.shieldStrength = 0;
	$TotalCargo[%this] = 0;

	// init the vehicle to hold an inv station
	$CargoHold[%this @ $TotalCargo[%this]] = DeployableInvPack;

	// increment total cargo count
	$TotalCargo[%this] ++;

}

function Cargo::onCollision(%this, %object) {
	Vehicle::onCollision(%this, %object);

	%type = getObjectType(%object);

	// echo("Type: "@%type);

	// if the driver just boarded
	if (%type == "Player" && %object.driver == 1) {

		// display cargo list
		%client = Player::getClient(%object);
		%message = "Cargo: (push fire to drop cargo) \n";

		for (%i=0;  %i < $TotalCargo[%this];  %i++) {
			%message = %message @"     "@ $CargoHold[%this @ %i].description@ "\n";
		}

		// echo("Message: " @%message);

		bottomprint(%client, %message, 5);
	}

	// if the object is not a pack, weapon, ammo, beacon, etc., then return
	if (%type != "Item") return;

	%item = Item::getItemData(%object);
	// echo("Item: "@%item);

	// if cargo capacity is reached, return
	if ($TotalCargo[%this] >= $CargoCapacity) return;

	// add cargo to cargo table
	$CargoHold[%this @ $TotalCargo[%this]] = %item;

	// increment total cargo count
	$TotalCargo[%this] ++;

	// remove object
	deleteobject(%object);

	// play sound
	GameBase::playSound (%this, SoundFlyerMount, 0);
}

function Cargo::onFire (%this, %slot) {
	// Release the Hounds!!
	// or release all the loaded cargo
	// by RCabrera for the Specialist mod, 4/5/00

	// if no cargo, return
	if ($TotalCargo[%this] <= 0) return;

	// Get current position
	%pos = GameBase::getPosition(%this);
	// place it below the vehicle
	%pos = Vector::add(%pos, "0 0 -4");

	// for each cargo item
	for (%i=0;  %i < $TotalCargo[%this];  %i++) {
//		echo("%i = " @%i);
//		echo("Creating item: " @$CargoHold[%this @ %i]);

		// create new item of that type
		if ($CargoHold[%this @ %i] != "") {
			%obj = newObject("", "Item", $CargoHold[%this @ %i] , 1, false);
 		 	addToSet("MissionCleanup", %obj);

			// drop the item
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, "0 0 -15");

			// play the sound
			GameBase::playSound(%this, SoundFlyerDismount, 0);
		}

		// remove cargo from cargo table
		$CargoHold[%this @ %i] = "";
	}

	%client = GameBase::getControlClient(%this);
	Client::sendMessage(%client, 0, "Cargo dropped");

	// set total cargo count to zero
	$TotalCargo[%this] = 0;
}

function Cargo::dismount(%this, %mom) {
	Vehicle::dismount(%this, %mom);
}

function Cargo::passengerJump(%this,%passenger,%mom) {
	Vehicle::passengerJump(%this,%passenger,%mom);
}

function Cargo::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	// proceed as normal
	Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Cargo::onDestroyed (%this,%mom) {
	Vehicle::onDestroyed (%this,%mom);
}



