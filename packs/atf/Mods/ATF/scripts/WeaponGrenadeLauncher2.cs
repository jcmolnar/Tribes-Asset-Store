//Thermal Nuke Script

//--------------------------------------

$AutoUse[TN] = True;
$SellAmmo[GrenadeAmmo] = 5;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackItems[3] = GrenadeAmmo;
$WeaponAmmo[TN] = GrenadeAmmo;
//--------------------------------------

$InvList[TN] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[TN] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

//--------------------------------------

GrenadeData GrenadeShell2
{
   bulletShapeName    = "discb.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $MortarDamageType;

   explosionRadius    = 170;
   kickBackStrength   = 170.0;
   maxLevelFlightDist = 400;
   totalTime          = 20.0;    // special meaning for grenades...
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.9;

   smokeName              = "MortarTrail.dts";
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

ItemImageData GrenadeLauncher2Image
{
	shapeFile = "grenadeL";
	mountPoint = 0;
                mountoffset = { 0, 0, -0.2 };
                mountrotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell2;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TN
{
	description = "Thermal Nuke Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = GrenadeLauncher2Image;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function TN::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Thermal Nuke Launcher...Using radioactive heat this weapon can harm things meters away from the explosion...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------