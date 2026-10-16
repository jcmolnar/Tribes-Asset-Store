$VehicleInvList[OutriderVehicle] = 1;
$DataBlockName[OutriderVehicle] = Outrider;
$VehicleToItem[Outrider] = OutriderVehicle;

$TeamItemMax[OutriderVehicle] = 1;

$OutriderShieldTime = 20; // number of seconds that the Outrider shields are activated
$OutriderShieldMinEnergy = 8;
$OutriderShieldStrengthFactor = 4; // strength of Outrider shields
$OutriderRechargeTime = 10;

// don't forget to initialize team data to zero in item.cs

ItemData OutriderVehicle
{
	description = "Outrider";
	className = "Vehicle";
	heading = "aVehicle";
	price = 700;
};

FlierData Outrider
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
   maxSpeed = 50;
   minSpeed = -20;
	lift = 0.6;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 60;
	accel = 0.32;

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
	description = "Outrider";
};

// ==================Outrider Cannons=====================
$DamageScale[Outrider, $ImpactDamageType] = 1.0;
$DamageScale[Outrider, $BulletDamageType] = 1.0;
$DamageScale[Outrider, $PlasmaDamageType] = 1.0;
$DamageScale[Outrider, $EnergyDamageType] = 1.0;
$DamageScale[Outrider, $ExplosionDamageType] = 1.0;
$DamageScale[Outrider, $ShrapnelDamageType] = 1.0;
$DamageScale[Outrider, $DebrisDamageType] = 1.0;
$DamageScale[Outrider, $MissileDamageType] = 1.0;
$DamageScale[Outrider, $LaserDamageType] = 1.0;
$DamageScale[Outrider, $MortarDamageType] = 1.0;
$DamageScale[Outrider, $BlasterDamageType] = 0.5;
$DamageScale[Outrider, $ElectricityDamageType] = 1.0;
$DamageScale[Outrider, $MineDamageType]        = 1.0;

$DamageScale[Outrider, $PoisonGasDamageType]        = 0.0;
$DamageScale[Outrider, $RadiationDamageType]        = 0.0;
$DamageScale[Outrider, $EMPDamageType]        = 1.0;
$DamageScale[Outrider, $NullDamageType]        = 0.0;
$DamageScale[Outrider, $FireDamageType]        = 0.8;
$DamageScale[Outrider, $AcidDamageType]        = 1.0;
$DamageScale[Outrider, $BlindDamageType]        = 1.0;
$DamageScale[Outrider, $SniperRifleDamageType]        = 1.0;
$DamageScale[Outrider, $ShotgunDamageType]        = 1.0;
$DamageScale[Outrider, $FlakDamageType]        = 1.3;
$DamageScale[Outrider, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Outrider, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Outrider, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Outrider, $RemoteBombDamageType]        = 1.0;

function Outrider::onAdd(%this)
{
	Vehicle::onAdd(%this);
	%this.shieldStrength = 0;
}

function Outrider::onCollision(%this, %object) {
	Vehicle::onCollision(%this, %object);

	// if this is the driver, we exit
	if (%object.driver == 1) return;

	// if sitting in either forward seat
	if (%object.vehicleSlot == 2 || %object.vehicleSlot == 3) {

		// mount the Outrider Secondary Cannon
		Player::setItemCount(%object, TankCannon, 1);
		Player::mountItem(%object, TankCannon, $WeaponSlot);

		%client = Player::getClient(%object);
		bottomprint(%client, "  Controlling Outrider Field Cannon", 2);

	}
}

function Outrider::dismount(%this, %mom) {
	// remove cannon
	%cl = GameBase::getControlClient(%this);
	Player::setItemCount(%cl, TankCannon, 0);

	%player = Client::getOwnedObject(%cl);

	Vehicle::dismount(%this, %mom);
}

function Outrider::passengerJump(%this,%passenger,%mom) {
	// remove cannon
	Player::setItemCount(%passenger, TankCannon, 0);

	Vehicle::passengerJump(%this,%passenger,%mom);
}

