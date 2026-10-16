//--------------------------------------

$AutoUse[GrenadeLauncher] = True;
addAmmo(GrenadeLauncher,GrenadeAmmo,5,15);

addToInv(GrenadeLauncher,1,1);
addToInv(GrenadeAmmo,1,1);

setArmorItemMax(GrenadeLauncher,1,1,1);
setArmorItemMax(GrenadeAmmo,10,10,15);

//--------------------------------------

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass 	      = 1.0;
   elasticity	      = 0.45;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.4;
   damageType	      = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime	      = 30.0;	 // special meaning for grenades...
   liveTime	      = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName		  = "smoke.dts";
};

//--------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvCatAmmo;
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

	lightType = 3;	// Weapon Fire
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
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

$MountMSG[GrenadeLauncher] = "<JC><F2>Grenade Launcher <F0>- <F1>Lobs concussion grenades.";

AddWeapon(GrenadeLauncher);
