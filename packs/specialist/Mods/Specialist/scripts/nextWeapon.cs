// This file defines the nextWeapon and previousWeapon tables, 
// AND has some miscellaneous weapon functions.

// -----------------------------------
// Original weapons
// -----------------------------------
// $NextWeapon[EnergyRifle] = Blaster;
// $NextWeapon[Blaster] = PlasmaGun;
// $NextWeapon[PlasmaGun] = Chaingun;
// $NextWeapon[Chaingun] = DiscLauncher;
// $NextWeapon[DiscLauncher] = GrenadeLauncher;
// $NextWeapon[GrenadeLauncher] = Mortar;
// $NextWeapon[Mortar] = LaserRifle;
//$NextWeapon[LaserRifle] = EnergyRifle;

// -----------------------------------
// Specialist weapons
// -----------------------------------
// $NextWeapon[LaserRifle] = GasCanister;
// $NextWeapon[GasCanister] = RadiationCanister;
// $NextWeapon[RadiationCanister] = SniperRifle;
// // $NextWeapon[SniperRifle] = ExplosiveGat;
// $NextWeapon[ExplosiveGat] = FlakCannon;
// // $NextWeapon[FlakCannon] = ArtilleryShell;
// $NextWeapon[ArtilleryShell] = Shotgun;
// $NextWeapon[Shotgun] = EMPCannon;
// $NextWeapon[EMPCannon] = Flamethrower;
// $NextWeapon[Flamethrower] = AcidSprayer;
// $NextWeapon[AcidSprayer] = EngRepairGun;
// $NextWeapon[EngRepairGun] = RemoteDetonator;
// $NextWeapon[RemoteDetonator] = LaserPistol;
// $NextWeapon[LaserPistol] = AntiPersonnelCannon;
// $NextWeapon[AntiPersonnelCannon] = TankCannon;
// $NextWeapon[TankCannon] = TankArtilleryShell;
// $NextWeapon[TankArtilleryShell] = AcidCanister;
// $NextWeapon[AcidCanister] = RocketLauncher;
// $NextWeapon[RocketLauncher] = EnergyRifle;

// Redone in alphabetical ordering
$NextWeapon[AcidCanister] = AcidSprayer;
$NextWeapon[AcidSprayer] = AntiPersonnelCannon;
$NextWeapon[AntiPersonnelCannon] = ArtilleryShell;
$NextWeapon[ArtilleryShell] = Blaster;
$NextWeapon[Blaster] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = EMPCannon;
$NextWeapon[EMPCannon] = EnergyRifle;
$NextWeapon[EnergyRifle] = EngRepairGun;
$NextWeapon[EngRepairGun] = ExplosiveGat;
$NextWeapon[ExplosiveGat] = FieldMortar;
$NextWeapon[FieldMortar] = FlakCannon;
$NextWeapon[FlakCannon] = Flamethrower;
$NextWeapon[Flamethrower] = GasCanister;
$NextWeapon[GasCanister] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = LaserPistol;
$NextWeapon[LaserPistol] = LaserRifle;
$NextWeapon[LaserRifle] = Mortar;
$NextWeapon[Mortar] = PlasmaGun;
$NextWeapon[PlasmaGun] = RadiationCanister;
$NextWeapon[RadiationCanister] = RemoteDetonator;
$NextWeapon[RemoteDetonator] = RocketLauncher;
$NextWeapon[RocketLauncher] = Shotgun;
$NextWeapon[Shotgun] = SniperRifle;
$NextWeapon[SniperRifle] = TankArtilleryShell;
$NextWeapon[TankArtilleryShell] = TankCannon;
$NextWeapon[TankCannon] = AcidCanister;


// ----------------------------------
// Original weapons
// ----------------------------------
// $PrevWeapon[Blaster] = EnergyRifle;
// $PrevWeapon[PlasmaGun] = Blaster;
// $PrevWeapon[Chaingun] = PlasmaGun;
// $PrevWeapon[DiscLauncher] = Chaingun;
// $PrevWeapon[GrenadeLauncher] = DiscLauncher;
// $PrevWeapon[Mortar] = GrenadeLauncher;
// $PrevWeapon[LaserRifle] = Mortar;
// $PrevWeapon[EnergyRifle] = LaserRifle;

