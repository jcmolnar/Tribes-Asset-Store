$InvList[RocketLauncher] = 1;
$RemoteInvList[RocketLauncher] = 1;
$AutoUse[RocketLauncher] = True;

$WeaponAmmo[RocketLauncher] = RocketLauncherAmmo;
$SellAmmo[RocketLauncherAmmo] = 15;
$InvList[RocketLauncherAmmo] = 1;
$RemoteInvList[RocketLauncherAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, RocketLauncher] = 0;
$ItemMax[reconfemalearmor, RocketLauncher] = 0;
$ItemMax[espionagearmor, RocketLauncher] = 0;
$ItemMax[espionagefemalearmor, RocketLauncher] = 0;
$ItemMax[engineerarmor, RocketLauncher] = 0;
$ItemMax[engineerfemalearmor, RocketLauncher] = 0;
$ItemMax[infantryarmor, RocketLauncher] = 0;
$ItemMax[infantryfemalearmor, RocketLauncher] = 0;
$ItemMax[falloutarmor, RocketLauncher] = 0;
$ItemMax[falloutfemalearmor, RocketLauncher] = 0;
$ItemMax[demolitionsarmor, RocketLauncher] = 0;
$ItemMax[assaultarmor, RocketLauncher] = 1;
$ItemMax[artilleryarmor, RocketLauncher] = 1;
$ItemMax[commanderarmor, RocketLauncher] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, RocketLauncherAmmo] = 0;
$ItemMax[reconfemalearmor, RocketLauncherAmmo] = 0;
$ItemMax[espionagearmor, RocketLauncherAmmo] = 0;
$ItemMax[espionagefemalearmor, RocketLauncherAmmo] = 0;
$ItemMax[engineerarmor, RocketLauncherAmmo] = 0;
$ItemMax[engineerfemalearmor, RocketLauncherAmmo] = 0;
$ItemMax[infantryarmor, RocketLauncherAmmo] = 0;
$ItemMax[infantryfemalearmor, RocketLauncherAmmo] = 0;
$ItemMax[falloutarmor, RocketLauncherAmmo] = 0;
$ItemMax[falloutfemalearmor, RocketLauncherAmmo] = 0;
$ItemMax[demolitionsarmor, RocketLauncherAmmo] = 0;
$ItemMax[assaultarmor, RocketLauncherAmmo] = 8;
$ItemMax[artilleryarmor, RocketLauncherAmmo] = 12;
$ItemMax[commanderarmor, RocketLauncherAmmo] = 0;

ItemData RocketLauncherAmmo
{
	description = "Rocket";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

SeekingMissileData PersonalRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 420.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;

  seekingTurningRadius = 10.0;
  nonSeekingTurningRadius = 10.0;
  proximityDist = 1.5;
  smokeDist = 0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


ItemImageData RocketLauncherImage 
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, -1.6, 0 };

	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single shot
	ammoType = RocketLauncherAmmo;
	// projectileType = FlakRound;
	accuFire = true;

	reloadTime = 1.0;
	fireTime = 0.5;

//	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDiscReload;
//	sfxReady = SoundDiscSpin;
};

ItemData RocketLauncher 
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "targetlaser";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 375;
	showWeaponBar = true;
};

function RocketLauncherImage::onFire(%this, %slot) {
	// This function implements a "tracking device" on the rocket launcher.
	// by RCabrera <rcabrera@atlanticuc.edu> 4/17/00

	// We get the gun's pos and rotation
	%gTrans = GameBase::getMuzzleTransform(%this);

	// initialize target
	%target = "";

	// Next, we see if there is something in the crosshairs (250 meters max)
	if (GameBase::getLOSInfo(%this, 250)) {
		%type = getObjectType($los::object);

		// if the object is a player (friend or foe) or vehicle
		if (%type == "Player" || %type == "Vehicle") {

			// we'll be so nice as to tell the player
			Client::sendMessage(GameBase::getOwnerClient(%this), 1, "Target locked");

			// set target
			%target = $los::object;
		}
	}

	// we subtract one ammo
	Player::decItemCount(%this, RocketLauncherAmmo);

	// we fire the projectile
	if (%target == "") {
		%success = Projectile::SpawnProjectile(PersonalRocket, %gTrans, %this, 0);
	}
	else {
		%success = Projectile::SpawnProjectile(PersonalRocket, %gTrans, %this, 0, %target);
	}

	// and play the fire and reload sounds
	GameBase::playSound(%this, SoundMissileTurretFire, 3);

}

function RocketLauncher::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Rocket Launcher is useful for firing into enemy bunkers.");
	}
}
