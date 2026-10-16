$InvList[AngelFire] = 1;
$MobileInvList[AngelFire] = 1;
$RemoteInvList[AngelFire] = 1;

$AutoUse[AngelFire] = False;
$WeaponAmmo[AngelFire] = "";

addWeapon(AngelFire);

ItemImageData AngelFireImage 
{	shapeFile = "enbolt";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, 0.45 };
	mountRotation = { 0, 1.5, 0 };
	weaponType = 0;
	reloadTime = 0.05;
	fireTime = 0.05;
	minEnergy = 5;
	maxEnergy = 25;
	projectileType = AngelFireGren;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundJetHeavy;
	sfxReload = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AngelFire 
{	description = "Angel Fire";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "enbolt";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = AngelFireImage;
	price = 475;
	showWeaponBar = true;
};

function AngelFire::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Angel Fire: <f2>Lobs explosive energy upon your victims.");
}

