//--------------------------------------

$AutoUse[FW] = True;
$SellAmmo[FireAmmo] = 25;
$AmmoPackMax[FireAmmo] = 350;
$AmmoPackItems[0] = FireAmmo;
$WeaponAmmo[FW] = FireAmmo;

//--------------------------------------

$InvList[FW] = 1;
$InvList[FireAmmo] = 1;
$RemoteInvList[FW] = 1;
$RemoteInvList[FireAmmo] = 1;

//--------------------------------------

BulletData FireWall
{
   bulletShapeName = "Plasmabolt.dts";
   explosionTag    = MortarExp;
   expRandCycle       = 0;
   collisionRadius = 0.0;
   mass            = 2.0;
   bulletHoleIndex    = 0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.33;
   damageType       = $PlasmaDamageType;
   explosionRadius  = 10.0;
   kickBackStrength = 55.0;

   muzzleVelocity    = 90.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   aimDeflection      = 0.005;//0.03;
   isVisible          = True;//+++++++++++

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

ItemData FireAmmo
{
	description = "Fire Cell";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData FWImage
{
	shapeFile = "PlasmaTrail";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 2;
	spinDownTime = 3;
	fireTime = 0.1;

	ammoType = FireAmmo;
	projectileType = FireWall;
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

ItemData FW
{
	description = "Energy Ball Blast";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "plasma";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = FWImage;
	price = 825;
	showWeaponBar = true;
};

//--------------------------------------
function FW::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Energy Ball Blast....one of DBZ's most used weapons it fires many shots off quickly but not accurately. DBZ Charge Time 2 Seconds", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------