//--------------------------------------

$AutoUse[PlasmaGun] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[1] = PlasmaAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

//--------------------------------------

$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

//--------------------------------------

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.95;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 7.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
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

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "fPlasma Guns";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function PlasmaGun::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The PlasmaGun....Barbeque your enemies :).", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

//--------------------------------------

//--------------------------------------

BulletData ChaingunBulletOs
{
   bulletShapeName = "discb.dts";
   explosionTag    = RocketExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;    
   damageValue      = 0.13;
   damageType       = $ExplosionDamageType;
   explosionRadius  = 40.0;
   kickBackStrength = 135.0;

   muzzleVelocity    = 875.5;
   terminalVelocity = 880.0; 
   acceleration     = 5.0;
   aimDeflection      = 0.003;
   isVisible          = True;

   totalTime         = 3.5;
   liveTime          = 3.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------

ItemImageData ChaingunImageOs
{
	shapeFile = "Disc";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.002;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.0002;

	projectileType = ChaingunBUlletOs;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundPlayerDeath;
	sfxSpinDown = SoundPlayerDeath;
};

ItemData ChaingunOs
{
	description = "-OS- Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "brocketlaunchers";
	shadowDetailMask = 4;
	imageType = ChaingunImageOs;
	price = 125;
	showWeaponBar = true;
};

//--------------------------------------