//--------------------------------------

$AutoUse[SE] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[SE] = PlasmaAmmo;

//--------------------------------------

$InvList[SE] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[SE] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------
RocketData SEWave
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.09;
   damageType       = $ShockDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 60.0;
   acceleration     = 50.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "FusionEX.dts";
   smokeDist   = 5;
 
   soundId = SoundTankCrash;
};

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SEImage
{
	shapeFile = "MortarGun";
	mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 1; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = SEWave;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.6;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
                sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
                sfxReady = SoundTankIdle;
};

ItemData SE
{
	description = "Static Shocker";
	className = "Weapon";
	shapeFile = "MortarGun";
	hudIcon = "plasma";
   heading = "dLightning Guns";
	shadowDetailMask = 4;
	imageType = SEImage;
	price = 3175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function SE::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Ever wonder what would happen if the elf was a projectile gun...Well here it is, the Static Shocker (Static energy) Gun....With a strong Blast of Electricity the victim will have one hell of a headache", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------