$InvList[FEBRifle] = 1;
$MobileInvList[FEBRifle] = 1;
$RemoteInvList[FEBRifle] = 1;

$InvList[FEBRifleAmmo] = 1;
$MobileInvList[FEBRifleAmmo] = 1;
$RemoteInvList[FEBRifleAmmo] = 1;

$AutoUse[FEBRifle] = false;
$SellAmmo[FEBRifleAmmo] = 5;
$WeaponAmmo[FEBRifle] = FEBRifleAmmo;

addWeapon(FEBRifle);
addAmmo(FEBRifle, FEBRifleAmmo, 2);

ItemData FEBRifleAmmo 
{
	description = "FEB Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FEBRifleImage 
{
	shapeFile = "sniper";//disc paintgun
	mountPoint = 0;
	mountOffset = { 0 , 0 , 0.05};//{0.065, 0.1, -0.1}
	mountRotation = {0, 7, 0}; //-1.57



	weaponType = 0; // 0 singleshot,3 disk, 1 spinning,2 sustained
	ammoType = FEBRifleAmmo;
	projectileType = FEBBullet;
	accuFire = true;
	reloadTime = 0.01;
	fireTime = 0;
	//spinUpTime = 0;

	sfxFire = ricochet1;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FEBRifle 
{
	description = "F.E.B Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FEBRifleImage;
	price = 3500;
	showWeaponBar = true;
};

function FEBRifle::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>F.E.B Rifle: <f2>Mounted");
}
