//--------------------------------------

GrenadeData SmokeShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = flashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.02;
   damageType         = $SmokeDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "shockwave.dts";
};

//--------------------------------------

GrenadeData SmokeShell2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = flashExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.02;
   damageType         = $SmokeDamageType;

   explosionRadius    = 20;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 15.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "bluex.dts";
};

//----------------------------------------------------------------------------

ItemData SmokeAmmo
{
	description = "Smoke Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SmokeLauncherImage
{
	shapeFile = "GrenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = SmokeAmmo;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SmokeLauncher
{
	description = "Smoke Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenadeL";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = SmokeLauncherImage;
	price =   50;
	showWeaponBar = true;
};

function SmokeLauncherImage::onFire(%player, %slot)
{
	if(Player::getItemCount(%player, SmokeAmmo) > 0) {
		Weapon::onFire(%player,SmokeShell,False);
		Weapon::onFire(%player,SmokeShell2);
	}
}

//-----------------------------------------------------

	$InvList[SmokeLauncher] = 1;
	$RemoteInvList[SmokeLauncher] = 1;

	$ItemMax[larmor, SmokeLauncher] = 0;
	$ItemMax[marmor, SmokeLauncher] = 0;
	$ItemMax[harmor, SmokeLauncher] = 0;
	$ItemMax[qarmor, SmokeLauncher] = 0;
	$ItemMax[tarmor, SmokeLauncher] = 0;
	$ItemMax[sarmor, SmokeLauncher] = 0;
	$ItemMax[srarmor, SmokeLauncher] = 1;
	$ItemMax[parmor, SmokeLauncher] = 0;
	$ItemMax[lfemale, SmokeLauncher] = 0;
	$ItemMax[mfemale, SmokeLauncher] = 0;
	$ItemMax[qfemale, SmokeLauncher] = 0;
	$ItemMax[sfemale, SmokeLauncher] = 0;
	$ItemMax[srfemale, SmokeLauncher] = 1;
	$ItemMax[pfemale, SmokeLauncher] = 0;

	$InvList[SmokeAmmo] = 1;
	$RemoteInvList[SmokeAmmo] = 1;

	$ItemMax[larmor, SmokeAmmo] = 10;
	$ItemMax[marmor, SmokeAmmo] = 10;
	$ItemMax[harmor, SmokeAmmo] = 10;
	$ItemMax[qarmor, SmokeAmmo] = 10;
	$ItemMax[tarmor, SmokeAmmo] = 10;
	$ItemMax[sarmor, SmokeAmmo] = 10;
	$ItemMax[srarmor, SmokeAmmo] = 10;
	$ItemMax[parmor, SmokeAmmo] = 10;
	$ItemMax[lfemale, SmokeAmmo] = 10;
	$ItemMax[mfemale, SmokeAmmo] = 10;
	$ItemMax[qfemale, SmokeAmmo] = 10;
	$ItemMax[sfemale, SmokeAmmo] = 10;
	$ItemMax[srfemale, SmokeAmmo] = 10;
	$ItemMax[pfemale, SmokeAmmo] = 10;