// ----------------------------------
// Specialist weapons
// ----------------------------------
// $PrevWeapon[GasCanister] = LaserRifle;
// $PrevWeapon[RadiationCanister] = GasCanister;
// $PrevWeapon[SniperRifle] = RadiationCanister;
// $PrevWeapon[ExplosiveGat] = SniperRifle;
// $PrevWeapon[FlakCannon] = ExplosiveGat;
// // $PrevWeapon[ArtilleryShell] = FlakCannon;
// $PrevWeapon[Shotgun] = ArtilleryShell;
// $PrevWeapon[EMPCannon] = Shotgun;
// $PrevWeapon[Flamethrower] = EMPCannon;
// $PrevWeapon[AcidSprayer] = Flamethrower;
// $PrevWeapon[EngRepairGun] = AcidSprayer;
// $PrevWeapon[RemoteDetonator] = EngRepairGun;
// $PrevWeapon[LaserPistol] = RemoteDetonator;
// $PrevWeapon[AntiPersonnelCannon] = LaserPistol;
// $PrevWeapon[TankArtilleryShell] = AntiPersonnelCannon;
// $PrevWeapon[TankCannon] = TankArtilleryShell;
// $PrevWeapon[AcidCanister] = TankCannon;
// $PrevWeapon[RocketLauncher] = AcidCanister;
// $PrevWeapon[EnergyRifle] = RocketLauncher;

// Redone in alphabetical ordering
$PrevWeapon[AcidSprayer] = AcidCanister;
$PrevWeapon[AntiPersonnelCannon] = AcidSprayer;
$PrevWeapon[ArtilleryShell] = AntiPersonnelCannon;
$PrevWeapon[Blaster] = ArtilleryShell;
$PrevWeapon[Chaingun] = Blaster;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[EMPCannon] = DiscLauncher;
$PrevWeapon[EnergyRifle] = EMPCannon;
$PrevWeapon[EngRepairGun] = EnergyRifle;
$PrevWeapon[ExplosiveGat] = EngRepairGun;
$PrevWeapon[FieldMortar] = ExplosiveGat;
$PrevWeapon[FlakCannon] = FieldMortar;
$PrevWeapon[Flamethrower] = FlakCannon;
$PrevWeapon[GasCanister] = Flamethrower;
$PrevWeapon[GrenadeLauncher] = GasCanister;
$PrevWeapon[LaserPistol] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = LaserPistol;
$PrevWeapon[Mortar] = LaserRifle;
$PrevWeapon[PlasmaGun] = Mortar;
$PrevWeapon[RadiationCanister] = PlasmaGun;
$PrevWeapon[RemoteDetonator] = RadiationCanister;
$PrevWeapon[RocketLauncher] = RemoteDetonator;
$PrevWeapon[Shotgun] = RocketLauncher;
$PrevWeapon[SniperRifle] = Shotgun;
$PrevWeapon[TankArtilleryShell] = SniperRifle;
$PrevWeapon[TankCannon] = TankArtilleryShell;
$PrevWeapon[AcidCanister] = TankCannon;


// -----------------------------------
// Specialist weapon functions
// -----------------------------------