function Outrider::onFire(%this, %slot) {
	// This function is called when the driver pushes the fire button.
	// It activates the Outriders shields for a few seconds.
	// By RCabrera for the Specialist mod, 3/31/00

	if ($TankShieldActivated[%this] != true && $TankRecharging[%this] != true) {

		// activate Outrider shields
		$TankShieldActivated[%this] = true;

		// activate shields for driver of Outrider
		%client = GameBase::getControlClient(%this);
		%player = Client::getOwnedObject(%client);
		if(%player != -1) {
			Client::sendMessage(%client, 0, "Outrider Shields Active");
		}

		// activate shields for players in Outrider
		for (%i = 0; %i < 4; %i++) {
			if (%this.Seat[%i] != "") {
				%client = %this.Seat[%i];
				%player = Client::getOwnedObject(%client);
				Client::sendMessage(%client, 0, "Outrider Shields Active");
			}
		}

		// play sound
		GameBase::playSound(%player, ForceFieldOpen, 0);

		schedule("Outrider::deactivateShields("@%this@");", $OutriderShieldTime);
	}
}

function Outrider::deactivateShields(%this) {
	$TankShieldActivated[%this] = "";

	// deactivate shields for driver of Outrider
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if(%player != -1) {
		Client::sendMessage(%client, 0, "Outrider Shields Recharging");
	}

	// deactivate shields for players in Outrider
	for (%i = 0; %i < 4; %i++) {
		if (%this.Seat[%i] != "") {
			%client = %this.Seat[%i];
			%player = Client::getOwnedObject(%client);
			Client::sendMessage(%client, 0, "Outrider Shields Recharging");
		}
	}

	GameBase::playSound(%player, ForceFieldOpen, 0);
	Outrider::RechargeStart(%this);
}

function Outrider::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if (%type == $EMPDamageType) {
		GameBase::setEnergy(%this, 0);
	}

	if ($TankShieldActivated[%this] == true) {

		if (%type == $EMPDamageType) {
			// knock out the shields
			Outrider::deactivateShields(%this);
			return;
		}

		// Absorb some of the damage
		%energy = GameBase::getEnergy(%this);

		// If the shield fully absorbs the damage (documentation by RCabrera)
		if (%energy > ($OutriderShieldMinEnergy)) {

			GameBase::setEnergy(%this, %energy - (%value * 100)/$OutriderShieldStrengthFactor);
			%value = 0;

			// Calculate a position around the object where the projectile hit
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);
	
			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;

			// Display the shield effect in the proper position
			GameBase::activateShield(%this, %sphereVec, %zOffset);
		}
		// If the shield doesn't fully absorb the damage (documentation by RCabrera)
		else {
			GameBase::setEnergy(%this,0);
			%value = %value - (%energy/100);
		}

	}

	// proceed as normal
	Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Outrider::onDestroyed (%this,%mom) {
	Outrider::deactivateShields(%this);
	$TankRecharging[%this] = "";
	Vehicle::onDestroyed (%this,%mom);
}

function Outrider::onRemove (%this) {
	$TankShieldActivated[%this] = "";
	$TankRecharging[%this] = "";
}

function Outrider::RechargeComplete(%this) {
	$TankRecharging[%this] = "";
}

function Outrider::RechargeStart(%this) {
	$TankRecharging[%this] = true;
	schedule("Outrider::RechargeComplete("@%this@");", $OutriderRechargeTime);
}

function Outrider::onPassengerDamage(%this, %value) {
	// called when passenger takes damage while shielded
	// By RCabrera for the Specialist mod, 6/26/00

	%energy = GameBase::getEnergy(%this);

	// If the shield fully absorbs the damage (documentation by RCabrera)
	if (%energy > ($OutriderShieldMinEnergy)) {

		GameBase::setEnergy(%this, %energy - (%value * 25)/$OutriderShieldStrengthFactor);
		%value = 0;
	}
	// If the shield doesn't fully absorb the damage (documentation by RCabrera)
	else {
		GameBase::setEnergy(%this,0);
		%value = %value - (%energy/100);
	}

	return %value;
}