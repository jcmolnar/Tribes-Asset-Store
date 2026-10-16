//IS NOW Acidcloud

$InvList[PlasmaGun] = 1;
$MobileInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;

$InvList[PlasmaAmmo] = 1;
$MobileInvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaAmmo] = 1;

$AutoUse[PlasmaGun] = false;
$SellAmmo[PlasmaAmmo] = 5;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

addWeapon(PlasmaGun);
addAmmo(PlasmaGun, PlasmaAmmo, 5);

ItemData PlasmaAmmo
{
	description = "Acid Canister";
	heading = $InvHead[ihAmm];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;	
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = AcidCloudShell;
	accuFire = true;
	reloadTime = 0.75;
	fireTime = 0.4;
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Acid Cloud";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 300;
	showWeaponBar = true;
};

function Plasmagun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Acid Cloud Launcher: <f2>Fires a shell that releases a cloud of acid on impact.");
}