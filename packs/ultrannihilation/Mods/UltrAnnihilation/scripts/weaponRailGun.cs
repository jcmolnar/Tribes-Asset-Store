$InvList[Railgun] = 1;
$MobileInvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$InvList[RailAmmo] = 1;
$MobileInvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$AutoUse[Railgun] = True;
$SellAmmo[RailAmmo] = 25;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

ItemData RailAmmo 
{	description = "Railgun Bolt";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RailgunImage 
{	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RailAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Railgun 
{	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

function Railgun::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Rail Gun: <f2>The ultimate sniper weapon.");
}