$InvList[RadiationCanister] = 1;
$RemoteInvList[RadiationCanister] = 1;
$AutoUse[RadiationCanister] = 1;

$WeaponAmmo[RadiationCanister] = RadiationCanisterAmmo;
$SellAmmo[RadiationCanisterAmmo] = 5;
$InvList[RadiationCanisterAmmo] = 1;
$RemoteInvList[RadiationCanisterAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, RadiationCanister] = 0;
$ItemMax[reconfemalearmor, RadiationCanister] = 0;
$ItemMax[espionagearmor, RadiationCanister] = 0;
$ItemMax[espionagefemalearmor, RadiationCanister] = 0;
$ItemMax[engineerarmor, RadiationCanister] = 0;
$ItemMax[engineerfemalearmor, RadiationCanister] = 0;
$ItemMax[infantryarmor, RadiationCanister] = 0;
$ItemMax[infantryfemalearmor, RadiationCanister] = 0;
$ItemMax[falloutarmor, RadiationCanister] = 1;
$ItemMax[falloutfemalearmor, RadiationCanister] = 1;
$ItemMax[demolitionsarmor, RadiationCanister] = 0;
$ItemMax[assaultarmor, RadiationCanister] = 0;
$ItemMax[artilleryarmor, RadiationCanister] = 0;
$ItemMax[commanderarmor, RadiationCanister] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, RadiationCanisterAmmo] = 0;
$ItemMax[reconfemalearmor, RadiationCanisterAmmo] = 0;
$ItemMax[espionagearmor, RadiationCanisterAmmo] = 0;
$ItemMax[espionagefemalearmor, RadiationCanisterAmmo] = 0;
$ItemMax[engineerarmor, RadiationCanisterAmmo] = 0;
$ItemMax[engineerfemalearmor, RadiationCanisterAmmo] = 0;
$ItemMax[infantryarmor, RadiationCanisterAmmo] = 0;
$ItemMax[infantryfemalearmor, RadiationCanisterAmmo] = 0;
$ItemMax[falloutarmor, RadiationCanisterAmmo] = 10;
$ItemMax[falloutfemalearmor, RadiationCanisterAmmo] = 10;
$ItemMax[demolitionsarmor, RadiationCanisterAmmo] = 0;
$ItemMax[assaultarmor, RadiationCanisterAmmo] = 0;
$ItemMax[artilleryarmor, RadiationCanisterAmmo] = 0;
$ItemMax[commanderarmor, RadiationCanisterAmmo] = 0;

// ======================= Explosion data ======================

ExplosionData RadiationCanisterExp
{
   shapeName = "enex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 12.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 1.0, 0.0 };
   colors[1]  = { 0.0, 1.0, 0.0 };
   colors[2]  = { 0.0, 1.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };
};

// ================ Ammo data =================

ItemData RadiationCanisterAmmo
{
	description = "Radiation Canister";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};

// ===================== Thrown canister data ==================

MineData ActualRadiationCanisterGrenade { 
 	mass = 1.0;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.25;
 	friction = 0.3;
 	className = "Handgrenade";
 	description = "Handgrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = RadiationCanisterExp;
 	explosionRadius = 20.0;
 	damageValue = 0.0001;
 	damageType = $RadiationDamageType;
 	kickBackStrength = 1.0;
 	triggerRadius = 1.0;
 	maxDamage = 0.3;
};

function ActualRadiationCanisterGrenade::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 3.0, %this);
}

function ActualRadiationCanisterGrenade::onDestroyed(%this) { 
	ActualRadiationCanisterGrenade::deployShape(%this, 20, $RadiationDamageType, 5.0);
}


function ActualRadiationCanisterGrenade::deployShape(%object, %radius, %type, %dur) { 

	// Get the position of the canister
	%canpos = getBoxCenter(%object);

	// Set position, time-to-go
	$RadiationPos[%object] = %canpos;
	$RadiationTTG[%object] = %dur;

	// And schedule radiation updates
	%damage = 0.1;
	%range = 20;
	schedule("RadiationUpdate(" @ %object @ ", " @%damage@ ", " @%range@ ");", 0.5);
	return true;
}

// =================== Radiation Canister Launcher data =================
ItemImageData RadiationCanisterImage
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };

	shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RadiationCanisterAmmo;
	// projectileType = GasCanisterGrenade;
	reloadTime = 1.0;
	fireTime = 0.5;

	accuFire = false;

	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 2;
	lightColor = { 0.0, 1.0, 0.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function RadiationCanisterImage::onFire(%this, %slot) {

	// Get some valuable info
	%client = Player::getClient(%this);

	// We subtract one ammo
	Player::decItemCount(%this, RadiationCanisterAmmo, 1);

	// Create the grenade
	%obj = newObject("","Mine","ActualRadiationCanisterGrenade");
	addToSet("MissionCleanup", %obj);

	// Shoot the grenade forward
	SpecialistSpawnProjectile(%this, %obj, 30);

	// Set the owner
	$RadiationCanisterOwner[%obj] = Player::getClient(%this);

	// Assign the grenade to a team
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
}

// =================== Item data for Radiation Canister Launcher ================
ItemData RadiationCanister
{
	heading = "bWeapons";
	description = "Radiation Canisters";
	className = "Weapon";
	shapeFile  = "grenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = RadiationCanisterImage;
	price = 150;
	showWeaponBar = true;
};

function RadiationCanister::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "Fires radiation canisters that can affect players through barriers.");
	}
}
