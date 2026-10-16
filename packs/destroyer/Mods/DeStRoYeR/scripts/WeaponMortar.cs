//--------------------------------------

$AutoUse[Mortar] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[5] = MortarAmmo;
$WeaponAmmo[Mortar] = Mortar;

//--------------------------------------

$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;

$ItemMax[narmor, Mortar] = 0;
$ItemMax[aarmor, Mortar] = 0;
$ItemMax[darmor, Mortar] = 1;
$ItemMax[nfemale, Mortar] = 0;
$ItemMax[afemale, Mortar] = 0;
$ItemMax[warmor, Mortar] = 0;
$ItemMax[barmor, Mortar] = 0;
$ItemMax[sarmor, Mortar] = 1;
$ItemMax[avarmor, Mortar] = 1;
$ItemMax[wfemale, Mortar] = 0;
$ItemMax[bfemale, Mortar] = 0;

$ItemMax[narmor, MortarAmmo] = 0;
$ItemMax[aarmor, MortarAmmo] = 0;
$ItemMax[darmor, MortarAmmo] = 25;
$ItemMax[nfemale, MortarAmmo] = 0;
$ItemMax[afemale, MortarAmmo] = 0;
$ItemMax[warmor, MortarAmmo] = 0;
$ItemMax[barmor, MortarAmmo] = 0;
$ItemMax[sarmor, MortarAmmo] = 500;
$ItemMax[avarmor, MortarAmmo] = 20;
$ItemMax[wfemale, MortarAmmo] = 0;
$ItemMax[bfemale, MortarAmmo] = 0;

//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "cWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Mortar::onMount(%player,%item)
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Mortar: <f2>Hurl a Canister-O-Death at your opponent.");
}