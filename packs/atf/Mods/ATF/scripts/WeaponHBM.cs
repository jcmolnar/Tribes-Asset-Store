//--------------------------------------

$AutoUse[HBM] = True;
$SellAmmo[GrenadeAmmo] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackItems[3] = GrenadeAmmo;
$WeaponAmmo[HBM] = GrenadeAmmo;
//--------------------------------------

$InvList[HBM] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[HBM] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------

GrenadeData HumanMedium
{
   bulletShapeName    = "Marmor.dts";
   explosionTag       = Rocketexp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.40;
   damageType         = $MortarDamageType;

   explosionRadius    = 40;
   kickBackStrength   = 260.0;
   maxLevelFlightDist = 400;
   totalTime          = 140.0;    // special meaning for grenades...
   liveTime           = 30.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.9;

   smokeName              = "PlasmaTrail.dts";
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

ItemImageData HBMImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = HumanMedium;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HBM
{
	description = "M Decoy Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eTrajectoryGuns";
	shadowDetailMask = 4;
	imageType = HBMImage;
	price = 550;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function HBM::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Medium Armor Decoy Launcher....Fool your enemies into investigating it...then watch them go boom!!! Twice as strong as the the Light Armor Decoy.....30 second Delay", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------