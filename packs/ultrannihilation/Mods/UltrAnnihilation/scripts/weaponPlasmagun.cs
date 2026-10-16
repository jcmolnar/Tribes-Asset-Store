$InvList[PlasmaGun] = 1;
$MobileInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;

$InvList[PlasmaAmmo] = 1;
$MobileInvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

$AutoUse[PlasmaGun] = True;
$SellAmmo[PlasmaAmmo] = 5;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

addWeapon(PlasmaGun);
addAmmo(PlasmaGun, PlasmaAmmo, 5);

ItemData PlasmaAmmo
{	description = "Plasma Bolt";
	heading = $InvHead[ihAmm];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

function Plasmagun::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Plasma Gun: <f2>Fire flaming plasma to toast those marshmellows.");
}