$InvList[AcidCanister] = 1;
$RemoteInvList[AcidCanister] = 1;
$AutoUse[AcidCanister] = 1;

$WeaponAmmo[AcidCanister] = AcidCanisterAmmo;
$SellAmmo[AcidCanisterAmmo] = 5;
$InvList[AcidCanisterAmmo] = 1;
$RemoteInvList[AcidCanisterAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, AcidCanister] = 0;
$ItemMax[reconfemalearmor, AcidCanister] = 0;
$ItemMax[espionagearmor, AcidCanister] = 0;
$ItemMax[espionagefemalearmor, AcidCanister] = 0;
$ItemMax[engineerarmor, AcidCanister] = 0;
$ItemMax[engineerfemalearmor, AcidCanister] = 0;
$ItemMax[infantryarmor, AcidCanister] = 0;
$ItemMax[infantryfemalearmor, AcidCanister] = 0;
$ItemMax[falloutarmor, AcidCanister] = 1;
$ItemMax[falloutfemalearmor, AcidCanister] = 1;
$ItemMax[demolitionsarmor, AcidCanister] = 0;
$ItemMax[assaultarmor, AcidCanister] = 1;
$ItemMax[artilleryarmor, AcidCanister] = 0;
$ItemMax[commanderarmor, AcidCanister] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, AcidCanisterAmmo] = 0;
$ItemMax[reconfemalearmor, AcidCanisterAmmo] = 0;
$ItemMax[espionagearmor, AcidCanisterAmmo] = 0;
$ItemMax[espionagefemalearmor, AcidCanisterAmmo] = 0;
$ItemMax[engineerarmor, AcidCanisterAmmo] = 0;
$ItemMax[engineerfemalearmor, AcidCanisterAmmo] = 0;
$ItemMax[infantryarmor, AcidCanisterAmmo] = 0;
$ItemMax[infantryfemalearmor, AcidCanisterAmmo] = 0;
$ItemMax[falloutarmor, AcidCanisterAmmo] = 10;
$ItemMax[falloutfemalearmor, AcidCanisterAmmo] = 10;
$ItemMax[demolitionsarmor, AcidCanisterAmmo] = 0;
$ItemMax[assaultarmor, AcidCanisterAmmo] = 20;
$ItemMax[artilleryarmor, AcidCanisterAmmo] = 0;
$ItemMax[commanderarmor, AcidCanisterAmmo] = 0;

// ================ Ammo data =================

ItemData AcidCanisterAmmo
{
	description = "Acid Canister";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};


// =================== Acid Canister Launcher data =================
ItemImageData AcidCanisterImage
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };

	shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AcidCanisterAmmo;
	// projectileType = AcidCanisterGrenade;
	reloadTime = 1.0;
	fireTime = 0.5;

	accuFire = false;

	lightType = 3; // Weapon Fire
	lightRadius = 0.5;
	lightTime = 0.1;
	lightColor = { 0.0, 1.0, 0.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function AcidCanisterImage::onFire(%this, %slot) {

	// Get some valuable info
	%client = Player::getClient(%this);

	// We subtract one ammo
	Player::decItemCount(%this, AcidCanisterAmmo, 1);

	// Create the grenade
	%obj = newObject("","Mine","mAcidGrenade");
	addToSet("MissionCleanup", %obj);

	// Shoot the grenade forward
	SpecialistSpawnProjectile(%this, %obj, 35);

	// Assign the grenade to a team
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
}

// =================== Item data for Acid Canister Launcher ================
ItemData AcidCanister
{
	heading = "bWeapons";
	description = "Acid Canisters";
	className = "Weapon";
	shapeFile  = "grenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = AcidCanisterImage;
	price = 150;
	showWeaponBar = true;
};