function SpecialistSpawnProjectile(%this, %obj, %muzzleVelocity) {
	// This function will take an object that has been
	// already created and make it appear to fire
	// from the user's mounted weapon.
	// Input: %this = playerId, %obj = firedObjectId, %muzzleVelocity = muzzle velocity
	// by RCabrera 2/11/00

	// We get the user's gun transform
	%gTrans = GameBase::getMuzzleTransform(%this);

	// Get the player's position
	%pos = getBoxCenter(%this);

	// Strip its components
	%posX = getWord(%pos, 0);
	%posY = getWord(%pos, 1);
	%posZ = getWord(%pos, 2);
	%gunposX = getWord(%gTrans, 0);
	%gunposY = getWord(%gTrans, 1);
	%gunposZ = getWord(%gTrans, 2);
	%rotX = getWord(%gTrans, 3);
	%rotY = getWord(%gTrans, 4);
	%rotZ = getWord(%gTrans, 5);

	// Place the grenade at player's gun position
	%posX += %gunposX;
	%posY += %gunposY;
	%posZ += %gunposZ;

	// Tweak the positioning a bit
	%posX += (2 * %rotX);
	%posY += (2 * %rotY);
	%posZ += (2 * %rotZ) + 0.8;

	%newpos = %posX @ " " @ %posY @ " " @ %posZ;
	GameBase::setPosition(%obj, %newpos);

	// Set the grenade's velocity in the right direction
	%velX = %rotX * %muzzleVelocity;
	%velY = %rotY * %muzzleVelocity;
	%velZ = %rotZ * %muzzleVelocity;
	%velocity = %velX @ " " @ %velY @ " " @ %velZ;

	Item::setVelocity(%obj, %velocity);
}

function SpecialistThrowSpread(%this, %objectClass, %objectType, %number, %velocity, %spreadFactor) {

	// NOTE: This function is unfinished.  Do not use it.

	// This function will create a number of copies of an object, 
	// and throw them from the player in a spread pattern.
	// Input: %this = playerId 
	//	%objectClass = throwing this class of object
	//	%objectType = throwing this type of object
	// 	%number = number of these objects to throw
	//	%velocity = the velocity at which to throw
	//	%spreadFactor = the degree of spread
	// by RCabrera 6/29/00

	echo("Number: " @%number);
	echo("Velocity: " @%velocity);

	// error-checking
	if (%number < 1) return;
	
	// We get the user's gun transform
	%gTrans = GameBase::getMuzzleTransform(%this);

	// Get the player's position
	%pos = getBoxCenter(%this);

	// Strip its components
	%posX = getWord(%pos, 0);
	%posY = getWord(%pos, 1);
	%posZ = getWord(%pos, 2);
	%gunposX = getWord(%gTrans, 0);
	%gunposY = getWord(%gTrans, 1);
	%gunposZ = getWord(%gTrans, 2);
	%rotX = getWord(%gTrans, 3);
	%rotY = getWord(%gTrans, 4);
	%rotZ = getWord(%gTrans, 5);

	// %rotation = GameBase::getRotation(%this);
	// %rotX = getWord(%rotation, 0);
	// %rotY = getWord(%rotation, 1);
	 // %rotZ = getWord(%rotation, 2);
	echo("X-rotation: " @ %rotX);
	echo("Y-rotation: " @ %rotY);
	echo("Z-rotation: " @ %rotZ);

	// Place the grenade at player's position
	%posX -= %gunposX;
	%posY -= %gunposY;
	%posZ += %gunposZ;

	// Tweak the positioning a bit
	// %posX += (3 * %rotX);
	// %posY += (3 * %rotY);
	// %posZ += (3 * %rotZ);
	%newpos = %posX @ " " @ %posY @ " " @ %posZ;

	// initialize rotation
	%rotX -= 1.0;
	%rotY -= 1.0;
	// %rotZ -= 1.5;

	// for each object
	for (%j=0; %j < %number; %j++) {

		// create the object
		%obj = newObject("", %objectClass, %objectType);
		addToSet("MissionCleanup", %obj);

		// set the position
		GameBase::setPosition(%obj, %newpos);

		// Set the grenade's velocity in the right direction
		%velX = %rotX * %velocity;
		%velY = %rotY * %velocity;
		%velZ = %rotZ * %velocity;
		%Tvelocity = %velX @ " " @ %velY @ " " @ %velZ;
		echo("Velocity: " @%velX@", "@%velY@", "@%velZ);

		Item::setVelocity(%obj, %Tvelocity);

		if (%j < (%number/2)) {
			%rotX -= 0.4;
			// %rotY -= 0.4;
			// %rotZ -= 0.6;
		}
		else {
			%rotX += 0.4;
			// %rotY += 0.4;
			// %rotZ += 0.6;
		}
		%rotY -= 0.4;
		echo("Grenade thrown at rotation: " @ %rotX @ ", " @ %rotY @", " @ %rotZ);
	}
}