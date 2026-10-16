$InvList[EMPCannon] = 1;
$RemoteInvList[EMPCannon] = 1;
$AutoUse[EMPCannon] = 1;

$WeaponAmmo[EMPCannon] = EMPCannonAmmo;
$SellAmmo[EMPCannonAmmo] = 5;
$InvList[EMPCannonAmmo] = 1;
$RemoteInvList[EMPCannonAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, EMPCannon] = 0;
$ItemMax[reconfemalearmor, EMPCannon] = 0;
$ItemMax[espionagearmor, EMPCannon] = 0;
$ItemMax[espionagefemalearmor, EMPCannon] = 0;
$ItemMax[engineerarmor, EMPCannon] = 0;
$ItemMax[engineerfemalearmor, EMPCannon] = 0;
$ItemMax[infantryarmor, EMPCannon] = 0;
$ItemMax[infantryfemalearmor, EMPCannon] = 0;
$ItemMax[falloutarmor, EMPCannon] = 0;
$ItemMax[falloutfemalearmor, EMPCannon] = 0;
$ItemMax[demolitionsarmor, EMPCannon] = 0;
$ItemMax[assaultarmor, EMPCannon] = 1;
$ItemMax[artilleryarmor, EMPCannon] = 1;
$ItemMax[commanderarmor, EMPCannon] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, EMPCannonAmmo] = 0;
$ItemMax[reconfemalearmor, EMPCannonAmmo] = 0;
$ItemMax[espionagearmor, EMPCannonAmmo] = 10;
$ItemMax[espionagefemalearmor, EMPCannonAmmo] = 10;
$ItemMax[engineerarmor, EMPCannonAmmo] = 10;
$ItemMax[engineerfemalearmor, EMPCannonAmmo] = 10;
$ItemMax[infantryarmor, EMPCannonAmmo] = 10;
$ItemMax[infantryfemalearmor, EMPCannonAmmo] = 10;
$ItemMax[falloutarmor, EMPCannonAmmo] = 10;
$ItemMax[falloutfemalearmor, EMPCannonAmmo] = 10;
$ItemMax[demolitionsarmor, EMPCannonAmmo] = 10;
$ItemMax[assaultarmor, EMPCannonAmmo] = 20;
$ItemMax[artilleryarmor, EMPCannonAmmo] = 10;
$ItemMax[commanderarmor, EMPCannonAmmo] = 10;

// ======================= Explosion data ======================


// ================ Ammo data =================

ItemData EMPCannonAmmo
{
	description = "EMP Shell";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

// =================== EMP Cannon data =================
ItemImageData EMPCannonImage
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 3.14, 0 };

	shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPCannonAmmo;
	projectileType = EMPGrenadeShell;
	reloadTime = 0.5;
	fireTime = 0.5;

	accuFire = false;

	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 2;
	lightColor = { 0.0, 0.0, 0.6 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxReady = SoundDiscSpin;
};

// =================== Item data for EMP Cannon ================
ItemData EMPCannon
{
	heading = "bWeapons";
	description = "EMP Cannon";
	className = "Weapon";
	shapeFile  = "grenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = EMPCannonImage;
	price = 250;
	showWeaponBar = true;
};

function EMPCannon::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The EMP Cannon is useful for taking out shields or grounding an opponent.");
	}
}
