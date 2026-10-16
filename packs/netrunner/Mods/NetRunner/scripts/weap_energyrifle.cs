$InvList[LEnergyRifle] = 1;
$RemoteInvList[LEnergyRifle] = 1;
$InvList[EnergyRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;
$InvList[HEnergyRifle] = 1;
$RemoteInvList[HEnergyRifle] = 1;

addWeapon(LEnergyRifle);
addWeapon(EnergyRifle);
addWeapon(HEnergyRifle);

$AutoUse[LEnergyRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[HEnergyRifle] = True;

ItemImageData LEnergyRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;// Sustained
	projectileType = LeechMK0;
	minEnergy = 3;
	maxEnergy = 10;// Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3;// Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire= SoundELFIdle;
};

ItemData LEnergyRifle
{
	description = "Leech Mk1";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = LEnergyRifleImage;
	showWeaponBar = true;
	price = 100;
};

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;// Sustained
	projectileType = LeechMK1;
	minEnergy = 3;
	maxEnergy = 10;// Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3;// Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire= SoundELFIdle;
};

ItemData EnergyRifle
{
	description = "Leech Mk2";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	showWeaponBar = true;
	price = 150;
};

ItemImageData HEnergyRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;// Sustained
	projectileType = LeechMK2;
	minEnergy = 3;
	maxEnergy = 10;// Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3;// Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire= SoundELFIdle;
};

ItemData HEnergyRifle
{
	description = "Leech Mk3";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = $InvHead[iOffe];
	shadowDetailMask = 4;
	imageType = HEnergyRifleImage;
	showWeaponBar = true;
	price = 200;
};