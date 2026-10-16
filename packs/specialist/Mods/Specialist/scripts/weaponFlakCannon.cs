$InvList[FlakCannon] = 1;
$RemoteInvList[FlakCannon] = 1;
$AutoUse[FlakCannon] = True;

$WeaponAmmo[FlakCannon] = FlakCannonAmmo;
$SellAmmo[FlakCannonAmmo] = 15;
$InvList[FlakCannonAmmo] = 1;
$RemoteInvList[FlakCannonAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, FlakCannon] = 0;
$ItemMax[reconfemalearmor, FlakCannon] = 0;
$ItemMax[espionagearmor, FlakCannon] = 0;
$ItemMax[espionagefemalearmor, FlakCannon] = 0;
$ItemMax[engineerarmor, FlakCannon] = 0;
$ItemMax[engineerfemalearmor, FlakCannon] = 0;
$ItemMax[infantryarmor, FlakCannon] = 1;
$ItemMax[infantryfemalearmor, FlakCannon] = 1;
$ItemMax[falloutarmor, FlakCannon] = 0;
$ItemMax[falloutfemalearmor, FlakCannon] = 0;
$ItemMax[demolitionsarmor, FlakCannon] = 0;
$ItemMax[assaultarmor, FlakCannon] = 0;
$ItemMax[artilleryarmor, FlakCannon] = 1;
$ItemMax[commanderarmor, FlakCannon] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, FlakCannonAmmo] = 0;
$ItemMax[reconfemalearmor, FlakCannonAmmo] = 0;
$ItemMax[espionagearmor, FlakCannonAmmo] = 0;
$ItemMax[espionagefemalearmor, FlakCannonAmmo] = 0;
$ItemMax[engineerarmor, FlakCannonAmmo] = 0;
$ItemMax[engineerfemalearmor, FlakCannonAmmo] = 0;
$ItemMax[infantryarmor, FlakCannonAmmo] = 25;
$ItemMax[infantryfemalearmor, FlakCannonAmmo] = 10;
$ItemMax[falloutarmor, FlakCannonAmmo] = 0;
$ItemMax[falloutfemalearmor, FlakCannonAmmo] = 0;
$ItemMax[demolitionsarmor, FlakCannonAmmo] = 25;
$ItemMax[assaultarmor, FlakCannonAmmo] = 0;
$ItemMax[artilleryarmor, FlakCannonAmmo] = 60;
$ItemMax[commanderarmor, FlakCannonAmmo] = 0;

ExplosionData flakExp
{
   shapeName = "bluex.dts";
   soundId   = rocketExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

SeekingMissileData FlakRound 
{
	bulletShapeName = "mortar.dts";
	explosionTag    = flakExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.1;
	damageType       = $FlakDamageType;
	explosionRadius  = 25.0;
	kickBackStrength = 150.0;

	triggerRadius = 25.0;	// testing this

	muzzleVelocity   = 80.0;
	terminalVelocity = 120.0;
	acceleration = 5.0;
	totalTime        = 0.9;
	liveTime         = 0.9;

	lightRange       = 5.0;
	lightColor       = { 1.0, 1.0, 0.5 };

	seekingTurningRadius    = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist     = 1.5;
	smokeDist         = 0.0;

	inheritedVelocityScale = 0.5;

	isVisible = true;
	tracerPercentage = 1.0;
	tracerLength = 90;

	// rocket specific
	trailType   = 1;
	trailLength = 15;
	trailWidth  = 0.3;

	soundId = SoundDiscSpin;
};

ItemData FlakCannonAmmo
{
	description = "Flak Round";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData FlakCannonImage 
{
	mountOffset = { 0, 0, 0.05 };
	mountRotation = { 0, -1.6, 0 };

	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single shot
	ammoType = FlakCannonAmmo;
	// projectileType = FlakRound;
	accuFire = true;

	reloadTime = 0.2;
	fireTime = 0.3;

//	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData FlakCannon 
{
	description = "Flak Cannon";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlakCannonImage;
	price = 325;
	showWeaponBar = true;
};

function FlakCannonImage::onFire(%this, %slot) {
	// This function implements a "targeting device" on the flak cannon.
	// by RCabrera <rcabrera@atlanticuc.edu> 1/19/00

	// We get the gun's pos and rotation
	%gTrans = GameBase::getMuzzleTransform(%this);
	
	// initialize targeting
	%target = "";

	// Next, we see if there is something in the way (80 meters max)
	if (GameBase::getLOSInfo(%this, 80)) {
		%type = getObjectType($los::object);

		if (%type == "Player" || %type == "Vehicle") {

			//  we'll be so nice as to tell the player
			Client::sendMessage(GameBase::getOwnerClient(%this), 1, "Target locked");
			
			%target = $los::object;
		}
	}

	if (%target == "") {
		%success = Projectile::SpawnProjectile(flakRound, %gTrans, %this, 0);
	}
	else {
		%success = Projectile::SpawnProjectile(flakRound, %gTrans, %this, 0, %target);
	}

	// we subtract one ammo
	Player::decItemCount(%this, FlakCannonAmmo);

	// and play the fire and reload sounds
	GameBase::playSound(%this, SoundMissileTurretFire, 3);
	GameBase::playSound(%this, SoundDiscReload, 2);

}

function FlakCannon::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Flak Cannon is useful for air defense.");
	}
}
