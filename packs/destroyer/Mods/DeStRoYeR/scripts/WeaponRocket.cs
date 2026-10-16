//--------------------------------------

$AutoUse[RocketL] = True;
$SellAmmo[Rockets] = 5;
$AmmoPackMax[Rockets] = 10;
$AmmoPackItems[6] = Rockets;
$WeaponAmmo[RocketL] = Rockets;

//--------------------------------------

$InvList[RocketL] = 1;
$InvList[Rockets] = 1;
$RemoteInvList[RocketL] = 1;
$RemoteInvList[Rockets] = 1;

$ItemMax[narmor, RocketL] = 0;
$ItemMax[aarmor, RocketL] = 0;
$ItemMax[darmor, RocketL] = 1;
$ItemMax[nfemale, RocketL] = 0;
$ItemMax[afemale, RocketL] = 0;
$ItemMax[warmor, RocketL] = 1;
$ItemMax[barmor, RocketL] = 1;
$ItemMax[sarmor, RocketL] = 1;
$ItemMax[avarmor, RocketL] = 1;
$ItemMax[wfemale, RocketL] = 1;
$ItemMax[bfemale, RocketL] = 1;

$ItemMax[narmor, Rockets] = 0;
$ItemMax[aarmor, Rockets] = 0;
$ItemMax[darmor, Rockets] = 25;
$ItemMax[nfemale, Rockets] = 0;
$ItemMax[afemale, Rockets] = 0;
$ItemMax[warmor, Rockets] = 10;
$ItemMax[barmor, Rockets] = 15;
$ItemMax[sarmor, Rockets] = 500;
$ItemMax[avarmor, Rockets] = 20;
$ItemMax[wfemale, Rockets] = 10;
$ItemMax[bfemale, Rockets] = 15;

//--------------------------------------


ItemData Rockets
{
	description = "Rocket";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "Rocket";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RocketLImage
{
	shapeFile = "Mortargun";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = Rockets;
	projectileType = FlierRocket;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData RocketL
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "MortarGun";
	hudIcon = "Blaster";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = RocketLImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function RocketL::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Rocket Launcher: <f2>Fire a standard rocket at your enemy.");
}
