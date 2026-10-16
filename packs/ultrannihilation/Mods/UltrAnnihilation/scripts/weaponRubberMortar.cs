$InvList[RubberMortar] = 1;
$MobileInvList[RubberMortar] = 1;
$RemoteInvList[RubberMortar] = 1;

$InvList[RubberAmmo] = 1;
$MobileInvList[RubberAmmo] = 1;
$RemoteInvList[RubberAmmo] = 1;

$AutoUse[RubberMortar]= True;
$WeaponAmmo[RubberMortar]= Rubberammo;
$SellAmmo[RubberAmmo]= 10;
$AmmoPackMax[RubberAmmo]= 60;

addWeapon(RubberMortar);
addAmmo(RubberMortar, RubberAmmo, 2);

ItemData RubberAmmo
{	description = "R Mortar Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RMortarImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RubberAmmo;
	projectileType = RubberMortarShell;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData RubberMortar
{	description = "Rubbery Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RMortarImage;
	price = 375;
	showWeaponBar = true;
};

function RubberMortar::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Rubber Mortar: <f2>A mortar and pack of silly putty rolled into one!.");
}