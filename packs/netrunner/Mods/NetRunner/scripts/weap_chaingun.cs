$InvList[LChaingun] = 1;
$RemoteInvList[LChaingun] = 1;
$InvList[Chaingun] = 1;
$RemoteInvList[Chaingun] = 1;
$InvList[HChaingun] = 1;
$RemoteInvList[HChaingun] = 1;

addWeapon(LChaingun);
addWeapon(Chaingun);
addWeapon(HChaingun);

$AutoUse[LChaingun] = True;
$AutoUse[Chaingun] = True;
$AutoUse[HChaingun] = True;

ItemImageData LChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0;
//	weaponType = 1; // Spinning
	reloadTime = 0;
//	spinUpTime = 0.5;
//	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = BulletAmmo;
	projectileType = KillerMK0;
	accuFire = true;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
//	sfxSpinUp = SoundSpinUp;
//	sfxSpinDown = SoundSpinDown;
};

ItemData LChaingun
{
	description = "Killer Mk1";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = LChaingunImage;
	price = 100;
	showWeaponBar = true;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
//	spinUpTime = 0.5;
//	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = BulletAmmo;
	projectileType = KillerMK1;
	accuFire = true;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
//	sfxSpinUp = SoundSpinUp;
//	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Killer Mk2";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData HChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
//	spinUpTime = 0.5;
//	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = BulletAmmo;
	projectileType = KillerMK2;
	accuFire = true;
	lightType = 3;// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
//	sfxSpinUp = SoundSpinUp;
//	sfxSpinDown = SoundSpinDown;
};

ItemData HChaingun
{
	description = "Killer Mk3";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = HChaingunImage;
	price = 200;
	showWeaponBar = true;
};