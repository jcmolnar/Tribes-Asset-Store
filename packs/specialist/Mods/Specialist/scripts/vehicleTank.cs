$VehicleInvList[TankVehicle] = 1;
$DataBlockName[TankVehicle] = Tank;
$VehicleToItem[Tank] = TankVehicle;

$TeamItemMax[TankVehicle] = 1;

$TankShieldTime = 30; // number of seconds that the tank shields are activated
$TankShieldMinEnergy = 18; 		// minimum shield energy
$TankShieldStrengthFactor = 5;	// strength of tank shields
$TankRechargeTime = 15;

// don't forget to initialize team data to zero in item.cs

ItemData TankVehicle
{
	description = "Tank";
	className = "Vehicle";
	heading = "aVehicle";
	price = 1800;
};

FlierData Tank
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	shieldStrength = 0.5;
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.2;
	maxPitch = 0.15;
	maxSpeed = 35;								   
	minSpeed = -20;
	lift = 0.4;
	maxAlt = 10;
	maxVertical = 4;
	maxDamage = 5.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.0;

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
	description = "Tank";
};

// ==================Tank Cannons=====================
// Who can use this weapon
$ItemMax[reconarmor, TankArtilleryShell] = 1;
$ItemMax[reconfemalearmor, TankArtilleryShell] = 1;
$ItemMax[espionagearmor, TankArtilleryShell] = 1;
$ItemMax[espionagefemalearmor, TankArtilleryShell] = 1;
$ItemMax[engineerarmor, TankArtilleryShell] = 1;
$ItemMax[engineerfemalearmor, TankArtilleryShell] = 1;
$ItemMax[infantryarmor, TankArtilleryShell] = 1;
$ItemMax[infantryfemalearmor, TankArtilleryShell] = 1;
$ItemMax[falloutarmor, TankArtilleryShell] = 1;
$ItemMax[falloutfemalearmor, TankArtilleryShell] = 1;
$ItemMax[demolitionsarmor, TankArtilleryShell] = 1;
$ItemMax[assaultarmor, TankArtilleryShell] = 1;
$ItemMax[artilleryarmor, TankArtilleryShell] = 1;
$ItemMax[commanderarmor, TankArtilleryShell] = 1;

