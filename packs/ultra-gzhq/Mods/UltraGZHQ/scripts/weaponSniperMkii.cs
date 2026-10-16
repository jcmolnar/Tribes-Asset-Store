$InvList[SniperMkii] = 1;
$MobileInvList[SniperMkii] = 1;
$RemoteInvList[SniperMkii] = 1;

$InvList[SniperMkiAmmo] = 1;
$MobileInvList[SniperMkiiAmmo] = 1;
$RemoteInvList[SniperMkiiAmmo] = 1;

$AutoUse[SniperMkii] = false;
$SellAmmo[SniperMkiiAmmo] = 5;
$WeaponAmmo[SniperMkii] = SniperMkiiAmmo;

addWeapon(SniperMkii);
addAmmo(SniperMkii, SniperMkiiAmmo, 2);

ItemData SniperMkiiAmmo 
{
	description = "Sniper Mkii Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SniperMkiiImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	projectileType = SniperBulletMkii;
	ammoType = SniperMkiiAmmo;
	accuFire = true;
	fireTime = 0;
	reloadTime = 0.01;
	sfxFire = debrisMediumExplosion;	//ricochet1; // SoundFireSniper
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperMkii 
{
	description = "Sniper Mkii";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SniperMkiiImage;
	price = 500;
	showWeaponBar = true;
};

function SniperMkii::onMount(%player,%item)
{	

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Sniper Mkii: <f2>Mounted");
}

