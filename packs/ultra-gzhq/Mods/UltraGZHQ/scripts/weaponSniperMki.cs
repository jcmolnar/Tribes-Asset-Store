$InvList[SniperMki] = 1;
$MobileInvList[SniperMki] = 1;
$RemoteInvList[SniperMki] = 1;

$InvList[SniperMkiAmmo] = 1;
$MobileInvList[SniperMkiAmmo] = 1;
$RemoteInvList[SniperMkiAmmo] = 1;

$AutoUse[SniperMki] = false;
$SellAmmo[SniperMkiAmmo] = 5;
$WeaponAmmo[SniperMki] = SniperMkiAmmo;

addWeapon(SniperMki);
addAmmo(SniperMki, SniperMkiAmmo, 2);

ItemData SniperMkiAmmo 
{
	description = "Sniper Mki Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData Scope1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Scope1
{
	description = "Scope1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Scope1Image;
	showWeaponBar = false;
};


ItemImageData SniperMkiImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	projectileType = SniperBulletMki;
	ammoType = SniperMkiAmmo;
	accuFire = true;
	fireTime = 0;
	reloadTime = 0.01;
	sfxFire = debrisSmallExplosion;	//ricochet1; // SoundFireSniper
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperMki 
{
	description = "Sniper Mki";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SniperMkiImage;
	price = 500;
	showWeaponBar = true;
};

function SniperMki::onMount(%player,%item)
{	

    Player::mountItem(%player,Scope1,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Sniper Mki: <f2>Mounted");
}

function SniperMki::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}