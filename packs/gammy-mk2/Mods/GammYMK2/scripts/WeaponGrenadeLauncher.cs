//--------------------------------------

$AutoUse[GrenadeLauncher] = True;
$SellAmmo[GrenadeAmmo] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackItems[3] = GrenadeAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

//--------------------------------------

$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function GrenadeLauncher::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The GrenadeLauncher...a weapon that taught us that shooting high speed bouncy grenades is better then throwing them :).", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------