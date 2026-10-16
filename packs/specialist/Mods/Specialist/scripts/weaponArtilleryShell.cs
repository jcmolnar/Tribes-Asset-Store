$InvList[ArtilleryShell] = 1;
$RemoteInvList[ArtilleryShell] = 1;
$AutoUse[ArtilleryShell] = True;

$WeaponAmmo[ArtilleryShell] = ArtilleryShellAmmo;
$SellAmmo[ArtilleryShellAmmo] = 3;
$InvList[ArtilleryShellAmmo] = 1;
$RemoteInvList[ArtilleryShellAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, ArtilleryShell] = 0;
$ItemMax[reconfemalearmor, ArtilleryShell] = 0;
$ItemMax[espionagearmor, ArtilleryShell] = 0;
$ItemMax[espionagefemalearmor, ArtilleryShell] = 0;
$ItemMax[engineerarmor, ArtilleryShell] = 0;
$ItemMax[engineerfemalearmor, ArtilleryShell] = 0;
$ItemMax[infantryarmor, ArtilleryShell] = 0;
$ItemMax[infantryfemalearmor, ArtilleryShell] = 0;
$ItemMax[falloutarmor, ArtilleryShell] = 0;
$ItemMax[falloutfemalearmor, ArtilleryShell] = 0;
$ItemMax[demolitionsarmor, ArtilleryShell] = 0;
$ItemMax[assaultarmor, ArtilleryShell] = 0;
$ItemMax[artilleryarmor, ArtilleryShell] = 1;
$ItemMax[commanderarmor, ArtilleryShell] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, ArtilleryShellAmmo] = 0;
$ItemMax[reconfemalearmor, ArtilleryShellAmmo] = 0;
$ItemMax[espionagearmor, ArtilleryShellAmmo] = 0;
$ItemMax[espionagefemalearmor, ArtilleryShellAmmo] = 0;
$ItemMax[engineerarmor, ArtilleryShellAmmo] = 0;
$ItemMax[engineerfemalearmor, ArtilleryShellAmmo] = 0;
$ItemMax[infantryarmor, ArtilleryShellAmmo] = 0;
$ItemMax[infantryfemalearmor, ArtilleryShellAmmo] = 0;
$ItemMax[falloutarmor, ArtilleryShellAmmo] = 0;
$ItemMax[falloutfemalearmor, ArtilleryShellAmmo] = 0;
$ItemMax[demolitionsarmor, ArtilleryShellAmmo] = 0;
$ItemMax[assaultarmor, ArtilleryShellAmmo] = 0;
$ItemMax[artilleryarmor, ArtilleryShellAmmo] = 3;
$ItemMax[commanderarmor, ArtilleryShellAmmo] = 0;

GrenadeData ArtilleryShellGrenade 
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = True;
  ownerGraceMS = 800;
  collisionRadius = 1.0;
  mass = 80.0;
  elasticity = 0.1;

  damageClass = 1; // 1 = radius
  damageValue = 0.85;
  damageType = $ArtilleryShellDamageType;

  explosionRadius = 20.5;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 400;  
  totalTime = 1000.0;
  liveTime = 3.5;
  projSpecialTime = 0.05;

  inheritedVelocityScale = 0.5;

  smokeName = "rsmoke.dts";
};

ItemData ArtilleryShellAmmo
{
	description = "Artillery Shell";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 95;
};

