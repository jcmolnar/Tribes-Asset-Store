$InvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;
$AutoUse[Shotgun] = True;

$WeaponAmmo[Shotgun] = ShotgunAmmo;
$SellAmmo[ShotgunAmmo] = 15;
$InvList[ShotgunAmmo] = 1;
$RemoteInvList[ShotgunAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, Shotgun] = 0;
$ItemMax[reconfemalearmor, Shotgun] = 0;
$ItemMax[espionagearmor, Shotgun] = 0;
$ItemMax[espionagefemalearmor, Shotgun] = 0;
$ItemMax[engineerarmor, Shotgun] = 1;
$ItemMax[engineerfemalearmor, Shotgun] = 1;
$ItemMax[infantryarmor, Shotgun] = 1;
$ItemMax[infantryfemalearmor, Shotgun] = 1;
$ItemMax[falloutarmor, Shotgun] = 0;
$ItemMax[falloutfemalearmor, Shotgun] = 0;
$ItemMax[demolitionsarmor, Shotgun] = 0;
$ItemMax[assaultarmor, Shotgun] = 1;
$ItemMax[artilleryarmor, Shotgun] = 0;
$ItemMax[commanderarmor, Shotgun] = 1;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, ShotgunAmmo] = 0;
$ItemMax[reconfemalearmor, ShotgunAmmo] = 0;
$ItemMax[espionagearmor, ShotgunAmmo] = 10;
$ItemMax[espionagefemalearmor, ShotgunAmmo] = 10;
$ItemMax[engineerarmor, ShotgunAmmo] = 15;
$ItemMax[engineerfemalearmor, ShotgunAmmo] = 15;
$ItemMax[infantryarmor, ShotgunAmmo] = 15;
$ItemMax[infantryfemalearmor, ShotgunAmmo] = 15;
$ItemMax[falloutarmor, ShotgunAmmo] = 0;
$ItemMax[falloutfemalearmor, ShotgunAmmo] = 0;
$ItemMax[demolitionsarmor, ShotgunAmmo] = 0;
$ItemMax[assaultarmor, ShotgunAmmo] = 30;
$ItemMax[artilleryarmor, ShotgunAmmo] = 0;
$ItemMax[commanderarmor, ShotgunAmmo] = 15;

// This sound taken from Renegades (2K, actually)
SoundData SoundFireShotgun 
{
	wavFileName = "mine_exp.wav";
	profile = Profile3dNear;
};

ExplosionData ShotExp 
{
	shapeName = "smoke.dts";
	soundId = ricochet3;

	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	timeScale = 0.5;

	timeZero = 0.100;
	timeOne = 0.900;

	shiftPosition = false;
};



BulletData ShotgunBullet 
{
	bulletShapeName = "tracer.dts";
	explosionTag = ShotExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.1;	// was 0.14 (RJC)
	damageType = $ShotgunDamageType;
	kickBackStrength = 300.0;
	aimDeflection = 0.02;
	muzzleVelocity = 400.0;
	acceleration = 5.0;
	totalTime = 0.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

ItemData ShotgunAmmo 
{
	description = "Shotgun Shell";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};


ItemImageData ShotgunImage 
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };

	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ShotgunAmmo;
	reloadTime = 1.0;
	accuFire = false;
	fireTime = 0.5;
	sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun 
{
	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 115;
};

function ShotgunImage::onFire(%this, %slot) {
	// This function will fire the multiple shotgun projectiles


	%player = %this;

	// First, we subtract one from ammo
	Player::decItemCount(%player, ShotgunAmmo, 1);

	// Then we get the direction that the player is aiming
	%trans = GameBase::getMuzzleTransform(%player);

	// Then we get the player's velocity
	%vel = Item::getVelocity(%player);

	// Last, we fire the bullets

	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
}

function Shotgun::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The shotgun is very powerful up-close.");
	}
}
