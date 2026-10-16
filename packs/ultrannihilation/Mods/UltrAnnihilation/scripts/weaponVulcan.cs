$InvList[Vulcan] = 1;
$MobileInvList[Vulcan] = 1;
$RemoteInvList[Vulcan] = 1;

$InvList[VulcanAmmo] = 1;
$MobileInvList[VulcanAmmo] = 1;
$RemoteInvList[VulcanAmmo] = 1;

$AutoUse[Vulcan] = True;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$SellAmmo[VulcanAmmo] = 100;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

ItemData VulcanAmmo 
{	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.75;
	spinDownTime = 3;
	fireTime = 0.045;
	ammoType = VulcanAmmo;
	projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan 
{	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

function Vulcan::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Vulcan: <f2>Fires high speed explosive bullets to mow down your enemies.");
}
