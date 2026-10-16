// Armored personnel carrier
// For the Specialist mod

$VehicleInvList[APCVehicle] = 1;
$DataBlockName[APCVehicle] = APC;
$VehicleToItem[APC] = APCVehicle;

$TeamItemMax[APCVehicle] = 2;

$APCShieldTime = 30; 	// number of seconds that the APC shields are activated
$APCShieldMinEnergy = 8;
$APCShieldStrengthFactor = 4; // strength of APC shields
$APCRechargeTime = 10;	// time to recharge shields

// don't forget to initialize team data to zero in item.cs

ItemData APCVehicle
{
	description = "APC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 800;
};

FlierData APC
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
   maxSpeed = 40;								   
   minSpeed = -15;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 3.0;
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
	description = "HPC";
};

// ==================APC Cannons=====================
$DamageScale[APC, $ImpactDamageType] = 1.0;
$DamageScale[APC, $BulletDamageType] = 1.0;
$DamageScale[APC, $PlasmaDamageType] = 1.0;
$DamageScale[APC, $EnergyDamageType] = 1.0;
$DamageScale[APC, $ExplosionDamageType] = 1.0;
$DamageScale[APC, $ShrapnelDamageType] = 1.0;
$DamageScale[APC, $DebrisDamageType] = 1.0;
$DamageScale[APC, $MissileDamageType] = 1.0;
$DamageScale[APC, $LaserDamageType] = 1.0;
$DamageScale[APC, $MortarDamageType] = 1.0;
$DamageScale[APC, $BlasterDamageType] = 0.5;
$DamageScale[APC, $ElectricityDamageType] = 1.0;
$DamageScale[APC, $MineDamageType]        = 1.0;

$DamageScale[APC, $PoisonGasDamageType]        = 0.0;
$DamageScale[APC, $RadiationDamageType]        = 0.0;
$DamageScale[APC, $EMPDamageType]        = 1.0;
$DamageScale[APC, $NullDamageType]        = 0.0;
$DamageScale[APC, $FireDamageType]        = 0.8;
$DamageScale[APC, $AcidDamageType]        = 1.0;
$DamageScale[APC, $BlindDamageType]        = 1.0;
$DamageScale[APC, $SniperRifleDamageType]        = 1.0;
$DamageScale[APC, $ShotgunDamageType]        = 1.0;
$DamageScale[APC, $FlakDamageType]        = 1.3;
$DamageScale[APC, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[APC, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[APC, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[APC, $RemoteBombDamageType]        = 1.0;

function APC::onAdd(%this)
{
	Vehicle::onAdd(%this);
	%this.shieldStrength = 0;
}

function APC::onCollision(%this, %object) {
	Vehicle::onCollision(%this, %object);

	// if this is the driver, we exit
	if (%object.driver == 1) return;

	// if sitting in the forward seat
	if (%object.vehicleSlot == 5) {

		// mount the APC Secondary Cannon
		Player::setItemCount(%object, TankCannon, 1);
		Player::mountItem(%object, TankCannon, $WeaponSlot);

		%client = Player::getClient(%object);
		bottomprint(%client, "  Controlling APC Field Cannon", 2);

	}
}

function APC::dismount(%this, %mom) {
	// remove cannon
	%cl = GameBase::getControlClient(%this);
	Player::setItemCount(%cl, TankCannon, 0);

	%player = Client::getOwnedObject(%cl);

	Vehicle::dismount(%this, %mom);
}

function APC::passengerJump(%this,%passenger,%mom) {
	// remove cannon
	Player::setItemCount(%passenger, TankCannon, 0);

	Vehicle::passengerJump(%this,%passenger,%mom);
}

function APC::onFire(%this, %slot) {
	// This function is called when the driver pushes the fire button.
	// It activates the APCs shields for a few seconds.
	// By RCabrera for the Specialist mod, 3/31/00

	if ($TankShieldActivated[%this] != true && $TankRecharging[%this] != true) {

		// activate APC shields
		$TankShieldActivated[%this] = true;

		// activate shields for driver of APC
		%client = GameBase::getControlClient(%this);
		%player = Client::getOwnedObject(%client);
		if(%player != -1) {
			Client::sendMessage(%client, 0, "APC Shields Active");
		}

		// activate shields for players in APC
		for (%i = 0; %i < 4; %i++) {
			if (%this.Seat[%i] != "") {
				%client = %this.Seat[%i];
				%player = Client::getOwnedObject(%client);
				Client::sendMessage(%client, 0, "APC Shields Active");
			}
		}

		// play sound
		GameBase::playSound(%player, ForceFieldOpen, 0);

		schedule("APC::deactivateShields("@%this@");", $APCShieldTime);
	}
}

function APC::deactivateShields(%this) {
	$TankShieldActivated[%this] = "";

	// deactivate shields for driver of APC
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if(%player != -1) {
		Client::sendMessage(%client, 0, "APC Shields Recharging");
	}

	// deactivate shields for players in APC
	for (%i = 0; %i < 4; %i++) {
		if (%this.Seat[%i] != "") {
			%client = %this.Seat[%i];
			%player = Client::getOwnedObject(%client);
			Client::sendMessage(%client, 0, "APC Shields Recharging");
		}
	}

	GameBase::playSound(%player, ForceFieldOpen, 0);
	APC::RechargeStart(%this);
}

function APC::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if (%type == $EMPDamageType) {
		GameBase::setEnergy(%this, 0);
	}

	if ($TankShieldActivated[%this] == true) {

		if (%type == $EMPDamageType) {
			// knock out the shields
			APC::deactivateShields(%this);
			return;
		}

		// Absorb some of the damage
		%energy = GameBase::getEnergy(%this);

		// If the shield fully absorbs the damage (documentation by RCabrera)
		if (%energy > ($APCShieldMinEnergy)) {

			GameBase::setEnergy(%this, %energy - (%value * 100)/$APCShieldStrengthFactor);
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

function APC::onDestroyed (%this,%mom) {
	APC::deactivateShields(%this);
	$TankRecharging[%this] = "";
	Vehicle::onDestroyed (%this,%mom);
}

function APC::onRemove (%this) {
	$TankShieldActivated[%this] = "";
	$TankRecharging[%this] = "";
}

function APC::RechargeComplete(%this) {
	$TankRecharging[%this] = "";
}

function APC::RechargeStart(%this) {
	$TankRecharging[%this] = true;
	schedule("APC::RechargeComplete("@%this@");", $APCRechargeTime);
}

function APC::onPassengerDamage(%this, %value) {
	// called when passenger takes damage while shielded
	// By RCabrera for the Specialist mod, 6/26/00

	%energy = GameBase::getEnergy(%this);

	// If the shield fully absorbs the damage (documentation by RCabrera)
	if (%energy > ($APCShieldMinEnergy)) {

		GameBase::setEnergy(%this, %energy - (%value * 25)/$APCShieldStrengthFactor);
		%value = 0;
	}
	// If the shield doesn't fully absorb the damage (documentation by RCabrera)
	else {
		GameBase::setEnergy(%this,0);
		%value = %value - (%energy/100);
	}

	return %value;
}