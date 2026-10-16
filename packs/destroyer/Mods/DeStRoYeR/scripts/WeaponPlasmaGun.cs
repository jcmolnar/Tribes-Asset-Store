//--------------------------------------

$AutoUse[PlasmaGun] = True;
$SellAmmo[PlasmaAmmo] = 5;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackItems[2] = PlasmaAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

//--------------------------------------

$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

$ItemMax[narmor, plasmagun] = 0;
$ItemMax[aarmor, plasmagun] = 1;
$ItemMax[darmor, plasmagun] = 1;
$ItemMax[nfemale, plasmagun] = 0;
$ItemMax[afemale, plasmagun] = 1;
$ItemMax[warmor, plasmagun] = 1;
$ItemMax[barmor, plasmagun] = 1;
$ItemMax[sarmor, plasmagun] = 1;
$ItemMax[avarmor, plasmagun] = 1;
$ItemMax[wfemale, plasmagun] = 1;
$ItemMax[bfemale, plasmagun] = 1;

$ItemMax[narmor, plasmaammo] = 0;
$ItemMax[aarmor, plasmaammo] = 20;
$ItemMax[darmor, plasmaammo] = 50;
$ItemMax[nfemale, plasmaammo] = 0;
$ItemMax[afemale, plasmaammo] = 20;
$ItemMax[warmor, plasmaammo] = 30;
$ItemMax[barmor, plasmaammo] = 40;
$ItemMax[sarmor, plasmaammo] = 500;
$ItemMax[avarmor, plasmaammo] = 50;
$ItemMax[wfemale, plasmaammo] = 30;
$ItemMax[bfemale, plasmaammo] = 40;

//--------------------------------------


ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = GPlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function PlasmaGun::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Plasma Gun: <f2>Give yer foe a nice hot plasma bath.");
}