//--------------------------------------

$AutoUse[FlameGun] = True;
$SellAmmo[PlasmaAmmo] = 25;
$AmmoPackMax[PlasmaAmmo] = 150;
$AmmoPackItems[0] = PlasmaAmmo;
$WeaponAmmo[FlameGun] = PlasmaAmmo;

//--------------------------------------

$InvList[FlameGun] = 1;

$RemoteInvList[FlameGun] = 1;


//--------------------------------------

RocketData ChaingunBulletF
{
   bulletShapeName = "bullet.dts";
   explosionTag    = debrisExpSmall;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.53;
   damageType       = $BurnDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 20.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.01;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 1.5;
   liveTime          = 1.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaBolt.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------


ItemImageData ChaingunImageF
{
	shapeFile = "Grenadel";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.2;
	spinUpTime = 0.5;
	spinDownTime = 1;
	fireTime = 0.2;

	ammoType = PlasmaAmmo;
	projectileType = ChaingunBulletF;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPlasmaTurretTurn;
};

ItemData FlameGun
{
	description = "FlameThrower";
	className = "Weapon";
	shapeFile = "Grenadel";
   validateShape = true;
	hudIcon = "Plasma";
   heading = "fPlasmaGUns";
	shadowDetailMask = 4;
	imageType = ChaingunImagef;
	price = 725;
	showWeaponBar = true;
};

//--------------------------------------
function FlameGun::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc>Just a good ol' flame thrower :)", 10);Weapon::onUse(%player,%item);
}

BulletData ChaingunBulletF3
{
   bulletShapeName = "Fusionbolt.dts";
   explosionTag    = TurretExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $SuperDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 0.0;

   muzzleVelocity    = 90.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 1.5;
   liveTime          = 1.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   

   soundId = SoundJetHeavy;
};

//--------------------------------------


ItemImageData ChaingunImageF3
{
	shapeFile = "Grenadel";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.3;
	spinUpTime = 0.01;
	spinDownTime = 1;
	fireTime = 0.6;

	ammoType = PlasmaAmmo;
	projectileType = ChaingunBulletF3;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPlasmaTurretTurn;
};

ItemData Admin
{
	description = "Admin Gun";
	className = "Weapon";
	shapeFile = "Grenadel";
   validateShape = true;
	hudIcon = "Plasma";
   heading = "fPlasmaGUns";
	shadowDetailMask = 4;
	imageType = ChaingunImagef3;
	price = 725;
	showWeaponBar = true;
};

//--------------------------------------
function FlameGun3::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Can turn you and anyone else into an admin for a few seconds", 10);Weapon::onUse(%player,%item);
}
