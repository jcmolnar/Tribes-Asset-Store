$InvList[LaserPistol] = 1;
$RemoteInvList[LaserPistol] = 1;
$AutoUse[LaserPistol] = 1;
$WeaponAmmo[LaserPistol] = "";

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, LaserPistol] = 0;
$ItemMax[reconfemalearmor, LaserPistol] = 0;
$ItemMax[espionagearmor, LaserPistol] = 1;
$ItemMax[espionagefemalearmor, LaserPistol] = 1;
$ItemMax[engineerarmor, LaserPistol] = 0;
$ItemMax[engineerfemalearmor, LaserPistol] = 0;
$ItemMax[infantryarmor, LaserPistol] = 0;
$ItemMax[infantryfemalearmor, LaserPistol] = 0;
$ItemMax[falloutarmor, LaserPistol] = 0;
$ItemMax[falloutfemalearmor, LaserPistol] = 0;
$ItemMax[demolitionsarmor, LaserPistol] = 0;
$ItemMax[assaultarmor, LaserPistol] = 0;
$ItemMax[artilleryarmor, LaserPistol] = 0;
$ItemMax[commanderarmor, LaserPistol] = 1;

LaserData laserPistolBeam
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.0, 0.0 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};


ItemImageData LaserPistolImage
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 1.6, 0 };

   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0.2;
	minEnergy = 25;
	maxEnergy = 55;

	// projectileType = laserPistolBeam;
	accuFire = true;

//	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserPistol
{
   heading = "bWeapons";
	description = "Laser Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = LaserPistolImage;
	price = 285;
	showWeaponBar = true;
};

function LaserPistolImage::onFire(%this, %slot) {
	// This function will fire the beam of the laser pistol.
	// The laser pistol is like the laser rifle, except the beam
	// must only fire at very short ranges (it is meant for indoor use).
	// Since there is no way to limit laser beam range, we have to write
	// our own function to do this.
	// by RCabrera <rcabrera@atlanticuc.edu> 1/19/00

	// First, we see if the player has enough energy to fire (12 minimum)
	%currEnergy = GameBase::getEnergy(%this);

	if (%currEnergy > 12) {
	
		// Then, we get the gun's pos and rotation
		%gTrans = GameBase::getMuzzleTransform(%this);
	
		// Next, we see if the shot hits (90 meters max)
		if (GameBase::getLOSInfo(%this, 90)) {

			// If it hits something, we subtract energy (25 maximum)
			%energyUsed = 25;
			if (%currEnergy < %energyUsed) %energyUsed = %currEnergy;
			GameBase::setEnergy(%this, %currEnergy - %energyUsed);

			// and we draw a beam to the target
			%success = Projectile::SpawnProjectile(laserPistolBeam, %gTrans, %this, 0, $los::object);
			GameBase::playSound(%this, SoundFireLaser, 3);

			// and we apply damage to it depending on how much energy was used
			%damage = %energyUsed * 0.02;
			%success = GameBase::applyDamage($los::object, $LaserDamageType, %damage, $los::position, $los::normal, "0 0 0", GameBase::getOwnerClient(%this));
		}

		// if the shot misses
		else {
			// we'll be so nice as to tell the player why
			Client::sendMessage(GameBase::getOwnerClient(%this), 1, "Target out of range");
			GameBase::playSound(%this, SoundDryFire, 3);
		}
	}
}

function LaserPistol::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The laser pistol packs a powerful punch, but only at close range.");
	}
}