ItemImageData ArtilleryShellImage 
{
	mountOffset = { 0, -0.4, 0.7 };
	mountRotation = { 0, 0, 0 };

	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 3.0;
	fireTime = 2.0;

	ammoType = ArtilleryShellAmmo;
	// projectileType = ArtilleryShellGrenade;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 1;
	lightColor = { 1.0, 1.0, 1.0 };
	//sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ArtilleryShell 
{
	description = "Artillery Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ArtilleryShellImage;
	price = 575;
	showWeaponBar = true;
};

function ArtilleryShellImage::onFire(%this, %slot) {
	// This function implements a "safety device" on the artillery shell
	// and fires multiple projectiles with each shot.
	// It will refuse to fire if there is an object too close to the 
	// player.
	// by RCabrera <rcabrera@atlanticuc.edu> 1/19/00

	// Check to see if the player is standing still
	if (!GameBase::isAtRest(%this)) {

		// if they aren't, we'll be so nice as to tell the player
		Client::sendMessage(GameBase::getOwnerClient(%this), 1, "Safety Override: Cannot fire while moving");

		return;
	}

	// We get the gun's pos and rotation
	%gTrans = GameBase::getMuzzleTransform(%this);

	// Next, we see if there is something in the way (80 meters max)
	if (GameBase::getLOSInfo(%this, 80)) {

		// if there is, we'll be so nice as to tell the player
		Client::sendMessage(GameBase::getOwnerClient(%this), 1, "Safety Override: Barrel obstructed within 80 meters");

		// And play the dry fire sound
		GameBase::playSound(%this, SoundDryFire, 3);
	}

	// if the line is clear
	else {

		// we subtract one ammo
		Player::decItemCount(%this, ArtilleryShellAmmo);

		// we get the components of the gun's transform
		%coord0 = getWord(%gTrans, 0);
		%coord1 = getWord(%gTrans, 1);
		%coord2 = getWord(%gTrans, 2);
		%coord3 = getWord(%gTrans, 3);
		%coord4 = getWord(%gTrans, 4);
		%coord5 = getWord(%gTrans, 5);
		%coord6 = getWord(%gTrans, 6);
		%coord7 = getWord(%gTrans, 7);
		%coord8 = getWord(%gTrans, 8);
		%coord9 = getWord(%gTrans, 9);
		%coord10 = getWord(%gTrans, 10);
		%coord11 = getWord(%gTrans, 11);

		// save the important ones
		%orig3 = %coord3;
		%orig4 = %coord4;
		%orig5 = %coord5;

		// fire the first projectile
		%success = Projectile::SpawnProjectile(ArtilleryShellGrenade, %coord0@" "@%coord1@" "@%coord2@" "@%coord3@" "@%coord4@" "@%coord5@" "@%coord6@" "@%coord7@" "@%coord8@" "@%coord9@" "@%coord10@" "@%coord11, %this, 0, $los::object);

		// adjust the aim a little bit and fire another projectile
		%rand = (getRandom() * 0.1);
		%coord3 = %orig3 - %rand;
		%coord4 = %orig4 + %rand;
		%coord5 = %orig5 - %rand;
		%success = Projectile::SpawnProjectile(ArtilleryShellGrenade, %coord0@" "@%coord1@" "@%coord2@" "@%coord3@" "@%coord4@" "@%coord5@" "@%coord6@" "@%coord7@" "@%coord8@" "@%coord9@" "@%coord10@" "@%coord11, %this, 0, $los::object);		
	
		// adjust the aim a little bit and fire another projectile
		%rand = (getRandom() * 0.1);
		%coord3 = %orig3 + %rand;
		%coord4 = %orig4 - %rand;
		%coord5 = %orig5 + %rand;
		%success = Projectile::SpawnProjectile(ArtilleryShellGrenade, %coord0@" "@%coord1@" "@%coord2@" "@%coord3@" "@%coord4@" "@%coord5@" "@%coord6@" "@%coord7@" "@%coord8@" "@%coord9@" "@%coord10@" "@%coord11, %this, 0, $los::object);		

		// adjust the aim a little bit and fire another projectile
		%rand = (getRandom() * 0.1);
		%coord3 = %orig3 + %rand;
		%coord4 = %orig4 - %rand;
		%coord5 = %orig5 - %rand;
		%success = Projectile::SpawnProjectile(ArtilleryShellGrenade, %coord0@" "@%coord1@" "@%coord2@" "@%coord3@" "@%coord4@" "@%coord5@" "@%coord6@" "@%coord7@" "@%coord8@" "@%coord9@" "@%coord10@" "@%coord11, %this, 0, $los::object);		

		// adjust the aim a little bit and fire another projectile
		%rand = (getRandom() * 0.1);
		%coord3 = %orig3 - %rand;
		%coord4 = %orig4 + %rand;
		%coord5 = %orig5 + %rand;
		%success = Projectile::SpawnProjectile(ArtilleryShellGrenade, %coord0@" "@%coord1@" "@%coord2@" "@%coord3@" "@%coord4@" "@%coord5@" "@%coord6@" "@%coord7@" "@%coord8@" "@%coord9@" "@%coord10@" "@%coord11, %this, 0, $los::object);		

		// play the fire and reload sounds
		GameBase::playSound(%this, SoundMortarTurretFire, 1);
		GameBase::playSound(%this, SoundMortarTurretTurn, 2);

		// get the player's rotation
		%rot = GameBase::getRotation(%this);
		
		// the force of the kickback
		%force = 800;

		// get the facing vector
		%vec = Vector::getFromRot(%rot, %force);

		// turn the vector around 180 degrees
		%kickbackvector = Vector::neg(%vec);

		// apply kickback from the cannon
		Player::applyImpulse(%this, %kickbackvector);

	}
}