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

BulletData ChaingunBulletF
{
   bulletShapeName = "Tumult_Medium.dts";
   explosionTag    = PlasmaExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.53;
   damageType       = $MissileDamageType;
   explosionRadius  = 4.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 40.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.02;//0.03;
   isVisible          = True;//+++++++++++

   totalTime         = 1.5;
   liveTime          = 1.5;
   inheritedVelocityScale = 0.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasma.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------


ItemImageData ChaingunImageF
{
	shapeFile = "Grenadel";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.1;
	spinUpTime = 0.1;
	spinDownTime = 1;
	fireTime = 0;

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
	bottomprint(Player::getClient(%player), "Just a good ol' flame thrower :)", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------