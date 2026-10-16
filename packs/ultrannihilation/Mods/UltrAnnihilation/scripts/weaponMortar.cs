$InvList[Mortar] = 1;
$MobileInvList[Mortar] = 1;
$RemoteInvList[Mortar] = 1;

$InvList[MortarAmmo] = 1;
$MobileInvList[MortarAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;

$AutoUse[Mortar] = True;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = Mortar;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 2);

ItemData MortarAmmo 
{	description = "Mortar Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage 
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar 
{	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Mortar: <f2>Lob this explosive canister at someone you love.");
}