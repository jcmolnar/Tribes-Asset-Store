$InvList[SniperRifle] = 1;
$MobileInvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;

$InvList[SniperAmmo] = 1;
$MobileInvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

$AutoUse[SniperRifle] = True;
$WeaponAmmo[SniperRifle] = SniperAmmo;

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 2);

ItemData SniperAmmo 
{	description = "Sniper Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SniperRifleImage 
{	shapeFile = "sniper";
	mountPoint = 0;
	//mountRotation = { 0,-1.57, 0 };
	weaponType = 0; 
	projectileType = SniperBullet;
	ammoType = SniperAmmo;
	accuFire = true;
	fireTime = 0.05;
	reloadTime = 0.05;
	sfxFire = ricochet1; // SoundFireSniper
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 4500;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "SniperRifle: <f2>Sniper weapon with an area effect.");
}