ItemImageData TankArtilleryShellImage 
{
	shapeFile = "mortar_turret";
	mountPoint = 0;
	mountOffset = { 0, 0.0, 0.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;

	weaponType = 0; // Single Shot
	reloadTime = 3.0;
	fireTime = 2.0;

	minEnergy = 40;
	maxEnergy = 40;

	// ammoType = ArtilleryShellAmmo;
	projectileType = MortarTurretShell;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 1;
	lightColor = { 1.0, 1.0, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData TankArtilleryShell 
{
	description = "Tank Artillery Cannon";
	className = "Weapon";
	shapeFile = "mortar_turret";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TankArtilleryShellImage;
	price = 375;
	showWeaponBar = true;
};

// Who can use this weapon
$ItemMax[reconarmor, TankCannon] = 1;
$ItemMax[reconfemalearmor, TankCannon] = 1;
$ItemMax[espionagearmor, TankCannon] = 1;
$ItemMax[espionagefemalearmor, TankCannon] = 1;
$ItemMax[engineerarmor, TankCannon] = 1;
$ItemMax[engineerfemalearmor, TankCannon] = 1;
$ItemMax[infantryarmor, TankCannon] = 1;
$ItemMax[infantryfemalearmor, TankCannon] = 1;
$ItemMax[falloutarmor, TankCannon] = 1;
$ItemMax[falloutfemalearmor, TankCannon] = 1;
$ItemMax[demolitionsarmor, TankCannon] = 1;
$ItemMax[assaultarmor, TankCannon] = 1;
$ItemMax[artilleryarmor, TankCannon] = 1;
$ItemMax[commanderarmor, TankCannon] = 1;

BulletData TankChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 625.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 50;
};

ItemImageData TankCannonImage 
{
	shapeFile = "chainturret";
	mountPoint = 0;
	mountOffset = { -0.3, 0.5, 0.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.1;

	minEnergy = 1;
	maxEnergy = 2;

	// ammoType = ArtilleryShellAmmo;
	projectileType = TankChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1.0, 1.0 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TankCannon
{
	description = "Tank Secondary Cannon";
	className = "Weapon";
	shapeFile = "chainturret";
	hudIcon = "chain";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TankCannonImage;
	price = 375;
	showWeaponBar = true;
};

$DamageScale[Tank, $ImpactDamageType] = 1.0;
$DamageScale[Tank, $BulletDamageType] = 1.0;
$DamageScale[Tank, $PlasmaDamageType] = 1.0;
$DamageScale[Tank, $EnergyDamageType] = 1.0;
$DamageScale[Tank, $ExplosionDamageType] = 1.0;
$DamageScale[Tank, $ShrapnelDamageType] = 1.0;
$DamageScale[Tank, $DebrisDamageType] = 1.0;
$DamageScale[Tank, $MissileDamageType] = 1.0;
$DamageScale[Tank, $LaserDamageType] = 1.0;
$DamageScale[Tank, $MortarDamageType] = 1.0;
$DamageScale[Tank, $BlasterDamageType] = 0.5;
$DamageScale[Tank, $ElectricityDamageType] = 1.0;
$DamageScale[Tank, $MineDamageType]        = 1.0;

$DamageScale[Tank, $PoisonGasDamageType]        = 0.0;
$DamageScale[Tank, $RadiationDamageType]        = 0.0;
$DamageScale[Tank, $EMPDamageType]        = 1.0;
$DamageScale[Tank, $NullDamageType]        = 0.0;
$DamageScale[Tank, $FireDamageType]        = 0.8;
$DamageScale[Tank, $AcidDamageType]        = 1.0;
$DamageScale[Tank, $BlindDamageType]        = 1.0;
$DamageScale[Tank, $SniperRifleDamageType]        = 1.0;
$DamageScale[Tank, $ShotgunDamageType]        = 1.0;
$DamageScale[Tank, $FlakDamageType]        = 1.3;
$DamageScale[Tank, $ExplosiveGatDamageType]        = 1.0;
$DamageScale[Tank, $ArtilleryShellDamageType]        = 1.0;
$DamageScale[Tank, $TimedExplosiveDamageType]        = 1.0;
$DamageScale[Tank, $RemoteBombDamageType]        = 1.0;

function Tank::onAdd(%this)
{
	Vehicle::onAdd(%this);
	%this.shieldStrength = 0;
}

function Tank::onCollision(%this, %object) {
	Vehicle::onCollision(%this, %object);

	// if this is the driver, we exit
	if (%object.driver == 1) return;

	// if sitting in a forward seat
	if (%object.vehicleSlot == 4 || %object.vehicleSlot == 5) {
		// echo("Forward position");

		// mount the Tank Secondary Cannon
		Player::setItemCount(%object, TankCannon, 1);
		Player::mountItem(%object, TankCannon, $WeaponSlot);

		%client = Player::getClient(%object);
		bottomprint(%client, "  Controlling Tank Field Cannon", 2);

	}

	// if sitting in a rear seat
	if (%object.vehicleSlot == 2 || %object.vehicleSlot == 3) {
		// echo("Rear position");

		// mount the Tank Artillery Cannon
		Player::setItemCount(%object, TankArtilleryShell, 1);
		Player::mountItem(%object, TankArtilleryShell, $WeaponSlot);

		%client = Player::getClient(%object);
		bottomprint(%client, "  Controlling Tank Artillery Cannon", 2);

	}

}

function Tank::dismount(%this, %mom) {
	// remove cannon
	%cl = GameBase::getControlClient(%this);
	Player::setItemCount(%cl, TankArtilleryShell, 0);
	Player::setItemCount(%cl, TankCannon, 0);

	%player = Client::getOwnedObject(%cl);

	Vehicle::dismount(%this, %mom);
}

function Tank::passengerJump(%this,%passenger,%mom) {
	// remove cannon
	Player::setItemCount(%passenger, TankArtilleryShell, 0);
	Player::setItemCount(%passenger, TankCannon, 0);

	Vehicle::passengerJump(%this,%passenger,%mom);
}

function Tank::onFire(%this, %slot) {
	// This function is called when the driver pushes the fire button.
	// It activates the tanks shields for a few seconds.
	// By RCabrera for the Specialist mod, 3/31/00

	if ($TankShieldActivated[%this] != true && $TankRecharging[%this] != true) {

		// activate tank shields
		$TankShieldActivated[%this] = true;

		// activate shields for driver of tank
		%client = GameBase::getControlClient(%this);
		%player = Client::getOwnedObject(%client);
		if(%player != -1) {
			Client::sendMessage(%client, 0, "Tank Shields Active");
		}

		// activate shields for players in tank
		for (%i = 0; %i < 4; %i++) {
			if (%this.Seat[%i] != "") {
				%client = %this.Seat[%i];
				%player = Client::getOwnedObject(%client);
				// echo("Client: "@%client@"  Player: "@%player);
				Client::sendMessage(%client, 0, "Tank Shields Active");
			}
		}

		// play sound
		GameBase::playSound(%player, ForceFieldOpen, 0);

		schedule("Tank::deactivateShields("@%this@");", $TankShieldTime);
	}
}

function Tank::deactivateShields(%this) {
	$TankShieldActivated[%this] = "";

	// deactivate shields for driver of tank
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if(%player != -1) {
		Client::sendMessage(%client, 0, "Tank Shields Recharging");
	}

	// deactivate shields for players in tank
	for (%i = 0; %i < 4; %i++) {
		if (%this.Seat[%i] != "") {
			%client = %this.Seat[%i];
			%player = Client::getOwnedObject(%client);
			Client::sendMessage(%client, 0, "Tank Shields Recharging");
		}
	}

	GameBase::playSound(%player, ForceFieldOpen, 0);
	Tank::RechargeStart(%this);
}

function Tank::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if (%type == $EMPDamageType) {
		GameBase::setEnergy(%this, 0);
	}

	if ($TankShieldActivated[%this] == true) {

		if (%type == $EMPDamageType) {
			// knock out the shields
			Tank::deactivateShields(%this);
			return;
		}

		// Absorb some of the damage
		%energy = GameBase::getEnergy(%this);

		// If the shield fully absorbs the damage (documentation by RCabrera)
		if (%energy > ($TankShieldMinEnergy)) {

			GameBase::setEnergy(%this, %energy - (%value * 100)/$TankShieldStrengthFactor);
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

function Tank::onDestroyed (%this,%mom) {
	Tank::deactivateShields(%this);
	$TankRecharging[%this] = "";
	Vehicle::onDestroyed (%this,%mom);
}

function Tank::onRemove (%this) {
	$TankShieldActivated[%this] = "";
	$TankRecharging[%this] = "";
}

function Tank::RechargeComplete(%this) {
	$TankRecharging[%this] = "";
}

function Tank::RechargeStart(%this) {
	$TankRecharging[%this] = true;
	schedule("Tank::RechargeComplete("@%this@");", $TankRechargeTime);
}

function Tank::onPassengerDamage(%this, %value) {
	// called when passenger takes damage while shielded
	// By RCabrera for the Specialist mod, 6/26/00

	%energy = GameBase::getEnergy(%this);

	// If the shield fully absorbs the damage (documentation by RCabrera)
	if (%energy > ($TankShieldMinEnergy)) {

		GameBase::setEnergy(%this, %energy - (%value * 25) / $TankShieldStrengthFactor);
		%value = 0;
	}
	// If the shield doesn't fully absorb the damage (documentation by RCabrera)
	else {
		GameBase::setEnergy(%this,0);
		%value = %value - (%energy/100);
	}

	return %value;
}